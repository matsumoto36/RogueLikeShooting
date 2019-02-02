// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33246,y:33129,varname:node_1873,prsc:2|emission-1684-OUT,alpha-8173-OUT,clip-1952-OUT;n:type:ShaderForge.SFN_Tex2d,id:2177,x:31148,y:32894,varname:_emi_texture,prsc:2,ntxv:0,isnm:False|UVIN-7999-OUT,TEX-8428-TEX;n:type:ShaderForge.SFN_Lerp,id:7003,x:32546,y:33098,varname:node_7003,prsc:2|A-5351-RGB,B-5711-RGB,T-942-OUT;n:type:ShaderForge.SFN_Color,id:5351,x:32349,y:33098,ptovrint:False,ptlb:0,ptin:_0,varname:_0,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:5711,x:32349,y:33306,ptovrint:False,ptlb:1,ptin:_1,varname:_1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.9905875,c4:1;n:type:ShaderForge.SFN_Multiply,id:1684,x:33019,y:33127,varname:node_1684,prsc:2|A-3442-OUT,B-7823-OUT;n:type:ShaderForge.SFN_Slider,id:1131,x:32511,y:33267,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:10,max:10;n:type:ShaderForge.SFN_RemapRange,id:942,x:31732,y:33297,varname:node_942,prsc:2,frmn:0,frmx:10,tomn:-10,tomx:10|IN-793-OUT;n:type:ShaderForge.SFN_Multiply,id:1952,x:33009,y:33480,varname:node_1952,prsc:2|A-9249-OUT,B-653-OUT,C-9539-OUT;n:type:ShaderForge.SFN_Slider,id:9539,x:32676,y:33549,ptovrint:False,ptlb:range,ptin:_range,varname:_range,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Noise,id:6091,x:32024,y:34054,varname:node_6091,prsc:2|XY-5870-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5870,x:31848,y:34054,varname:node_5870,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3865,x:31848,y:33887,varname:node_3865,prsc:2;n:type:ShaderForge.SFN_Frac,id:4718,x:32374,y:33887,varname:node_4718,prsc:2|IN-7442-OUT;n:type:ShaderForge.SFN_Multiply,id:7442,x:32201,y:33887,varname:node_7442,prsc:2|A-6091-OUT,B-5361-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:5361,x:32024,y:33887,varname:node_5361,prsc:2|IN-3865-TSL,IMIN-5639-OUT,IMAX-8609-OUT,OMIN-9929-OUT,OMAX-5631-OUT;n:type:ShaderForge.SFN_Vector1,id:8609,x:31872,y:33699,varname:node_8609,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:7133,x:31554,y:33800,varname:node_7133,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:5639,x:31716,y:33699,varname:node_5639,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:9929,x:31716,y:33800,varname:node_9929,prsc:2|A-5631-OUT,B-7133-OUT;n:type:ShaderForge.SFN_Multiply,id:3442,x:32758,y:32924,varname:node_3442,prsc:2|A-7003-OUT,B-4718-OUT,C-7002-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5631,x:31872,y:33800,ptovrint:False,ptlb:noise speed,ptin:_noisespeed,varname:_noisespeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Multiply,id:9249,x:32808,y:33392,varname:node_9249,prsc:2|A-8173-OUT,B-4718-OUT;n:type:ShaderForge.SFN_Slider,id:793,x:31406,y:33297,ptovrint:False,ptlb:state_switch,ptin:_state_switch,varname:_state_switch,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Tex2d,id:3110,x:32178,y:32706,ptovrint:False,ptlb:vignette,ptin:_vignette,varname:_vignette,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cf78027b7b6cf4b4f8c6ac24596fd2dd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7002,x:32546,y:32889,varname:node_7002,prsc:2|A-653-OUT,B-5933-OUT;n:type:ShaderForge.SFN_Slider,id:578,x:32021,y:32927,ptovrint:False,ptlb:hani,ptin:_hani,varname:_hani,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_OneMinus,id:653,x:32349,y:32706,varname:node_653,prsc:2|IN-3110-RGB;n:type:ShaderForge.SFN_TexCoord,id:9694,x:30311,y:32894,varname:node_9694,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7920,x:30800,y:32894,varname:node_7920,prsc:2|A-2453-OUT,B-7937-OUT;n:type:ShaderForge.SFN_Slider,id:7937,x:30470,y:32776,ptovrint:False,ptlb:tiling,ptin:_tiling,varname:_tiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.07693,max:3;n:type:ShaderForge.SFN_Frac,id:7999,x:30964,y:32894,varname:node_7999,prsc:2|IN-7920-OUT;n:type:ShaderForge.SFN_Add,id:2453,x:30632,y:32894,varname:node_2453,prsc:2|A-9694-UVOUT,B-4352-OUT;n:type:ShaderForge.SFN_Append,id:2542,x:30180,y:32894,varname:node_2542,prsc:2|A-1784-OUT,B-7911-OUT;n:type:ShaderForge.SFN_Slider,id:1784,x:29631,y:32808,ptovrint:False,ptlb:tile_width,ptin:_tile_width,varname:_tile_width,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Slider,id:7911,x:29390,y:32944,ptovrint:False,ptlb:tile_height,ptin:_tile_height,varname:_tile_height,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7946047,max:10;n:type:ShaderForge.SFN_Multiply,id:4352,x:30470,y:32894,varname:node_4352,prsc:2|A-696-TSL,B-2542-OUT;n:type:ShaderForge.SFN_Time,id:696,x:30311,y:32724,varname:node_696,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:4958,x:30311,y:33112,varname:node_4958,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:9490,x:30814,y:33112,varname:node_9490,prsc:2|A-9240-OUT,B-7937-OUT;n:type:ShaderForge.SFN_Frac,id:9659,x:30964,y:33112,varname:node_9659,prsc:2|IN-9490-OUT;n:type:ShaderForge.SFN_Add,id:9240,x:30632,y:33112,varname:node_9240,prsc:2|A-4958-UVOUT,B-6231-OUT;n:type:ShaderForge.SFN_Append,id:9737,x:30180,y:33112,varname:node_9737,prsc:2|A-1851-OUT,B-2589-OUT;n:type:ShaderForge.SFN_Multiply,id:6231,x:30470,y:33112,varname:node_6231,prsc:2|A-6296-TSL,B-9737-OUT;n:type:ShaderForge.SFN_Time,id:6296,x:30311,y:33261,varname:node_6296,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:8173,x:31794,y:33009,varname:node_8173,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6019-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:8428,x:30946,y:33301,ptovrint:False,ptlb:texture,ptin:_texture,varname:_texture,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9099,x:31148,y:33112,varname:_node_9099,prsc:2,ntxv:0,isnm:False|UVIN-9659-OUT,TEX-8428-TEX;n:type:ShaderForge.SFN_Multiply,id:5628,x:29856,y:33004,varname:node_5628,prsc:2|A-1784-OUT,B-1967-OUT;n:type:ShaderForge.SFN_Vector1,id:1967,x:29426,y:33103,varname:node_1967,prsc:2,v1:-1;n:type:ShaderForge.SFN_Add,id:6399,x:31449,y:33009,varname:node_6399,prsc:2|A-2177-RGB,B-9099-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:2589,x:30014,y:33151,ptovrint:False,ptlb:height_switch,ptin:_height_switch,varname:_height_switch,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-317-OUT,B-7911-OUT;n:type:ShaderForge.SFN_Multiply,id:317,x:29856,y:33151,varname:node_317,prsc:2|A-7911-OUT,B-1967-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:1851,x:30034,y:33004,ptovrint:False,ptlb:width_switch,ptin:_width_switch,varname:_width_switch,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-5628-OUT,B-1784-OUT;n:type:ShaderForge.SFN_RemapRange,id:7823,x:32857,y:33127,varname:node_7823,prsc:2,frmn:0,frmx:10,tomn:0.1,tomx:10|IN-1131-OUT;n:type:ShaderForge.SFN_RemapRange,id:5933,x:32349,y:32909,varname:node_5933,prsc:2,frmn:0,frmx:10,tomn:0.1,tomx:20|IN-578-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:6019,x:31628,y:33009,ptovrint:False,ptlb:dual_texture_switch,ptin:_dual_texture_switch,varname:_dual_texture_switch,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6399-OUT,B-2177-RGB;n:type:ShaderForge.SFN_Tex2d,id:3668,x:31404,y:33150,ptovrint:False,ptlb:emi_texture_copy,ptin:_emi_texture_copy,varname:_emi_texture_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:13abfc38e94b0db4681f60284764f0c1,ntxv:0,isnm:False;proporder:8428-1131-5351-5711-793-9539-578-3110-5631-7937-1784-7911-2589-1851-6019;pass:END;sub:END;*/

