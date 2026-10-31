# Cartoon Hot Racer 3D reconstruction

Open this folder as a Unity project with **Unity 2023.2.22f1**. The entry scene is [Assets/MENU.unity](Assets/MENU.unity). Run the Windows player at [Build/CartoonRacerRecon.exe](Build/CartoonRacerRecon.exe).

Original installation: `C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D`. Output project: `D:\Games\CartoonRacerRecon`. The original files were retained unchanged; a separate hash-verified preservation copy and pristine export are under `Recovery/extraction`.

## Versions and migration

- Source: Unity **2018.2.20f1**, Windows x64, Mono, built-in rendering.
- Recovery baseline: pristine AssetRipper export for 2018.2.20f1. A source-version editor project was not tested; the original executable was tested directly.
- Requested and tested target: **2023.2.22f1**, upgraded with explicit user confirmation. Built-in rendering was retained.
- Standalone: Windows x64 Mono development build, tested with Direct3D 11. Final build succeeded with **0 errors and 410 warnings**; see [build result](Build/CartoonRacerRecon.exe.build-result.json) and [complete build log](Recovery/scenes/windows-build.log).

## Recovery and validation

All **198 original files** were fingerprinted and preserved. Independent inventory confirmed **394,116 serialized objects in 21 files**, including 70 built-in resource objects. Combined base and assembly-generated type-tree ledgers decode all indexed objects. All **211 external audio payload ranges** resolve within the preserved files. This establishes source coverage; it does not establish complete imported or behavioral fidelity.

The project contains all **eight source scenes** and **292 recovered prefabs**. Build order is MENU, GAME, FARM_STATIC, CITY_STATIC, TRAFFIC, SCHOOL, BENCHMARK, VILLY. The editor opened every scene and prefab with no asset-load failures. Source-versus-export comparison checked **116,620 GameObject/Transform records** for names, activation, tags, layers, parent/child ordering, local transforms, component ordering and RectTransform layout with no mismatches before documented migration additions.

Recovered code covers **nine assemblies, 1,058 types and 6,764 executable method bodies**. Gameplay source is editable under `Assets/Scripts`. Compatible plugin binaries retain assembly and serialized script identities; their editable decompilation, repair scripts and rebuilding commands remain under `Recovery/code`. Compilation was tested both separately and in the actual target editor/player build. See [code recovery report](Recovery/code/recovery-report.md).

An independent comparison of **11,922 scene MonoBehaviours**, **69,956 scalar fields**, and **21,362 local/null references** found no differences against original data in the integrated scenes. Cross-file references, nested fields and long strings are not exhaustively covered by this comparison. The static GUID audit resolved 175,737 target references with no missing/duplicate GUIDs, including explicit handling of built-in UI references.

Migration preserves original renderer local IDs for **195 legacy particle groups**, using native target ParticleSystem/ParticleSystemRenderer objects plus data and behavior adapters. Focused editor verification passed all 195 links. Four obsolete GUILayer records retain their original data; the source contains no legacy GUIText/GUITexture native objects. Thirty-two non-Resources prefab assets were moved into separate folders to preserve their original imported root names, retaining GUIDs and payloads. [Focused migration audit](Recovery/scenes/native-renderer-audit.json).

The original editor audit reported one missing script, ten missing-reference candidates and 43 invalid UnityEvents. Independent examination traced **all 54 rows to original disabled/null or stale components and callbacks**, including legacy ads/purchase UI and an RCC demo prefab. They were retained and classified, not deleted to make the audit pass. [Original issue classification](Recovery/verification/original-issue-classification.json).

The original executable and reconstructed player both rendered menu and driving scenes. On the initial reconstructed build, independent physical input completed the actual first-run garage tutorial, bought the starter car for 3,000 in-game coins, selected Green Valleys, accelerated and steered; the car moved and triggered drift scoring. The automated smoke test separately exercised MENU initialization/reload and GAME plus additive CITY_STATIC loading without runtime exceptions. Its direct PLAY_BUTTON invocation bypasses the normal first-car purchase UI, so it is not a substitute for that physical UI test. The final frozen build completed a normal visible smoke run with exit code 0, zero managed errors/exceptions and zero native presentation diagnostics. Its rendered [menu](Recovery/verification/final-runtime-normal/7-initial-menu.png) and [city gameplay](Recovery/verification/final-runtime-normal/25-gameplay.png) captures are retained. The final run still logged 191 negative-scale collider warnings and the one preserved original missing-script warning. Final-build results and fingerprints are recorded in the [independent verification report](Recovery/verification/verification-report.json); source file-set and hash preservation are recorded in [final source integrity](Recovery/verification/final-source-integrity.json).

