shader_type canvas_item;

uniform float spacing: hint_range(10.0, 1000.0, 10.0);
uniform vec4 stripe_color: source_color;
uniform vec4 bg_color: source_color;
uniform float alpha: hint_range(0.0, 1.0, 0.1);

void fragment() {
    float x = UV.x*spacing;
    float mix_factor_x = exp(-pow((x - round(x)), 2) * 1000.0);
	
    float y = UV.y*spacing;
    float mix_factor_y = exp(-pow((y - round(y)), 2) * 1000.0);
	
	float mix_factor = max(mix_factor_x, mix_factor_y);
    
    vec4 color = mix(bg_color, stripe_color, mix_factor);
    
    COLOR = vec4(color.rgb, alpha);
}