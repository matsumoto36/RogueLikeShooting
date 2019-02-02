// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32520,y:32537,varname:node_2865,prsc:2|emission-5666-OUT,clip-1118-OUT;n:type:ShaderForge.SFN_Multiply,id:276,x:31273,y:32590,varname:node_276,prsc:2|A-5486-OUT,B-9959-OUT;n:type:ShaderForge.SFN_Slider,id:5486,x:30944,y:32437,ptovrint:False,ptlb:node_5486,ptin:_node_5486,varname:_node_5486,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.014939,max:20;n:type:ShaderForge.SFN_Frac,id:5063,x:31430,y:32590,varname:node_5063,prsc:2|IN-276-OUT;n:type:ShaderForge.SFN_Slider,id:52,x:31273,y:32443,ptovrint:False,ptlb:m5,ptin:_m5,varname:_m5,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.824225,max:2;n:type:ShaderForge.SFN_Multiply,id:966,x:31589,y:32590,varname:node_966,prsc:2|A-5063-OUT,B-52-OUT,C-3414-OUT;n:type:ShaderForge.SFN_TexCoord,id:6569,x:30518,y:32519,varname:node_6569,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Lerp,id:8577,x:31927,y:32422,varname:node_8577,prsc:2|A-9013-OUT,B-9013-OUT,T-5665-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5665,x:31751,y:32590,varname:node_5665,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-966-OUT;n:type:ShaderForge.SFN_Lerp,id:6388,x:32099,y:32422,varname:node_6388,prsc:2|A-8577-OUT,B-8577-OUT,T-8651-VFACE;n:type:ShaderForge.SFN_FaceSign,id:8651,x:31927,y:32590,varname:node_8651,prsc:2,fstp:0;n:type:ShaderForge.SFN_Time,id:625,x:30447,y:32682,varname:node_625,prsc:2;n:type:ShaderForge.SFN_Add,id:9959,x:31069,y:32579,varname:node_9959,prsc:2|A-6569-UVOUT,B-3337-OUT;n:type:ShaderForge.SFN_Append,id:3337,x:30916,y:32695,varname:node_3337,prsc:2|A-100-OUT,B-5710-OUT;n:type:ShaderForge.SFN_Slider,id:9504,x:30290,y:32920,ptovrint:False,ptlb:speed,ptin:_speed,varname:_speed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1634855,max:1;n:type:ShaderForge.SFN_Multiply,id:100,x:30742,y:32695,varname:node_100,prsc:2|A-625-T,B-2954-OUT;n:type:ShaderForge.SFN_Multiply,id:5710,x:30742,y:32833,varname:node_5710,prsc:2|A-625-T,B-9504-OUT;n:type:ShaderForge.SFN_Slider,id:3414,x:31273,y:32731,ptovrint:False,ptlb:node_3414,ptin:_node_3414,varname:_node_3414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5042276,max:1;n:type:ShaderForge.SFN_Slider,id:8999,x:31541,y:33129,ptovrint:False,ptlb:node_8999,ptin:_node_8999,varname:_node_8999,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.991138,max:10;n:type:ShaderForge.SFN_ComponentMask,id:1163,x:31102,y:32885,varname:node_1163,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-6569-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4402,x:31917,y:32901,varname:node_4402,prsc:2|A-5665-OUT,B-7908-OUT,C-8999-OUT;n:type:ShaderForge.SFN_Multiply,id:5666,x:32310,y:32615,varname:node_5666,prsc:2|A-6388-OUT,B-5569-RGB,C-7287-OUT;n:type:ShaderForge.SFN_Color,id:5569,x:32099,y:32590,ptovrint:False,ptlb:node_5569,ptin:_node_5569,varname:_node_5569,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:7287,x:31942,y:32789,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3256304,max:10;n:type:ShaderForge.SFN_Step,id:1118,x:32099,y:32901,varname:node_1118,prsc:2|A-4006-OUT,B-4402-OUT;n:type:ShaderForge.SFN_Vector1,id:4006,x:32112,y:33092,varname:node_4006,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Vector1,id:2954,x:30447,y:32846,varname:node_2954,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:5835,x:31288,y:32913,varname:node_5835,prsc:2|IN-1163-OUT,IMIN-3281-OUT,IMAX-8400-OUT,OMIN-9597-OUT,OMAX-3478-OUT;n:type:ShaderForge.SFN_Vector1,id:3281,x:30967,y:33074,varname:node_3281,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8400,x:31102,y:33074,varname:node_8400,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:9597,x:30671,y:33158,ptovrint:False,ptlb:omin,ptin:_omin,varname:_omin,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Slider,id:3478,x:30671,y:33271,ptovrint:False,ptlb:omax,ptin:_omax,varname:_omax,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.155578,max:10;n:type:ShaderForge.SFN_Multiply,id:7908,x:31659,y:32941,varname:node_7908,prsc:2|A-5835-OUT,B-3988-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3988,x:31288,y:33104,varname:node_3988,prsc:2|IN-1163-OUT,IMIN-3281-OUT,IMAX-8400-OUT,OMIN-3478-OUT,OMAX-9597-OUT;n:type:ShaderForge.SFN_Vector4,id:9013,x:31563,y:32297,varname:node_9013,prsc:2,v1:1,v2:1,v3:1,v4:0;proporder:5486-52-9504-3414-8999-5569-7287-9597-3478;pass:END;sub:END;*/

