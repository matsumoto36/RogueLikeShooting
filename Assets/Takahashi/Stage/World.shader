// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32839,y:33445,varname:node_2865,prsc:2|diff-6933-OUT,spec-3427-OUT,gloss-3427-OUT,emission-7438-OUT,clip-5308-OUT;n:type:ShaderForge.SFN_Multiply,id:5820,x:32007,y:33705,varname:node_5820,prsc:2|A-3308-OUT,B-1352-RGB,C-8508-OUT;n:type:ShaderForge.SFN_Color,id:1352,x:31826,y:33705,ptovrint:False,ptlb:emi_color,ptin:_emi_color,varname:_emi_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:8508,x:31274,y:33818,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1238048,max:100;n:type:ShaderForge.SFN_Color,id:8466,x:31832,y:33104,ptovrint:False,ptlb:base color,ptin:_basecolor,varname:_basecolor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:520,x:32002,y:33104,varname:node_520,prsc:2|A-1404-OUT,B-8466-RGB;n:type:ShaderForge.SFN_OneMinus,id:1404,x:31714,y:33104,varname:node_1404,prsc:2|IN-3308-OUT;n:type:ShaderForge.SFN_Step,id:3308,x:31431,y:33583,varname:node_3308,prsc:2|A-7731-OUT,B-1686-OUT;n:type:ShaderForge.SFN_Vector1,id:3427,x:33131,y:33522,varname:node_3427,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:1691,x:32002,y:33280,varname:node_1691,prsc:2|A-4582-OUT,B-3308-OUT;n:type:ShaderForge.SFN_Add,id:9305,x:32193,y:33280,varname:node_9305,prsc:2|A-520-OUT,B-1691-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5308,x:32128,y:33859,ptovrint:False,ptlb:node_5308,ptin:_node_5308,varname:_node_5308,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-3308-OUT,B-248-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:3477,x:30882,y:32232,varname:node_3477,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:8299,x:30882,y:32352,varname:node_8299,prsc:2;n:type:ShaderForge.SFN_Subtract,id:7414,x:31105,y:32232,varname:node_7414,prsc:2|A-3477-Y,B-8299-Y;n:type:ShaderForge.SFN_Divide,id:4756,x:31271,y:32232,varname:node_4756,prsc:2|A-7414-OUT,B-2535-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9782,x:31051,y:32104,ptovrint:False,ptlb:height,ptin:_height,varname:_height,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1213,x:31445,y:32232,varname:node_1213,prsc:2|IN-4756-OUT,IMIN-4182-OUT,IMAX-7118-OUT,OMIN-4222-OUT,OMAX-8272-OUT;n:type:ShaderForge.SFN_Vector1,id:4182,x:31105,y:32352,varname:node_4182,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:7118,x:31271,y:32363,varname:node_7118,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4222,x:31105,y:32414,varname:node_4222,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:8272,x:31271,y:32432,ptovrint:False,ptlb:haba,ptin:_haba,varname:_haba,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Clamp01,id:6596,x:31605,y:32232,varname:node_6596,prsc:2|IN-1213-OUT;n:type:ShaderForge.SFN_Multiply,id:6933,x:32420,y:33280,varname:node_6933,prsc:2|A-9305-OUT,B-869-OUT;n:type:ShaderForge.SFN_Multiply,id:718,x:32193,y:33500,varname:node_718,prsc:2|A-6596-OUT,B-5820-OUT;n:type:ShaderForge.SFN_Lerp,id:869,x:31786,y:32232,varname:node_869,prsc:2|A-3587-OUT,B-8443-OUT,T-6596-OUT;n:type:ShaderForge.SFN_Vector4,id:8443,x:31605,y:31970,varname:node_8443,prsc:2,v1:1,v2:1,v3:1,v4:0;n:type:ShaderForge.SFN_FragmentPosition,id:4628,x:28403,y:33246,varname:node_4628,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8836,x:28963,y:33103,varname:node_8836,prsc:2|A-5060-OUT,B-1588-OUT;n:type:ShaderForge.SFN_Append,id:5511,x:28714,y:33249,varname:node_5511,prsc:2|A-4628-Z,B-4628-X;n:type:ShaderForge.SFN_Append,id:1507,x:28714,y:33408,varname:node_1507,prsc:2|A-4628-X,B-4628-Y;n:type:ShaderForge.SFN_Multiply,id:9646,x:28963,y:33249,varname:node_9646,prsc:2|A-5511-OUT,B-1588-OUT;n:type:ShaderForge.SFN_Multiply,id:5476,x:28963,y:33368,varname:node_5476,prsc:2|A-1507-OUT,B-1588-OUT;n:type:ShaderForge.SFN_NormalVector,id:3169,x:30565,y:32861,prsc:2,pt:False;n:type:ShaderForge.SFN_Abs,id:6987,x:30730,y:32861,varname:node_6987,prsc:2|IN-3169-OUT;n:type:ShaderForge.SFN_Multiply,id:401,x:30895,y:32861,varname:node_401,prsc:2|A-6987-OUT,B-6987-OUT;n:type:ShaderForge.SFN_Ceil,id:2116,x:29519,y:33243,varname:node_2116,prsc:2|IN-8927-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8927,x:29366,y:33243,ptovrint:False,ptlb:node_3060,ptin:_node_3060,varname:_node_3060,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:4934,x:30060,y:33136,varname:node_4934,prsc:2|A-8836-OUT,B-6229-OUT;n:type:ShaderForge.SFN_Frac,id:7985,x:30222,y:33136,varname:node_7985,prsc:2|IN-4934-OUT;n:type:ShaderForge.SFN_Step,id:8621,x:30584,y:33140,varname:node_8621,prsc:2|A-7985-OUT,B-218-OUT;n:type:ShaderForge.SFN_RemapRange,id:218,x:30222,y:32980,varname:node_218,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.5|IN-7813-OUT;n:type:ShaderForge.SFN_Slider,id:7813,x:29903,y:32996,ptovrint:False,ptlb:node_8486,ptin:_node_8486,varname:_node_8486,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9310892,max:1;n:type:ShaderForge.SFN_Subtract,id:8637,x:30400,y:33296,varname:node_8637,prsc:2|A-4100-OUT,B-7985-OUT;n:type:ShaderForge.SFN_Vector1,id:4100,x:30222,y:33308,varname:node_4100,prsc:2,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:6593,x:30747,y:33140,varname:node_6593,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8621-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2391,x:30747,y:33299,varname:node_2391,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3651-OUT;n:type:ShaderForge.SFN_Step,id:3651,x:30584,y:33299,varname:node_3651,prsc:2|A-8637-OUT,B-218-OUT;n:type:ShaderForge.SFN_Add,id:9670,x:30995,y:33207,varname:node_9670,prsc:2|A-6593-R,B-6593-G,C-2391-R,D-2391-G;n:type:ShaderForge.SFN_Multiply,id:6044,x:30059,y:33676,varname:node_6044,prsc:2|A-9646-OUT,B-6229-OUT;n:type:ShaderForge.SFN_Frac,id:3951,x:30221,y:33676,varname:node_3951,prsc:2|IN-6044-OUT;n:type:ShaderForge.SFN_Step,id:4947,x:30583,y:33680,varname:node_4947,prsc:2|A-3951-OUT,B-2424-OUT;n:type:ShaderForge.SFN_RemapRange,id:2424,x:30221,y:33520,varname:node_2424,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.5|IN-7813-OUT;n:type:ShaderForge.SFN_Subtract,id:1356,x:30399,y:33836,varname:node_1356,prsc:2|A-3351-OUT,B-3951-OUT;n:type:ShaderForge.SFN_Vector1,id:3351,x:30221,y:33848,varname:node_3351,prsc:2,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:5492,x:30746,y:33680,varname:node_5492,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4947-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5721,x:30746,y:33839,varname:node_5721,prsc:2,cc1:1,cc2:0,cc3:-1,cc4:-1|IN-4927-OUT;n:type:ShaderForge.SFN_Step,id:4927,x:30583,y:33839,varname:node_4927,prsc:2|A-1356-OUT,B-2424-OUT;n:type:ShaderForge.SFN_Add,id:706,x:30994,y:33747,varname:node_706,prsc:2|A-5492-R,B-5492-G,C-5721-R,D-5721-G;n:type:ShaderForge.SFN_Multiply,id:6109,x:30068,y:34205,varname:node_6109,prsc:2|A-5476-OUT,B-6229-OUT;n:type:ShaderForge.SFN_Frac,id:5908,x:30230,y:34205,varname:node_5908,prsc:2|IN-6109-OUT;n:type:ShaderForge.SFN_Step,id:4161,x:30592,y:34209,varname:node_4161,prsc:2|A-5908-OUT,B-8504-OUT;n:type:ShaderForge.SFN_RemapRange,id:8504,x:30230,y:34049,varname:node_8504,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.5|IN-7813-OUT;n:type:ShaderForge.SFN_Subtract,id:1023,x:30408,y:34365,varname:node_1023,prsc:2|A-3635-OUT,B-5908-OUT;n:type:ShaderForge.SFN_Vector1,id:3635,x:30230,y:34377,varname:node_3635,prsc:2,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:9885,x:30755,y:34209,varname:node_9885,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4161-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1843,x:30755,y:34368,varname:node_1843,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1391-OUT;n:type:ShaderForge.SFN_Step,id:1391,x:30592,y:34368,varname:node_1391,prsc:2|A-1023-OUT,B-8504-OUT;n:type:ShaderForge.SFN_Add,id:1599,x:31003,y:34276,varname:node_1599,prsc:2|A-9885-R,B-9885-G,C-1843-R,D-1843-G;n:type:ShaderForge.SFN_ChannelBlend,id:1686,x:31240,y:33583,varname:node_1686,prsc:2,chbt:0|M-401-OUT,R-9670-OUT,G-706-OUT,B-1599-OUT;n:type:ShaderForge.SFN_Vector1,id:7731,x:31240,y:33518,varname:node_7731,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:6229,x:29691,y:33243,varname:node_6229,prsc:2|A-2116-OUT,B-6701-OUT;n:type:ShaderForge.SFN_Vector1,id:6701,x:29519,y:33408,varname:node_6701,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Append,id:5060,x:28714,y:33085,varname:node_5060,prsc:2|A-4628-Y,B-4628-Z;n:type:ShaderForge.SFN_Vector1,id:1588,x:28403,y:33410,varname:node_1588,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector4,id:3587,x:31605,y:32082,varname:node_3587,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector1,id:248,x:31534,y:33946,varname:node_248,prsc:2,v1:1;n:type:ShaderForge.SFN_FaceSign,id:4968,x:32370,y:33616,varname:node_4968,prsc:2,fstp:0;n:type:ShaderForge.SFN_Lerp,id:7438,x:32370,y:33500,varname:node_7438,prsc:2|A-718-OUT,B-718-OUT,T-4968-VFACE;n:type:ShaderForge.SFN_Vector4,id:4582,x:31832,y:33280,varname:node_4582,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Clamp,id:2535,x:31247,y:32104,varname:node_2535,prsc:2|IN-9782-OUT,MIN-8450-OUT,MAX-7458-Y;n:type:ShaderForge.SFN_Vector1,id:8450,x:31277,y:32002,varname:node_8450,prsc:2,v1:0;n:type:ShaderForge.SFN_ObjectScale,id:7458,x:31271,y:31837,varname:node_7458,prsc:2,rcp:False;proporder:1352-8508-8466-5308-9782-8272-8927-7813;pass:END;sub:END;*/

