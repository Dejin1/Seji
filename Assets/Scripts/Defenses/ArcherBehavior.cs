using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehavior : MonoBehaviour
{
    public ArcherStates currentStates = ArcherStates.Searching;
    public Transform engagementTarget;
    private LineRenderer lineRenderer;
    private float attackTimer = 1f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStates == ArcherStates.Searching)
        {
            lineRenderer.SetPosition(1, transform.position);
            engagementTarget = CheckForTarget();

            if (engagementTarget != null)
            {
                currentStates = ArcherStates.Fighting;
            }
        }
        else
        {
            if(!engagementTarget.gameObject.activeInHierarchy)
            {
                currentStates = ArcherStates.Searching;
            }
            float targetDistance = Vector2.Distance(transform.position, engagementTarget.position);
            if (targetDistance > DefenseController.archerRadius)
            {
                currentStates = ArcherStates.Searching;
            }
            else
            {
                EnemyBehavior enemyBehavior = engagementTarget.GetComponent<EnemyBehavior>();
                if(enemyBehavior != null)
                {
                    lineRenderer.SetPosition(1, enemyBehavior.transform.position);
                    if (attackTimer <= 0)
                    {
                        enemyBehavior.TakeDamage();
                        attackTimer = DefenseController.attackDelay;
                    }
                    else
                    {
                        attackTimer -= Time.deltaTime;
                    }
                }
                else
                {
                    currentStates = ArcherStates.Searching;
                }
            }
        }
    }

    private Transform CheckForTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, DefenseController.archerRadius);
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

public enum ArcherStates
{
    Searching,
    Fighting
}