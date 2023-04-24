using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private bool isPlayerInRadius;

    [SerializeField] private float damageDealtByEnemy;
    [SerializeField] private float attackIntervalTime;
    [SerializeField] private Transform enemy;

    [SerializeField] private float x_knockback;
    [SerializeField] private float y_knockback;

    private float currentTime;

    private HealthManager healthManager;
    private KnockBack playerKnockback;

    private void Start()
    {
        currentTime = attackIntervalTime;
    }

    private void Update()
    {
        transform.position = enemy.position;

        if (isPlayerInRadius && currentTime <= 0)
        {
            healthManager.IsAttacked(damageDealtByEnemy);

            if (enemy.GetComponent<SlimeBehaviour>().isPlayerOnRight())
            {
                playerKnockback.AddKnockBack(-x_knockback, y_knockback);
            }
            else
            {
                playerKnockback.AddKnockBack(x_knockback, y_knockback);
            }

            currentTime = attackIntervalTime;
        }
        else if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRadius = true;

            healthManager = collision.GetComponent<HealthManager>();
            playerKnockback = collision.GetComponent<KnockBack>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRadius = false;
        }
    }

}
