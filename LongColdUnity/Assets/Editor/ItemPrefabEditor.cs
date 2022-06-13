using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainItemObject))]
public class ItemPrefabEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MainItemObject itemObject = (MainItemObject)target;

        DrawDefaultInspector();
        if (GUILayout.Button("Initialize"))
        {
            itemObject.Init();
        }
    }

}
