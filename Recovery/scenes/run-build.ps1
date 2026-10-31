param([string]$Output)
$ErrorActionPreference='Stop'
$projectRoot=[IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..\..'))
$editor='C:\Program Files\Unity 2023.2.22f1\Editor\Unity.exe'
if(-not $Output){$Output=Join-Path $projectRoot 'Build\CartoonRacerRecon.exe'}
$Output=[IO.Path]::GetFullPath($Output)
New-Item -ItemType Directory -Path (Split-Path -Parent $Output) -Force | Out-Null
$arguments=@('-batchmode','-projectPath',$projectRoot,'-executeMethod','CartoonRacerRecovery.ReconstructionAudit.BuildWindows','-recoveryBuild',$Output,'-logFile',(Join-Path $PSScriptRoot 'windows-build.log'))
$process=Start-Process -FilePath $editor -ArgumentList $arguments -WindowStyle Hidden -Wait -PassThru
Write-Output "Unity exit $($process.ExitCode); player: $Output"
exit $process.ExitCode

