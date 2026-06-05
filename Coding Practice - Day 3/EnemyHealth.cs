using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] enemyHealth = new int[]
        {
            100,
            80,
            60,
            40,
            10
        };

        Debug.Log("==== Enemy Health ====");
        for (int i = 0; i < enemyHealth.Length; i++)
        {
            Debug.Log("Enemy " + i + ": " + enemyHealth[i] + " HP");
        }

        Debug.Log("==== Damaging the Enemy ====");
        for (int i = 0; i < enemyHealth.Length; i++)
        {
            enemyHealth[i] -= 10;
            Debug.Log("Enemy " + i + " has taken 10 damage: " + enemyHealth[i] + " HP");

            if (enemyHealth[i] == 0)
            {
                Debug.Log("Enemy " + i + " is dead!");
            }  
        }
    }
}
