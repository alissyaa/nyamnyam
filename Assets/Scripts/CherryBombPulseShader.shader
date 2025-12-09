Shader "Custom/CherryBombPulseShader"
{
    Properties
    {
        _MainTex ("Bomb Texture", 2D) = "white" {}
        _Pulse ("Pulse Strength", Range(0,1)) = 0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Pulse;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 tex = tex2D(_MainTex, i.uv);
                fixed4 danger = fixed4(1, 0, 0, 1);

                // Animasi: texture <-> merah
                return lerp(tex, danger, _Pulse);
            }
            ENDCG
        }
    }
}
