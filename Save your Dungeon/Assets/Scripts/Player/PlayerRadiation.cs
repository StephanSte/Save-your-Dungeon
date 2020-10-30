using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRadiation : MonoBehaviour
{
	public Slider slider;
	public static int MinRadiation = 0;
	public int Radiation;
	public GameObject Player;

	public Gradient gradient;
	public Image fill;

	//Set starting Health
	void Start()
	{
		Radiation = MinRadiation;
		SetMaxRadiation(MinRadiation);
	}

	//TODO: Death Screen
	//Take damage and display on healthbar
	public void LooseRadiation(int radLost)
	{
		Radiation -= radLost;
		if (Radiation <= 0)
		{
			Debug.Log("You are mucho thirsty");

			PlayerHealth::TakeDamageOverTime();

			//Fadeout
			//Disable FPS controller
			//Player.SetActive(false);
			//show deathscreen "You dead the end of game restart game"
		}
		SetRadiation(Radiation);
	}

	public int GetCurrentRadiation()
	{
		return this.Radiation;
	}



	//gain and display on bar
	public void GainRadiation(int radGained)
	{
		Radiation += radGained;
		SetRadiation(Radiation);
	}


	//Betrifft nur die bar selber
	public void SetRadiation(int rad)
	{
		slider.value = rad;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}


	public void SetMaxRadiation(int rad)
	{
		slider.maxValue = rad;
		slider.value = rad;

		//set it to most right value since it goes from o to 1
		fill.color = gradient.Evaluate(1f);
	}
}
