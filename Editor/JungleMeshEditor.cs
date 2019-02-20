using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace ThroughTheJungle
{
    [CustomEditor(typeof(JungleMesh))]
    public class JungleMeshEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if(GUILayout.Button("Bake"))
            {
                JungleMesh jungleMesh = target as JungleMesh;
                jungleMesh.Bake();
            }
        }
    }
}
