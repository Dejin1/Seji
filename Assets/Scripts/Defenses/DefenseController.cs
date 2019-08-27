using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefenseController
{
    public static float patrolSpeed = 1.5f;
    public static float vanguardRadius = 2.0f;
    public static float archerRadius = 3.5f;
    public static float vanguardSpeed = 2.0f;
    public static float attackDelay = 1f;
    public static int defenses = 0;
    public static List<Vector3> patrolPoints;
}
