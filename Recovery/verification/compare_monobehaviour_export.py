import pathlib,json,re,gzip,math,hashlib,collections,sys
R=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery');OUT=R/'verification';P=pathlib.Path(sys.argv[1]) if len(sys.argv)>1 else R/'extraction/pristine-export/ExportedProject'
summary=json.loads((R/'scenes/source/source-summary.json').read_text())
records=collections.defaultdict(list)
for line in gzip.open(OUT/'recovered-monobehaviour-trees.jsonl.gz','rt',encoding='utf-8'):
 row=json.loads(line);source=row['id'].split(':')[0]
 if source in summary['scenes']:records[source].append(row)
counts=collections.Counter();issues=[];scenes=[]
def scalar(raw,expected):
 raw=raw.strip()
 if isinstance(expected,bool):return bool(int(raw))
 if isinstance(expected,int):return int(raw)
 if isinstance(expected,float):return float(raw)
 if raw.startswith('"'):return json.loads(raw)
 if raw.startswith("'") and raw.endswith("'"):return raw[1:-1].replace("''", "'")
 return raw
for source,rows in records.items():
 path=P/summary['scenes'][source]['source_path'];text=path.read_text(encoding='utf-8-sig')
 docs={m[1]:m[2] for m in re.finditer(r'^--- !u!114 &(-?\d+)\n(.*?)(?=^--- !u!|\Z)',text,re.M|re.S)}
 sc=collections.Counter()
 for row in rows:
  pid=row['id'].split(':')[1];body=docs.get(pid)
  if body is None:issues.append({'source':row['id'],'class':row['class'],'error':'missing MonoBehaviour export'});continue
  fields=dict(re.findall(r'^  ([^ :][^:\n]*):([^\n]*)$',body,re.M));sc['objects']+=1
  for key,value in row['tree'].items():
   if key not in fields:sc['missing_fields']+=1;issues.append({'source':row['id'],'field':key,'error':'field absent'});continue
   raw=fields[key];expected=value
   if isinstance(value,(int,float,str,bool)):
    if isinstance(value,str) and (len(value)>80 or ('"' in raw and not raw.strip().endswith('"'))):sc['long_strings_unchecked']+=1;continue
    try:actual=scalar(raw,value)
    except Exception:sc['complex_scalars_unchecked']+=1;continue
    equal=math.isclose(actual,value,rel_tol=1e-5,abs_tol=1e-6) if isinstance(value,float) else actual==value
    sc['scalar_fields']+=1
   elif isinstance(value,dict) and 'm_FileID' in value:
    if value['m_PathID']==0:expected=0
    elif value['m_FileID']==0:expected=value['m_PathID']
    else:sc['cross_file_refs_unchecked']+=1;continue
    m=re.search(r'fileID: (-?\d+)',raw);actual=int(m[1]) if m else None;equal=actual==expected;sc['local_or_null_references']+=1
   else:sc['nested_fields_unchecked']+=1;continue
   if not equal:issues.append({'source':row['id'],'class':row['class'],'field':key,'expected':expected,'actual':actual})
 counts.update(sc);scenes.append({'source':source,'export':str(path),'sha256':hashlib.sha256(path.read_bytes()).hexdigest(),'counts':dict(sc)})
report={'scope':'Independent original generated MonoBehaviour layouts versus pristine AssetRipper scene YAML: scalar fields and original local/null references; no target import claim; nested fields, long/multiline strings, external references explicitly counted unchecked','counts':dict(counts),'scenes':scenes,'issues':issues,'result':'pass' if not issues else 'fail'}
(OUT/(sys.argv[2] if len(sys.argv)>2 else 'independent-monobehaviour-export-comparison.json')).write_text(json.dumps(report,indent=2),encoding='utf-8');print(json.dumps({'counts':dict(counts),'issues':len(issues),'sample':issues[:8]}))


