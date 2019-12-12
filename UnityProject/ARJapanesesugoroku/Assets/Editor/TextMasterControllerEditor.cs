using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(TextMasterController))]
public class TextMasterControllerEditor : Editor
{
    bool isinitialized = false;
    bool folding_List = false;
    bool[] foldings;

    public override void OnInspectorGUI()
    {
        TextMasterController textMasterController = target as TextMasterController;
        DrawDefaultInspector();

        var list = textMasterController.list;
        if (!isinitialized) InitializeList(list.Count);
        if (folding_List=EditorGUILayout.Foldout(folding_List,"List"))
        {
            EditorGUI.indentLevel++;

            for (int i=0;i<list.Count;i++)
            {
                if (foldings[i] = EditorGUILayout.Foldout(foldings[i],list[i].gameState.ToString()))
                {
                    list[i].gameState = (GameState)EditorGUILayout.EnumPopup("GameState",list[i].gameState);
                    list[i].mainText = EditorGUILayout.TextField("MainText",list[i].mainText);
                    list[i].othersText = EditorGUILayout.TextField("OtherText", list[i].othersText);
                }
            }

            EditorGUI.indentLevel--;
        }
        if (GUILayout.Button("Add"))
        {
            list.Add(new TextMaster(GameState.Idle, "", ""));
            InitializeList(list.Count);
        }
        // Listの長さを初期化
        void InitializeList(int count)
        {
            foldings = new bool[count];
            isinitialized = true;
        }
    }
}
