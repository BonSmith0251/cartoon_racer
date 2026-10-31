# Terrain material audit

Checked in Unity 2023.2.22f1 against original Unity 2018.2.20f1 serialized TerrainData. Audit only; no terrain, material, prefab or scene repairs were saved. Original game unchanged.

## Confirmed defect

FARM_TERRAIN has eight valid texture layers but both 512 x 512 splat alpha textures are missing. Unity returns null for both alphamapTextures entries. The current binary TerrainData references local texture IDs 28709254077376921 and 28730242686860875 but contains neither object. Original sharedassets1.assets:129725 references valid textures 241 and 238. These paint maps control the distribution/blending of the eight ground textures; the farm cannot reproduce the original painted surface with these dependencies absent. Restore from the original maps, preserving TerrainData GUID and layer order, then validate rendering and rebuild the player.

## Passing checks

- All 29 layer entries across MENU (8), CITY_TERRAIN (8), FARM_TERRAIN (8), SCHOOL (5) match original texture names/order, tile size/offset, smoothness and zero specular/metallic settings. Normal maps are absent in both original and reconstruction. Texture pixel identity was not compared for diffuse layer PNGs.
- MENU, CITY_TERRAIN and SCHOOL each retain both paint maps with byte-identical decoded RGBA pixels to the original.
- MENU, BENCHMARK, CITY_TERRAIN prefab and FARM_TERRAIN prefab resolve to supported Nature/Terrain/Diffuse. SCHOOL resolves to supported Nature/Terrain/Specular. Null material references in legacy YAML do not mean missing materials: Unity resolves its built-in defaults.

## Remaining check

SCHOOL serializes legacy shininess 0.278 while its resolved built-in material reports _Shininess 0.078125. This is a potential migration issue, not yet a confirmed rendering defect: a render comparison or inspection of Terrain property overrides is required. No visual fidelity verdict or standalone rebuild was performed during this focused audit.

Evidence: editor-terrain-audit.json, source-comparison.json, editor.log. Repeatable tools: compare.py and Assets/Editor/TerrainAudit/TerrainMaterialAudit.cs.

## Reusable validation finding

A successful import and supported Terrain shader do not establish that splat dependencies survived migration. Explicitly check every TerrainData.alphamapTextures entry for null, verify referenced local Texture2D subassets exist, and compare decoded control-map pixels against the source. Include prefab-owned Terrain components as well as scene-owned ones.
