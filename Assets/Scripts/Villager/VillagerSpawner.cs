using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{
    private float spawnTimer = 0;
    [SerializeField] private GameObject villagerPrefab;
    [SerializeField] private Transform travelPoints;
    
    private void Awake()
    {
        VillagerController.travelPoints = PopulateList();
    }

    List<Vector3> PopulateList()
    {
        List<Vector3> temporaryList = new List<Vector3>();
        for (int i = 0; i < this.travelPoints.childCount; i++)
        {
            Transform child = this.travelPoints.GetChild(i);
            if (child != null)
            {
                temporaryList.Add(child.position);
            }
        }
        return temporaryList;
    }

    private void Update()
    {
        if (!EnemyController.isSpawning) return;
        if(spawnTimer >= 0) { spawnTimer -= Time.deltaTime; return; }
        spawnTimer = VillagerController.spawnTimer;

        Spawner();
    }

    private void Spawner()
    {
        GameObject villager = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (!child.gameObject.activeInHierarchy)
            {
                villager = child.gameObject;
            }
        }
        if (villager == null)
        {
            villager = Instantiate(villagerPrefab, transform);
        }
        villager.SetActive(true);
        VillagerController.travelers++;
    }
}
