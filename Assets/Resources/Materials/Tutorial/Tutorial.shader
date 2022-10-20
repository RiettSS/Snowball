Shader "Unlit/Tutorial"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
        _MarginTop ("Margin Top", Range(0,1)) = 0
        _MarginRight ("Margin Right", Range(0,1)) = 0
        _MarginLeft ("Margin Left", Range(0,1)) = 0
        _MarginBottom ("Margin Bottom", Range(0,1)) = 0
        _Blur ("Blur", Range(0, 0.1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Color;
            float _MarginBottom;
            float _MarginTop;
            float _MarginLeft;
            float _MarginRight;
            float _Blur;

            float Greatest(float a, float b, float c, float d)
            {
                if(a >= b && a >= c && a >= d)
                {
                    return a;
                }
                else if (b >= a && b >= c && b >= d)
                {
                    return b;
                } else if (c >= a && c >= b && c >= d)
                {
                    return c;
                } else
                {
                    return d;
                }
            }
            
            float BlendBorders(float2 uvCoords)
            {
                float2 blendingBorders = float2(_MarginTop - _Blur, _MarginTop + _Blur);
                float horizontalRange = abs(blendingBorders.x - blendingBorders.y);
                float horizontalCoefficient = 1 / horizontalRange;

                float range = abs(blendingBorders.x - blendingBorders.y);
                float coefficient = 1 / range * _ScreenParams.y / _ScreenParams.x;
                
                float a = (uvCoords.y - (1 - _MarginTop - _Blur)) * coefficient;
                float topResult = clamp(a, 0, 1);

                float2 blendingBordersBot = float2(_MarginBottom - _Blur, _MarginBottom + _Blur);
                float aBot = (uvCoords.y - (_MarginBottom - _Blur)) * coefficient;
                float botResult = clamp(1 - aBot,0,1);
                
                
                float2 blendingBordersleft = float2(_MarginLeft - _Blur, _MarginLeft + _Blur);
                float aLeft = (uvCoords.x - (_MarginLeft - _Blur)) * horizontalCoefficient;
                float leftResult = clamp(1 - aLeft,0,1);

                float2 blendingBordersright = float2(_MarginRight - _Blur, _MarginRight + _Blur);
                float aRight = (uvCoords.x - (1-_MarginRight - _Blur)) * horizontalCoefficient;
                float rightResult = clamp(aRight,0,1);

                

                float result = Greatest(topResult, botResult, rightResult, leftResult);
                
                return clamp(result,0, 1);
            }
            
            float GetAlplha(float2 uvCoords)
            {
                /*
                if(uvCoords.y < 1- _MarginTop && uvCoords.y > _MarginBottom)
                {
                    if(uvCoords.x < 1 - _MarginRight && uvCoords.x > _MarginLeft)
                    {
                        return 0;
                    }
                    else return 1;
                }
                else
                {
                    return 1;
                }
                */

                return BlendBorders(uvCoords);
            }
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                
                return o;
            }

            float4  frag (v2f i) : SV_Target
            {
                float2 uv = float2(i.uv.x, i.uv.y);
                float4 result = float4(_Color.r, _Color.g , _Color.b, GetAlplha(uv) * _Color.a);
                return result;
            }
            ENDCG
        }
    }
}
