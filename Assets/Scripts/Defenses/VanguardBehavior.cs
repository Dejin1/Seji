using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanguardBehavior : MonoBehaviour
{
    public Vector3 originPosition;
    public VanguardStates currentStates = VanguardStates.Guarding;
    public Transform engagementTarget;

    private void Awake()
    {
        originPosition = transform.position;
    }

    private void Update()
    {
        if(currentStates == VanguardStates.Guarding)
        {
            engagementTarget = CheckForTarget();

            if (engagementTarget != null)
            {
                currentStates = VanguardStates.Chasing;
            }
        }
        else if(currentStates == VanguardStates.Chasing)
        {
            if(!engagementTarget.gameObject.activeInHierarchy) { currentStates = VanguardStates.Guarding; }
            transform.position = Vector3.MoveTowards(transform.position, engagementTarget.position, DefenseController.vanguardSpeed * Time.deltaTime);
        }
        else
        {
            if(!engagementTarget.gameObject.activeInHierarchy)
            {
                if(transform.position == originPosition) { currentStates = VanguardStates.Guarding; }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, originPosition, DefenseController.vanguardSpeed * Time.deltaTime);
                }
            }
        }
    }

    private Transform CheckForTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, DefenseController.vanguardRadius);
        float closestDistance = 0f;
        int targetIndex = -1;
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].CompareTag("Enemy"))
            {
                float targetDistance = Vector2.Distance(transform.position, targets[i].transform.position);
                if (closestDistance == 0 || closestDistance > targetDistance)
                {
                    closestDistance = targetDistance;
                    targetIndex = i;
                }
            }
        }
        if (targetIndex == -1)
        {
            return null;
        }
        return targets[targetIndex].transform;
    }
}

public enum VanguardStates
{
    Guarding,
    Chasing,
    Engaged
}