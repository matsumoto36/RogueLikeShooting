// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33343,y:32607,varname:node_2865,prsc:2|emission-1289-OUT,clip-35-OUT;n:type:ShaderForge.SFN_TexCoord,id:1127,x:30855,y:32681,varname:node_1127,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:5386,x:30560,y:32550,ptovrint:False,ptlb:node_5386,ptin:_node_5386,varname:_node_5386,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.830219,max:4;n:type:ShaderForge.SFN_Slider,id:494,x:31117,y:32442,ptovrint:False,ptlb:node_5386sss,ptin:_node_5386sss,varname:_node_5386sss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3454632,max:1;n:type:ShaderForge.SFN_Frac,id:6266,x:31335,y:32683,varname:node_6266,prsc:2|IN-1404-OUT;n:type:ShaderForge.SFN_Step,id:60,x:31663,y:32685,varname:node_60,prsc:2|A-6266-OUT,B-494-OUT;n:type:ShaderForge.SFN_Subtract,id:587,x:31506,y:32836,varname:node_587,prsc:2|A-7366-OUT,B-6266-OUT;n:type:ShaderForge.SFN_Vector1,id:7366,x:31276,y:32870,varname:node_7366,prsc:2,v1:1;n:type:ShaderForge.SFN_Step,id:2646,x:31663,y:32836,varname:node_2646,prsc:2|A-587-OUT,B-494-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8833,x:31825,y:32685,varname:node_8833,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-60-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4902,x:31825,y:32836,varname:node_4902,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2646-OUT;n:type:ShaderForge.SFN_Add,id:8986,x:32006,y:32753,varname:node_8986,prsc:2|A-8833-R,B-8833-G,C-4902-R,D-4902-G;n:type:ShaderForge.SFN_Multiply,id:1404,x:31179,y:32683,varname:node_1404,prsc:2|A-1127-UVOUT,B-3813-OUT;n:type:ShaderForge.SFN_Ceil,id:3813,x:30990,y:32581,varname:node_3813,prsc:2|IN-5386-OUT;n:type:ShaderForge.SFN_Step,id:35,x:32204,y:32736,varname:node_35,prsc:2|A-5346-OUT,B-8986-OUT;n:type:ShaderForge.SFN_Vector1,id:5346,x:32006,y:32678,varname:node_5346,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:1289,x:33001,y:32695,varname:node_1289,prsc:2|A-35-OUT,B-1680-RGB,C-4804-OUT;n:type:ShaderForge.SFN_Color,id:1680,x:32793,y:32695,ptovrint:False,ptlb:emi_color,ptin:_emi_color,varname:_emi_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:4804,x:32636,y:32958,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;proporder:5386-494-4804-1680;pass:END;sub:END;*/

Shader "Shader Forge/particleshiled" {
    Properties {
        _node_5386 ("node_5386", Range(0, 4)) = 1.830219
        _node_5386sss ("node_5386sss", Range(0, 1)) = 0.3454632
        _emi ("emi", Range(0, 10)) = 0
        _emi_color ("emi_color", Color) = (0.5,0.5,0.5,1)
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
            uniform float _node_5386;
            uniform float _node_5386sss;
            uniform float4 _emi_color;
            uniform float _emi;
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
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 node_6266 = frac((i.uv0*ceil(_node_5386)));
                float2 node_8833 = step(node_6266,_node_5386sss).rg;
                float2 node_4902 = step((1.0-node_6266),_node_5386sss).rg;
                float node_8986 = (node_8833.r+node_8833.g+node_4902.r+node_4902.g);
                float node_35 = step(0.5,node_8986);
                clip(node_35 - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (node_35*_emi_color.rgb*_emi);
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
            Cull Back
            
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
            uniform float _node_5386;
            uniform float _node_5386sss;
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
            float4 frag(VertexOutput i) : COLOR {
                float2 node_6266 = frac((i.uv0*ceil(_node_5386)));
                float2 node_8833 = step(node_6266,_node_5386sss).rg;
                float2 node_4902 = step((1.0-node_6266),_node_5386sss).rg;
                float node_8986 = (node_8833.r+node_8833.g+node_4902.r+node_4902.g);
                float node_35 = step(0.5,node_8986);
                clip(node_35 - 0.5);
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
            uniform float _node_5386;
            uniform float _node_5386sss;
            uniform float4 _emi_color;
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
            float4 frag(VertexOutput i) : SV_Target {
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float2 node_6266 = frac((i.uv0*ceil(_node_5386)));
                float2 node_8833 = step(node_6266,_node_5386sss).rg;
                float2 node_4902 = step((1.0-node_6266),_node_5386sss).rg;
                float node_8986 = (node_8833.r+node_8833.g+node_4902.r+node_4902.g);
                float node_35 = step(0.5,node_8986);
                o.Emission = (node_35*_emi_color.rgb*_emi);
                
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
