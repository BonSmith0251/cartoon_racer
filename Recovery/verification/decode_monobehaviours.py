import collections,gzip,hashlib,json,pathlib,time,UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator
from UnityPy.helpers.TypeTreeNode import TypeTreeNode
from UnityPy.helpers.Tpk import get_typetree_node
ROOT=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery')
OUT=ROOT/'verification'
SRC=pathlib.Path(r'C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D')
data=SRC/'Cartoon Hot Racer 3D_Data'
prior=json.loads((ROOT/'extraction'/'coverage.json').read_text(encoding='utf-8-sig'))
failed={x['id'] for x in prior['issues']}
env=UnityPy.load(str(data/'data.unity3d'),str(data/'Resources'/'unity default resources'))
gen=TypeTreeGenerator('2018.2.20f1');gen.load_local_dll_folder(str(data/'Managed'));env.typetree_generator=gen
alt=TypeTreeGenerator('2018.2.20f1',generator='AssetRipper');alt.load_local_dll_folder(str(data/'Managed'))
loaded=set(gen.get_loaded_dll_names())
def corrected_nodes(assembly,fullname):
 key=(assembly,fullname)
 if key in gen.cache:return gen.cache[key]
 candidates=[assembly,assembly+'.dll',assembly.removesuffix('.dll')]
 actual=next((x for x in candidates if x in loaded),assembly)
 nodes=json.loads((alt if 'UnityScript' in assembly else gen).get_nodes_as_json(actual,fullname))
 n=TypeTreeNode.from_list(nodes)
 base=get_typetree_node(114,UnityPy.helpers.UnityVersion.UnityVersion.from_str('2018.2.20f1'))
 assert [c.m_Name for c in n.m_Children[:4]]==[c.m_Name for c in base.m_Children]
 n.m_Children[:4]=base.m_Children
 def repair_string_array(node):
  children=[repair_string_array(child) for child in node.m_Children]
  typ=node.m_Type
  if typ=='string' and children and children[0].m_Type=='Array' and children[0].m_Children:
   if children[0].m_Children[-1].m_Type=='string':typ='vector'
  return TypeTreeNode(node.m_Level,typ,node.m_Name,node.m_ByteSize,node.m_Version,children,m_MetaFlag=node.m_MetaFlag)
 n=repair_string_array(n)
 gen.cache[key]=n
 return n
gen.get_nodes_up=corrected_nodes
lookup=collections.defaultdict(list)
for f in env.assets:lookup[f.name.lower()].append(f)
def walk(x,path=''):
 if isinstance(x,dict):
  if 'm_FileID' in x and 'm_PathID' in x:yield path,x
  else:
   for k,v in x.items():yield from walk(v,path+'.'+k)
 elif isinstance(x,list):
  for i,v in enumerate(x):yield from walk(v,path+'['+str(i)+']')
counts=collections.Counter();refs=collections.Counter();errors=[];classes=collections.Counter()
with gzip.open(OUT/'recovered-monobehaviour-trees.jsonl.gz','wt',encoding='utf-8') as th,gzip.open(OUT/'recovered-monobehaviour-references.jsonl.gz','wt',encoding='utf-8') as rh:
 for f in env.assets:
  for obj in f.objects.values():
   ident=f.name+':'+str(obj.path_id)
   if ident not in failed:continue
   try:
    tree=obj.read_typetree(nodes=obj.generate_monobehaviour_node())
    counts['decoded']+=1
    script=obj.parse_monobehaviour_head().m_Script.deref_parse_as_object()
    fullname=(script.m_Namespace+'.' if script.m_Namespace else '')+script.m_ClassName
    classes[fullname]+=1
    th.write(json.dumps({'id':ident,'class':fullname,'tree':tree},default=str,separators=(',',':'))+'\n')
    for prop,p in walk(tree):
     fid=int(p['m_FileID']);pid=int(p['m_PathID']);r={'owner':ident,'property':prop,'file_id':fid,'path_id':str(pid)}
     if pid==0:r['outcome']='original-null'
     else:
      external=str(f.externals[fid-1].path) if 0<fid<=len(f.externals) else ''
      candidates=[f] if fid==0 else lookup.get(pathlib.PurePosixPath(external.replace('\\','/')).name.lower(),[])
      targets=[z for z in candidates if pid in z.objects]
      if len(targets)==1:r['outcome']='resolved';r['target']=targets[0].name+':'+str(pid)
      elif len(targets)>1:r['outcome']='ambiguous'
      else:r['outcome']='missing';r['external']=external
     refs[r['outcome']]+=1;rh.write(json.dumps(r,separators=(',',':'))+'\n')
   except Exception as ex:counts['failed']+=1;errors.append({'id':ident,'error':str(ex)})
  print(f.name,dict(counts),flush=True)
summary={'timestamp_utc':time.strftime('%Y-%m-%dT%H:%M:%SZ',time.gmtime()),'method':'UnityPy generated custom layouts from original DLLs; engine header from versioned TPK fixes generator alignment; module names resolved against loaded names; strict byte-size checks','source':'immutable installed build','previous_failures':len(failed),'result':dict(counts),'references':dict(refs),'classes':dict(classes),'errors':errors,'unitypy':UnityPy.__version__}
(OUT/'monobehaviour-decode-summary.json').write_text(json.dumps(summary,indent=2),encoding='utf-8')
print(json.dumps({k:v for k,v in summary.items() if k not in ('classes','errors')}),flush=True)






