using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] float maxHealth = 100;

	[SerializeField] public float health;

	private bool isDead = false;

	public Action onDamage;
	public Action onHeal;
	public Action onDeath;

	private void Awake()
	{
		health = maxHealth;
	}

	public void OnApplyDamage(float damage)
	{
		if (isDead) return;

		if (GetComponent<PlayerMovement>()?.invinciblility < 0 || GetComponent<PlayerMovement>() == null)
		{ 
			health -= damage;
			health = Mathf.Clamp(health, 0, maxHealth);
			onDamage?.Invoke();
			if (health <= 0)
			{
				isDead = true;
				onDeath?.Invoke();
			}
		}
	}

	public void OnApplyHealth(float heal)
	{
		if (isDead) return;

		health += heal;
		health = Mathf.Clamp(health, 0, maxHealth);
		onHeal?.Invoke();
	}

}
