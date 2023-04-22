using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float totalHealth = 5f;
    [SerializeField] private float flashLength = 0.2f;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private Color flashColor;
    [SerializeField] private Color origColor;

    private float healthPercentage;
    private float currentHealth;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = totalHealth;
        healthPercentage = currentHealth / totalHealth;

        healthBar.setMaxHealth(healthPercentage);
    }

    public void IsAttacked(float dmg)
    {
        currentHealth -= dmg;

        healthPercentage = currentHealth / totalHealth;

        healthBar.setHealth(healthPercentage);

        StartCoroutine(Flash());

        if (currentHealth <= 0)
        {
            Debug.Log("Player Is Dead!, Game Over!!");
        }
    }

    IEnumerator Flash()
    {
        ChangeSpriteColor(flashColor);

        yield return new WaitForSeconds(flashLength);

        ChangeSpriteColor(origColor);
    }

    private void ChangeSpriteColor(Color color)
    {
        spriteRenderer.color = color;
    }    
}
