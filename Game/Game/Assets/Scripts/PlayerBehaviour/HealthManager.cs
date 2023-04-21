using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 5f;
    [SerializeField] private float flashLength = 0.2f;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color flashColor;
    [SerializeField] private Color origColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void IsAttacked(float dmg)
    {
        health -= dmg;
        Debug.Log("Dealt Damage To Player!");

        StartCoroutine(Flash());

        if (health <= 0)
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
