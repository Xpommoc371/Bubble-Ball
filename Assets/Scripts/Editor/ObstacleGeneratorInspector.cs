using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObstacleGenerator))]
public class ObstacleGeneratorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        ObstacleGenerator obstacleGenerator = (ObstacleGenerator)target;


        if (GUILayout.Button("Generate Obstacles"))
        {
            obstacleGenerator.GenerateObstacles();
        }
        
        if (GUILayout.Button("Clear"))
        {
            obstacleGenerator.Clear();
        }
    }
}