using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Water : MonoBehaviour
{
    [Header("Drowning Config")]
    public float drowningTime = 5f;

    [Header("UI")]
    public TextMeshProUGUI waterTimerText;

    private float timer = 0f;
    private bool buckInWater = false;
    private BuckController buck;

    void Start()
    {
        if (waterTimerText != null)
            waterTimerText.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (!buckInWater) return;

        timer += Time.deltaTime;

        float remaining = drowningTime - timer;

        if (waterTimerText != null)
        {
            waterTimerText.text = "Drowning: " + remaining.ToString("F1") + "s";
            float danger = 1f - Mathf.Clamp01(remaining / drowningTime);
            waterTimerText.color = new Color(1f, 1f - danger, 0f);
        }

        if (timer >= drowningTime)
        {
            buckInWater = false;
            BuckController target = buck;
            buck = null;
            timer = 0f;
            HideTimer();
            target.Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buck = other.GetComponent<BuckController>();
            buckInWater = true;
            timer = 0f;

            if (waterTimerText != null)
                waterTimerText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buckInWater = false;
            timer = 0f;
            buck = null;
            HideTimer();
        }
    }

    public void HideTimer()
    {
        if (waterTimerText != null)
        {
            waterTimerText.text = "";
            waterTimerText.gameObject.SetActive(false);
        }
    }
}
