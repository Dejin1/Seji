using System.Collections.Generic;
using UnityEngine;

public class VillagerBehavior : MonoBehaviour
{
    private bool isReversed = false;
    private int travelIndex;
    public float moveSpeed;
    private Vector3 targetDestination;

    private void OnEnable()
    {
        IsReversed();
        GatherPoints();
        DetermineMoveSpeed();
        if(!isReversed)
        {
            transform.position = VillagerController.travelPoints[0];
            targetDestination = VillagerController.travelPoints[1];
        }
        else
        {
            transform.position = VillagerController.travelPoints[VillagerController.travelPoints.Count - 1];
            targetDestination = VillagerController.travelPoints[VillagerController.travelPoints.Count - 2];
        }
    }

    private void GatherPoints()
    {
        if(!isReversed)
        {
            travelIndex = 0;
        }
        else
        {
            travelIndex = VillagerController.travelPoints.Count - 1;
        }
    }

    void IsReversed()
    {
        int determination = Random.Range(1, 100);
        if (determination % 2 == 0)
        {
            isReversed = false;
        }
        else
        {
            isReversed = true;
        }
    }

    void Update()
    {
        if(transform.position == targetDestination)
        {
            NextPosition();
        }
        MoveTraveler();
    }

    private void NextPosition()
    {
        if(!isReversed)
        {
            travelIndex++;
        }
        else { travelIndex--; }

        if(travelIndex >= VillagerController.travelPoints.Count || travelIndex < 0)
        {
            VillagerController.successes++;
            Debug.Log("Successes: " + VillagerController.successes);
            gameObject.SetActive(false);
        }
        else
        {
            targetDestination = VillagerController.travelPoints[travelIndex];
        }
    }

    private void MoveTraveler()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetDestination, moveSpeed * Time.deltaTime);
    }

    private void DetermineMoveSpeed()
    {
        int determination = Random.Range(1, 100);
        if (determination <= 70)
        {
            moveSpeed = VillagerController.medSpeed;
        }
        else if (determination <= 80)
        {
            moveSpeed = VillagerController.highSpeed;
        }
        else if (determination <= 90)
        {
            moveSpeed = VillagerController.slowSpeed;
        }
        else if (determination <= 95)
        {
            moveSpeed = VillagerController.minSpeed;
        }
        else if (determination <= 100)
        {
            moveSpeed = VillagerController.maxSpeed;
        }
    }
}

