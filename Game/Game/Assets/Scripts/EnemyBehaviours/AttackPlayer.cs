using System.Collections;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private bool isPlayerInRadius;

    [SerializeField] private float damageDealtByEnemy;
    [SerializeField] private float attackIntervalTime;
    [SerializeField] private Transform enemy;

    private void Update()
    {
        transform.position = enemy.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRadius = true;
            StartCoroutine(Attack(collision.GetComponent<HealthManager>()));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRadius = false;
        }
    }

    IEnumerator Attack(HealthManager healthManager)
    {
        while (isPlayerInRadius)
        {
            healthManager.IsAttacked(damageDealtByEnemy);

            yield return new WaitForSeconds(attackIntervalTime);
        }
    }
}