Shader "Shader Forge/shield" {
    Properties {
        _node_5486 ("node_5486", Range(0, 20)) = 3.014939
        _m5 ("m5", Range(0, 2)) = 1.824225
        _speed ("speed", Range(0, 1)) = 0.1634855
        _node_3414 ("node_3414", Range(0, 1)) = 0.5042276
        _node_8999 ("node_8999", Range(0, 10)) = 1.991138
        _node_5569 ("node_5569", Color) = (0.5,0.5,0.5,1)
        _emi ("emi", Range(0, 10)) = 0.3256304
        _omin ("omin", Range(0, 10)) = 0
        _omax ("omax", Range(0, 10)) = 1.155578
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
            uniform float _node_5486;
            uniform float _m5;
            uniform float _speed;
            uniform float _node_3414;
            uniform float _node_8999;
            uniform float4 _node_5569;
            uniform float _emi;
            uniform float _omin;
            uniform float _omax;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float4 node_625 = _Time;
                float node_5665 = (frac((_node_5486*(i.uv0+float2((node_625.g*0.0),(node_625.g*_speed)))))*_m5*_node_3414).g;
                float node_1163 = i.uv0.g;
                float node_3281 = 0.0;
                float node_8400 = 1.0;
                clip(step(0.6,(node_5665*((_omin + ( (node_1163 - node_3281) * (_omax - _omin) ) / (node_8400 - node_3281))*(_omax + ( (node_1163 - node_3281) * (_omin - _omax) ) / (node_8400 - node_3281)))*_node_8999)) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_9013 = float4(1,1,1,0);
                float4 node_8577 = lerp(node_9013,node_9013,node_5665);
                float3 emissive = (lerp(node_8577,node_8577,isFrontFace)*_node_5569.rgb*_emi).rgb;
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
            uniform float _node_5486;
            uniform float _m5;
            uniform float _speed;
            uniform float _node_3414;
            uniform float _node_8999;
            uniform float _omin;
            uniform float _omax;
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
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_625 = _Time;
                float node_5665 = (frac((_node_5486*(i.uv0+float2((node_625.g*0.0),(node_625.g*_speed)))))*_m5*_node_3414).g;
                float node_1163 = i.uv0.g;
                float node_3281 = 0.0;
                float node_8400 = 1.0;
                clip(step(0.6,(node_5665*((_omin + ( (node_1163 - node_3281) * (_omax - _omin) ) / (node_8400 - node_3281))*(_omax + ( (node_1163 - node_3281) * (_omin - _omax) ) / (node_8400 - node_3281)))*_node_8999)) - 0.5);
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
            uniform float _node_5486;
            uniform float _m5;
            uniform float _speed;
            uniform float _node_3414;
            uniform float4 _node_5569;
            uniform float _emi;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_9013 = float4(1,1,1,0);
                float4 node_625 = _Time;
                float node_5665 = (frac((_node_5486*(i.uv0+float2((node_625.g*0.0),(node_625.g*_speed)))))*_m5*_node_3414).g;
                float4 node_8577 = lerp(node_9013,node_9013,node_5665);
                o.Emission = (lerp(node_8577,node_8577,isFrontFace)*_node_5569.rgb*_emi).rgb;
                
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
