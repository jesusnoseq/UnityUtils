using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace com.jesusnoseq.util.editor
{
    [CustomEditor(typeof(LocalizedTMP))]
    public class LocalizedTMPEditor : Editor
    {

        override public void OnInspectorGUI()
        {
            serializedObject.Update();
            LocalizedText localizedTextScript = target as LocalizedTMP;

            localizedTextScript.useTextComponentTextAsKey = EditorGUILayout.Toggle("Text Component As Key", localizedTextScript.useTextComponentTextAsKey);
            if (!localizedTextScript.useTextComponentTextAsKey)
            {
                localizedTextScript.key = EditorGUILayout.TextField("Key", localizedTextScript.key);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}