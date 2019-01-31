using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;
using DDD.Matsumoto.Character.EnemyAI;

public class CharacterAssetInspector : Editor {

	protected SerializedProperty CharacterHp;
	protected SerializedProperty ThemeColor;
	protected SerializedProperty Weapon;

	protected virtual void OnEnable() {

		CharacterHp = serializedObject.FindProperty("HP");
		ThemeColor = serializedObject.FindProperty("ThemeColor");
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
		EditorGUILayout.PropertyField(ThemeColor);
		EditorGUILayout.PropertyField(Weapon);

		serializedObject.ApplyModifiedProperties();
	}

}

[CanEditMultipleObjects]
[CustomEditor(typeof(EnemyAsset))]
public class EnemyAssetInspector : CharacterAssetInspector {

	private SerializedProperty _enemyAIType;
	private SerializedProperty _enemyAIParameter;

	protected override void OnEnable() {
		base.OnEnable();

		_enemyAIType = serializedObject.FindProperty("EnemyAIType");
		_enemyAIParameter = serializedObject.FindProperty("EnemyAIParameter");
	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUILayout.PropertyField(CharacterHp);
		EditorGUILayout.PropertyField(ThemeColor);
		EditorGUILayout.PropertyField(_enemyAIType);
		EditorGUILayout.PropertyField(_enemyAIParameter, true);
		EditorGUILayout.PropertyField(Weapon);

		serializedObject.ApplyModifiedProperties();
	}

}