using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float m_Health = 5;
    
    public void IsAttacked(float dmg)
    {
        m_Health -= dmg;
        Debug.Log("Dealt Damage To Player!");

        if (m_Health <= 0)
        {
            Debug.Log("Player Is Dead!, Game Over!!");
        }
    }
}
