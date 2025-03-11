using NUnit.Framework.Interfaces;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitData))]
public class ItemDataEditor : Editor {
    private SerializedProperty sizeProp;
    private SerializedProperty dmgProp;
    private SerializedProperty atkSpdProp;
    private SerializedProperty gradeProp;
    private SerializedProperty codeProp;

    private void OnEnable() {
        sizeProp = serializedObject.FindProperty("size");
        dmgProp = serializedObject.FindProperty("Dmg");
        atkSpdProp = serializedObject.FindProperty("AtkSpd");
        gradeProp = serializedObject.FindProperty("Grade");
        codeProp = serializedObject.FindProperty("unitCode");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.LabelField("Visual Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sprite"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("anim"));

        EditorGUILayout.LabelField("Combat Stats", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(dmgProp);
        EditorGUILayout.PropertyField(atkSpdProp);
        EditorGUILayout.PropertyField(gradeProp);
        EditorGUILayout.PropertyField(codeProp);


        // �׸��� ���� ���
        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("Item Shape Grid", EditorStyles.boldLabel);

        // �׸��� ũ�� ���� ��ư
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Row"))
            AddRow();
        if (GUILayout.Button("Remove Row"))
            RemoveRow();
        EditorGUILayout.EndHorizontal();

        // �׸��� �ð�ȭ
        DrawGrid();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawGrid() {

        for (int y = 0; y < sizeProp.arraySize; y++) {
            SerializedProperty rowProp = sizeProp.GetArrayElementAtIndex(y).FindPropertyRelative("row");
            EditorGUILayout.BeginHorizontal();

            // �÷� �߰�/���� ��ư (ù ��° �࿡��)
            if (y == 0) {
                EditorGUILayout.BeginVertical(GUILayout.Width(20));
                if (GUILayout.Button("+", GUILayout.Width(20)))
                    AddColumn();
                if (GUILayout.Button("-", GUILayout.Width(20)))
                    RemoveColumn();
                EditorGUILayout.EndVertical();
            }

            // �� �� ��� ��ư
            for (int x = 0; x < rowProp.arraySize; x++) {
                bool value = rowProp.GetArrayElementAtIndex(x).boolValue;
                bool newValue = GUILayout.Toggle(value, "", GUILayout.Width(20), GUILayout.Height(20));
                if (newValue != value) {
                    rowProp.GetArrayElementAtIndex(x).boolValue = newValue;
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    private void AddRow() {
        int columns = sizeProp.arraySize > 0 ?
            sizeProp.GetArrayElementAtIndex(0).FindPropertyRelative("row").arraySize : 0;

        sizeProp.InsertArrayElementAtIndex(sizeProp.arraySize);
        SerializedProperty newRow = sizeProp.GetArrayElementAtIndex(sizeProp.arraySize - 1).FindPropertyRelative("row");
        newRow.arraySize = columns;
    }

    private void RemoveRow() {
        if (sizeProp.arraySize > 0)
            sizeProp.DeleteArrayElementAtIndex(sizeProp.arraySize - 1);
    }

    private void AddColumn() {
        for (int y = 0; y < sizeProp.arraySize; y++) {
            SerializedProperty row = sizeProp.GetArrayElementAtIndex(y).FindPropertyRelative("row");
            row.InsertArrayElementAtIndex(row.arraySize);
        }
    }

    private void RemoveColumn() {
        for (int y = 0; y < sizeProp.arraySize; y++) {
            SerializedProperty row = sizeProp.GetArrayElementAtIndex(y).FindPropertyRelative("row");
            if (row.arraySize > 0)
                row.DeleteArrayElementAtIndex(row.arraySize - 1);
        }
    }

}
