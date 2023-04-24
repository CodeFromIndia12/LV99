using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private float damageDealtByPlayer;
    [SerializeField] private float x_Knockback;
    [SerializeField] private float y_Knockback;

    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HealthManager>().IsAttacked(damageDealtByPlayer);

            if (playerController.IsLookingRight()) //FOR SOME REASON, THIS IS REVERSED
            {
                collision.GetComponent<KnockBack>().AddKnockBack(x_Knockback, y_Knockback);
            }
            else
            {
                collision.GetComponent<KnockBack>().AddKnockBack(-x_Knockback, y_Knockback);
            }
        }

        gameObject.SetActive(false);
    }
}
