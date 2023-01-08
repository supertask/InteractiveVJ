Shader "FontTest"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        Pass
        {
            CGPROGRAM

            #include "UnityCG.cginc"
            
            #pragma vertex Vertex
            #pragma fragment Fragment

            sampler2D _MainTex;
            float4 _MainTex_ST;

            void Vertex
              (float4 inPos : POSITION, float2 inUV : TEXCOORD0,
               out float4 outPos : SV_Position, out float2 outUV : TEXCOORD0)
            {
                outPos = UnityObjectToClipPos(inPos);
                outUV = inUV;
            }

            float4 Fragment(float4 pos : SV_Position,
                            float2 uv : TEXCOORD0) : SV_Target
            {
                return tex2D(_MainTex, uv).a;
            }

            ENDCG
        }
    }
}