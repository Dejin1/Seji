using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VillagerController
{
    public static float minSpeed = 1.5f;
    public static float slowSpeed = 1.75f;
    public static float medSpeed = 2f;
    public static float highSpeed = 2.25f;
    public static float maxSpeed = 2.5f;

    public static List<Vector3> travelPoints;

    public static int successes = 0;
    public static int travelers = 0;

    public static bool isSpawning = true;
    public static float spawnTimer = 1f;
}
