using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerAdd : MonoBehaviour
{
    // ref to health bar ui
    public RectTransform healthBar;

    public float maxHealth = 100f;
    private float currentHealth;

    private Vector2 originalSize;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        originalSize = healthBar.sizeDelta;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercent = currentHealth / maxHealth;
        healthBar.sizeDelta = new Vector2(originalSize.x * healthPercent, originalSize.y);
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        Time.timeScale = 1f;
        //same screen as portal
        SceneManager.LoadScene("Level1Portal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            Debug.Log("Player hit by projectile!");
            //damage taking from one projectile
            TakeDamage(20f);
            //no need to destroy projectile game obj -> does so once collides with player in bullet script
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Portal at end of level -> moves player to next scene
        if (collision.gameObject.CompareTag("Portal"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Level1Portal");
        }
    }
}
