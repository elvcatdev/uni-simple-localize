using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using archieSakai.UniSimpleLocalize;


namespace archieSakai.UniSimpleLocalize
{

    [CustomEditor(typeof(ApplyToImage))]
    public class ImageEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ApplyToImage imageManager = target as ApplyToImage;

            EditorGUILayout.HelpBox("Please adjust \"UniSimpleLocalize/Resources/SimpleLocalizeManager\" for your project", MessageType.Info, true);

            imageManager.langData = Resources.Load<UniSimpleLocalizeController>("SimpleLocalizeManager");
            for (int i = 0; i < imageManager.langData.langs.Count; i++)
            {
                imageManager.langSpriteList.Add(null);
                EditorGUILayout.LabelField(imageManager.langData.langs[i].ToString(), EditorStyles.boldLabel);
                imageManager.langSpriteList[i] = (Sprite)EditorGUILayout.ObjectField("Sprite", imageManager.langSpriteList[i], typeof(Sprite), allowSceneObjects: true);
            }
            EditorGUILayout.LabelField("Default Sprite", EditorStyles.boldLabel);
            imageManager.defaultSprite = (Sprite)EditorGUILayout.ObjectField("Sprite", imageManager.defaultSprite, typeof(Sprite), allowSceneObjects: true);

            EditorUtility.SetDirty(target);
        }
    }
}
