using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointSetter : MonoBehaviour
{
    [SerializeField] float layerCount;
    [SerializeField] float startAngle;
    [SerializeField] float divideLayerSize;

    [HideInInspector] public List<EnemyPoint> enemyPoints;

    void Awake()
    {
        CreateWithSinAndCos();
    }
    void CreateWithSinAndCos()
    {
        AddList(0, 0, 0);
        for (int layer = 1; layer < layerCount; layer++)
        {
            float angle = startAngle / layer;
            for (float totalAngle = 0; totalAngle < 360; totalAngle += angle)
            {
                float sinX = Mathf.Sin(totalAngle * Mathf.PI / 180);
                float cosX = Mathf.Cos(totalAngle * Mathf.PI / 180);

                AddList(sinX, cosX, layer);
            }
        }
    }
    void AddList(float sinX, float cosX, int layer)
    {
        EnemyPoint newEnemyPoint = new EnemyPoint();
        newEnemyPoint.Point = new Vector3(sinX, 0, cosX) * layer / divideLayerSize;
        enemyPoints.Add(newEnemyPoint);
    }
}
