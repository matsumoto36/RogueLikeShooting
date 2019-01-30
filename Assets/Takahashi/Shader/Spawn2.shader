// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0,fgrn:11,fgrf:300.03,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:30315,y:32467,varname:node_2865,prsc:2|diff-8351-OUT,spec-358-OUT,gloss-1813-OUT,emission-4205-OUT,clip-5638-OUT;n:type:ShaderForge.SFN_Slider,id:358,x:30597,y:32518,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:_Metallic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:30623,y:32563,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Add,id:9098,x:27569,y:32216,varname:node_9098,prsc:2|A-7207-Y,B-1761-OUT,C-4617-OUT;n:type:ShaderForge.SFN_Multiply,id:1761,x:27401,y:32171,varname:node_1761,prsc:2|A-5281-OUT,B-981-Y;n:type:ShaderForge.SFN_FragmentPosition,id:7207,x:27401,y:32030,varname:node_7207,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:981,x:27220,y:32171,varname:node_981,prsc:2;n:type:ShaderForge.SFN_Vector1,id:5281,x:27220,y:32095,varname:node_5281,prsc:2,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:4617,x:27401,y:32316,ptovrint:False,ptlb:takasa,ptin:_takasa,varname:_takasa,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:2767,x:28071,y:32062,cmnt:A,varname:node_2767,prsc:2|A-6890-OUT,B-8451-OUT,T-8503-OUT;n:type:ShaderForge.SFN_Lerp,id:6902,x:28071,y:32216,cmnt:B,varname:node_6902,prsc:2|A-8451-OUT,B-6890-OUT,T-8503-OUT;n:type:ShaderForge.SFN_Clamp01,id:8503,x:27898,y:32216,varname:node_8503,prsc:2|IN-7185-OUT;n:type:ShaderForge.SFN_Append,id:5013,x:26442,y:33388,varname:node_5013,prsc:2|A-5650-Y,B-5650-Z;n:type:ShaderForge.SFN_Append,id:659,x:26442,y:33559,varname:node_659,prsc:2|A-5650-Z,B-5650-X;n:type:ShaderForge.SFN_Append,id:279,x:26442,y:33725,varname:node_279,prsc:2|A-5650-X,B-5650-Y;n:type:ShaderForge.SFN_FragmentPosition,id:5650,x:26225,y:33559,varname:node_5650,prsc:2;n:type:ShaderForge.SFN_ChannelBlend,id:3194,x:27599,y:33213,varname:node_3194,prsc:2,chbt:0|M-7403-OUT,R-9701-OUT,G-5048-OUT,B-8429-OUT;n:type:ShaderForge.SFN_Power,id:7403,x:27385,y:33213,varname:node_7403,prsc:2|VAL-2594-OUT,EXP-2594-OUT;n:type:ShaderForge.SFN_Abs,id:2594,x:27228,y:33213,varname:node_2594,prsc:2|IN-9253-OUT;n:type:ShaderForge.SFN_NormalVector,id:9253,x:27073,y:33213,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:6047,x:26600,y:33388,varname:node_6047,prsc:2|A-5013-OUT,B-9145-OUT;n:type:ShaderForge.SFN_Floor,id:7793,x:26756,y:33388,varname:node_7793,prsc:2|IN-6047-OUT;n:type:ShaderForge.SFN_Dot,id:5037,x:26916,y:33388,varname:node_5037,prsc:2,dt:0|A-7793-OUT,B-770-XYZ;n:type:ShaderForge.SFN_Sin,id:4620,x:27073,y:33388,varname:node_4620,prsc:2|IN-5037-OUT;n:type:ShaderForge.SFN_Multiply,id:4815,x:27228,y:33388,varname:node_4815,prsc:2|A-4620-OUT,B-8626-OUT;n:type:ShaderForge.SFN_Frac,id:9701,x:27385,y:33388,varname:node_9701,prsc:2|IN-4815-OUT;n:type:ShaderForge.SFN_Multiply,id:139,x:26600,y:33559,varname:node_139,prsc:2|A-659-OUT,B-9145-OUT;n:type:ShaderForge.SFN_Floor,id:8926,x:26756,y:33559,varname:node_8926,prsc:2|IN-139-OUT;n:type:ShaderForge.SFN_Dot,id:1281,x:26916,y:33559,varname:node_1281,prsc:2,dt:0|A-8926-OUT,B-770-XYZ;n:type:ShaderForge.SFN_Sin,id:9930,x:27073,y:33559,varname:node_9930,prsc:2|IN-1281-OUT;n:type:ShaderForge.SFN_Multiply,id:7211,x:27228,y:33559,varname:node_7211,prsc:2|A-9930-OUT,B-8626-OUT;n:type:ShaderForge.SFN_Frac,id:5048,x:27385,y:33559,varname:node_5048,prsc:2|IN-7211-OUT;n:type:ShaderForge.SFN_Vector4Property,id:770,x:26756,y:33916,ptovrint:False,ptlb:noise,ptin:_noise,varname:_noise,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:12,v2:14,v3:0,v4:0;n:type:ShaderForge.SFN_ValueProperty,id:9145,x:26442,y:33916,ptovrint:False,ptlb:noise_size,ptin:_noise_size,varname:_noise_size,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:8067,x:26600,y:33725,varname:node_8067,prsc:2|A-279-OUT,B-9145-OUT;n:type:ShaderForge.SFN_Floor,id:5445,x:26756,y:33725,varname:node_5445,prsc:2|IN-8067-OUT;n:type:ShaderForge.SFN_Dot,id:8831,x:26916,y:33725,varname:node_8831,prsc:2,dt:0|A-5445-OUT,B-770-XYZ;n:type:ShaderForge.SFN_Sin,id:4398,x:27073,y:33725,varname:node_4398,prsc:2|IN-8831-OUT;n:type:ShaderForge.SFN_Multiply,id:9968,x:27228,y:33725,varname:node_9968,prsc:2|A-4398-OUT,B-8626-OUT;n:type:ShaderForge.SFN_Frac,id:8429,x:27385,y:33725,varname:node_8429,prsc:2|IN-9968-OUT;n:type:ShaderForge.SFN_Time,id:4519,x:26905,y:34078,varname:node_4519,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:8626,x:27073,y:33838,varname:node_8626,prsc:2,frmn:0,frmx:1,tomn:-3,tomx:3|IN-2697-OUT;n:type:ShaderForge.SFN_Multiply,id:2697,x:27073,y:34078,varname:node_2697,prsc:2|A-4519-TDB,B-2542-OUT;n:type:ShaderForge.SFN_Vector4,id:6890,x:27898,y:32062,varname:node_6890,prsc:2,v1:1,v2:1,v3:1,v4:0;n:type:ShaderForge.SFN_FragmentPosition,id:9431,x:28697,y:31958,varname:node_9431,prsc:2;n:type:ShaderForge.SFN_Append,id:7191,x:28878,y:31819,varname:node_7191,prsc:2|A-9431-Y,B-9431-Z;n:type:ShaderForge.SFN_Append,id:4729,x:28878,y:31937,varname:node_4729,prsc:2|A-9431-Z,B-9431-X;n:type:ShaderForge.SFN_Append,id:364,x:28878,y:32053,varname:node_364,prsc:2|A-9431-X,B-9431-Y;n:type:ShaderForge.SFN_Tex2d,id:7692,x:29102,y:31816,varname:_node_7692,prsc:2,ntxv:0,isnm:False|UVIN-7191-OUT,TEX-1012-TEX;n:type:ShaderForge.SFN_Tex2d,id:370,x:29102,y:31934,varname:_node_370,prsc:2,ntxv:0,isnm:False|UVIN-4729-OUT,TEX-1012-TEX;n:type:ShaderForge.SFN_Tex2d,id:5111,x:29102,y:32050,varname:_node_5111,prsc:2,ntxv:0,isnm:False|UVIN-364-OUT,TEX-1012-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1012,x:28878,y:31507,ptovrint:False,ptlb:tiling texture,ptin:_tilingtexture,varname:_tilingtexture,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ChannelBlend,id:4829,x:29299,y:31853,varname:node_4829,prsc:2,chbt:0|M-7711-OUT,R-7692-RGB,G-370-RGB,B-5111-RGB;n:type:ShaderForge.SFN_Power,id:7711,x:29102,y:31689,varname:node_7711,prsc:2|VAL-9514-OUT,EXP-9514-OUT;n:type:ShaderForge.SFN_Abs,id:9514,x:28878,y:31692,varname:node_9514,prsc:2|IN-810-OUT;n:type:ShaderForge.SFN_NormalVector,id:810,x:28697,y:31692,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector4,id:8451,x:27732,y:32062,varname:node_8451,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_ValueProperty,id:2542,x:26905,y:34264,ptovrint:False,ptlb:noise_speed,ptin:_noise_speed,varname:_noise_speed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Slider,id:6665,x:27504,y:32787,ptovrint:False,ptlb:haba,ptin:_haba,varname:_haba,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:10,max:10;n:type:ShaderForge.SFN_Multiply,id:264,x:29481,y:32010,varname:node_264,prsc:2|A-4829-OUT,B-3395-RGB;n:type:ShaderForge.SFN_Color,id:3395,x:29299,y:32010,ptovrint:False,ptlb:tiling_color,ptin:_tiling_color,varname:_tiling_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Subtract,id:6125,x:28539,y:32575,varname:node_6125,prsc:2|A-2767-OUT,B-6214-OUT;n:type:ShaderForge.SFN_Clamp01,id:3084,x:28706,y:32575,varname:node_3084,prsc:2|IN-6125-OUT;n:type:ShaderForge.SFN_Vector1,id:1290,x:28706,y:32517,varname:node_1290,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Step,id:8986,x:28905,y:32553,varname:node_8986,prsc:2|A-1290-OUT,B-3084-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5638,x:30086,y:32744,varname:node_5638,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6976-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:8514,x:27846,y:32823,varname:node_8514,prsc:2|IN-6665-OUT,IMIN-8347-OUT,IMAX-9955-OUT,OMIN-9256-OUT,OMAX-5643-OUT;n:type:ShaderForge.SFN_Vector1,id:9955,x:27661,y:32970,varname:node_9955,prsc:2,v1:10;n:type:ShaderForge.SFN_Vector1,id:8347,x:27504,y:32970,varname:node_8347,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:7185,x:27745,y:32216,varname:node_7185,prsc:2|A-9098-OUT,B-1317-OUT;n:type:ShaderForge.SFN_Multiply,id:6214,x:28332,y:32837,varname:node_6214,prsc:2|A-6902-OUT,B-5807-OUT;n:type:ShaderForge.SFN_Subtract,id:5807,x:28069,y:32823,varname:node_5807,prsc:2|A-3194-OUT,B-8514-OUT;n:type:ShaderForge.SFN_OneMinus,id:4621,x:29283,y:32553,varname:node_4621,prsc:2|IN-9237-OUT;n:type:ShaderForge.SFN_Multiply,id:6976,x:29133,y:32775,varname:node_6976,prsc:2|A-3084-OUT,B-510-OUT;n:type:ShaderForge.SFN_RemapRange,id:510,x:28937,y:32803,varname:node_510,prsc:2,frmn:0,frmx:10,tomn:1,tomx:5|IN-6665-OUT;n:type:ShaderForge.SFN_Vector1,id:9256,x:27504,y:33074,varname:node_9256,prsc:2,v1:-20;n:type:ShaderForge.SFN_Vector1,id:5643,x:27661,y:33074,varname:node_5643,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:2056,x:29825,y:32261,varname:node_2056,prsc:2|A-264-OUT,B-603-RGB,T-4621-OUT;n:type:ShaderForge.SFN_Color,id:603,x:29361,y:32263,ptovrint:False,ptlb:emi_texture_color,ptin:_emi_texture_color,varname:_emi_texture_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:1317,x:27569,y:32382,varname:node_1317,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Color,id:8439,x:29574,y:32743,ptovrint:False,ptlb:emi_color,ptin:_emi_color,varname:_emi_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Divide,id:7108,x:29647,y:32590,varname:node_7108,prsc:2|A-4621-OUT,B-6976-OUT;n:type:ShaderForge.SFN_Multiply,id:4205,x:30086,y:32619,varname:node_4205,prsc:2|A-7108-OUT,B-8439-RGB,C-292-OUT;n:type:ShaderForge.SFN_Slider,id:467,x:27491,y:32468,ptovrint:False,ptlb:01,ptin:_01,varname:_01,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:7075,x:27856,y:32567,varname:node_7075,prsc:2|IN-467-OUT,IMIN-8030-OUT,IMAX-7506-OUT,OMIN-3842-OUT,OMAX-5717-OUT;n:type:ShaderForge.SFN_Vector1,id:8030,x:27504,y:32597,varname:o,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7506,x:27661,y:32597,varname:node_7506,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:2388,x:28028,y:32600,varname:node_2388,prsc:2|A-7075-OUT,B-5982-OUT;n:type:ShaderForge.SFN_Slider,id:292,x:29456,y:32946,ptovrint:False,ptlb:emi,ptin:_emi,varname:_emi,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Multiply,id:9237,x:29078,y:32519,varname:node_9237,prsc:2|A-6155-OUT,B-8986-OUT;n:type:ShaderForge.SFN_RemapRange,id:5982,x:27774,y:33213,varname:node_5982,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1|IN-3194-OUT;n:type:ShaderForge.SFN_OneMinus,id:6155,x:28358,y:32600,varname:node_6155,prsc:2|IN-3300-OUT;n:type:ShaderForge.SFN_Step,id:3300,x:28195,y:32600,varname:node_3300,prsc:2|A-6315-OUT,B-2388-OUT;n:type:ShaderForge.SFN_Lerp,id:8351,x:30076,y:32354,varname:node_8351,prsc:2|A-9962-RGB,B-2056-OUT,T-521-OUT;n:type:ShaderForge.SFN_Slider,id:521,x:29668,y:32409,ptovrint:False,ptlb:texture_switch,ptin:_texture_switch,varname:_texture_switch,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9962,x:29825,y:32071,varname:_node_9962,prsc:2,ntxv:0,isnm:False|TEX-6282-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6282,x:29653,y:32071,ptovrint:False,ptlb:base_texture,ptin:_base_texture,varname:_base_texture,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:5717,x:27661,y:32680,varname:node_5717,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:3842,x:27504,y:32692,varname:node_3842,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:6315,x:28028,y:32539,varname:node_6315,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Power,id:2223,x:30071,y:34368,varname:node_2223,prsc:2|VAL-909-OUT,EXP-909-OUT;n:type:ShaderForge.SFN_Abs,id:909,x:29914,y:34368,varname:node_909,prsc:2|IN-5255-OUT;n:type:ShaderForge.SFN_NormalVector,id:5255,x:29759,y:34368,prsc:2,pt:False;n:type:ShaderForge.SFN_Power,id:422,x:30135,y:34432,varname:node_422,prsc:2|VAL-7883-OUT,EXP-7883-OUT;n:type:ShaderForge.SFN_Abs,id:7883,x:29978,y:34432,varname:node_7883,prsc:2|IN-6680-OUT;n:type:ShaderForge.SFN_NormalVector,id:6680,x:29823,y:34432,prsc:2,pt:False;n:type:ShaderForge.SFN_Power,id:6373,x:29304,y:35151,varname:node_6373,prsc:2|VAL-1890-OUT,EXP-1890-OUT;n:type:ShaderForge.SFN_Abs,id:1890,x:29147,y:35151,varname:node_1890,prsc:2|IN-2855-OUT;n:type:ShaderForge.SFN_NormalVector,id:2855,x:28992,y:35151,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:5180,x:30478,y:34375,varname:node_5180,prsc:2|B-2121-OUT;n:type:ShaderForge.SFN_Slider,id:2121,x:30184,y:34492,ptovrint:False,ptlb:emi_copy_copy,ptin:_emi_copy_copy,varname:_emi_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:20;n:type:ShaderForge.SFN_Power,id:5612,x:30135,y:34432,varname:node_5612,prsc:2|VAL-639-OUT,EXP-639-OUT;n:type:ShaderForge.SFN_Abs,id:639,x:29978,y:34432,varname:node_639,prsc:2|IN-2074-OUT;n:type:ShaderForge.SFN_NormalVector,id:2074,x:29823,y:34432,prsc:2,pt:False;n:type:ShaderForge.SFN_Power,id:141,x:30199,y:34496,varname:node_141,prsc:2|VAL-6107-OUT,EXP-6107-OUT;n:type:ShaderForge.SFN_Abs,id:6107,x:30042,y:34496,varname:node_6107,prsc:2|IN-3285-OUT;n:type:ShaderForge.SFN_NormalVector,id:3285,x:29887,y:34496,prsc:2,pt:False;n:type:ShaderForge.SFN_Power,id:1027,x:29368,y:35215,varname:node_1027,prsc:2|VAL-4243-OUT,EXP-4243-OUT;n:type:ShaderForge.SFN_Abs,id:4243,x:29211,y:35215,varname:node_4243,prsc:2|IN-8955-OUT;n:type:ShaderForge.SFN_NormalVector,id:8955,x:29056,y:35215,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9746,x:30542,y:34439,varname:node_9746,prsc:2|B-4222-OUT;n:type:ShaderForge.SFN_Slider,id:4222,x:30248,y:34556,ptovrint:False,ptlb:emi_copy_copy_copy,ptin:_emi_copy_copy_copy,varname:_emi_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:20;proporder:4617-6282-358-1813-521-1012-3395-292-8439-603-770-9145-2542-6665-467;pass:END;sub:END;*/

