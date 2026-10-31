# Independent verification

**Pass for the recorded scopes; whole-game fidelity remains unverified.** The final Unity 2023.2.22f1 Windows build succeeds with 0 errors and 410 warnings. Its normal-window player exits 0 after rendering the menu and loading GAME plus CITY_STATIC, with no managed exceptions, app errors or native presentation diagnostics.

- Original installation and preserved clone: exactly 198 files each, no extra, missing or changed files. Original PlayerPrefs and five existing LocalLow files were restored; subsequent target runs used a separate save identity.
- Source coverage: 394,116 objects in 21 serialized files; all strict type-tree reads now covered. All 211 reported external stream ranges are valid. Original DLL layouts recovered the initial 26,724 custom-component decoding failures.
- Independent final scene comparison: 11,922 MonoBehaviours, 69,956 scalar fields and 21,362 local/null references match the original. External references, nested fields and long strings are explicitly counted as unchecked.
- All 54 initial editor audit warning rows trace to original null scripts/targets or methods absent from the original DLL. Final migration reports pass 195 renderer links and 32 prefab names; 303 custom shaders compile without errors.
- Physical input on the preceding successful build followed the actual first-run garage tutorial, bought the starter car with 3,000 in-game coins, selected Green Valleys, and supplied W for 3 seconds and D for 1 second. The car moved and triggered a drift overlay. The final-build smoke uses actual menu methods and applies no driving input; these are separate checks.

The original reference also rendered its menu and Green Valleys and accepted physical driving input. Captures are qualitative comparisons: profiles, camera timing, starting poses and random state differ.

The final normal-window run has 191 negative-scale BoxCollider warnings and one source-original missing-script warning. An earlier show/resize-loop run produced eight native D3D11 presentation diagnostics; a normal launch of the same frozen build produced none. Historical logs remain; hidden black captures are rejected evidence.

**Limits:** 281 custom shaders remain placeholders; 11 selected shaders are reconstructed and 11 are TMP replacements. Optional effects, exact legacy-particle behavior, full missions/races, all maps, audio fidelity and precise physics/pixel equivalence are unverified. Four obsolete GUILayer records preserve data through bridges. Visible trial-version and Development Build watermarks remain unchanged.

Evidence: [full report](verification-report.json), [final menu](final-runtime-normal/7-initial-menu.png), [final gameplay](final-runtime-normal/25-gameplay.png), [physical driving](target-driving-after.png), [final build fingerprint](final-tested-build-files.json), [editable project fingerprint](final-tested-project-files.json), [source integrity](final-source-integrity.json). Fingerprints cover all 255 final build files and 6,389 files under Assets, Packages and ProjectSettings.
