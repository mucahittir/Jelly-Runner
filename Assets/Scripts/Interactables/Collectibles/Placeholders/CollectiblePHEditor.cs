using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(CollectiblePH))]
public class CollectiblePHEditor : Editor
{
    CollectiblePH collectiblePH;
    private void OnEnable()
    {
        collectiblePH = (CollectiblePH)target;
    }
    public override void OnInspectorGUI()
    {
        
        //base.OnInspectorGUI();
        collectiblePH.collectibleType = (CollectibleType)EditorGUILayout.EnumPopup("Collectible Type", collectiblePH.collectibleType);
        switch (collectiblePH.collectibleType)
        {
            case CollectibleType.Coin:
                {
                    collectiblePH.Value = EditorGUILayout.IntField("Value", collectiblePH.Value);
                    break;
                }
            case CollectibleType.CollectibleJelly:
                {
                    break;
                }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            //EditorSceneManager.MarkSceneDirty();
        }
    }
}
#endif