#version 100
#define M_2xSQRT2 2.8284271247461900976033774484194
precision highp float;
varying vec3 Ray;
uniform vec4 crop;
uniform float scalar;
uniform sampler2D sample_projection;

void main()
{
	vec3 R = normalize(Ray);
	vec2 uv = scalar * R.xy / (M_2xSQRT2 * sqrt(R.z + 1.0));
	if (length(uv) >= 0.5)
		gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);
	else
	{
		uv *= vec2(crop.z, crop.w);
		uv.x = crop.x + uv.x;
		uv.y = crop.y - uv.y;
		gl_FragColor = texture2D(sample_projection, uv);
	}
}