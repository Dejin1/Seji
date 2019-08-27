using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSpawner : MonoBehaviour
{
    [SerializeField] private Transform patrolPath;
    [SerializeField] private GameObject patrolPrefab;
    private int patrolCount = 0;
    public int patrolAvailable = 3;

    private void Awake()
    {
        DefenseController.patrolPoints = PopulateList();
    }

    List<Vector3> PopulateList()
    {
        List<Vector3> temporaryList = new List<Vector3>();
        for (int i = 0; i < this.patrolPath.childCount; i++)
        {
            Transform child = this.patrolPath.GetChild(i);
            if (child != null)
            {
                temporaryList.Add(child.position);
            }
        }
        return temporaryList;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && patrolCount < patrolAvailable)
        {
            Spawner();
        }
    }

    private void Spawner()
    {
        GameObject patrol = Instantiate(patrolPrefab, transform);
        patrol.SetActive(true);
        patrolCount++;
    }
}
