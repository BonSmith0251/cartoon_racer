[void][Reflection.Assembly]::LoadFrom('C:\Program Files\Unity 2023.2.22f1\Editor\Data\Tools\Compilation\ApiUpdater\Mono.Cecil.dll')
$original='C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D\Cartoon Hot Racer 3D_Data\Managed'
$root=$PSScriptRoot
$types=[Collections.Generic.List[object]]::new();$methods=[Collections.Generic.List[object]]::new();$assemblies=[Collections.Generic.List[object]]::new()
function Visit-Type($type,$asm) {
 if($type.Name -eq '<Module>'){return}
 $fields=@($type.Fields | ForEach-Object {@{name=$_.Name;type=$_.FieldType.FullName;attributes=$_.Attributes.ToString();custom_attributes=@($_.CustomAttributes | ForEach-Object {$_.AttributeType.FullName})}})
 $types.Add(@{assembly=$asm;type=$type.FullName;base_type=if($type.BaseType){$type.BaseType.FullName}else{$null};metadata_token=$type.MetadataToken.ToInt32();fields=$fields;attributes=@($type.CustomAttributes | ForEach-Object {$_.AttributeType.FullName})})
 foreach($method in $type.Methods){$methods.Add(@{assembly=$asm;type=$type.FullName;signature=$method.FullName;metadata_token=$method.MetadataToken.ToInt32();has_body=$method.HasBody;il_instruction_count=if($method.HasBody){$method.Body.Instructions.Count}else{0};status=if($method.HasBody){'recovered_decompiled_not_runtime_validated'}elseif($method.IsAbstract){'abstract_contract'}elseif($method.IsPInvokeImpl){'external_native_dependency'}else{'runtime_or_external_method'};integration=if($type.FullName -like 'RCC_UNetNetwork*' -or $type.FullName -eq 'Unity.GeneratedNetworkCode'){'preserved_optional_UNet_not_enabled_no_serialized_references'}else{'source_or_recompiled_plugin'}})}
 foreach($nested in $type.NestedTypes){Visit-Type $nested $asm}
}
foreach($dir in Get-ChildItem -LiteralPath "$root\pristine" -Directory){
 $path=Join-Path $original ($dir.Name+'.dll');$a=[Mono.Cecil.AssemblyDefinition]::ReadAssembly($path)
 $assemblies.Add(@{assembly=$a.Name.FullName;source=$path;sha256=(Get-FileHash -LiteralPath $path -Algorithm SHA256).Hash;references=@($a.MainModule.AssemblyReferences | ForEach-Object {$_.FullName});source_file_count=@(Get-ChildItem -LiteralPath $dir.FullName -Filter '*.cs' -Recurse).Count})
 foreach($t in $a.MainModule.Types){Visit-Type $t $a.Name.Name}
 $a.Dispose()
}
$assemblies.ToArray() | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath "$root\assemblies.json" -Encoding UTF8
$types.ToArray() | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath "$root\types-fields.json" -Encoding UTF8
$methods.ToArray() | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath "$root\method-status.json" -Encoding UTF8
$methods.ToArray() | Group-Object assembly | Select-Object Name,Count
