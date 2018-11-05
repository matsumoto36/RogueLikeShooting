using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RogueLike.Matsumoto.Character;
using RogueLike.Matsumoto;

[CanEditMultipleObjects]
[CustomEditor(typeof(CharacterAsset))]
public class CharacterAssetInspector : Editor {

	SerializedProperty _characterType;
	SerializedProperty _characterHP;
	SerializedProperty _modelPrefab;
	SerializedProperty _enemyAIType;

	void OnEnable() {

		_characterType = serializedObject.FindProperty("CharacterType");
		_characterHP = serializedObject.FindProperty("HP");
		_modelPrefab = serializedObject.FindProperty("ModelPrefab");
		_enemyAIType = serializedObject.FindProperty("EnemyAIType");

	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUILayout.PropertyField(_characterType);
		EditorGUILayout.PropertyField(_characterHP);

		EditorGUILayout.PropertyField(_modelPrefab);
		if(_characterType.enumValueIndex == (int)CharacterType.Enemy)
			EditorGUILayout.PropertyField(_enemyAIType);

		serializedObject.ApplyModifiedProperties();
	}

}
