import pathlib,json,re,hashlib,collections
root=pathlib.Path(r'D:\Games\CartoonRacerRecon');out=root/'Recovery/shaders';original=json.loads((out/'shader-inventory.json').read_text());finds=collections.defaultdict(list)
for p in (root/'Assets/Scripts').rglob('*.cs'):
 for name in set(re.findall(r'Shader\.Find\("([^"]+)"\)',p.read_text(encoding='utf-8-sig'))):finds[name].append(p.relative_to(root).as_posix())
rows=[]
for row in original:
 p=root/row['path'];text=p.read_text(encoding='utf-8-sig') if p.exists() else '';status='missing' if not p.exists() else 'placeholder' if 'DummyShaderTextExporter' in text else 'target-package-replacement' if row['name'].startswith('TextMeshPro/') else 'evidence-based-reconstruction'
 rows.append({'name':row['name'],'path':row['path'],'guid':row['guid'],'status':status,'sha256':hashlib.sha256(p.read_bytes()).hexdigest() if p.exists() else None,'original_materials':row['materials'],'code_find_sites':finds[row['name']]})
report={'scope':'303 exporter-created custom shaders; built-in editor shaders excluded. Material and Shader.Find references are static evidence, not proof of runtime use.','counts':dict(collections.Counter(r['status'] for r in rows)),'render_validation':'See independent verification reports; target compile alone does not prove original visual equivalence.','shaders':rows}
(out/'final-shader-status.json').write_text(json.dumps(report,indent=2),encoding='utf-8');print(report['counts'])
