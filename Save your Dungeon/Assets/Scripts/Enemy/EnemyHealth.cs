using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public Slider slider;
	public static int MaxHealth = 100;
	public int CurrentHealth;
	public GameObject Enemy;

	public Gradient gradient;
	public Image fill;

	public EnemyAI EnemyAI;

	//Set starting Health
	void Start()
	{
		CurrentHealth = MaxHealth;
		SetMaxHealth(MaxHealth);
	}

	//Take damage and display on healthbar
	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
		if (CurrentHealth <= 0)	EnemyAI.DestroyEnemy();
		SetHealth(CurrentHealth);
	}

	//Heal and display on Healthbar
	public void HealDamage(int healingPoints)
	{
		CurrentHealth += healingPoints;
		SetHealth(CurrentHealth);
	}


	//Betrifft nur die Healthbar selber
	public void SetHealth(int health)
	{
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}


	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		//set it to most right value since it goes from o to 1
		fill.color = gradient.Evaluate(1f);
	}
}
