Shader "Hidden/FxPro" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ChromAberrTex ("Chromatic Aberration (RGB)", 2D) = "black" {}
		_LensDirtTex ("Lens Dirt Texture", 2D) = "black" {}
		_DirtIntensity ("Lens Dirt Intensity", Float) = 0.1
		_ChromaticAberrationOffset ("Chromatic Aberration Offset", Float) = 1
		_BloomTex ("Bloom (RGBA)", 2D) = "black" {}
		_DOFTex ("DOF (RGB), COC(A)", 2D) = "black" {}
		_COCTex ("COC Texture (RGBA)", 2D) = "white" {}
		_SCurveIntensity ("S-Curve Intensity", Float) = 0.5
		_LensCurvatureBarrelPower ("Lens Curvature Barrel Power", Float) = 1.1
		_LensCurvatureZoom ("Lens Curvature Zoom", Float) = 1
		_FilmGrainTex ("Film Grain (RGB)", 2D) = "white" {}
		_FilmGrainIntensity ("Film Grain Intensity", Float) = 0.5
		_FilmGrainTiling ("Film Grain Tiling", Float) = 4
		_FilmGrainChannel ("Film Grain Channel", Vector) = (1,0,0,0)
		_VignettingIntensity ("Vignetting Intensity", Float) = 0.5
		_CloseTint ("Warm Tint Color", Vector) = (1,0.5,0,1)
		_FarTint ("Warm Tint Color", Vector) = (0,0,1,1)
		_CloseTintStrength ("Close Tint Strength", Float) = 0.5
		_FarTintStrength ("Far Tint Strength", Float) = 0.5
		_DesaturateDarksStrength ("Desaturate Darks Strength", Float) = 0.25
		_DesaturateFarObjsStrength ("Desaturate Far Objs Strength", Float) = 0.5
		_FogTint ("Fog Tint Color", Vector) = (1,1,1,1)
		_FogStrength ("Fog Strength", Float) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;
			float4 _MainTex_ST;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Vertex_Stage_Output
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.uv = (input.uv.xy * _MainTex_ST.xy) + _MainTex_ST.zw;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			Texture2D<float4> _MainTex;
			SamplerState sampler_MainTex;

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy);
			}

			ENDHLSL
		}
	}
}