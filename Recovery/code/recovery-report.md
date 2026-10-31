# Cartoon Hot Racer managed-code recovery and migration

Original Unity player: 2018.2.20f1, Mono. Requested target: 2023.2.22f1. Original files were read only. Pristine decompilation and target repairs are separate.

All nine game/plugin assemblies were decompiled with ILSpy 8.2.0.7535 and matching original references. The inventory records 1,058 types including nested compiler-generated types and 6,936 methods, of which 6,764 contain recoverable IL bodies. 64 abstract contracts, 104 runtime/external methods, and four native imports are explicitly distinguished. These are actual executable bodies, not dummy metadata stubs. This is source recovery coverage, not proof every behavior has been exercised.

Gameplay and UnityScript source is installed in Assets, preserving exporter .cs.meta GUIDs. Assembly-UnityScript and Assembly-UnityScript-firstpass have asmdefs retaining their original assembly identities. Empty Assembly-CSharp-firstpass is retained through Unity predefined assembly; its name is reserved for asmdefs. Boo.Lang and UnityScript.Lang runtimes are copied from the original installation. Five ES2/Moodkie/Graphy/EasyCombine plugins are recompiled for target APIs, retaining DLL metadata GUIDs and original assembly versions. Their complete editable source is in repaired/ and compile.ps1 rebuilds them. Do not import their source alongside the same DLLs, which would duplicate types and invalidate DLL script attachments.

| Encountered system | Evidence/action | Remaining limitation |
| --- | --- | --- |
| Gameplay source | Assembly-CSharp independently compiles against installed 2023.2.22f1 API references | Full project/runtime audit owned by scene worker |
| UnityScript | Decompiled to editable C#; original assembly identities retained; Boo and UnityScript runtime dependencies included | Native-language source text cannot be recovered |
| ES2 saves | Full original save/read logic recovered; removed WebPlayer enum names replaced by verified original integers (Windows=5, OSX=3); obsolete Unity API compatibility marker removed | Launch MENU and follow first-run language flow before GAME; preserve isolated product/company settings |
| GUITexture / GUIText | Two unused demo scripts use UI.Image requirement / UI.Text field now | Zero GUID references across exported scenes/prefabs/assets; demos not visual fidelity claims |
| UNet RCC integration | Entire source preserved behind CARTOON_RECON_LEGACY_UNET; audit found zero serialized references | Removed legacy networking unsupported in target; enabling define is not sufficient without old transport migration |
| Legacy native particles | Zero managed ParticleEmitter / ParticleAnimator references in all nine assemblies | Native component conversion belongs to scenes expert |
| TextMeshPro/UI | Target compile used Unity 2023-compatible package assemblies | Scene worker replaces copied old TMP DLL, remaps script identities, and installs UGUI/TMP packages |
| sycoforge_imaging | Four original native imports preserved (HSB/RGB and gamma conversion) | No matching native DLL exists in original installation; no game source call sites found. Dormant original dependency remains unverified |
| Old platform/framework plugins | Unused exported Analytics/Purchasing/StandardEvents/framework DLLs backed up outside Assets after zero GUID reference audit | No gameplay networking dependency found; ES2 web examples remain original code |

Compile logs: logs/compile-*.log. Metadata and fingerprints: assemblies.json, types-fields.json, method-status.json. Source MonoScript destinations: monoscript-map.json. Integration changes: integration.json. Reconstruction edits retain game behavior except explicitly identified unused demo/legacy feature migration.

Startup: MENU_MANAGER.Awake establishes first-run settings, shows START_UI, disables itself, and waits for SELECT_ENG_()/CONTINUE() to reload MENU. MENU_MANAGER.Start initializes DEFAULT_CONFIG save keys. GAME_MANAGER.Awake instantiates the selected terrain prefab then loads FARM_STATIC or CITY_STATIC additively; never duplicate those procedural/runtime objects into the static scene. All eight scene indices must preserve source build order.

Applicable official migration references consulted: https://docs.unity3d.com/2023.2/Documentation/Manual/UpgradeGuide20232.html and https://docs.unity3d.com/2020.1/Documentation/Manual/UpgradeGuide20201.html. The concrete API changes above are confirmed by installed compiler diagnostics, not guessed from naming.

Reusable skill finding: a UnityScript-era Mono build may need both Boo.Lang.dll and UnityScript.Lang.dll even after C# decompilation. Separate source asmdefs retain original firstpass identity; player assembly property/version attributes must not be dropped when rebuilding plugin DLLs whose serialized MonoScript references are retained. Verify decompiled source with matching target reference profiles (Unity 2023 editor assemblies use .NET Standard 2.1), not generic desktop .NET 4.x facades.

Actual project compile completed in Unity2023.2.22f1 (editor-import-5.log). Namespace mapping repair: ILSpy dot-separated namespace folders must be merged into exporter nested paths, retaining existing metas. The source full scene audit then identified43 invalid UnityEvents; all43 callback component payloads exactly match pristine export.16targets are originally null,10target an original disabled component with no script,17reference methods absent from original managed build. See unityevent-source-classification.json. No behavior was silently supplied or removed to clear these warnings.
