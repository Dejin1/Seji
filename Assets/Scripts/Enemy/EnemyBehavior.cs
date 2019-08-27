using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Vector3 originPosition;
    Vector3 targetPosition;
    private int health = 4;
    
    public EnemyStates currentState;
    

    private void OnEnable()
    {
        health = 4;
        currentState = EnemyStates.Inactive;
    }

    void Update()
    {
        if (currentState == EnemyStates.Inactive) return;
        if(currentState == EnemyStates.Escaping && transform.position == originPosition) { gameObject.SetActive(false); }
        if(currentState == EnemyStates.MovingIn && transform.position == targetPosition) { currentState = EnemyStates.Pillaging; }
        
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 target;
        if (currentState == EnemyStates.Escaping)
        {
            target = originPosition;
        }
        else if (currentState == EnemyStates.MovingIn)
        {
            target = targetPosition;
        }
        else if(currentState == EnemyStates.Pillaging)
        {
            target = GetTargetVillager();
        }
        else
        {
            target = transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, EnemyController.enemySpeed * Time.deltaTime);
    }

    private Vector3 GetTargetVillager()
    {
        return transform.position;
    }

    public void SetEnemy(Vector3 origin, Vector3 target)
    {
        originPosition = origin;
        targetPosition = target;

        transform.position = originPosition;

        currentState = EnemyStates.MovingIn;
    }

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Villager") && currentState != EnemyStates.Engaged && currentState != EnemyStates.Escaping)
        {
            currentState = EnemyStates.Escaping;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Guard") && currentState != EnemyStates.Engaged)
        {
            if(collision.GetComponent<PatrolBehavior>() != null)
            {
                PatrolBehavior patrolBehavior = collision.GetComponent<PatrolBehavior>();
                if(patrolBehavior.currentState != PatrolStates.Engaged)
                {
                    currentState = EnemyStates.Engaged;
                    patrolBehavior.currentState = PatrolStates.Engaged;
                    patrolBehavior.engagedTarget = transform;
                }
            }
            else if (collision.GetComponent<VanguardBehavior>() != null)
            {
                VanguardBehavior vanguardBehavior = collision.GetComponent<VanguardBehavior>();
                if(vanguardBehavior.currentStates != VanguardStates.Engaged)
                {
                    currentState = EnemyStates.Engaged;
                    vanguardBehavior.currentStates = VanguardStates.Engaged;
                    vanguardBehavior.engagementTarget = transform;
                }
            }
        }
    }
}

public enum EnemyStates
{
    Inactive,
    MovingIn,
    Engaged,
    Pillaging,
    Escaping
}