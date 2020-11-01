using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
	public static int MaxHealth = 100;
	public int CurrentHealth;
	public GameObject Player;

	public Gradient gradient;
	public Image fill;

	public PlayerFood PlayerFood;
	public PlayerWater PlayerWater;
	public PlayerRadiation playerRadiation;


	//Set starting Health
	void Start()
	{
		CurrentHealth = MaxHealth;
		SetMaxHealth(MaxHealth);	
	}

	//may work for damage over time not sure though
	/*private void LateUpdate()
	{
		if (PlayerWater.GetCurrentWater() <= 0 ||PlayerFood.GetCurrentFood() <= 0 || playerRadiation.isInRadiation == true)
		{
			StartCoroutine("TakeDamageOverTime", 1f);

		}
	}*/
    
    public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
		if (CurrentHealth <= 0)
		{
			Debug.Log("You are Dead NOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!");
			//Fadeout
			//Disable FPS controller
			//Player.SetActive(false);
			//show deathscreen "You dead the end of game restart game"
		}
		SetHealth(CurrentHealth);
	}

	IEnumerator TakeDamageOverTime() {
		yield return new WaitForSeconds(1);
		TakeDamage(1);
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
