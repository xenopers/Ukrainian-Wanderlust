using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Character
{
    public float detectionRange = 5f;
    public Transform playerTransform;
    public float attackRange = 2f; 
    public float attackDelay = 1f;
    
    Animator animator;
    string state = "state";

    private bool isDeath = false;
    private bool canRun = true;
    private float timePressing = 0;

    private IEnumerator coroutine;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

         if (playerTransform != null && !isDeath)
        {
            
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position );

            if (distanceToPlayer <= detectionRange && distanceToPlayer > attackRange && canRun)
            {
                Vector3 direction = playerTransform.position - transform.position;
                direction.Normalize(); 
                transform.position += direction * moveSpeed * Time.deltaTime;
                animator.SetInteger(state, (int) EnemyStates.run);
            } 
            else if (distanceToPlayer <= attackRange)
            {
                animator.SetInteger(state, (int) EnemyStates.attack);
                canRun = false;
                timePressing += Time.deltaTime;
                if(timePressing >= attackDelay)
                {
                    Character character = playerTransform.GetComponent<PlayerController>();
                    Attack(character);
                    timePressing = 0;
                    Debug.Log("Ворог атакує гравця!");
                    canRun = true;
                }
                
            }
            else if(!canRun)
            {
                timePressing += Time.deltaTime;
                if(timePressing >= attackDelay)
                {
                    timePressing = 0;
                    canRun = true;
                }
                
            }
            else if(canRun)
            {
                animator.SetInteger(state, (int) EnemyStates.idle);
            }
            
        }
    }


        public IEnumerator waitToDie(float timeToDie)
        {
            isDeath = true;
            Collider2D collision = GetComponent<BoxCollider2D>();
            collision.isTrigger = true;
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Destroy(rb);
            
            animator.SetInteger(state, (int) EnemyStates.death);
           
            
            yield return new WaitForSeconds(timeToDie);
            
            Destroy(gameObject);
            Debug.Log(gameObject + " помирає");
        }

        public override void Die()
        {
            
            coroutine = waitToDie(4.0f);
            StartCoroutine(coroutine);
            
        
        }
        
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    enum EnemyStates 
    {
        idle = 0,
        run = 1,
        attack = 2,
        death = 3
    }

}