Shader "Shader Forge/HP" {
    Properties {
        _texture ("texture", 2D) = "white" {}
        _emi ("emi", Range(0, 10)) = 10
        _0 ("0", Color) = (1,0,0,1)
        _1 ("1", Color) = (0,1,0.9905875,1)
        _state_switch ("state_switch", Range(0, 10)) = 0
        _range ("range", Range(0, 10)) = 0
        _hani ("hani", Range(0, 10)) = 0
        _vignette ("vignette", 2D) = "white" {}
        _noisespeed ("noise speed", Float ) = 10
        _tiling ("tiling", Range(0, 3)) = 2.07693
        _tile_width ("tile_width", Range(0, 10)) = 0
        _tile_height ("tile_height", Range(0, 10)) = 0.7946047
        [MaterialToggle] _height_switch ("height_switch", Float ) = -0.7946047
        [MaterialToggle] _width_switch ("width_switch", Float ) = 0
        [MaterialToggle] _dual_texture_switch ("dual_texture_switch", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _0;
            uniform float4 _1;
            uniform float _emi;
            uniform float _range;
            uniform float _noisespeed;
            uniform float _state_switch;
            uniform sampler2D _vignette; uniform float4 _vignette_ST;
            uniform float _hani;
            uniform float _tiling;
            uniform float _tile_width;
            uniform float _tile_height;
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform fixed _height_switch;
            uniform fixed _width_switch;
            uniform fixed _dual_texture_switch;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_696 = _Time;
                float2 node_7999 = frac(((i.uv0+(node_696.r*float2(_tile_width,_tile_height)))*_tiling));
                float4 _emi_texture = tex2D(_texture,TRANSFORM_TEX(node_7999, _texture));
                float4 node_6296 = _Time;
                float node_1967 = (-1.0);
                float2 node_9659 = frac(((i.uv0+(node_6296.r*float2(lerp( (_tile_width*node_1967), _tile_width, _width_switch ),lerp( (_tile_height*node_1967), _tile_height, _height_switch ))))*_tiling));
                float4 _node_9099 = tex2D(_texture,TRANSFORM_TEX(node_9659, _texture));
                float node_8173 = lerp( (_emi_texture.rgb+_node_9099.rgb), _emi_texture.rgb, _dual_texture_switch ).r;
                float2 node_6091_skew = i.uv0 + 0.2127+i.uv0.x*0.3713*i.uv0.y;
                float2 node_6091_rnd = 4.789*sin(489.123*(node_6091_skew));
                float node_6091 = frac(node_6091_rnd.x*node_6091_rnd.y*(1+node_6091_skew.x));
                float4 node_3865 = _Time;
                float node_5639 = 0.0;
                float node_9929 = (_noisespeed*(-1.0));
                float node_4718 = frac((node_6091*(node_9929 + ( (node_3865.r - node_5639) * (_noisespeed - node_9929) ) / (1.0 - node_5639))));
                float4 _vignette_var = tex2D(_vignette,TRANSFORM_TEX(i.uv0, _vignette));
                float3 node_653 = (1.0 - _vignette_var.rgb);
                clip(((node_8173*node_4718)*node_653*_range) - 0.5);
////// Lighting:
////// Emissive:
                float3 node_7002 = (node_653*(_hani*1.99+0.1));
                float3 node_3442 = (lerp(_0.rgb,_1.rgb,(_state_switch*2.0+-10.0))*node_4718*node_7002);
                float3 emissive = (node_3442*(_emi*0.9899999+0.1));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_8173);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _range;
            uniform float _noisespeed;
            uniform sampler2D _vignette; uniform float4 _vignette_ST;
            uniform float _tiling;
            uniform float _tile_width;
            uniform float _tile_height;
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform fixed _height_switch;
            uniform fixed _width_switch;
            uniform fixed _dual_texture_switch;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_696 = _Time;
                float2 node_7999 = frac(((i.uv0+(node_696.r*float2(_tile_width,_tile_height)))*_tiling));
                float4 _emi_texture = tex2D(_texture,TRANSFORM_TEX(node_7999, _texture));
                float4 node_6296 = _Time;
                float node_1967 = (-1.0);
                float2 node_9659 = frac(((i.uv0+(node_6296.r*float2(lerp( (_tile_width*node_1967), _tile_width, _width_switch ),lerp( (_tile_height*node_1967), _tile_height, _height_switch ))))*_tiling));
                float4 _node_9099 = tex2D(_texture,TRANSFORM_TEX(node_9659, _texture));
                float node_8173 = lerp( (_emi_texture.rgb+_node_9099.rgb), _emi_texture.rgb, _dual_texture_switch ).r;
                float2 node_6091_skew = i.uv0 + 0.2127+i.uv0.x*0.3713*i.uv0.y;
                float2 node_6091_rnd = 4.789*sin(489.123*(node_6091_skew));
                float node_6091 = frac(node_6091_rnd.x*node_6091_rnd.y*(1+node_6091_skew.x));
                float4 node_3865 = _Time;
                float node_5639 = 0.0;
                float node_9929 = (_noisespeed*(-1.0));
                float node_4718 = frac((node_6091*(node_9929 + ( (node_3865.r - node_5639) * (_noisespeed - node_9929) ) / (1.0 - node_5639))));
                float4 _vignette_var = tex2D(_vignette,TRANSFORM_TEX(i.uv0, _vignette));
                float3 node_653 = (1.0 - _vignette_var.rgb);
                clip(((node_8173*node_4718)*node_653*_range) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
