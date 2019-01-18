// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-8558-OUT,clip-7378-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:31912,y:32714,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31719,y:32807,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31719,y:32622,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e181ef14ff70fbc469b3fc96fd7d3d62,ntxv:0,isnm:False|UVIN-1595-UVOUT;n:type:ShaderForge.SFN_Lerp,id:944,x:32291,y:32564,varname:node_944,prsc:2|A-6343-OUT,B-6343-OUT,T-8903-VFACE;n:type:ShaderForge.SFN_FaceSign,id:8903,x:31912,y:32884,varname:node_8903,prsc:2,fstp:0;n:type:ShaderForge.SFN_Multiply,id:8558,x:32491,y:32564,varname:node_8558,prsc:2|A-6298-OUT,B-2022-OUT;n:type:ShaderForge.SFN_Slider,id:2022,x:32134,y:32705,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.194034,max:10;n:type:ShaderForge.SFN_Slider,id:2563,x:31875,y:32255,ptovrint:False,ptlb:haba,ptin:_haba,varname:_haba,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Blend,id:6298,x:32676,y:32211,varname:node_6298,prsc:2,blmd:10,clmp:True|SRC-1985-OUT,DST-944-OUT;n:type:ShaderForge.SFN_Panner,id:1595,x:31495,y:32525,varname:node_1595,prsc:2,spu:0,spv:-0.3|UVIN-1050-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1050,x:31261,y:32509,varname:node_1050,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_OneMinus,id:9973,x:32032,y:32075,varname:node_9973,prsc:2|IN-32-OUT;n:type:ShaderForge.SFN_TexCoord,id:1723,x:31708,y:32075,varname:node_1723,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:32,x:31864,y:32075,varname:node_32,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-1723-UVOUT;n:type:ShaderForge.SFN_Power,id:1985,x:32211,y:32075,varname:node_1985,prsc:2|VAL-9973-OUT,EXP-2563-OUT;n:type:ShaderForge.SFN_Step,id:7378,x:32445,y:31951,varname:node_7378,prsc:2|A-736-OUT,B-9944-OUT;n:type:ShaderForge.SFN_Slider,id:736,x:31749,y:31915,ptovrint:False,ptlb:alpha_ width,ptin:_alpha_width,varname:_alpha_width,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4227358,max:1;n:type:ShaderForge.SFN_Multiply,id:9944,x:32289,y:32259,varname:node_9944,prsc:2|A-9973-OUT,B-944-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1512,x:31323,y:33872,ptovrint:False,ptlb:node_6191_copy_copy_copy,ptin:_node_6191_copy_copy_copy,varname:_node_6191_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:6665-7736-2022-2563-736;pass:END;sub:END;*/

Shader "Shader Forge/black" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _emi ("emi", Range(0, 10)) = 4.194034
        _haba ("haba", Range(0, 10)) = 0
        _alpha_width ("alpha_ width", Range(0, 1)) = 0.4227358
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
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _emi;
            uniform float _haba;
            uniform float _alpha_width;
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
                float node_9973 = (1.0 - i.uv0.g);
                float4 node_6726 = _Time;
                float2 node_1595 = (i.uv0+node_6726.g*float2(0,-0.3));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1595, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float3 node_944 = lerp(node_6343,node_6343,isFrontFace);
                clip(step(_alpha_width,(node_9973*node_944)) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (saturate(( node_944 > 0.5 ? (1.0-(1.0-2.0*(node_944-0.5))*(1.0-pow(node_9973,_haba))) : (2.0*node_944*pow(node_9973,_haba)) ))*_emi);
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
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _alpha_width;
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
                float node_9973 = (1.0 - i.uv0.g);
                float4 node_8989 = _Time;
                float2 node_1595 = (i.uv0+node_8989.g*float2(0,-0.3));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1595, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float3 node_944 = lerp(node_6343,node_6343,isFrontFace);
                clip(step(_alpha_width,(node_9973*node_944)) - 0.5);
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
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _emi;
            uniform float _haba;
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
                
                float node_9973 = (1.0 - i.uv0.g);
                float4 node_9976 = _Time;
                float2 node_1595 = (i.uv0+node_9976.g*float2(0,-0.3));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1595, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float3 node_944 = lerp(node_6343,node_6343,isFrontFace);
                o.Emission = (saturate(( node_944 > 0.5 ? (1.0-(1.0-2.0*(node_944-0.5))*(1.0-pow(node_9973,_haba))) : (2.0*node_944*pow(node_9973,_haba)) ))*_emi);
                
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
