using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BuckController buck = other.GetComponent<BuckController>();
            if (buck != null)
            {
                buck.Die();
            }
        }
    }
}
