using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float delay;
    private GameObject enemyToSpawn;

    void Awake()
    {
        enemyToSpawn = transform.Find("FX_EnemySpawn").gameObject;
    }

    private void Start()
    {
        if(!IsInvoking("Spawn"))
        Invoke("Spawn", delay);
    }

    void Spawn()
    {
        enemyToSpawn.SetActive(true);
    }
}
