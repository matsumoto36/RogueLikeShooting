// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.07,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32481,y:33096,varname:node_2865,prsc:2|emission-6541-OUT,clip-5233-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1243,x:29829,y:33111,varname:node_1243,prsc:2|IN-2549-OUT,IMIN-6507-OUT,IMAX-362-OUT,OMIN-4353-OUT,OMAX-9973-OUT;n:type:ShaderForge.SFN_Vector1,id:9973,x:29452,y:33340,varname:node_9973,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:8368,x:28975,y:33107,ptovrint:False,ptlb:takasa,ptin:_takasa,varname:_takasa,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_FragmentPosition,id:1520,x:29269,y:33028,varname:node_1520,prsc:2;n:type:ShaderForge.SFN_Add,id:2549,x:29452,y:33028,varname:node_2549,prsc:2|A-1520-Y,B-40-OUT,C-9846-OUT;n:type:ShaderForge.SFN_Tex2d,id:1336,x:30204,y:32788,varname:_node_1336,prsc:2,ntxv:0,isnm:False|UVIN-1642-UVOUT,TEX-8777-TEX;n:type:ShaderForge.SFN_Add,id:6823,x:30374,y:33019,varname:node_6823,prsc:2|A-8303-OUT,B-1243-OUT;n:type:ShaderForge.SFN_Clamp01,id:5588,x:30550,y:33019,varname:node_5588,prsc:2|IN-6823-OUT;n:type:ShaderForge.SFN_Multiply,id:2021,x:31210,y:33051,varname:node_2021,prsc:2|A-1926-OUT,B-9724-OUT;n:type:ShaderForge.SFN_Clamp01,id:6205,x:31409,y:33034,varname:node_6205,prsc:2|IN-2021-OUT;n:type:ShaderForge.SFN_Relay,id:5233,x:32299,y:33353,varname:node_5233,prsc:2|IN-8535-OUT;n:type:ShaderForge.SFN_Multiply,id:6541,x:32122,y:33169,varname:node_6541,prsc:2|A-9615-RGB,B-7429-RGB,C-4138-RGB,D-8668-OUT;n:type:ShaderForge.SFN_Slider,id:8668,x:31680,y:33439,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:7.970545,max:10;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1926,x:30878,y:33078,varname:node_1926,prsc:2|IN-5588-OUT,IMIN-9460-OUT,IMAX-2148-OUT,OMIN-8547-OUT,OMAX-8037-OUT;n:type:ShaderForge.SFN_Vector1,id:8037,x:30550,y:33277,varname:node_8037,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:8547,x:30550,y:33190,varname:node_8547,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:4138,x:31837,y:33209,ptovrint:False,ptlb:emi_color,ptin:_emi_color,varname:_emi_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:2148,x:30550,y:33451,varname:node_2148,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:9460,x:30550,y:33334,varname:node_9460,prsc:2|A-445-OUT,B-2148-OUT;n:type:ShaderForge.SFN_Multiply,id:445,x:30375,y:33334,varname:node_445,prsc:2|A-5282-OUT,B-6566-OUT;n:type:ShaderForge.SFN_Vector1,id:5282,x:30204,y:33305,varname:node_5282,prsc:2,v1:-0.01;n:type:ShaderForge.SFN_Slider,id:6566,x:30060,y:33385,ptovrint:False,ptlb:haba,ptin:_haba,varname:_haba,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:100,max:100;n:type:ShaderForge.SFN_Vector1,id:4353,x:29452,y:33201,varname:node_4353,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:6507,x:29452,y:33145,varname:node_6507,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:362,x:29452,y:33296,varname:node_362,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:40,x:29141,y:33028,varname:node_40,prsc:2|A-6813-OUT,B-8368-OUT;n:type:ShaderForge.SFN_Vector1,id:6813,x:28975,y:33028,varname:node_6813,prsc:2,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:9846,x:29269,y:33178,ptovrint:False,ptlb:v_jouge,ptin:_v_jouge,varname:_v_jouge,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.75;n:type:ShaderForge.SFN_OneMinus,id:7644,x:31061,y:33257,varname:node_7644,prsc:2|IN-5588-OUT;n:type:ShaderForge.SFN_Panner,id:1642,x:30036,y:32788,varname:node_1642,prsc:2,spu:0.01,spv:-0.05|UVIN-757-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:757,x:29805,y:32634,varname:node_757,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:5204,x:30204,y:32634,varname:_node_5204,prsc:2,ntxv:0,isnm:False|UVIN-7800-UVOUT,TEX-8777-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8777,x:30036,y:32994,ptovrint:False,ptlb:node_8777,ptin:_node_8777,varname:_node_8777,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:8303,x:30374,y:32788,varname:node_8303,prsc:2,blmd:10,clmp:True|SRC-5204-R,DST-1336-R;n:type:ShaderForge.SFN_Panner,id:7800,x:30036,y:32634,varname:node_7800,prsc:2,spu:0.05,spv:0.01|UVIN-757-UVOUT;n:type:ShaderForge.SFN_Vector1,id:9724,x:30878,y:33205,varname:node_9724,prsc:2,v1:5;n:type:ShaderForge.SFN_VertexColor,id:7429,x:31851,y:32976,varname:node_7429,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:9615,x:31409,y:32831,ptovrint:False,ptlb:node_9615,ptin:_node_9615,varname:_node_9615,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:68383f8b42f8efe48ad7cc69ec1e38c4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8535,x:32072,y:33338,varname:node_8535,prsc:2|A-9615-A,B-7644-OUT;proporder:8368-8668-4138-6566-9846-8777-9615;pass:END;sub:END;*/

