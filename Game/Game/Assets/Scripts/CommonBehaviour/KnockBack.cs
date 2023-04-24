using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public void AddKnockBack(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
    }
}
