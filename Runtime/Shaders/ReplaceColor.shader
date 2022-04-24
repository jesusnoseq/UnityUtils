
Shader "Custom/ReplaceColor" {
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _ColorIn ("Color to replace", Color) = (1,1,1,1)
        _Color1out ("Replace color", Color) = (1,1,1,1)
        _Color2out ("Color for other areas", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag      
            #pragma multi_compile DUMMY PIXELSNAP_ON
            #include "UnityCG.cginc"
           
            struct appdata_t
            {
                float4 vertex   : POSITION;
                fixed4 color    : COLOR;
                half2 texcoord : TEXCOORD0;
            };
            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
            };
           
            fixed4 _ColorIn;
            fixed4 _Color1out;
            fixed4 _Color2out;
            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;        
                OUT.color = IN.color;
                #ifdef PIXELSNAP_ON
                    OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif
                return OUT;
            }
            sampler2D _MainTex;    
           
            fixed4 frag(v2f IN) : COLOR
            {
                fixed4 texColor = tex2D( _MainTex, IN.texcoord );
     
                //Distance is used to know the difference
                // between texture color and the chosen color for replacement
                fixed dist1 = distance(texColor, _ColorIn);
     
                //We want to have the first color when the texture color is nearly
                // similar to the chosen color and slowly switch to second color
                // as the color gets more different.
                fixed4 finalColor = (1 - dist1) * _Color1out + dist1  * _Color2out;
     
                //Copy the alpha value from the original texture.
                finalColor.w = texColor.w;
                texColor = finalColor;
     
                return texColor * IN.color;
            }
        ENDCG
        }
    }
}
     
