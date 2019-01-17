// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|gloss-1813-OUT,normal-5964-RGB,emission-8558-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31719,y:32622,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e181ef14ff70fbc469b3fc96fd7d3d62,ntxv:0,isnm:False|UVIN-1595-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32590,y:32988,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Lerp,id:944,x:32291,y:32564,varname:node_944,prsc:2|A-7736-RGB,B-7736-RGB,T-8903-VFACE;n:type:ShaderForge.SFN_FaceSign,id:8903,x:31912,y:32884,varname:node_8903,prsc:2,fstp:0;n:type:ShaderForge.SFN_Multiply,id:8558,x:32491,y:32564,varname:node_8558,prsc:2|A-6298-OUT,B-2022-OUT;n:type:ShaderForge.SFN_Slider,id:2022,x:32134,y:32705,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5913218,max:10;n:type:ShaderForge.SFN_Slider,id:2563,x:31875,y:32257,ptovrint:False,ptlb:node_2563,ptin:_node_2563,varname:_node_2563,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6061992,max:10;n:type:ShaderForge.SFN_Blend,id:6298,x:32676,y:32211,varname:node_6298,prsc:2,blmd:10,clmp:True|SRC-1985-OUT,DST-5485-OUT;n:type:ShaderForge.SFN_Panner,id:1595,x:31495,y:32525,varname:node_1595,prsc:2,spu:0,spv:-0.3|UVIN-1050-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1050,x:31261,y:32509,varname:node_1050,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_OneMinus,id:9973,x:32032,y:32075,varname:node_9973,prsc:2|IN-32-OUT;n:type:ShaderForge.SFN_TexCoord,id:1723,x:31708,y:32075,varname:node_1723,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:32,x:31864,y:32075,varname:node_32,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-1723-UVOUT;n:type:ShaderForge.SFN_Power,id:1985,x:32211,y:32075,varname:node_1985,prsc:2|VAL-9973-OUT,EXP-2563-OUT;n:type:ShaderForge.SFN_Lerp,id:5485,x:32354,y:32387,varname:node_5485,prsc:2|A-6832-RGB,B-981-RGB,T-944-OUT;n:type:ShaderForge.SFN_Color,id:981,x:32009,y:32489,ptovrint:False,ptlb:out,ptin:_out,varname:_out,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:6832,x:31883,y:32455,ptovrint:False,ptlb:in,ptin:_in,varname:_in,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:5964-7736-1813-2022-2563-981-6832;pass:END;sub:END;*/

Shader "Shader Forge/black" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _MainTex ("Base Color", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _emi ("emi", Range(0, 10)) = 0.5913218
        _node_2563 ("node_2563", Range(0, 10)) = 0.6061992
        _out ("out", Color) = (0.5,0.5,0.5,1)
        _in ("in", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Gloss;
            uniform float _emi;
            uniform float _node_2563;
            uniform float4 _out;
            uniform float4 _in;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 node_4897 = _Time;
                float2 node_1595 = (i.uv0+node_4897.g*float2(0,-0.3));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1595, _MainTex));
                float3 emissive = (saturate(( lerp(_in.rgb,_out.rgb,lerp(_MainTex_var.rgb,_MainTex_var.rgb,isFrontFace)) > 0.5 ? (1.0-(1.0-2.0*(lerp(_in.rgb,_out.rgb,lerp(_MainTex_var.rgb,_MainTex_var.rgb,isFrontFace))-0.5))*(1.0-pow((1.0 - i.uv0.g),_node_2563))) : (2.0*lerp(_in.rgb,_out.rgb,lerp(_MainTex_var.rgb,_MainTex_var.rgb,isFrontFace))*pow((1.0 - i.uv0.g),_node_2563)) ))*_emi);
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
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Gloss;
            uniform float _emi;
            uniform float _node_2563;
            uniform float4 _out;
            uniform float4 _in;
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
                
                float4 node_5909 = _Time;
                float2 node_1595 = (i.uv0+node_5909.g*float2(0,-0.3));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1595, _MainTex));
                o.Emission = (saturate(( lerp(_in.rgb,_out.rgb,lerp(_MainTex_var.rgb,_MainTex_var.rgb,isFrontFace)) > 0.5 ? (1.0-(1.0-2.0*(lerp(_in.rgb,_out.rgb,lerp(_MainTex_var.rgb,_MainTex_var.rgb,isFrontFace))-0.5))*(1.0-pow((1.0 - i.uv0.g),_node_2563))) : (2.0*lerp(_in.rgb,_out.rgb,lerp(_MainTex_var.rgb,_MainTex_var.rgb,isFrontFace))*pow((1.0 - i.uv0.g),_node_2563)) ))*_emi);
                
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
