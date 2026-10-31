import pathlib,hashlib,json,datetime
base=pathlib.Path(r'C:\Users\Administrator\.codex\skills\unity-project-reconstruction\references')
out=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\skill-maintenance')
changes={
'discovery-and-extraction.md': '''\n## Verify exporter configuration before loading\n\nSome AssetRipper GUI releases lock configuration after loading a build. In a tested release, a settings POST after load returned without applying the requested unreadable-asset option. Configure before load, then verify the effective settings in the UI/API or saved configuration; a successful HTTP response alone is not evidence the option changed. Preserve unreadable/raw objects independently when the effective exporter mode omits them. Record collection counts separately from serialized-object counts.\n''',
'scenes-and-engine-features.md': '''\n## Compiled shader recovery checks\n\nDetect exporter-generated shader placeholders explicitly (for example `DummyShaderTextExporter`) and classify their behavior as stubbed even when they compile. Prioritize actual material references and runtime `Shader.Find`/Resources loads; an unreferenced shader asset can still be used by an image effect.\n\nWhen a UnityPy shader text export omits a render state, inspect the original serialized pass state before treating that state as default. In UnityPy 1.25.4 on a Unity 2018.2 build, exported text omitted blend operations while `m_State.rtBlend0` retained additive/alpha/multiply factors and color masks. Read depth, culling, tags, blend and stencil state independently of the generated shader text.\n\nFor D3D11 payloads on Windows, preserved shader subprogram bytes can contain a DXBC container after a Unity-specific prefix. Validate its magic and recorded container length before passing the bounded bytes to the installed D3D compiler disassembler. Disassembly plus serialized parameters can support a documented HLSL reconstruction; it is not recovered authoring source or proof of visual fidelity. Keep original variants, bytecode and property metadata, preserve shader GUIDs, and separately test target compilation and graphics output.\n'''
}
ledger=[]
for name,addition in changes.items():
 p=base/name;before=p.read_bytes();after=before.decode('utf-8-sig').rstrip()+'\n'+addition
 (out/(name+'.before')).write_bytes(before)
 p.write_text(after,encoding='utf-8')
 ledger.append({'path':str(p),'before_sha256':hashlib.sha256(before).hexdigest(),'after_sha256':hashlib.sha256(p.read_bytes()).hexdigest(),'installed':True,'evidence':['Recovery/extraction/skill-improvement-proposals.json','Recovery/shaders/audit_shaders.py','Recovery/shaders/source-shader-evidence.json'],'validation':'observed exporter setting lock; 380 D3D11 programs disassembled; blend states compared to original typed data; structural validation follows'})
(out/'installed-improvements.json').write_text(json.dumps(ledger,indent=2),encoding='utf-8')
print(json.dumps(ledger,indent=2))
