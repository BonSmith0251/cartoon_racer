[void][Reflection.Assembly]::LoadFrom('C:\Program Files\Unity 2023.2.22f1\Editor\Data\Tools\Compilation\ApiUpdater\Mono.Cecil.dll')
$original='C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D\Cartoon Hot Racer 3D_Data\Managed';$root=$PSScriptRoot
$rows=[Collections.Generic.List[object]]::new()
foreach($file in Get-ChildItem -LiteralPath "$root\compiled" -Filter '*.dll'){
 $a=[Mono.Cecil.AssemblyDefinition]::ReadAssembly((Join-Path $original $file.Name));$b=[Mono.Cecil.AssemblyDefinition]::ReadAssembly($file.FullName)
 if($a.Name.FullName -ne $b.Name.FullName){$rows.Add(@{assembly=$file.Name;kind='assembly_identity_difference';original=$a.Name.FullName;rebuilt=$b.Name.FullName})}
 foreach($t in $a.MainModule.Types){
  if($t.Name -eq '<Module>'){continue}
  $target=$b.MainModule.Types | Where-Object FullName -ceq $t.FullName | Select-Object -First 1
  if(!$target){$rows.Add(@{assembly=$file.Name;type=$t.FullName;kind='missing_top_level_type'});continue}
  foreach($f in $t.Fields){
   if($f.IsStatic -or $f.IsNotSerialized){continue}
   $serialized=$f.IsPublic -or @($f.CustomAttributes | Where-Object {$_.AttributeType.FullName -eq 'UnityEngine.SerializeField'}).Count -gt 0
   if(!$serialized){continue}
   $tf=$target.Fields | Where-Object Name -ceq $f.Name | Select-Object -First 1
   if(!$tf -or $tf.FieldType.FullName -ne $f.FieldType.FullName){$rows.Add(@{assembly=$file.Name;type=$t.FullName;field=$f.Name;kind='field_layout_difference';original_type=$f.FieldType.FullName;rebuilt_type=if($tf){$tf.FieldType.FullName}else{$null}})}
  }
 }
 $a.Dispose();$b.Dispose()
}
ConvertTo-Json -InputObject $rows.ToArray() -Depth 8 | Set-Content -LiteralPath "$root\field-layout-differences.json" -Encoding UTF8
$rows.ToArray() | Format-List

