using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Vector3 originPosition;
    Vector3 targetPosition;
    
    private EnemyStates currentState;
    

    private void OnEnable()
    {
        currentState = EnemyStates.Inactive;
    }

    void Update()
    {
        if (currentState == EnemyStates.Inactive) return;
        if(currentState == EnemyStates.Escaping && transform.position == originPosition) { gameObject.SetActive(false); }
        if(currentState == EnemyStates.MovingIn && transform.position == targetPosition) { currentState = EnemyStates.Pillaging; }

        if(currentState == EnemyStates.Pillaging)
        {
            FindVillager();
        }

        MoveEnemy();
    }

    private void FindVillager()
    {
        Debug.Log("FINDING VILLAGER");
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

    public void Engaged()
    {
        currentState = EnemyStates.Engaged;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Villager") && currentState != EnemyStates.Escaping && currentState != EnemyStates.Engaged)
        {
            EnemyController.successes++;
            collision.gameObject.SetActive(false);
            currentState = EnemyStates.Escaping;
        }
        else if (collision.CompareTag("Guard"))
        {
            currentState = EnemyStates.Engaged;
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