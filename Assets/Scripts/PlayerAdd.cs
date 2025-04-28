using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAdd : MonoBehaviour
{
    public float Health, MaxHealth;

    [SerializeField]
    private HealthBarUi healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            SetHealth(-10f);
        }
        if (Input.GetKeyDown("h"))
        {
            SetHealth(10f);
        }
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }
}
