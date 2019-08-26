using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyController
{
    public static float enemySpeed = 2f;

    public static List<Vector3> spawners;
    public static List<Vector3> targets;

    public static int successes = 0;
    public static int attacked = 0;

    public static bool isSpawning = true;
    public static float spawnTimer = 2f;
}
