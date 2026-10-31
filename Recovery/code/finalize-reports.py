import pathlib,json,collections
root=pathlib.Path(r'D:\Games\CartoonRacerRecon');code=root/'Recovery/code';water=code/'water'
report='''# LowPolyWater/Advanced recovered material variants

Deliverables: LowPolyWaterAdvancedRecovered.shader and LowPolyWaterHighRecovered.cginc. Copy the shader body into the existing original shader asset while preserving meta GUID 9901c4e4da79e9e4d83ac3d13f695301, and put the include beside it. The include path is relative. No project files were changed by this analysis worker for this shader task.

This proposal uses original parsed shader constant-buffer layouts and D3D11 instruction listings, not a generic replacement water effect. All original exposed and hidden material properties are retained. Source first-pass blend state is SrcAlpha/OneMinusSrcAlpha, ZWrite uses _ZWrite, and Cull uses _Cull_. Textual disassembly says default Off; parsed state links the runtime properties, which is essential for these materials.

| Material | Recovered behavior |
| --- | --- |
| LOW | Custom triangle mesh, ripple displacement, vertex diffuse/SH/Fresnel/specular, reflected scene, depth absorption, no distortion or foam |
| MED | LOW plus original two-sample scrolling normal distortion |
| HIGH | Custom triangle mesh, ripple displacement, pixel diffuse/SH/Fresnel/specular, reflection/distortion, depth absorption and shoreline foam |
| MAX | HIGH plus original high-quality analytic waves and horizontal displacement |

Linear fog is translated from source FOG_LINEAR vertex and fragment bytecode. Source passes clip-position Z, applies max((1-clipZ/near)*far,0), then the saturating unity_FogParams.z/w blend with unity_FogColor. This was added after the initial handoff; copy the latest wrapper.

Key evidence details:

- _WAVES_OFF does not disable ripple displacement. Ripple UV is ((world.x + 57.299999*world.y), (world.z + _Time.y*_RSpeed_))/_TexSize_; alpha of _NoiseTex shifts along the original object normal. Preserve this unusual object-normal/world-position combination because it is in the original bytecode.
- For MAX, hash is frac(sin(n)*43758.546875). CPU Displacement.cs uses multiplier10 and omits the shader horizontal movement, so it is not a faithful shader substitute.
- BakeCustomMesh stores edge vectors in UV0.xyzw+UV1.xy. Shader reconstructs two neighboring positions, displaces all three, and takes a face cross product. Replacing UVs with ordinary texture coordinates changes the water normals.
- Pixel variants do not renormalize interpolated face normals. Ambient SH gamma conversion is explicitly present in the original DXBC.
- The original runtime reflection script binds _ReflectionTex and optional _RefractionTex. None of the four selected fragment variants samples _RefractionTex; they use reflection and scene depth. No invented refraction pass was added.
- The source material cache fields (_Direction_, _Scale_, _Height_, _BumpScale_ etc.) are preserved; they already contain values prepared by the lost editor tooling. No material regeneration is required to render recovered original values.

Evidence files: high/low/med/max-progVertex.asm.txt and -progFragment.asm.txt, corresponding binding JSON, high-fog-* assembly, and variant-inventory.json for all144 first-pass shader subprograms. The full compiled export contains318 disassembly blocks; subsequent passes are outside this proposal.

Validation: all four material vertex/fragment variants compiled with installed FXC10.0.22621.0 against Unity2023.2.22f1 CGIncludes using /Gec, vs_4_0 and ps_4_0. MAX linear-fog vertex/fragment also compiled. This establishes HLSL compilation, not render equivalence or byte-for-byte instruction identity. Rendered original-vs-reconstruction comparison remains required.

Remaining gaps: source screen-shadow variants, other source passes/fallbacks, arbitrary non-custom meshes, waves-low-quality, flat-shading and custom point-light keyword combinations are not implemented. The actual four recovered materials are custom shape, reflective, absorption enabled; LOW/MED are vertex-lit, HIGH/MAX pixel-lit, and all have _EnableShadows0. Fog-exp/exp2 are not present in the recovered source variant set. Shader inspector functionality is unavailable: editing public properties such as Direction/Height may require updating corresponding cached underscore uniforms; no silent editor behavior substitute is provided.
'''
(water/'water-recovery-report.md').write_text(report,encoding='utf-8')
p=code/'coverage-summary.json';d=json.loads(p.read_text());d['project_compile']='passed Unity 2023.2.22f1 editor-import-5.log after namespace-path, reserved-asmdef, package and AndroidJNI repairs';d['structural_source_issue_classification']={'original_null_unityevent_targets':16,'original_null_script_unityevent_targets':10,'original_absent_callback_methods':17};p.write_text(json.dumps(d,indent=2))
p=code/'recovery-report.md';s=p.read_text();s+='\nActual project compile completed in Unity2023.2.22f1 (editor-import-5.log). Namespace mapping repair: ILSpy dot-separated namespace folders must be merged into exporter nested paths, retaining existing metas. The source full scene audit then identified43 invalid UnityEvents; all43 callback component payloads exactly match pristine export.16targets are originally null,10target an original disabled component with no script,17reference methods absent from original managed build. See unityevent-source-classification.json. No behavior was silently supplied or removed to clear these warnings.\n';p.write_text(s,encoding='utf-8')
print('Water and final code reports updated.')
