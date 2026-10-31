import pathlib,json,collections
out=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\extraction');d=json.loads((out/'coverage.json').read_text(encoding='utf-8'));checks=[]
for s in d['streams']:
 name=pathlib.PurePosixPath(s['path'].replace('\\','/')).name;candidates=list((out/'raw-source').rglob(name)) + list((out/'bundle-entries').glob(name));r=dict(s)
 r['candidates']=[str(z) for z in candidates]
 r['outcome']='pass' if any(s['offset']>=0 and s['offset']+s['size']<=z.stat().st_size for z in candidates) else 'missing-or-out-of-bounds'
 checks.append(r)
r={'stream_references':len(checks),'outcomes':dict(collections.Counter(z['outcome'] for z in checks)),'checks':checks};(out/'stream-coverage.json').write_text(json.dumps(r,indent=2),encoding='utf-8');print(json.dumps({k:v for k,v in r.items() if k!='checks'}))
