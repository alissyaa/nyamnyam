Shader "Custom/ShieldGlowShader"
{
    Properties
    {
        _Color ("Shield Color", Color) = (0,0.5,1,1)
        _Glow ("Glow Strength", Range(1,3)) = 1.5
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

            fixed4 _Color;
            float _Glow;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color * _Glow;
            }
            ENDCG
        }
    }
}
