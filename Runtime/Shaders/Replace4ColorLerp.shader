
Shader "Custom/Replace4Color" {
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Threshold ("Threshold", Range(0,1)) = 0.1
		_Color1in("Color 1 In", Color) = (1,1,1,1)
		_Color1out("Color 1 Out", Color) = (1,1,1,1)
		_Color2in("Color 2 In", Color) = (1,1,1,1)
		_Color2out("Color 2 Out", Color) = (1,1,1,1)
		_Color3in("Color 3 In", Color) = (1,1,1,1)
		_Color3out("Color 3 Out", Color) = (1,1,1,1)
		_Color4in("Color 4 In", Color) = (1,1,1,1)
		_Color4out("Color 4 Out", Color) = (1,1,1,1)
		_ColorMult("Mult", Color) = (1,1,1,1)
		_ColorAdd("Add", Color) = (0,0,0,0)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog{ Mode Off }
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
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex   : SV_POSITION;
		fixed4 color : COLOR;
		half2 texcoord  : TEXCOORD0;
	};

	float _Threshold;
	fixed4 _ColorMult;
	fixed4 _ColorAdd;
	fixed4 _Color1in;
	fixed4 _Color1out;
	fixed4 _Color2in;
	fixed4 _Color2out;
	fixed4 _Color3in;
	fixed4 _Color3out;
	fixed4 _Color4in;
	fixed4 _Color4out;

	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.vertex = UnityObjectToClipPos(IN.vertex);
		OUT.texcoord = IN.texcoord;
		OUT.color = IN.color;
		#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
		#endif

		return OUT;
	}

	sampler2D _MainTex;

	fixed4 frag(v2f IN) : COLOR
	{
		fixed4 texColor = tex2D(_MainTex, IN.texcoord);
		/*
		texColor = all(texColor == _Color1in) ? _Color1out : texColor;
		texColor = all(texColor == _Color2in) ? _Color2out : texColor;
		texColor = all(texColor == _Color3in) ? _Color3out : texColor;
		texColor = all(texColor == _Color4in) ? _Color4out : texColor;
		*/
		/*
		texColor = (texColor == _Color1in) ? _Color1out : texColor;
		texColor = (texColor == _Color2in) ? _Color2out : texColor;
		texColor = (texColor == _Color3in) ? _Color3out : texColor;
		texColor = (texColor == _Color4in) ? _Color4out : texColor;
		*/
		
		/*texColor = (distance(texColor, _Color1in)<=_Threshold) ? _Color1out : texColor;
		texColor = (distance(texColor, _Color2in)<=_Threshold) ? _Color2out : texColor;
		texColor = (distance(texColor, _Color3in)<=_Threshold) ? _Color3out : texColor;
		texColor = (distance(texColor, _Color4in)<=_Threshold) ? _Color4out : texColor;
		*/
		
		texColor = lerp(_Color1out, texColor, distance(texColor, _Color1in));
		texColor = lerp(_Color2out, texColor, distance(texColor, _Color2in));
		texColor = lerp(_Color3out, texColor, distance(texColor, _Color3in));
		texColor = lerp(_Color4out, texColor, distance(texColor, _Color4in));
		
		return ((texColor * IN.color)+ _ColorAdd)*_ColorMult;
	}
		ENDCG
	}
	}
}