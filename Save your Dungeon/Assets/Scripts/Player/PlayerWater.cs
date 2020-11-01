using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWater : MonoBehaviour
{
	public Slider slider;
	public static int MaxWater = 100;
	public int CurrentWater;
	public GameObject Player;

	public Gradient gradient;
	public Image fill;

	public PlayerHealth PlayerHealth;

	
	void Start()
	{
		CurrentWater = MaxWater;
		SetMaxWater(MaxWater);
	}

	
	public void LooseWater(int WaterLost)
	{
		CurrentWater -= WaterLost;
		if (CurrentWater <= 0)
		{
			Debug.Log("You are mucho thirsty");
			//take damage here
			
		}
		SetWater(CurrentWater);
	}
	
	//gain and display on bar
	public void GainWater(int WaterGained)
	{
		CurrentWater += WaterGained;
		SetWater(CurrentWater);
	}
	
	public int GetCurrentWater()
    {
		return this.CurrentWater;
    }

	//Betrifft nur die bar selber
	public void SetWater(int health)
	{
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}


	public void SetMaxWater(int Water)
	{
		slider.maxValue = Water;
		slider.value = Water;

		//set it to most right value since it goes from o to 1
		fill.color = gradient.Evaluate(1f);
	}
}