Shader "Shader Forge/Spawn2" {
    Properties {
        _takasa ("takasa", Float ) = 0
        _base_texture ("base_texture", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _texture_switch ("texture_switch", Range(0, 1)) = 0
        _tilingtexture ("tiling texture", 2D) = "white" {}
        _tiling_color ("tiling_color", Color) = (0.5,0.5,0.5,1)
        _emi ("emi", Range(0, 10)) = 0
        _emi_color ("emi_color", Color) = (0.5,0.5,0.5,1)
        _emi_texture_color ("emi_texture_color", Color) = (0.5,0.5,0.5,1)
        _noise ("noise", Vector) = (12,14,0,0)
        _noise_size ("noise_size", Float ) = 4
        _noise_speed ("noise_speed", Float ) = 0
        _haba ("haba", Range(0, 10)) = 10
        _01 ("01", Range(0, 1)) = 1
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
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float _takasa;
            uniform float4 _noise;
            uniform float _noise_size;
            uniform sampler2D _tilingtexture; uniform float4 _tilingtexture_ST;
            uniform float _noise_speed;
            uniform float _haba;
            uniform float4 _tiling_color;
            uniform float4 _emi_texture_color;
            uniform float4 _emi_color;
            uniform float _01;
            uniform float _emi;
            uniform float _texture_switch;
            uniform sampler2D _base_texture; uniform float4 _base_texture_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
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
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 node_6890 = float4(1,1,1,0);
                float4 node_8451 = float4(0,0,0,0);
                float node_8503 = saturate(((i.posWorld.g+((-1.0)*objPos.g)+_takasa)*0.7));
                float3 node_2594 = abs(i.normalDir);
                float3 node_7403 = pow(node_2594,node_2594);
                float4 node_4519 = _Time;
                float node_8626 = ((node_4519.b*_noise_speed)*6.0+-3.0);
                float node_3194 = (node_7403.r*frac((sin(dot(floor((float2(i.posWorld.g,i.posWorld.b)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.g*frac((sin(dot(floor((float2(i.posWorld.b,i.posWorld.r)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.b*frac((sin(dot(floor((float2(i.posWorld.r,i.posWorld.g)*_noise_size)),_noise.rgb))*node_8626)));
                float node_8347 = 0.0;
                float node_9256 = (-20.0);
                float4 node_3084 = saturate((lerp(node_6890,node_8451,node_8503)-(lerp(node_8451,node_6890,node_8503)*(node_3194-(node_9256 + ( (_haba - node_8347) * (1.0 - node_9256) ) / (10.0 - node_8347))))));
                float4 node_6976 = (node_3084*(_haba*0.4+1.0));
                clip(node_6976.r - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
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
                float4 _node_9962 = tex2D(_base_texture,TRANSFORM_TEX(i.uv0, _base_texture));
                float3 node_9514 = abs(i.normalDir);
                float3 node_7711 = pow(node_9514,node_9514);
                float2 node_7191 = float2(i.posWorld.g,i.posWorld.b);
                float4 _node_7692 = tex2D(_tilingtexture,TRANSFORM_TEX(node_7191, _tilingtexture));
                float2 node_4729 = float2(i.posWorld.b,i.posWorld.r);
                float4 _node_370 = tex2D(_tilingtexture,TRANSFORM_TEX(node_4729, _tilingtexture));
                float2 node_364 = float2(i.posWorld.r,i.posWorld.g);
                float4 _node_5111 = tex2D(_tilingtexture,TRANSFORM_TEX(node_364, _tilingtexture));
                float o = 0.0;
                float node_3842 = 0.1;
                float4 node_4621 = (1.0 - ((1.0 - step(0.4,((node_3842 + ( (_01 - o) * (2.0 - node_3842) ) / (1.0 - o))*(node_3194*1.0+0.0))))*step(0.5,node_3084)));
                float3 diffuseColor = lerp(float4(_node_9962.rgb,0.0),lerp(float4(((node_7711.r*_node_7692.rgb + node_7711.g*_node_370.rgb + node_7711.b*_node_5111.rgb)*_tiling_color.rgb),0.0),float4(_emi_texture_color.rgb,0.0),node_4621),_texture_switch).rgb; // Need this for specular when using metallic
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
                float3 emissive = ((node_4621/node_6976)*_emi_color.rgb*_emi).rgb;
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
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float _takasa;
            uniform float4 _noise;
            uniform float _noise_size;
            uniform sampler2D _tilingtexture; uniform float4 _tilingtexture_ST;
            uniform float _noise_speed;
            uniform float _haba;
            uniform float4 _tiling_color;
            uniform float4 _emi_texture_color;
            uniform float4 _emi_color;
            uniform float _01;
            uniform float _emi;
            uniform float _texture_switch;
            uniform sampler2D _base_texture; uniform float4 _base_texture_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
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
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_6890 = float4(1,1,1,0);
                float4 node_8451 = float4(0,0,0,0);
                float node_8503 = saturate(((i.posWorld.g+((-1.0)*objPos.g)+_takasa)*0.7));
                float3 node_2594 = abs(i.normalDir);
                float3 node_7403 = pow(node_2594,node_2594);
                float4 node_4519 = _Time;
                float node_8626 = ((node_4519.b*_noise_speed)*6.0+-3.0);
                float node_3194 = (node_7403.r*frac((sin(dot(floor((float2(i.posWorld.g,i.posWorld.b)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.g*frac((sin(dot(floor((float2(i.posWorld.b,i.posWorld.r)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.b*frac((sin(dot(floor((float2(i.posWorld.r,i.posWorld.g)*_noise_size)),_noise.rgb))*node_8626)));
                float node_8347 = 0.0;
                float node_9256 = (-20.0);
                float4 node_3084 = saturate((lerp(node_6890,node_8451,node_8503)-(lerp(node_8451,node_6890,node_8503)*(node_3194-(node_9256 + ( (_haba - node_8347) * (1.0 - node_9256) ) / (10.0 - node_8347))))));
                float4 node_6976 = (node_3084*(_haba*0.4+1.0));
                clip(node_6976.r - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
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
                float4 _node_9962 = tex2D(_base_texture,TRANSFORM_TEX(i.uv0, _base_texture));
                float3 node_9514 = abs(i.normalDir);
                float3 node_7711 = pow(node_9514,node_9514);
                float2 node_7191 = float2(i.posWorld.g,i.posWorld.b);
                float4 _node_7692 = tex2D(_tilingtexture,TRANSFORM_TEX(node_7191, _tilingtexture));
                float2 node_4729 = float2(i.posWorld.b,i.posWorld.r);
                float4 _node_370 = tex2D(_tilingtexture,TRANSFORM_TEX(node_4729, _tilingtexture));
                float2 node_364 = float2(i.posWorld.r,i.posWorld.g);
                float4 _node_5111 = tex2D(_tilingtexture,TRANSFORM_TEX(node_364, _tilingtexture));
                float o = 0.0;
                float node_3842 = 0.1;
                float4 node_4621 = (1.0 - ((1.0 - step(0.4,((node_3842 + ( (_01 - o) * (2.0 - node_3842) ) / (1.0 - o))*(node_3194*1.0+0.0))))*step(0.5,node_3084)));
                float3 diffuseColor = lerp(float4(_node_9962.rgb,0.0),lerp(float4(((node_7711.r*_node_7692.rgb + node_7711.g*_node_370.rgb + node_7711.b*_node_5111.rgb)*_tiling_color.rgb),0.0),float4(_emi_texture_color.rgb,0.0),node_4621),_texture_switch).rgb; // Need this for specular when using metallic
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
            uniform float _takasa;
            uniform float4 _noise;
            uniform float _noise_size;
            uniform float _noise_speed;
            uniform float _haba;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_6890 = float4(1,1,1,0);
                float4 node_8451 = float4(0,0,0,0);
                float node_8503 = saturate(((i.posWorld.g+((-1.0)*objPos.g)+_takasa)*0.7));
                float3 node_2594 = abs(i.normalDir);
                float3 node_7403 = pow(node_2594,node_2594);
                float4 node_4519 = _Time;
                float node_8626 = ((node_4519.b*_noise_speed)*6.0+-3.0);
                float node_3194 = (node_7403.r*frac((sin(dot(floor((float2(i.posWorld.g,i.posWorld.b)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.g*frac((sin(dot(floor((float2(i.posWorld.b,i.posWorld.r)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.b*frac((sin(dot(floor((float2(i.posWorld.r,i.posWorld.g)*_noise_size)),_noise.rgb))*node_8626)));
                float node_8347 = 0.0;
                float node_9256 = (-20.0);
                float4 node_3084 = saturate((lerp(node_6890,node_8451,node_8503)-(lerp(node_8451,node_6890,node_8503)*(node_3194-(node_9256 + ( (_haba - node_8347) * (1.0 - node_9256) ) / (10.0 - node_8347))))));
                float4 node_6976 = (node_3084*(_haba*0.4+1.0));
                clip(node_6976.r - 0.5);
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
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float _takasa;
            uniform float4 _noise;
            uniform float _noise_size;
            uniform sampler2D _tilingtexture; uniform float4 _tilingtexture_ST;
            uniform float _noise_speed;
            uniform float _haba;
            uniform float4 _tiling_color;
            uniform float4 _emi_texture_color;
            uniform float4 _emi_color;
            uniform float _01;
            uniform float _emi;
            uniform float _texture_switch;
            uniform sampler2D _base_texture; uniform float4 _base_texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float o = 0.0;
                float node_3842 = 0.1;
                float3 node_2594 = abs(i.normalDir);
                float3 node_7403 = pow(node_2594,node_2594);
                float4 node_4519 = _Time;
                float node_8626 = ((node_4519.b*_noise_speed)*6.0+-3.0);
                float node_3194 = (node_7403.r*frac((sin(dot(floor((float2(i.posWorld.g,i.posWorld.b)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.g*frac((sin(dot(floor((float2(i.posWorld.b,i.posWorld.r)*_noise_size)),_noise.rgb))*node_8626)) + node_7403.b*frac((sin(dot(floor((float2(i.posWorld.r,i.posWorld.g)*_noise_size)),_noise.rgb))*node_8626)));
                float4 node_6890 = float4(1,1,1,0);
                float4 node_8451 = float4(0,0,0,0);
                float node_8503 = saturate(((i.posWorld.g+((-1.0)*objPos.g)+_takasa)*0.7));
                float node_8347 = 0.0;
                float node_9256 = (-20.0);
                float4 node_3084 = saturate((lerp(node_6890,node_8451,node_8503)-(lerp(node_8451,node_6890,node_8503)*(node_3194-(node_9256 + ( (_haba - node_8347) * (1.0 - node_9256) ) / (10.0 - node_8347))))));
                float4 node_4621 = (1.0 - ((1.0 - step(0.4,((node_3842 + ( (_01 - o) * (2.0 - node_3842) ) / (1.0 - o))*(node_3194*1.0+0.0))))*step(0.5,node_3084)));
                float4 node_6976 = (node_3084*(_haba*0.4+1.0));
                o.Emission = ((node_4621/node_6976)*_emi_color.rgb*_emi).rgb;
                
                float4 _node_9962 = tex2D(_base_texture,TRANSFORM_TEX(i.uv0, _base_texture));
                float3 node_9514 = abs(i.normalDir);
                float3 node_7711 = pow(node_9514,node_9514);
                float2 node_7191 = float2(i.posWorld.g,i.posWorld.b);
                float4 _node_7692 = tex2D(_tilingtexture,TRANSFORM_TEX(node_7191, _tilingtexture));
                float2 node_4729 = float2(i.posWorld.b,i.posWorld.r);
                float4 _node_370 = tex2D(_tilingtexture,TRANSFORM_TEX(node_4729, _tilingtexture));
                float2 node_364 = float2(i.posWorld.r,i.posWorld.g);
                float4 _node_5111 = tex2D(_tilingtexture,TRANSFORM_TEX(node_364, _tilingtexture));
                float3 diffColor = lerp(float4(_node_9962.rgb,0.0),lerp(float4(((node_7711.r*_node_7692.rgb + node_7711.g*_node_370.rgb + node_7711.b*_node_5111.rgb)*_tiling_color.rgb),0.0),float4(_emi_texture_color.rgb,0.0),node_4621),_texture_switch).rgb;
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
