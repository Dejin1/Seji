using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    private bool isReversed = false;
    [SerializeField]private int travelIndex;
    private Vector3 targetDestination;
    public PatrolStates currentState;
    public Transform engagedTarget;

    private void OnEnable()
    {
        currentState = PatrolStates.Patrolling;
        transform.position = DefenseController.patrolPoints[0];
        targetDestination = DefenseController.patrolPoints[1];
    }

    void Update()
    {
        if (currentState == PatrolStates.Inactive) return;

        else if(currentState == PatrolStates.Patrolling)
        {
            if (transform.position == targetDestination)
            {
                NextPosition();
            }
            MoveTraveler();
        }
        else
        {
            if(!engagedTarget.gameObject.activeInHierarchy)
            {
                engagedTarget = null;
                currentState = PatrolStates.Patrolling;
            }
        }
    }

    private void NextPosition()
    {
        if (!isReversed)
        {
            travelIndex++;
        }
        else { travelIndex--; }

        if (travelIndex >= DefenseController.patrolPoints.Count || travelIndex < 0)
        {
            if(!isReversed)
            {
                isReversed = true;
                transform.position = DefenseController.patrolPoints[DefenseController.patrolPoints.Count - 1];
                travelIndex = DefenseController.patrolPoints.Count - 2;
            }
            else
            {
                isReversed = false;
                transform.position = DefenseController.patrolPoints[0];
                travelIndex = 1;
            }
        }

        targetDestination = DefenseController.patrolPoints[travelIndex];
    }

    private void MoveTraveler()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetDestination, DefenseController.patrolSpeed * Time.deltaTime);
    }
}

public enum PatrolStates
{
    Inactive,
    Patrolling,
    Engaged
}
