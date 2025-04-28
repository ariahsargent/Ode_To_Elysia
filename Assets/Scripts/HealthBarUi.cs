using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * Code created by: Ariah Sargent
 * Year: 2025
 * For GIMM Individual Game at Boise State University
 * References used:
 *  Gatsby on YouTube -> Simple Health Bar Unity Tutorial
 *      https://www.youtube.com/watch?v=IYZayXViTN8&ab_channel=Gatsby
 *  ChaptGPT -> for lots of troubleshooting
 *      https://chatgpt.com/share/680f673d-5e80-8007-bf36-b2ef3eee7008
 * 
 */

public class HealthBarUi : MonoBehaviour
{
    public float Health, MaxHealth, Width, Height;

    [SerializeField]
    private RectTransform healthBar;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = (Health / MaxHealth) * Width;

        healthBar.sizeDelta = new Vector2 (newWidth, Height);
    }
}
