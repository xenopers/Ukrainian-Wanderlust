using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class PlayerController : Character
{
    public float jumpForce = 7.5f;

    [SerializeField] private bool isRunning;
    private bool isGrounded = false;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;


    private float timePressing = 0;

    public float healingAmount = 10f;
    public float healingInterval = 5f;
    private float timer;


    Animator animator;

    string state = "state";

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        timer = healingInterval;
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            if (Input.GetButton("Horizontal"))
            {
                Move();
            }
            else
            {
                if (isRunning)
                    isRunning = false;
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetMouseButton(0))
        {
            timePressing += Time.deltaTime;
            if (timePressing > 0.6f)
            {
                AttackEnemy();
                timePressing = 0;
            }
        }
        else
        {
            timePressing = 0;
        }

        UpdateState();

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            HealPlayer();
            timer = healingInterval;
        }
    }

    private void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healingAmount;
            healthBar.fillAmount = currentHealth / maxHealth;
        }

    }

    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void AttackEnemy()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Character enemyHealth = enemy.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                Attack(enemyHealth);
                Debug.Log("Гравець атакує ворога!");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }

    private void Move()
    {
        if (!isRunning && Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        sprite.flipX = dir.x < 0.0f;
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * (isRunning ? moveSpeed : moveSpeed * 0.75f), rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void UpdateState()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetInteger(state, (int)CharStates.attack);
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetInteger(state, isRunning ? (int)CharStates.run : (int)CharStates.walk);
        }
        else
        {
            animator.SetInteger(state, (int)CharStates.idle);
        }
    }

    enum CharStates
    {
        idle = 0,
        run = 1,
        attack = 2,
        walk = 3
    }
}