using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private float enemySpawnInterval = 5f;
    [SerializeField]
    private bool playerIsAlive = true;
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //IEnumerator EnemySpawnRoutine()

    //while loop
    //instantiate enemy prefab at random X between -8.5f and 8.5f , Y = 6.5 , Z = 0
    //yield wait enemyspawninterval seconds

    IEnumerator EnemySpawnRoutine()
    {
        while (playerIsAlive)
        {
            if (enemyContainer.transform.childCount < 10)
            {
                GameObject instantiatedEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-8.5f, 8.5f), 6f, 0), transform.rotation);
                instantiatedEnemy.transform.parent = enemyContainer.transform;
                yield return new WaitForSeconds(enemySpawnInterval);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void OnPlayerDeath()
        {
        playerIsAlive = false;
        }


}
