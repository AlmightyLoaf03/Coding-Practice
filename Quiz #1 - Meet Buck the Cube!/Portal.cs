using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [Header("VFX")]
    public SpriteRenderer portalSprite;
    public float pulseSpeed = 2f;

    private bool activated = false;

    void Update()
    {
        if (!activated && portalSprite != null)
        {
            float alpha = Mathf.PingPong(Time.time * pulseSpeed, 1f);
            Color c = portalSprite.color;
            c.a = Mathf.Lerp(0.4f, 1f, alpha);
            portalSprite.color = c;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            if (portalSprite != null)
            {
                Color c = portalSprite.color;
                c.a = 1f;
                portalSprite.color = c;
            }

            Debug.Log("Buck reached the portal — YOU WIN!");
            GameManager.Instance.WinGame();
        }
    }
}
