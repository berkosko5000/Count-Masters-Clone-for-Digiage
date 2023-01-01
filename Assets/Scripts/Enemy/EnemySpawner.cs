using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int enemyCount;
    [SerializeField] GameObject enemyPrefab;
    void Start()
    {
        float randomPositionRange = 0.5f;
        for (int i = 0; i < enemyCount; i++){
            Vector3 position = new Vector3(Random.Range(this.transform.position.x - randomPositionRange, this.transform.position.x + randomPositionRange),
                                                this.transform.position.y,
                                                Random.Range(this.transform.position.z - randomPositionRange, this.transform.position.z + randomPositionRange));

            Debug.Log(ObjectPooler.SharedInstance.pooledObjects);
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
            enemy.transform.position = position;
            enemy.transform.SetParent(transform);
            enemy.GetComponent<EnemyPartyMember>().JoinTeam();
            enemy.SetActive(true);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
