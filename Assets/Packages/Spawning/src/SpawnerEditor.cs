using UnityEditor;

namespace Packages.Spawning.src
{
    [CustomEditor(typeof(Spawner))]
    public class SpawnerEditor : Editor
    {
        #region

        private SerializedProperty _spawnMode;
        private SerializedProperty _objectToSpawn;
        private SerializedProperty _spawnLocations;
        private SerializedProperty _spawnRate;
        private SerializedProperty _spawnDuration;
        private SerializedProperty _sceneBoundsX;
        private SerializedProperty _sceneBoundsY;
        #endregion

        private void OnEnable()
        {
            #region 
            _spawnMode = serializedObject.FindProperty("spawnMode");
            _objectToSpawn = serializedObject.FindProperty("objectToSpawn");
            _spawnLocations = serializedObject.FindProperty("spawnLocations");
            _spawnRate = serializedObject.FindProperty("spawnRate");
            _spawnDuration = serializedObject.FindProperty("spawnDuration");
            _sceneBoundsX = serializedObject.FindProperty("sceneBoundsX");
            _sceneBoundsY = serializedObject.FindProperty("sceneBoundsY");
            #endregion
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_spawnMode);
            if (_spawnMode.enumValueIndex == 0) // Classic mode
            {
                EditorGUILayout.PropertyField(_objectToSpawn);
                EditorGUILayout.PropertyField(_spawnDuration);
                EditorGUILayout.PropertyField(_spawnRate);
                EditorGUILayout.PropertyField(_spawnLocations);
            }
            else if (_spawnMode.enumValueIndex == 1) // Random mode
            {
                EditorGUILayout.PropertyField(_objectToSpawn);
                EditorGUILayout.PropertyField(_spawnDuration);
                EditorGUILayout.PropertyField(_spawnRate);
                EditorGUILayout.PropertyField(_sceneBoundsX);
                EditorGUILayout.PropertyField(_sceneBoundsY);
            }
            else // Random On Edges mode
            {
                EditorGUILayout.PropertyField(_objectToSpawn);
                EditorGUILayout.PropertyField(_spawnDuration);
                EditorGUILayout.PropertyField(_spawnRate);
                EditorGUILayout.PropertyField(_sceneBoundsX);
                EditorGUILayout.PropertyField(_sceneBoundsY);
            
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}