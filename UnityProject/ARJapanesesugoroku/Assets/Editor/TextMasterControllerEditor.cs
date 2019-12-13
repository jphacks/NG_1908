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

                    // --変更--
                    EditorGUILayout.BeginHorizontal();

                    // いっぱいまで空白を埋める
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button("Delete"))
                    {
                        list.RemoveAt(i);

                        InitializeRenewList(i, list.Count);
                    }

                    EditorGUILayout.EndHorizontal();
                    // --ここまで--
                }
            }

            EditorGUI.indentLevel--;
        }
        if (GUILayout.Button("Add"))
        {
            list.Add(new TextMaster(GameState.Idle, "", ""));
            InitializeRenewList(-1,list.Count);
        }
        // Listの長さを初期化
        void InitializeList(int count)
        {
            foldings = new bool[count];
            isinitialized = true;
        }
        // 指定した番号以外をキャッシュして初期化 (i = -1の時は全てキャッシュして初期化)
        void InitializeRenewList(int i, int count)
        {
            bool[] foldings_temp = foldings;
            foldings = new bool[count];

            for (int k = 0, j = 0; k < count; k++)
            {
                if (i == j) j++;
                if (foldings_temp.Length - 1 < j) break;
                foldings[k] = foldings_temp[j++];
            }
        }
    }
}
