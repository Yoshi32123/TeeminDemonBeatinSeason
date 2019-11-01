//source https://forum.unity.com/threads/hue-saturation-brightness-contrast-shader.260649/

Shader "Unlit/ColorAdjust"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Brightness("Brightness", Range(-0.5, 0.7)) = 0
		_Contrast("Contrast", Range(0.3, 3)) = 1
		_Saturation("Saturation", Range(0, 3)) = 1
	}
		SubShader
		{
			Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 200
			CGPROGRAM

			#pragma surface surf Standard fullforwardshadows alpha:fade
			#pragma target 3.0

			sampler2D _MainTex;

			struct Input {
				float2 uv_MainTex;
				float4 vertColor : COLOR;
			};

			float _Brightness;
			float _Contrast;
			float _Saturation;
			fixed4 _Color;

			inline float4 applyHSBEffect(float4 startColor)
			{
				float4 outputColor = startColor;
				outputColor.rgb = (outputColor.rgb - 0.5f) * (_Contrast)+0.5f;
				outputColor.rgb = outputColor.rgb + _Brightness;
				float3 intensity = dot(outputColor.rgb, float3(0.299, 0.587, 0.114));
				outputColor.rgb = lerp(intensity, outputColor.rgb, _Saturation);
				return outputColor;
			}
			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color * IN.vertColor;
				o.Albedo = applyHSBEffect(c)*6;
				o.Alpha = c.a;
			}
			ENDCG
		}
	FallBack "Standard"
}