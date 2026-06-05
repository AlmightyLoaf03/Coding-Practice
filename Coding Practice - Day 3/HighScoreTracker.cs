using UnityEngine;
using System;

public class HighScoreTracker : MonoBehaviour
{
    void Start()
    {
        int[] scores = new int[]
        {
            5400,
            3200,
            1300,
            4100,
            2500
        };

        Debug.Log("==== Unsorted Scores ====");
        for (int i = 0; i < scores.Length; i++)
        {
            Debug.Log("Score " + i + ": " + scores[i]);
        }

        Debug.Log("==== Sorted Scores ====");
        for (int i = 0; i < scores.Length - 1; i++)
        {
            for (int j = 0; j < scores.Length - 1 - i; j++)
            {
                if (scores[j] < scores[j + 1])
                {
                    int temp = scores[j];

                    scores[j] = scores[j + 1];

                    scores[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < scores.Length; i++)
        {
            Debug.Log("Rank " + (i + 1) + ": " + scores[i]);
        }
    }
}
