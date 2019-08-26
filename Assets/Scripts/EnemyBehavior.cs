using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Vector3 originPosition;
    Vector3 targetPosition;

    public bool isEngaged = false;
    public bool isReversed = false;

    private void OnEnable()
    {
        isEngaged = false;
        isReversed = false;
    }

    void Update()
    {
        if(isReversed && transform.position == originPosition) { EnemyController.successes++; gameObject.SetActive(false); }
        if(transform.position == targetPosition)
        {
            isEngaged = true;
        }
        if(isEngaged)
        {
            //Check for Traveler
            //if Traveler 
            isReversed = true;
        }
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 target;
        if(isReversed)
        {
            target = originPosition;
        }
        else
        {
            target = targetPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, EnemyController.enemySpeed * Time.deltaTime);
    }

    public void SetEnemy(Vector3 origin, Vector3 target)
    {
        originPosition = origin;
        targetPosition = target;

        transform.position = originPosition;
    }
}
