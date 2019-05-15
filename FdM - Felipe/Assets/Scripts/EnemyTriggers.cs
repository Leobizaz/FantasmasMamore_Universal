using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggers : MonoBehaviour
{
    [SerializeField] private bool triggerActivity;

    public GameObject enemyBatch;

    // Start is called before the first frame update
    void Start()
    {
        triggerActivity = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player") && triggerActivity)
        {
            enemyBatch.SetActive(true);
            triggerActivity = false;
        }
    }
}
