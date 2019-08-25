using System.Collections.Generic;
using UnityEngine;

public class VillagerBehavior : MonoBehaviour
{
    [SerializeField] Transform TravelerPoints = null;
    private List<Vector3> travelPoints;
    private bool isReversed = false;
    private int travelIndex;
    [SerializeField] private float moveSpeed;
    private Vector3 targetDestination;

    private void OnEnable()
    {
        travelPoints.Clear();
        IsReversed();
        GatherPoints();
        if(!isReversed)
        {
            transform.position = travelPoints[0];
            targetDestination = travelPoints[1];
        }
        else
        {
            transform.position = travelPoints[travelPoints.Count - 1];
            targetDestination = travelPoints[travelPoints.Count - 2];
        }
    }

    private void GatherPoints()
    {
        for(int i = 0; i < TravelerPoints.childCount; i++)
        {
            Transform child = TravelerPoints.GetChild(i);
            if(child != null)
            {
                travelPoints.Add(child.position);
            }
        }
        if(!isReversed)
        {
            travelIndex = 0;
        }
        else
        {
            travelIndex = travelPoints.Count - 1;
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

        if(travelIndex >= travelPoints.Count || travelIndex < 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            targetDestination = travelPoints[travelIndex];
        }
    }

    private void MoveTraveler()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetDestination, moveSpeed * Time.deltaTime);
    }
}
