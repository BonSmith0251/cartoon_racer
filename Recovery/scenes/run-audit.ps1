param([switch]$ShaderOnly,[switch]$MigrationOnly,[switch]$Graphics,[string]$ReportDirectory)
$ErrorActionPreference='Stop'
$projectRoot=[IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..\..'))
$editor='C:\Program Files\Unity 2023.2.22f1\Editor\Unity.exe'
if(-not (Test-Path -LiteralPath $editor)){throw "Unity editor missing: $editor"}
if(-not $ReportDirectory){$ReportDirectory=if($MigrationOnly){$PSScriptRoot}else{Join-Path $PSScriptRoot $(if($ShaderOnly){'shader-audit'}else{'editor-audit'})}}
$ReportDirectory=[IO.Path]::GetFullPath($ReportDirectory)
New-Item -ItemType Directory -Path $ReportDirectory -Force | Out-Null
$entry=if($MigrationOnly){'CartoonRacerRecovery.RecoveryMigrationAudit.Run'}elseif($ShaderOnly){'CartoonRacerRecovery.RecoveryShaderAudit.Run'}else{'CartoonRacerRecovery.ReconstructionAudit.Run'}
$arguments=@('-batchmode','-projectPath',$projectRoot,'-executeMethod',$entry,'-recoveryReport',$ReportDirectory,'-logFile',(Join-Path $ReportDirectory 'editor.log'))
if(-not $Graphics){$arguments+= '-nographics'}
$process=Start-Process -FilePath $editor -ArgumentList $arguments -WindowStyle Hidden -Wait -PassThru
Write-Output "Unity exit $($process.ExitCode); report: $ReportDirectory"
exit $process.ExitCode

