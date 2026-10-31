import pathlib,re,json
root=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\code')
changes=[]
def edit(rel,old,new,why):
 p=root/'repaired'/rel
 s=p.read_text(encoding='utf-8-sig')
 assert old in s,(rel,old)
 p.write_text(s.replace(old,new),encoding='utf-8')
 changes.append(dict(path=rel,old=old,new=new,reason=why))
edit('Assembly-CSharp/ForcedReset.cs','typeof(GUITexture)','typeof(UnityEngine.UI.Image)','Removed engine GUITexture replaced with supported UI Image requirement; attachment usage must be checked.')
edit('Assembly-CSharp/UnityStandardAssets.Utility/SimpleActivatorMenu.cs','public GUIText camSwitchButton;','public UnityEngine.UI.Text camSwitchButton;','Removed engine GUIText replaced with UI Text; any original field reference needs migration.')
# Protect removed optional UNet subsystem while preserving complete source for recovery.
for rel in ['Assembly-CSharp/RCC_UNetNetwork.cs','Assembly-CSharp/Unity/GeneratedNetworkCode.cs']:
 p=root/'repaired'/rel;s=p.read_text(encoding='utf-8-sig');p.write_text('#if CARTOON_RECON_LEGACY_UNET\n'+s+'\n#endif\n',encoding='utf-8')
 changes.append(dict(path=rel,reason='Isolated removed UNet subsystem behind explicit define pending original attachment audit; no replacement stubs.'))
(root/'repairs.json').write_text(json.dumps(changes,indent=2),encoding='utf-8')
