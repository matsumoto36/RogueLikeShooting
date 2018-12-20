// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.07,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32916,y:32722,varname:node_2865,prsc:2|diff-5574-OUT,spec-358-OUT,gloss-1813-OUT,normal-5964-RGB,emission-6541-OUT,clip-5233-OUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32074,y:32736,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:_Metallic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1243,x:29829,y:33111,varname:node_1243,prsc:2|IN-2549-OUT,IMIN-6507-OUT,IMAX-362-OUT,OMIN-4353-OUT,OMAX-9973-OUT;n:type:ShaderForge.SFN_Lerp,id:5574,x:31867,y:33006,varname:node_5574,prsc:2|A-7017-RGB,B-7386-RGB,T-6205-OUT;n:type:ShaderForge.SFN_Color,id:7386,x:31569,y:33212,ptovrint:False,ptlb:node_7386,ptin:_node_7386,varname:_node_7386,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:9973,x:29452,y:33340,varname:node_9973,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:3464,x:32032,y:33636,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:9.745958,max:10;n:type:ShaderForge.SFN_ValueProperty,id:8368,x:28975,y:33107,ptovrint:False,ptlb:takasa,ptin:_takasa,varname:_takasa,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_FragmentPosition,id:1520,x:29269,y:33028,varname:node_1520,prsc:2;n:type:ShaderForge.SFN_Add,id:2549,x:29452,y:33028,varname:node_2549,prsc:2|A-1520-Y,B-40-OUT,C-9846-OUT;n:type:ShaderForge.SFN_Tex2d,id:1336,x:30204,y:32788,varname:_node_1336,prsc:2,tex:bd559d3c908878449adb0d0a63e24a2f,ntxv:0,isnm:False|UVIN-1642-UVOUT,TEX-8777-TEX;n:type:ShaderForge.SFN_Add,id:6823,x:30374,y:33019,varname:node_6823,prsc:2|A-8303-OUT,B-1243-OUT;n:type:ShaderForge.SFN_Clamp01,id:5588,x:30550,y:33019,varname:node_5588,prsc:2|IN-6823-OUT;n:type:ShaderForge.SFN_Multiply,id:2021,x:31210,y:33051,varname:node_2021,prsc:2|A-1926-OUT,B-9724-OUT;n:type:ShaderForge.SFN_Clamp01,id:6205,x:31409,y:33034,varname:node_6205,prsc:2|IN-2021-OUT;n:type:ShaderForge.SFN_Relay,id:5233,x:31409,y:33256,varname:node_5233,prsc:2|IN-7644-OUT;n:type:ShaderForge.SFN_Tex2d,id:7017,x:31389,y:32801,ptovrint:False,ptlb:node_7017,ptin:_node_7017,varname:_node_7017,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6541,x:32262,y:33274,varname:node_6541,prsc:2|A-6205-OUT,B-4138-RGB,C-8668-OUT;n:type:ShaderForge.SFN_Slider,id:8668,x:31872,y:33486,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8.837745,max:10;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1926,x:30878,y:33078,varname:node_1926,prsc:2|IN-5588-OUT,IMIN-9460-OUT,IMAX-2148-OUT,OMIN-8547-OUT,OMAX-8037-OUT;n:type:ShaderForge.SFN_Vector1,id:8037,x:30550,y:33277,varname:node_8037,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:8547,x:30550,y:33190,varname:node_8547,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:4138,x:31977,y:33314,ptovrint:False,ptlb:emi_color,ptin:_emi_color,varname:_emi_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:2148,x:30550,y:33451,varname:node_2148,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:9460,x:30550,y:33334,varname:node_9460,prsc:2|A-445-OUT,B-2148-OUT;n:type:ShaderForge.SFN_Multiply,id:445,x:30375,y:33334,varname:node_445,prsc:2|A-5282-OUT,B-6566-OUT;n:type:ShaderForge.SFN_Vector1,id:5282,x:30204,y:33305,varname:node_5282,prsc:2,v1:-0.01;n:type:ShaderForge.SFN_Slider,id:6566,x:30060,y:33385,ptovrint:False,ptlb:haba,ptin:_haba,varname:_haba,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Vector1,id:4353,x:29452,y:33201,varname:node_4353,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:6507,x:29452,y:33145,varname:node_6507,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:362,x:29452,y:33296,varname:node_362,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:40,x:29141,y:33028,varname:node_40,prsc:2|A-6813-OUT,B-8368-OUT;n:type:ShaderForge.SFN_Vector1,id:6813,x:28975,y:33028,varname:node_6813,prsc:2,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:9846,x:29269,y:33178,ptovrint:False,ptlb:v_jouge,ptin:_v_jouge,varname:_v_jouge,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.75;n:type:ShaderForge.SFN_OneMinus,id:7644,x:31061,y:33257,varname:node_7644,prsc:2|IN-5588-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8458,x:31195,y:33744,ptovrint:False,ptlb:node_6191_copy_copy,ptin:_node_6191_copy_copy,varname:_node_6191_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Panner,id:1642,x:30036,y:32788,varname:node_1642,prsc:2,spu:0.01,spv:-0.05|UVIN-757-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:757,x:29805,y:32634,varname:node_757,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:5204,x:30204,y:32634,varname:_node_5204,prsc:2,tex:bd559d3c908878449adb0d0a63e24a2f,ntxv:0,isnm:False|UVIN-7800-UVOUT,TEX-8777-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8777,x:30036,y:32994,ptovrint:False,ptlb:node_8777,ptin:_node_8777,varname:_node_8777,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bd559d3c908878449adb0d0a63e24a2f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:8303,x:30374,y:32788,varname:node_8303,prsc:2,blmd:10,clmp:True|SRC-5204-R,DST-1336-R;n:type:ShaderForge.SFN_Panner,id:7800,x:30036,y:32634,varname:node_7800,prsc:2,spu:0.05,spv:0.01|UVIN-757-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:6459,x:31259,y:33808,ptovrint:False,ptlb:node_6191_copy_copy_copy,ptin:_node_6191_copy_copy_copy,varname:_node_6191_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Vector1,id:9724,x:30878,y:33205,varname:node_9724,prsc:2,v1:5;proporder:5964-358-1813-7386-3464-8368-7017-8668-4138-6566-9846-8777;pass:END;sub:END;*/

