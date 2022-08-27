using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    #region
    SerializedProperty spawnMode;
    SerializedProperty objectToSpawn;
    SerializedProperty spawnLocations;
    SerializedProperty spawnRate;
    SerializedProperty spawnDuration;
    SerializedProperty sceneBoundsX;
    SerializedProperty sceneBoundsY;
    #endregion
    
    void OnEnable()
    {
        #region 
        spawnMode = serializedObject.FindProperty("spawnMode");
        objectToSpawn = serializedObject.FindProperty("objectToSpawn");
        spawnLocations = serializedObject.FindProperty("spawnLocations");
        spawnRate = serializedObject.FindProperty("spawnRate");
        spawnDuration = serializedObject.FindProperty("spawnDuration");
        sceneBoundsX = serializedObject.FindProperty("sceneBoundsX");
        sceneBoundsY = serializedObject.FindProperty("sceneBoundsY");
        #endregion
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(spawnMode);
        if (spawnMode.enumValueIndex == 0) // Classic mode
        {
            EditorGUILayout.PropertyField(objectToSpawn);
            EditorGUILayout.PropertyField(spawnDuration);
            EditorGUILayout.PropertyField(spawnRate);
            EditorGUILayout.PropertyField(spawnLocations);
        }
        else if (spawnMode.enumValueIndex == 1) // Random mode
        {
            EditorGUILayout.PropertyField(objectToSpawn);
            EditorGUILayout.PropertyField(spawnDuration);
            EditorGUILayout.PropertyField(spawnRate);
            EditorGUILayout.PropertyField(sceneBoundsX);
            EditorGUILayout.PropertyField(sceneBoundsY);
        }
        else // Random On Edges mode
        {
            EditorGUILayout.PropertyField(objectToSpawn);
            EditorGUILayout.PropertyField(spawnDuration);
            EditorGUILayout.PropertyField(spawnRate);
            EditorGUILayout.PropertyField(sceneBoundsX);
            EditorGUILayout.PropertyField(sceneBoundsY);
            
        }
        serializedObject.ApplyModifiedProperties();
    }
}