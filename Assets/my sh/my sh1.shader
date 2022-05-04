Shader "Unlit/my sh1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    _Color("Color", Color) = (1.000000,1.000000,1.000000,1.000000)
 _Cutoff("Alpha Cutoff", Range(0.000000,1.000000)) = 0.500000
 _Glossiness("Smoothness", Range(0.000000,1.000000)) = 0.500000
 _GlossMapScale("Smoothness Scale", Range(0.000000,1.000000)) = 1.000000
[Enum(Metallic Alpha,0,Albedo Alpha,1)]  _SmoothnessTextureChannel("Smoothness texture channel", Float) = 0.000000
[Gamma]  _Metallic("Metallic", Range(0.000000,1.000000)) = 0.000000
 _MetallicGlossMap("Metallic", 2D) = "white" { }
[ToggleOff]  _SpecularHighlights("Specular Highlights", Float) = 1.000000
[ToggleOff]  _GlossyReflections("Glossy Reflections", Float) = 1.000000
 _BumpScale("Scale", Float) = 1.000000
[Normal]  _BumpMap("Normal Map", 2D) = "bump" { }
 _Parallax("Height Scale", Range(0.005000,0.080000)) = 0.020000
 _ParallaxMap("Height Map", 2D) = "black" { }
 _OcclusionStrength("Strength", Range(0.000000,1.000000)) = 1.000000
 _OcclusionMap("Occlusion", 2D) = "white" { }
 _EmissionColor("Color", Color) = (0.000000,0.000000,0.000000,1.000000)
 _EmissionMap("Emission", 2D) = "white" { }
 _DetailMask("Detail Mask", 2D) = "white" { }
 _DetailAlbedoMap("Detail Albedo x2", 2D) = "grey" { }
 _DetailNormalMapScale("Scale", Float) = 1.000000
[Normal]  _DetailNormalMap("Normal Map", 2D) = "bump" { }
[Enum(UV0,0,UV1,1)]  _UVSec("UV Set for secondary textures", Float) = 0.000000
[HideInInspector]  _Mode("__mode", Float) = 0.000000
[HideInInspector]  _SrcBlend("__src", Float) = 1.000000
[HideInInspector]  _DstBlend("__dst", Float) = 0.000000
[HideInInspector]  _ZWrite("__zw", Float) = 1.000000
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
