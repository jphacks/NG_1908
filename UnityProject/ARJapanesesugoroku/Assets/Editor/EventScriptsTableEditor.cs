using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventScriptsTable))]
public class EventScriptsTableEditor : Editor
{
    //初期化されたかどうかの判定
    bool isInitialized = false;
    // Listの折りたたみ用の変数
    bool folding_list = false;
    // Listの要素の折りたたみ用の配列
    bool[] foldings;

    public override void OnInspectorGUI()
    {
        // tagetでeventScriptsTableを取得
        EventScriptsTable eventScriptsTable = target as EventScriptsTable;

        var list = eventScriptsTable.list;
        if (isInitialized == false)
        {
            foldings = new bool[list.Count];
            isInitialized = true;
        }
        // Listを折りたたみ表示
        if (folding_list = EditorGUILayout.Foldout(folding_list, "List"))
        {
            // インデントを増やす
            EditorGUI.indentLevel++;

            for (int i = 0; i < list.Count; i++)
            {
                // インデントを増やす
                EditorGUI.indentLevel++;

                // Listの要素を折りたたみ表示
                if (foldings[i] = EditorGUILayout.Foldout(foldings[i], list[i].eventTextName))
                {
                    list[i].eventTextName = EditorGUILayout.TextField("Name", list[i].eventTextName);
                    list[i].eventText = EditorGUILayout.TextField("Content", list[i].eventText);
                    list[i].flag = EditorGUILayout.Toggle("Enable", list[i].flag);
                }


                // インデントを減らす
                EditorGUI.indentLevel--;
            }

            // Listの追加
            if (GUILayout.Button("Add"))
            {
                list.Add(new EventScripts("New Event","",false));
                isInitialized = false;
            }
            if (GUILayout.Button("Save"))
            {
                Undo.RecordObject(target, "Save");
                EditorUtility.SetDirty(eventScriptsTable);
            }


        // インデントを減らす
        EditorGUI.indentLevel--;
        }
    }
}
