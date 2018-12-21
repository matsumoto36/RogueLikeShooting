using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;

public class CharacterAssetInspector : Editor {

	protected SerializedProperty CharacterHp;
	protected SerializedProperty ModelPrefab;
	protected SerializedProperty Weapon;

	protected virtual void OnEnable() {

		CharacterHp = serializedObject.FindProperty("HP");
		ModelPrefab = serializedObject.FindProperty("ModelPrefab");
		Weapon = serializedObject.FindProperty("Weapon");
	}
}

[CanEditMultipleObjects]
[CustomEditor(typeof(PlayerAsset))]
public class PlayerAssetInspector : CharacterAssetInspector {

	private SerializedProperty _playerID;

	protected override void OnEnable() {
		base.OnEnable();

		_playerID = serializedObject.FindProperty("ID");
	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUILayout.PropertyField(_playerID);
		EditorGUILayout.PropertyField(CharacterHp);
		EditorGUILayout.PropertyField(ModelPrefab);
		EditorGUILayout.PropertyField(Weapon);

		serializedObject.ApplyModifiedProperties();
	}

}

[CanEditMultipleObjects]
[CustomEditor(typeof(EnemyAsset))]
public class EnemyAssetInspector : CharacterAssetInspector {

	private SerializedProperty _enemyAIType;

	protected override void OnEnable() {
		base.OnEnable();

		_enemyAIType = serializedObject.FindProperty("EnemyAIType");
	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUILayout.PropertyField(CharacterHp);
		EditorGUILayout.PropertyField(ModelPrefab);
		EditorGUILayout.PropertyField(_enemyAIType);
		EditorGUILayout.PropertyField(Weapon);

		serializedObject.ApplyModifiedProperties();
	}

}