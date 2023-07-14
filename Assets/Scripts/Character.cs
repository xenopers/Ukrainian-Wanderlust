using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Character : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int attackDamage;
    public float moveSpeed;

    public Image healthBar;


    public void TakeDamage(int damage)
    {   
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {

            Die();
            
        }
    }

    public void Attack(Character character)
    {
        if(character != null)
        {
            character.TakeDamage(attackDamage); 
            character.healthBar.fillAmount = character.currentHealth / character.maxHealth;
        }
        
    }


    public virtual void Die()
    {
        Destroy(gameObject);
        Debug.Log(gameObject + " помирає");
    }
}
