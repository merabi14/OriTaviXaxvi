using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public static bool boostDestroyed = false;

    [SerializeField] Transform[] boostSpawnPoints;
    [SerializeField] GameObject speedUp;

    private void Start()
    {
        SpawnBoost();
    }
    private void Update()
    {
        if (boostDestroyed)
        {
            SpawnBoost();
            boostDestroyed = false;
        }
    }
    void SpawnBoost()
    {
        int i = Random.Range(0, (boostSpawnPoints.Length - 1));
        Instantiate(speedUp, boostSpawnPoints[i].position, boostSpawnPoints[i].rotation);
    }

}
