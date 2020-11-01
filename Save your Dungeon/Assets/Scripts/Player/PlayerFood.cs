using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFood : MonoBehaviour
{
	public Slider slider;
	public static int MaxFood = 100;
	public int CurrentFood;
	public GameObject Player;

	public Gradient gradient;
	public Image fill;

	public PlayerHealth PlayerHealth;

	//Set starting food
	void Start()
	{
		CurrentFood = MaxFood;
		SetMaxFood(MaxFood);
	}

	
	//Take damage and display on bar
	public void LooseFood(int FoodLost)
	{
		CurrentFood -= FoodLost;
		if (CurrentFood <= 0)
		{
			Debug.Log("You are mucho hungo");

			//PlayerHealth::TakeDamageOverTime();

			
		}
		SetFood(CurrentFood);
	}

	public int GetCurrentFood()
	{
		return this.CurrentFood;
	}



	//gain and display on bar
	public void GainFood(int FoodGained)
	{
		CurrentFood += FoodGained;
		SetFood(CurrentFood);
	}


	//Betrifft nur die bar selber
	public void SetFood(int food)
	{
		slider.value = food;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}


	public void SetMaxFood(int Food)
	{
		slider.maxValue = Food;
		slider.value = Food;

		//set it to most right value since it goes from o to 1
		fill.color = gradient.Evaluate(1f);
	}
}
