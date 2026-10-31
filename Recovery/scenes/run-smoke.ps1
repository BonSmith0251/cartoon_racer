param([string]$Executable,[string]$Output)
$ErrorActionPreference='Stop'
$projectRoot=[IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..\..'))
if(-not $Executable){$Executable=Join-Path $projectRoot 'Build\CartoonRacerRecon.exe'}
if(-not $Output){$Output=Join-Path $PSScriptRoot 'runtime-smoke'}
$Output=[IO.Path]::GetFullPath($Output)
if(-not(Test-Path -LiteralPath $Executable)){throw "Build missing: $Executable"}
New-Item -ItemType Directory -Path $Output -Force | Out-Null
$arguments=@('-recoverySmoke',$Output,'-screen-width','1280','-screen-height','720','-screen-fullscreen','0','-logFile',(Join-Path $Output 'player.log'))
Add-Type -TypeDefinition @"
using System;
using System.Runtime.InteropServices;
public static class RecoverySmokeWindow {
 [DllImport("user32.dll")] public static extern uint GetWindowThreadProcessId(IntPtr hwnd,out uint processId);
 [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hwnd);
}
"@
# Interactive graphics validation needs a normal presented game window.
# Never toggle ShowWindow/topmost during Unity swapchain initialization.
$process=Start-Process -FilePath $Executable -ArgumentList $arguments -WindowStyle Normal -PassThru
for($attempt=0;$attempt -lt 60 -and -not $process.HasExited;$attempt++){
 $process.Refresh()
 $handle=$process.MainWindowHandle
 if($handle -ne [IntPtr]::Zero){
  [uint32]$ownerProcess=0
  [void][RecoverySmokeWindow]::GetWindowThreadProcessId($handle,[ref]$ownerProcess)
  if($ownerProcess -eq $process.Id){[void][RecoverySmokeWindow]::SetForegroundWindow($handle);break}
 }
 Start-Sleep -Milliseconds 250
}
$process.WaitForExit()
Write-Output "Player exit $($process.ExitCode); evidence: $Output"
exit $process.ExitCode

