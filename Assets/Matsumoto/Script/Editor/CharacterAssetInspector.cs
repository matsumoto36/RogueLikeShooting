using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RogueLike.Matsumoto.Character;
using RogueLike.Matsumoto.Character.Asset;

[CanEditMultipleObjects]
[CustomEditor(typeof(PlayerAsset))]
public class PlayerAssetInspector : Editor {

	SerializedProperty _playerID;
	SerializedProperty _characterHP;
	SerializedProperty _modelPrefab;

	void OnEnable() {

		_playerID = serializedObject.FindProperty("ID");
		_characterHP = serializedObject.FindProperty("HP");
		_modelPrefab = serializedObject.FindProperty("ModelPrefab");
	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUILayout.PropertyField(_playerID);
		EditorGUILayout.PropertyField(_characterHP);
		EditorGUILayout.PropertyField(_modelPrefab);

		serializedObject.ApplyModifiedProperties();
	}

}

[CanEditMultipleObjects]
[CustomEditor(typeof(EnemyAsset))]
public class EnemyAssetInspector : Editor {

	SerializedProperty _characterHP;
	SerializedProperty _modelPrefab;
	SerializedProperty _enemyAIType;

	void OnEnable() {

		_characterHP = serializedObject.FindProperty("HP");
		_modelPrefab = serializedObject.FindProperty("ModelPrefab");
		_enemyAIType = serializedObject.FindProperty("EnemyAIType");
	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUILayout.PropertyField(_characterHP);
		EditorGUILayout.PropertyField(_modelPrefab);
		EditorGUILayout.PropertyField(_enemyAIType);

		serializedObject.ApplyModifiedProperties();
	}

}