Shader "Shader Forge/fade" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _node_7386 ("node_7386", Color) = (1,1,1,1)
        _emi ("emi", Range(0, 10)) = 9.745958
        _takasa ("takasa", Float ) = 0
        _node_7017 ("node_7017", 2D) = "white" {}
        _emi ("emi", Range(0, 10)) = 8.837745
        _emi_color ("emi_color", Color) = (0.5,0.5,0.5,1)
        _haba ("haba", Range(0, 10)) = 0
        _v_jouge ("v_jouge", Float ) = -0.75
        _node_8777 ("node_8777", 2D) = "white" {}
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _node_7386;
            uniform float _takasa;
            uniform sampler2D _node_7017; uniform float4 _node_7017_ST;
            uniform float _emi;
            uniform float4 _emi_color;
            uniform float _haba;
            uniform float _v_jouge;
            uniform sampler2D _node_8777; uniform float4 _node_8777_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
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
                float4 node_4596 = _Time;
                float2 node_7800 = (i.uv0+node_4596.g*float2(0.05,0.01));
                float4 _node_5204 = tex2D(_node_8777,TRANSFORM_TEX(node_7800, _node_8777));
                float2 node_1642 = (i.uv0+node_4596.g*float2(0.01,-0.05));
                float4 _node_1336 = tex2D(_node_8777,TRANSFORM_TEX(node_1642, _node_8777));
                float node_6507 = (-1.0);
                float node_4353 = (-1.0);
                float node_5588 = saturate((saturate(( _node_1336.r > 0.5 ? (1.0-(1.0-2.0*(_node_1336.r-0.5))*(1.0-_node_5204.r)) : (2.0*_node_1336.r*_node_5204.r) ))+(node_4353 + ( ((i.posWorld.g+((-1.0)*_takasa)+_v_jouge) - node_6507) * (0.0 - node_4353) ) / (0.0 - node_6507))));
                clip((1.0 - node_5588) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation,i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _node_7017_var = tex2D(_node_7017,TRANSFORM_TEX(i.uv0, _node_7017));
                float node_2148 = 0.5;
                float node_9460 = (((-0.01)*_haba)+node_2148);
                float node_8547 = 0.0;
                float node_6205 = saturate(((node_8547 + ( (node_5588 - node_9460) * (1.0 - node_8547) ) / (node_2148 - node_9460))*5.0));
                float3 diffuseColor = lerp(_node_7017_var.rgb,_node_7386.rgb,node_6205); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (node_6205*_emi_color.rgb*_emi);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _node_7386;
            uniform float _takasa;
            uniform sampler2D _node_7017; uniform float4 _node_7017_ST;
            uniform float _emi;
            uniform float4 _emi_color;
            uniform float _haba;
            uniform float _v_jouge;
            uniform sampler2D _node_8777; uniform float4 _node_8777_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
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
                float4 node_6618 = _Time;
                float2 node_7800 = (i.uv0+node_6618.g*float2(0.05,0.01));
                float4 _node_5204 = tex2D(_node_8777,TRANSFORM_TEX(node_7800, _node_8777));
                float2 node_1642 = (i.uv0+node_6618.g*float2(0.01,-0.05));
                float4 _node_1336 = tex2D(_node_8777,TRANSFORM_TEX(node_1642, _node_8777));
                float node_6507 = (-1.0);
                float node_4353 = (-1.0);
                float node_5588 = saturate((saturate(( _node_1336.r > 0.5 ? (1.0-(1.0-2.0*(_node_1336.r-0.5))*(1.0-_node_5204.r)) : (2.0*_node_1336.r*_node_5204.r) ))+(node_4353 + ( ((i.posWorld.g+((-1.0)*_takasa)+_v_jouge) - node_6507) * (0.0 - node_4353) ) / (0.0 - node_6507))));
                clip((1.0 - node_5588) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation,i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _node_7017_var = tex2D(_node_7017,TRANSFORM_TEX(i.uv0, _node_7017));
                float node_2148 = 0.5;
                float node_9460 = (((-0.01)*_haba)+node_2148);
                float node_8547 = 0.0;
                float node_6205 = saturate(((node_8547 + ( (node_5588 - node_9460) * (1.0 - node_8547) ) / (node_2148 - node_9460))*5.0));
                float3 diffuseColor = lerp(_node_7017_var.rgb,_node_7386.rgb,node_6205); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _takasa;
            uniform float _v_jouge;
            uniform sampler2D _node_8777; uniform float4 _node_8777_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9827 = _Time;
                float2 node_7800 = (i.uv0+node_9827.g*float2(0.05,0.01));
                float4 _node_5204 = tex2D(_node_8777,TRANSFORM_TEX(node_7800, _node_8777));
                float2 node_1642 = (i.uv0+node_9827.g*float2(0.01,-0.05));
                float4 _node_1336 = tex2D(_node_8777,TRANSFORM_TEX(node_1642, _node_8777));
                float node_6507 = (-1.0);
                float node_4353 = (-1.0);
                float node_5588 = saturate((saturate(( _node_1336.r > 0.5 ? (1.0-(1.0-2.0*(_node_1336.r-0.5))*(1.0-_node_5204.r)) : (2.0*_node_1336.r*_node_5204.r) ))+(node_4353 + ( ((i.posWorld.g+((-1.0)*_takasa)+_v_jouge) - node_6507) * (0.0 - node_4353) ) / (0.0 - node_6507))));
                clip((1.0 - node_5588) - 0.5);
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _node_7386;
            uniform float _takasa;
            uniform sampler2D _node_7017; uniform float4 _node_7017_ST;
            uniform float _emi;
            uniform float4 _emi_color;
            uniform float _haba;
            uniform float _v_jouge;
            uniform sampler2D _node_8777; uniform float4 _node_8777_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_1685 = _Time;
                float2 node_7800 = (i.uv0+node_1685.g*float2(0.05,0.01));
                float4 _node_5204 = tex2D(_node_8777,TRANSFORM_TEX(node_7800, _node_8777));
                float2 node_1642 = (i.uv0+node_1685.g*float2(0.01,-0.05));
                float4 _node_1336 = tex2D(_node_8777,TRANSFORM_TEX(node_1642, _node_8777));
                float node_6507 = (-1.0);
                float node_4353 = (-1.0);
                float node_5588 = saturate((saturate(( _node_1336.r > 0.5 ? (1.0-(1.0-2.0*(_node_1336.r-0.5))*(1.0-_node_5204.r)) : (2.0*_node_1336.r*_node_5204.r) ))+(node_4353 + ( ((i.posWorld.g+((-1.0)*_takasa)+_v_jouge) - node_6507) * (0.0 - node_4353) ) / (0.0 - node_6507))));
                float node_2148 = 0.5;
                float node_9460 = (((-0.01)*_haba)+node_2148);
                float node_8547 = 0.0;
                float node_6205 = saturate(((node_8547 + ( (node_5588 - node_9460) * (1.0 - node_8547) ) / (node_2148 - node_9460))*5.0));
                o.Emission = (node_6205*_emi_color.rgb*_emi);
                
                float4 _node_7017_var = tex2D(_node_7017,TRANSFORM_TEX(i.uv0, _node_7017));
                float3 diffColor = lerp(_node_7017_var.rgb,_node_7386.rgb,node_6205);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
