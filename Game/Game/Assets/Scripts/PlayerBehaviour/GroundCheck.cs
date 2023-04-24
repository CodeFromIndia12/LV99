using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;

    private bool isGrounded;

    public bool IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, whatIsGround);

        return isGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, groundCheckRadius);
    }
}
