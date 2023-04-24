using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float totalHealth = 5f;
    [SerializeField] private float flashLength = 0.2f;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private Color flashColor;
    [SerializeField] private Color origColor;

    [SerializeField] private bool isPlayer;

    [SerializeField] private Transform objectTransform;

    private float healthPercentage;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = totalHealth;
        healthPercentage = currentHealth / totalHealth;

        if (healthBar != null)
            healthBar.setMaxHealth(healthPercentage);
    }

    public void IsAttacked(float dmg)
    {
        currentHealth -= dmg;

        healthPercentage = currentHealth / totalHealth;

        if (healthBar != null)
            healthBar.setHealth(healthPercentage);

        StartCoroutine(Flash());

        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                Debug.Log("Player Is Dead!!");
            }
            else
            {
                GameObject.Destroy(objectTransform.gameObject);
            }
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
