using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using archieSakai.UniSimpleLocalize;

namespace archieSakai.UniSimpleLocalize
{

    [CustomEditor(typeof(ApplyToText))]
    public class TextEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ApplyToText textManager = target as ApplyToText;

            EditorGUILayout.HelpBox("Please adjust \"UniSimpleLocalize/Resources/SimpleLocalizeManager\" for your project", MessageType.Info, true);

            textManager.langData = Resources.Load<UniSimpleLocalizeController>("SimpleLocalizeManager");
            for(int i = 0; i < textManager.langData.langs.Count; i++)
            {
                textManager.langStrList.Add("");
                EditorGUILayout.LabelField(textManager.langData.langs[i].ToString(), EditorStyles.boldLabel);
                textManager.langStrList[i] = EditorGUILayout.TextArea(textManager.langStrList[i], GUILayout.Height(50));
            }
            EditorGUILayout.LabelField("Default Text", EditorStyles.boldLabel);
            textManager.defaultText = EditorGUILayout.TextArea(textManager.defaultText, GUILayout.Height(50));


            EditorUtility.SetDirty(target);
        }
    }
}