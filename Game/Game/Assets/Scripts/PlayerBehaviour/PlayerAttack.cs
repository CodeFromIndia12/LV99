using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;

    [SerializeField] private GameObject attackArea;
    
    private InputAction attack;

    [SerializeField] private float attackIntervalTime;

    private float currentAttackInterval;

    private bool canAttack;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        attack = playerInput.actions["Attack"];

        attack.performed += Attack;

        currentAttackInterval = attackIntervalTime;
    }

    private void Update()
    {
        if (currentAttackInterval > 0)
        {
            currentAttackInterval -= Time.deltaTime;
            canAttack = false;
        }
        else if (currentAttackInterval <= 0.01f)
        {
            canAttack = true;
        }
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            attackArea.SetActive(true);
            currentAttackInterval = attackIntervalTime;
            canAttack = false;
        } 

    }

    private void OnDisable()
    {
        attack.performed -= Attack;
    }
}
