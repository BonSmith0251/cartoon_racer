import collections,hashlib,json,pathlib,re,struct
root=pathlib.Path(r"D:\Games\CartoonRacerRecon")
package=pathlib.Path(r"C:\Users\Administrator\AppData\Local\Unity\cache\packages\packages.unity.com\com.unity.textmeshpro@3.0.1")
def md4(data):
 n=len(data);data+=b"\x80";data+=b"\0"*((56-len(data)%64)%64)+struct.pack("<Q",n*8);h=[0x67452301,0xefcdab89,0x98badcfe,0x10325476]
 for pos in range(0,len(data),64):
  x=struct.unpack("<16I",data[pos:pos+64]);a,b,c,d=h
  for round in range(3):
   for i in range(16):
    if round==0:f=(b&c)|(~b&d);k=i;constant=0;shift=(3,7,11,19)[i%4]
    elif round==1:f=(b&c)|(b&d)|(c&d);k=(i%4)*4+i//4;constant=0x5a827999;shift=(3,5,9,13)[i%4]
    else:f=b^c^d;k=(0,8,4,12,2,10,6,14,1,9,5,13,3,11,7,15)[i];constant=0x6ed9eba1;shift=(3,9,11,15)[i%4]
    value=(a+f+x[k]+constant)&0xffffffff;value=((value<<shift)|(value>>(32-shift)))&0xffffffff
    a,b,c,d=d,value,b,c
  h=[(p+q)&0xffffffff for p,q in zip(h,(a,b,c,d))]
 return struct.pack("<4I",*h)
assert md4(b"").hex()=="31d6cfe0d16ae931b73c59d7e0c089c0"
source=json.loads((root/"Recovery/scenes/source/source-scripts.json").read_text())
mapping={};names={}
for row in source:
 d=row["data"]
 if d.get("m_AssemblyName")!="Unity.TextMeshPro.dll":continue
 ns=d.get("m_Namespace","");name=d.get("m_ClassName","");oldid=struct.unpack("<i",md4(("s\0\0\0"+ns+name).encode())[:4])[0]
 found=list(package.rglob(name+".cs.meta"))
 if found:
  guid=re.search(r"guid: (\w+)",found[0].read_text())[1];mapping[str(oldid)]=guid;names[str(oldid)]=ns+"."+name
oldguid="67dfb1fdfb2b407222eda8e23ac8b724";changes=[];unknown=collections.Counter()
for path in root.joinpath("Assets").rglob("*"):
 if path.suffix not in (".unity",".prefab",".asset",".mat"):continue
 try:text=path.read_text(encoding="utf-8-sig")
 except UnicodeDecodeError:continue
 if oldguid not in text:continue
 def replace(m):
  old=m[1]
  if old not in mapping:unknown[old]+=1;return m[0]
  changes.append({"asset":str(path.relative_to(root)),"original_dll_guid":oldguid,"original_local_id":old,"class":names[old],"new_script_guid":mapping[old],"new_local_id":"11500000"})
  return "fileID: 11500000, guid: "+mapping[old]
 text=re.sub(r"fileID: (-?\d+), guid: "+oldguid,replace,text)
 path.write_text(text,encoding="utf-8",newline="\n")
if not changes and not unknown and (root/"Recovery/scenes/tmp-script-remap.json").exists():
 print("TMP identities already remapped; retaining prior ledger");raise SystemExit(0)
if unknown:raise RuntimeError("Unmapped TMP identities: "+str(unknown))
backup=root/"Recovery/scenes/original-plugins";backup.mkdir(exist_ok=True)
for name in ("Unity.TextMeshPro.dll","Unity.TextMeshPro.dll.meta"):
 path=root/"Assets/Plugins"/name
 if path.exists():path.rename(backup/name)
(root/"Recovery/scenes/tmp-script-remap.json").write_text(json.dumps({"package":"com.unity.textmeshpro","target_guid_source":str(package),"count":len(changes),"changes":changes,"unmapped":dict(unknown)},indent=2))
print(json.dumps({"remapped":len(changes),"types":dict(collections.Counter(x["class"] for x in changes))}))