Shader "Shader Forge/fade" {
    Properties {
        _takasa ("takasa", Float ) = 0
        _emi ("emi", Range(0, 10)) = 7.970545
        _emi_color ("emi_color", Color) = (0.5,0.5,0.5,1)
        _haba ("haba", Range(0, 100)) = 100
        _v_jouge ("v_jouge", Float ) = -0.75
        _node_8777 ("node_8777", 2D) = "white" {}
        _node_9615 ("node_9615", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _takasa;
            uniform float _emi;
            uniform float4 _emi_color;
            uniform float _v_jouge;
            uniform sampler2D _node_8777; uniform float4 _node_8777_ST;
            uniform sampler2D _node_9615; uniform float4 _node_9615_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _node_9615_var = tex2D(_node_9615,TRANSFORM_TEX(i.uv0, _node_9615));
                float4 node_2444 = _Time;
                float2 node_7800 = (i.uv0+node_2444.g*float2(0.05,0.01));
                float4 _node_5204 = tex2D(_node_8777,TRANSFORM_TEX(node_7800, _node_8777));
                float2 node_1642 = (i.uv0+node_2444.g*float2(0.01,-0.05));
                float4 _node_1336 = tex2D(_node_8777,TRANSFORM_TEX(node_1642, _node_8777));
                float node_6507 = (-1.0);
                float node_4353 = (-1.0);
                float node_5588 = saturate((saturate(( _node_1336.r > 0.5 ? (1.0-(1.0-2.0*(_node_1336.r-0.5))*(1.0-_node_5204.r)) : (2.0*_node_1336.r*_node_5204.r) ))+(node_4353 + ( ((i.posWorld.g+((-1.0)*_takasa)+_v_jouge) - node_6507) * (0.0 - node_4353) ) / (0.0 - node_6507))));
                clip((_node_9615_var.a*(1.0 - node_5588)) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_node_9615_var.rgb*i.vertexColor.rgb*_emi_color.rgb*_emi);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _takasa;
            uniform float _v_jouge;
            uniform sampler2D _node_8777; uniform float4 _node_8777_ST;
            uniform sampler2D _node_9615; uniform float4 _node_9615_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _node_9615_var = tex2D(_node_9615,TRANSFORM_TEX(i.uv0, _node_9615));
                float4 node_6323 = _Time;
                float2 node_7800 = (i.uv0+node_6323.g*float2(0.05,0.01));
                float4 _node_5204 = tex2D(_node_8777,TRANSFORM_TEX(node_7800, _node_8777));
                float2 node_1642 = (i.uv0+node_6323.g*float2(0.01,-0.05));
                float4 _node_1336 = tex2D(_node_8777,TRANSFORM_TEX(node_1642, _node_8777));
                float node_6507 = (-1.0);
                float node_4353 = (-1.0);
                float node_5588 = saturate((saturate(( _node_1336.r > 0.5 ? (1.0-(1.0-2.0*(_node_1336.r-0.5))*(1.0-_node_5204.r)) : (2.0*_node_1336.r*_node_5204.r) ))+(node_4353 + ( ((i.posWorld.g+((-1.0)*_takasa)+_v_jouge) - node_6507) * (0.0 - node_4353) ) / (0.0 - node_6507))));
                clip((_node_9615_var.a*(1.0 - node_5588)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _emi;
            uniform float4 _emi_color;
            uniform sampler2D _node_9615; uniform float4 _node_9615_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _node_9615_var = tex2D(_node_9615,TRANSFORM_TEX(i.uv0, _node_9615));
                o.Emission = (_node_9615_var.rgb*i.vertexColor.rgb*_emi_color.rgb*_emi);
                
                float3 diffColor = float3(0,0,0);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0, specColor, specularMonochrome );
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
