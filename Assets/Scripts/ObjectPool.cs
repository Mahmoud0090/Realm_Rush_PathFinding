using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField][Range(0,50)] int poolSize = 5;
    [SerializeField] int numOfWaves = 2;
    [SerializeField][Range(0.2f , 30f)] float spawnTimer = 1f;

    int numOfAllEnemies;

    GameObject[] pool;
    int countingNumWaves = 0;
    public int CountingNumWaves { get { return countingNumWaves; } }
    Bank bank;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        bank = FindObjectOfType<Bank>();
        numOfAllEnemies = poolSize * numOfWaves;
        StartCoroutine(SpawnEnemy());
    }

    public int GetNumOfAllEnemies()
    {
        return numOfAllEnemies;
    }


    private void Update()
    {
        if (countingNumWaves >= numOfAllEnemies && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            bank.NextLevel();
        }
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        if(countingNumWaves >= numOfAllEnemies) { return; }
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                countingNumWaves++;
                return;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer); 
        }
    }
}
