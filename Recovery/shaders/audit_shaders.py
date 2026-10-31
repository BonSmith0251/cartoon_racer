import pathlib,json,re,collections,ctypes,hashlib
import UnityPy
from UnityPy.export import ShaderConverter as SC
ROOT=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\shaders')
EXPORT=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\extraction\pristine-export\ExportedProject')
SOURCE=pathlib.Path(r'C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D\Cartoon Hot Racer 3D_Data\data.unity3d')
rows=[]; guids={}
for p in EXPORT.glob('Assets/**/*.shader'):
 text=p.read_text(encoding='utf-8-sig'); meta=p.with_suffix(p.suffix+'.meta').read_text(); guid=re.search(r'guid: (\w+)',meta).group(1)
 row={'path':p.relative_to(EXPORT).as_posix(),'name':re.search(r'Shader\s+"([^"]+)"',text).group(1),'guid':guid,'dummy':'DummyShaderTextExporter' in text,'materials':[]};rows.append(row);guids[guid]=row
for p in EXPORT.glob('Assets/**/*.mat'):
 text=p.read_text(encoding='utf-8-sig');m=re.search(r'm_Shader:.*guid: (\w+)',text)
 if m and m.group(1) in guids:guids[m.group(1)]['materials'].append(p.relative_to(EXPORT).as_posix())
(ROOT/'shader-inventory.json').write_text(json.dumps(rows,indent=2),encoding='utf-8')
dll=ctypes.WinDLL('d3dcompiler_47.dll');dis=dll.D3DDisassemble;dis.argtypes=[ctypes.c_void_p,ctypes.c_size_t,ctypes.c_uint,ctypes.c_char_p,ctypes.POINTER(ctypes.c_void_p)];dis.restype=ctypes.c_long
original=SC.ShaderSubProgram.Export
stats=collections.Counter()
def program_export(self):
 data=bytes(self.m_ProgramCode);start=data.find(b'DXBC')
 if start<0:return original(self)
 data=data[start:];size=int.from_bytes(data[24:28],'little');data=data[:size];blob=ctypes.c_void_p();buf=ctypes.create_string_buffer(data)
 hr=dis(buf,len(data),0,None,ctypes.byref(blob))
 if hr<0:stats['disassembly_failures']+=1;return original(self)
 vtable=ctypes.cast(blob,ctypes.POINTER(ctypes.POINTER(ctypes.c_void_p))).contents
 ptr=ctypes.WINFUNCTYPE(ctypes.c_void_p,ctypes.c_void_p)(vtable[3])(blob)
 count=ctypes.WINFUNCTYPE(ctypes.c_size_t,ctypes.c_void_p)(vtable[4])(blob)
 text=ctypes.string_at(ptr,count).decode('utf-8',errors='replace')
 ctypes.WINFUNCTYPE(ctypes.c_ulong,ctypes.c_void_p)(vtable[2])(blob);stats['disassembled_programs']+=1
 return '\n/* Keywords '+str(self.m_Keywords)+' */\n'+text
SC.ShaderSubProgram.Export=program_export
env=UnityPy.load(str(SOURCE));evidence=[]
for obj in env.objects:
 if obj.type.name!='Shader':continue
 shader=obj.read();name=shader.m_ParsedForm.m_Name
 selected=name in ['Custom/BLUR','RCCSkidmarks','Projector/Light','Projector/Multiply','Cartoon FX/Mobile Particles Additive Alpha8','Sprites/Default with Fog','LowPolyWater/Advanced','Water/Water 2D Waves'] or 'bloompro' in name.lower() or name in ['CameraFilterPack/Blur_Blurry','CameraFilterPack/Blur_Radial_Fast','CameraFilterPack/Color_GrayScale']
 if not selected:continue
 stem=re.sub(r'[^a-zA-Z0-9_.-]','_',name)
 row={'source_container':str(SOURCE),'serialized_file':obj.assets_file.name,'path_id':str(obj.path_id),'name':name,'platforms':shader.platforms}
 try:
  text=SC.export_shader(shader);(ROOT/(stem+'.compiled.txt')).write_text(text,encoding='utf-8');row['decoded']=True
 except Exception as e:row['decoded']=False;row['error']=str(e)
 (ROOT/(stem+'.raw')).write_bytes(obj.get_raw_data()); (ROOT/(stem+'.parsed.json')).write_text(json.dumps(obj.read_typetree()['m_ParsedForm'],default=str),encoding='utf-8');evidence.append(row)
(ROOT/'source-shader-evidence.json').write_text(json.dumps({'shaders':evidence,'stats':stats},indent=2,default=str),encoding='utf-8')
print(json.dumps({'exported_shaders':len(rows),'dummy_shaders':sum(r['dummy'] for r in rows),'selected':len(evidence),'stats':stats,'material_priorities':[(r['name'],len(r['materials'])) for r in sorted(rows,key=lambda x:-len(x['materials']))[:20]]}))