Shader "Shader Forge/World" {
    Properties {
        _emi_color ("emi_color", Color) = (0.5,0.5,0.5,1)
        _emi ("emi", Range(0, 100)) = 0.1238048
        _basecolor ("base color", Color) = (1,1,1,1)
        [MaterialToggle] _node_5308 ("node_5308", Float ) = 1
        _height ("height", Float ) = 0
        _haba ("haba", Float ) = 1
        _node_3060 ("node_3060", Float ) = 2
        _node_8486 ("node_8486", Range(0, 1)) = 0.9310892
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
            uniform float4 _emi_color;
            uniform float _emi;
            uniform float4 _basecolor;
            uniform fixed _node_5308;
            uniform float _height;
            uniform float _haba;
            uniform float _node_3060;
            uniform float _node_8486;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 node_6987 = abs(i.normalDir);
                float3 node_401 = (node_6987*node_6987);
                float node_1588 = 1.0;
                float node_6229 = (ceil(_node_3060)*0.1);
                float2 node_7985 = frac(((float2(i.posWorld.g,i.posWorld.b)*node_1588)*node_6229));
                float node_218 = (_node_8486*0.5+0.0);
                float2 node_6593 = step(node_7985,node_218).rg;
                float2 node_2391 = step((1.0-node_7985),node_218).rg;
                float2 node_3951 = frac(((float2(i.posWorld.b,i.posWorld.r)*node_1588)*node_6229));
                float node_2424 = (_node_8486*0.5+0.0);
                float2 node_5492 = step(node_3951,node_2424).rg;
                float2 node_5721 = step((1.0-node_3951),node_2424).gr;
                float2 node_5908 = frac(((float2(i.posWorld.r,i.posWorld.g)*node_1588)*node_6229));
                float node_8504 = (_node_8486*0.5+0.0);
                float2 node_9885 = step(node_5908,node_8504).rg;
                float2 node_1843 = step((1.0-node_5908),node_8504).rg;
                float node_3308 = step(0.5,(node_401.r*(node_6593.r+node_6593.g+node_2391.r+node_2391.g) + node_401.g*(node_5492.r+node_5492.g+node_5721.r+node_5721.g) + node_401.b*(node_9885.r+node_9885.g+node_1843.r+node_1843.g)));
                clip(lerp( node_3308, 1.0, _node_5308 ) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float node_3427 = 0.0;
                float gloss = node_3427;
                float perceptualRoughness = 1.0 - node_3427;
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
                float3 specularColor = node_3427;
                float specularMonochrome;
                float node_4756 = ((i.posWorld.g-objPos.g)/clamp(_height,0.0,objScale.g));
                float node_4182 = (-1.0);
                float node_4222 = 0.0;
                float node_6596 = saturate((node_4222 + ( (node_4756 - node_4182) * (_haba - node_4222) ) / (1.0 - node_4182)));
                float3 diffuseColor = ((((1.0 - node_3308)*_basecolor.rgb)+(float4(0,0,0,0)*node_3308))*lerp(float4(0,0,0,0),float4(1,1,1,0),node_6596)).rgb; // Need this for specular when using metallic
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
                float3 node_718 = (node_6596*(node_3308*_emi_color.rgb*_emi));
                float3 emissive = lerp(node_718,node_718,isFrontFace);
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
            #define UNITY_PASS_FORWARDADD
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
            uniform float4 _emi_color;
            uniform float _emi;
            uniform float4 _basecolor;
            uniform fixed _node_5308;
            uniform float _height;
            uniform float _haba;
            uniform float _node_3060;
            uniform float _node_8486;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 node_6987 = abs(i.normalDir);
                float3 node_401 = (node_6987*node_6987);
                float node_1588 = 1.0;
                float node_6229 = (ceil(_node_3060)*0.1);
                float2 node_7985 = frac(((float2(i.posWorld.g,i.posWorld.b)*node_1588)*node_6229));
                float node_218 = (_node_8486*0.5+0.0);
                float2 node_6593 = step(node_7985,node_218).rg;
                float2 node_2391 = step((1.0-node_7985),node_218).rg;
                float2 node_3951 = frac(((float2(i.posWorld.b,i.posWorld.r)*node_1588)*node_6229));
                float node_2424 = (_node_8486*0.5+0.0);
                float2 node_5492 = step(node_3951,node_2424).rg;
                float2 node_5721 = step((1.0-node_3951),node_2424).gr;
                float2 node_5908 = frac(((float2(i.posWorld.r,i.posWorld.g)*node_1588)*node_6229));
                float node_8504 = (_node_8486*0.5+0.0);
                float2 node_9885 = step(node_5908,node_8504).rg;
                float2 node_1843 = step((1.0-node_5908),node_8504).rg;
                float node_3308 = step(0.5,(node_401.r*(node_6593.r+node_6593.g+node_2391.r+node_2391.g) + node_401.g*(node_5492.r+node_5492.g+node_5721.r+node_5721.g) + node_401.b*(node_9885.r+node_9885.g+node_1843.r+node_1843.g)));
                clip(lerp( node_3308, 1.0, _node_5308 ) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float node_3427 = 0.0;
                float gloss = node_3427;
                float perceptualRoughness = 1.0 - node_3427;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = node_3427;
                float specularMonochrome;
                float node_4756 = ((i.posWorld.g-objPos.g)/clamp(_height,0.0,objScale.g));
                float node_4182 = (-1.0);
                float node_4222 = 0.0;
                float node_6596 = saturate((node_4222 + ( (node_4756 - node_4182) * (_haba - node_4222) ) / (1.0 - node_4182)));
                float3 diffuseColor = ((((1.0 - node_3308)*_basecolor.rgb)+(float4(0,0,0,0)*node_3308))*lerp(float4(0,0,0,0),float4(1,1,1,0),node_6596)).rgb; // Need this for specular when using metallic
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
            #define UNITY_PASS_SHADOWCASTER
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
            uniform fixed _node_5308;
            uniform float _node_3060;
            uniform float _node_8486;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 node_6987 = abs(i.normalDir);
                float3 node_401 = (node_6987*node_6987);
                float node_1588 = 1.0;
                float node_6229 = (ceil(_node_3060)*0.1);
                float2 node_7985 = frac(((float2(i.posWorld.g,i.posWorld.b)*node_1588)*node_6229));
                float node_218 = (_node_8486*0.5+0.0);
                float2 node_6593 = step(node_7985,node_218).rg;
                float2 node_2391 = step((1.0-node_7985),node_218).rg;
                float2 node_3951 = frac(((float2(i.posWorld.b,i.posWorld.r)*node_1588)*node_6229));
                float node_2424 = (_node_8486*0.5+0.0);
                float2 node_5492 = step(node_3951,node_2424).rg;
                float2 node_5721 = step((1.0-node_3951),node_2424).gr;
                float2 node_5908 = frac(((float2(i.posWorld.r,i.posWorld.g)*node_1588)*node_6229));
                float node_8504 = (_node_8486*0.5+0.0);
                float2 node_9885 = step(node_5908,node_8504).rg;
                float2 node_1843 = step((1.0-node_5908),node_8504).rg;
                float node_3308 = step(0.5,(node_401.r*(node_6593.r+node_6593.g+node_2391.r+node_2391.g) + node_401.g*(node_5492.r+node_5492.g+node_5721.r+node_5721.g) + node_401.b*(node_9885.r+node_9885.g+node_1843.r+node_1843.g)));
                clip(lerp( node_3308, 1.0, _node_5308 ) - 0.5);
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
            uniform float4 _emi_color;
            uniform float _emi;
            uniform float4 _basecolor;
            uniform float _height;
            uniform float _haba;
            uniform float _node_3060;
            uniform float _node_8486;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_4756 = ((i.posWorld.g-objPos.g)/clamp(_height,0.0,objScale.g));
                float node_4182 = (-1.0);
                float node_4222 = 0.0;
                float node_6596 = saturate((node_4222 + ( (node_4756 - node_4182) * (_haba - node_4222) ) / (1.0 - node_4182)));
                float3 node_6987 = abs(i.normalDir);
                float3 node_401 = (node_6987*node_6987);
                float node_1588 = 1.0;
                float node_6229 = (ceil(_node_3060)*0.1);
                float2 node_7985 = frac(((float2(i.posWorld.g,i.posWorld.b)*node_1588)*node_6229));
                float node_218 = (_node_8486*0.5+0.0);
                float2 node_6593 = step(node_7985,node_218).rg;
                float2 node_2391 = step((1.0-node_7985),node_218).rg;
                float2 node_3951 = frac(((float2(i.posWorld.b,i.posWorld.r)*node_1588)*node_6229));
                float node_2424 = (_node_8486*0.5+0.0);
                float2 node_5492 = step(node_3951,node_2424).rg;
                float2 node_5721 = step((1.0-node_3951),node_2424).gr;
                float2 node_5908 = frac(((float2(i.posWorld.r,i.posWorld.g)*node_1588)*node_6229));
                float node_8504 = (_node_8486*0.5+0.0);
                float2 node_9885 = step(node_5908,node_8504).rg;
                float2 node_1843 = step((1.0-node_5908),node_8504).rg;
                float node_3308 = step(0.5,(node_401.r*(node_6593.r+node_6593.g+node_2391.r+node_2391.g) + node_401.g*(node_5492.r+node_5492.g+node_5721.r+node_5721.g) + node_401.b*(node_9885.r+node_9885.g+node_1843.r+node_1843.g)));
                float3 node_718 = (node_6596*(node_3308*_emi_color.rgb*_emi));
                o.Emission = lerp(node_718,node_718,isFrontFace);
                
                float3 diffColor = ((((1.0 - node_3308)*_basecolor.rgb)+(float4(0,0,0,0)*node_3308))*lerp(float4(0,0,0,0),float4(1,1,1,0),node_6596)).rgb;
                float specularMonochrome;
                float3 specColor;
                float node_3427 = 0.0;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, node_3427, specColor, specularMonochrome );
                float roughness = 1.0 - node_3427;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
