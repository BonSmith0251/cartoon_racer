param([string]$Assembly='Assembly-CSharp')
$root=$PSScriptRoot
$unity='C:\Program Files\Unity 2023.2.22f1\Editor\Data'
$original='C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D\Cartoon Hot Racer 3D_Data\Managed'
New-Item -ItemType Directory -Force -Path "$root\compiled" | Out-Null
$refs=@((Get-ChildItem -LiteralPath "$unity\Managed\UnityEngine" -Filter '*.dll').FullName)
$refs+=@((Get-ChildItem -LiteralPath "$unity\NetStandard\ref\2.1.0" -Filter '*.dll').FullName)
$refs+=@((Get-ChildItem -LiteralPath "$unity\NetStandard\compat\2.1.0\shims\netfx" -Filter '*.dll').FullName)
$refs+=@('UnityEngine.UI','Unity.TextMeshPro' | ForEach-Object {"D:\UnityRebuildLab\SampleGame\Library\ScriptAssemblies\$_.dll"})
$refs+=@('ES2','MoodkieSecurity','Tayx.Graphy','Assembly-UnityScript-firstpass','Boo.Lang','UnityScript.Lang','ch.sycoforge.Combine','ch.sycoforge.Unity.Runtime','UnityEngine.Networking' | Where-Object {$_ -ne $Assembly} | ForEach-Object {"$original\$_.dll"})
$argsList=@('/nologo','/target:library','/unsafe','/langversion:7.3','/nostdlib+',('/out:"'+$root+'\compiled\'+$Assembly+'.dll"'))
$argsList+=@($refs | ForEach-Object {'/r:"'+$_+'"'})
$argsList+=@((Get-ChildItem -LiteralPath "$root\repaired\$Assembly" -Recurse -Filter '*.cs').FullName | ForEach-Object {'"'+$_+'"'})
$argsList | Set-Content -LiteralPath "$root\compiled\$Assembly.rsp" -Encoding UTF8
& "$unity\MonoBleedingEdge\bin\mono.exe" "$unity\MonoBleedingEdge\lib\mono\4.5\csc.exe" "@$root\compiled\$Assembly.rsp" *> "$root\logs\compile-$Assembly.log"
Write-Output "$Assembly compiler exit=$LASTEXITCODE"
Get-Content -LiteralPath "$root\logs\compile-$Assembly.log" | Select-String 'error ' | Select-Object -First 45


