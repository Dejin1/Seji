using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float spawnTimer = 0;
    [SerializeField] private Transform enemyParent = null;
    [SerializeField] private Transform targetChildren = null;
    [SerializeField] private Transform spawnerChildren = null;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EnemyController.spawners = PopulateList(spawnerChildren);
        EnemyController.targets = PopulateList(targetChildren);
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnemyController.isSpawning) return;
        if (spawnTimer >= 0) { spawnTimer -= Time.deltaTime; return; }
        spawnTimer = EnemyController.spawnTimer;

        Spawner();
    }

    List<Vector3> PopulateList(Transform focus)
    {
        List<Vector3> temporaryList = new List<Vector3>();

        for (int i = 0; i < focus.childCount; i++)
        {
            temporaryList.Add(focus.GetChild(i).position);
        }

        return temporaryList;
    }
    
    private void Spawner()
    {
        GameObject enemy = null;
        for (int i = 0; i < enemyParent.childCount; i++)
        {
            Transform child = enemyParent.GetChild(i);
            if (!child.gameObject.activeInHierarchy)
            {
                enemy = child.gameObject;
            }
        }
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab, enemyParent);
        }
        enemy.SetActive(true);
        AssignEnemy(enemy);
    }

    private void AssignEnemy(GameObject enemy)
    {
        int targetIndex = 0;
        int spawnIndex = 0;
        float determination = Random.Range(1f, 100f);
        if(determination <= 12.5f)
        {
            targetIndex = 0;
            spawnIndex = 0;
        }
        else if (determination <= 25f)
        {
            targetIndex = 1;
            spawnIndex = 1;
        }
        else if (determination <= 37.5f)
        {
            targetIndex = 2;
            spawnIndex = 2;
        }
        else if (determination <= 50f)
        {
            targetIndex = 3;
            spawnIndex = 3;
        }
        else if (determination <= 62.5f)
        {
            targetIndex = 0;
            spawnIndex = 4;
        }
        else if (determination <= 75f)
        {
            targetIndex = 1;
            spawnIndex = 5;
        }
        else if (determination <= 87.5)
        {
            targetIndex = 2;
            spawnIndex = 6;
        }
        else
        {
            targetIndex = 3;
            spawnIndex = 7;
        }
        enemy.GetComponent<EnemyBehavior>().SetEnemy(EnemyController.spawners[spawnIndex], EnemyController.targets[targetIndex]);
    }

    public void ChangeSpawnRate(float sliderValue)
    {
        EnemyController.spawnTimer = sliderValue * 10;
    }
}
