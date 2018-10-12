using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RogueLike.Matsumoto.Character;

[CanEditMultipleObjects]
[CustomEditor(typeof(CharacterAsset))]
public class CharacterAssetInspector : Editor {

	CharacterAsset _characterAsset = null;

	void OnEnable() {
		//Character コンポーネントを取得
		_characterAsset = (CharacterAsset)target;
	}

	public override void OnInspectorGUI() {



	}

}
