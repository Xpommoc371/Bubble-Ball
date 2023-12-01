using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public enum GenerationMode { RandomInBounds = 0, AvoidArea = 1}

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private List<BaseObstacle> obstacles;
    [SerializeField] private float maxOffset = 0.5f;
    [SerializeField] private float spacing = 1f;
    [SerializeField] Vector2 arraySize = new Vector2(3, 4);
    [SerializeField] Vector3 startPoint = new Vector3(-9, 0.5f, -10);

    private List<GameObject> generatedObstacles = new List<GameObject>();

    public void GenerateObstacles()
    {
        Clear();
#if UNITY_EDITOR
        for (int z_index = 0; z_index < arraySize.x; z_index++)
        {
            for (int x_index = 0; x_index < arraySize.y; x_index++)
            {
                int RandomObstacleIndex = Random.Range(0, obstacles.Count);
                float offsetX = Random.Range(-maxOffset, maxOffset);
                float offsetZ = Random.Range(-maxOffset, maxOffset);
                float x = x_index * spacing + offsetX;
                float z = z_index * spacing + offsetZ;
                GameObject randomObstacle = (GameObject)PrefabUtility.InstantiatePrefab(obstacles[RandomObstacleIndex].gameObject, transform);
                randomObstacle.transform.position = new Vector3(startPoint.x + x, startPoint.y, startPoint.z + z);
                generatedObstacles.Add(randomObstacle);
            }
        }
        EditorUtility.SetDirty(gameObject);
#endif
    }

    public void Clear()
    {
#if UNITY_EDITOR
        foreach (GameObject obstacle in generatedObstacles)
        {
            DestroyImmediate(obstacle);
        }
        generatedObstacles.Clear();
        foreach(Transform t in transform)
        {
            DestroyImmediate(t.gameObject);
        }
#endif
    }
}