Original saves and PlayerPrefs used during reference testing were backed up and restored with hash checks. Reconstructed tests use the separate `CartoonRacerRecovery / CartoonRacerRecon Validation` save namespace. The test profile owns the starter car and has 500 coins after the purchase. No real-money purchase was made.

## Remaining limitations

- **281 of 303 exported custom shaders remain placeholders.** Eleven selected custom shaders were reconstructed from original bytecode and eleven TextMeshPro shaders were replaced with genuine target-package versions. Remaining gaps include optional CameraFilterPack/FxPro effects and Graphy shaders. Compiler success for all 303 shaders does not mean their original visual behavior is recovered. [Exact shader coverage and paths](Recovery/shaders/final-shader-status.json).
- Legacy particle simulation is an evidence-based approximation using modern ParticleSystems. The original parameters and raw records are preserved; dynamics, renderer modes and timing are not proven identical.
- The advanced water shader reconstructs the LOW/MED/HIGH/MAX variants used by the four source materials, including linear fog. Other shadow/alternate variants and exact rendered equivalence remain unverified. [Water recovery evidence](Recovery/code/water/water-recovery-report.md).
- The player has visible `trial version` and `Development Build` marks in this environment. They were retained; no licensing restriction was bypassed. Obsolete API/unused-member build warnings and source negative-scale BoxCollider warnings remain.
- Original stale UI callbacks remain nonfunctional. Unused legacy UNet code is preserved behind an explicit compatibility define; multiplayer has not been restored or tested.
- Visual comparison is qualitative, with different camera/time/profile states. All missions, races, school progression, optional effects, audio equivalence, exhaustive nested/cross-file field fidelity, other graphics APIs and release builds have not been validated.
- Original editor-only tools, authoring shader graphs, comments/model source files and prefab ancestry are not recoverable merely from this player build. The editable reconstruction and raw evidence distinguish recovered, reconstructed, approximate and unsupported content.

## Reproduce checks

Close other editors using this project before running these commands from the project root:

```powershell
& .\Recovery\scenes\run-build.ps1
& .\Recovery\scenes\run-audit.ps1 -MigrationOnly -Graphics
& .\Recovery\scenes\run-audit.ps1 -ShaderOnly -Graphics
& .\Recovery\scenes\run-smoke.ps1
```

The comprehensive `run-audit.ps1` without filters opens every scene/prefab and records all issues, including preserved source defects; its raw result can therefore be a failure even when no reconstruction regression is found. Read the independent classification alongside it. `run-smoke.ps1` supplies UI-method calls, not keyboard driving input, and writes to the isolated test save namespace.

Recovery scripts, pristine exports, raw payloads, source/object/reference ledgers, scene identity mappings, migration reports and full logs are retained under `Recovery`. The [run ledger](Recovery/run.json), [source inventory](Recovery/evidence/source-files-sha256.json), [source coverage](Recovery/extraction/coverage.json), [feature matrix](Recovery/scenes/engine-feature-matrix.json), and [verification report](Recovery/verification/verification-report.json) provide the detailed scope and evidence.

Expert agents were requested through the supported host controls as Sol/medium for extraction, Sol/high for scene integration, and Astra/high for code/migration and independent verification. Spawn requests were accepted; actual model settings were not exposed independently by the host. The coordinator stayed in the current session.

Verified findings were installed into the reconstruction suite's shared extraction, script/component, scene/rendering and migration references: exporter settings sequencing, shader placeholder/render-state checks, generated-layout alignment/module/string-array/Unicode handling, and native typed-reference preservation. Backups, hashes, scripts and validation results are in the [installed improvements ledger](Recovery/skill-maintenance/installed-improvements.json). Additional project-specific findings remain in their evidence reports. The skill-creator structural validator passed after the installed changes.

