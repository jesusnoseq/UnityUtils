using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace com.jesusnoseq.util
{
    [CustomEditor(typeof(LocalizedText))]
    public class LocalizedTextEditor : Editor
    {

        override public void OnInspectorGUI()
        {
            serializedObject.Update();
            LocalizedText localizedTextScript = target as LocalizedText;

            localizedTextScript.useTextComponentTextAsKey = EditorGUILayout.Toggle("Text Component As Key", localizedTextScript.useTextComponentTextAsKey);
            if (!localizedTextScript.useTextComponentTextAsKey)
            {
                localizedTextScript.key = EditorGUILayout.TextField("Key", localizedTextScript.key);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}