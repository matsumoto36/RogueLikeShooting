// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-9894-OUT;n:type:ShaderForge.SFN_TexCoord,id:6466,x:30919,y:32745,varname:node_6466,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:147,x:31181,y:32506,ptovrint:False,ptlb:haba,ptin:_haba,varname:_haba,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.626107,max:1;n:type:ShaderForge.SFN_Frac,id:4961,x:31399,y:32747,varname:node_4961,prsc:2|IN-9919-OUT;n:type:ShaderForge.SFN_Step,id:4440,x:31727,y:32749,varname:node_4440,prsc:2|A-4961-OUT,B-147-OUT;n:type:ShaderForge.SFN_Subtract,id:7123,x:31570,y:32900,varname:node_7123,prsc:2|A-5355-OUT,B-4961-OUT;n:type:ShaderForge.SFN_Vector1,id:5355,x:31340,y:32934,varname:node_5355,prsc:2,v1:1;n:type:ShaderForge.SFN_Step,id:4476,x:31727,y:32900,varname:node_4476,prsc:2|A-7123-OUT,B-147-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2206,x:31889,y:32749,varname:node_2206,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4440-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8482,x:31889,y:32900,varname:node_8482,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4476-OUT;n:type:ShaderForge.SFN_Multiply,id:9919,x:31243,y:32747,varname:node_9919,prsc:2|A-6466-UVOUT,B-2655-OUT;n:type:ShaderForge.SFN_Ceil,id:2655,x:31054,y:32645,varname:node_2655,prsc:2|IN-9938-OUT;n:type:ShaderForge.SFN_Add,id:2984,x:32110,y:32749,varname:node_2984,prsc:2|A-2206-R,B-8482-R,C-8482-G,D-2206-G;n:type:ShaderForge.SFN_Multiply,id:9894,x:32468,y:32840,varname:node_9894,prsc:2|A-2808-OUT,B-9935-RGB,C-1475-OUT;n:type:ShaderForge.SFN_Color,id:9935,x:32065,y:33016,ptovrint:False,ptlb:emi_color,ptin:_emi_color,varname:_emi_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:1475,x:31957,y:33240,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Vector1,id:9938,x:30800,y:32617,varname:node_9938,prsc:2,v1:1;n:type:ShaderForge.SFN_Step,id:2808,x:32274,y:32768,varname:node_2808,prsc:2|A-906-OUT,B-2984-OUT;n:type:ShaderForge.SFN_Vector1,id:906,x:32090,y:32658,varname:node_906,prsc:2,v1:0.5;proporder:147-9935-1475;pass:END;sub:END;*/

Shader "Shader Forge/sita" {
    Properties {
        _haba ("haba", Range(0, 1)) = 0.626107
        _emi_color ("emi_color", Color) = (0.5,0.5,0.5,1)
        _emi ("emi", Range(0, 10)) = 0
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
            uniform float _haba;
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
////// Lighting:
////// Emissive:
                float2 node_4961 = frac((i.uv0*ceil(1.0)));
                float2 node_2206 = step(node_4961,_haba).rg;
                float2 node_8482 = step((1.0-node_4961),_haba).rg;
                float3 emissive = (step(0.5,(node_2206.r+node_8482.r+node_8482.g+node_2206.g))*_emi_color.rgb*_emi);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            uniform float _haba;
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
                
                float2 node_4961 = frac((i.uv0*ceil(1.0)));
                float2 node_2206 = step(node_4961,_haba).rg;
                float2 node_8482 = step((1.0-node_4961),_haba).rg;
                o.Emission = (step(0.5,(node_2206.r+node_8482.r+node_8482.g+node_2206.g))*_emi_color.rgb*_emi);
                
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
