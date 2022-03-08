using UnityEngine;
using System.Collections;
public class DrinkBehavior : MonoBehaviour {
	public static float DrinkPlayer;
	public float seconds;
	public float secondsh;
	public Texture Drink;
	public int FullDrink = 100;
	void Start (){
		DrinkPlayer = FullDrink;
	}
	void Update (){
		seconds +=Time.deltaTime;
		if (seconds >= 5) {
			DrinkPlayer -= 1;
			seconds = 0;

		if (DrinkPlayer >= FullDrink) {
			DrinkPlayer = FullDrink;
		} else if (DrinkPlayer <= 0) {
			DrinkPlayer = 0;
		}
	}
	if (DrinkPlayer <= 0) {
		secondsh +=Time.deltaTime;
		if (secondsh >= 1) {
			HealthBehavior.HealthPlayer --;
			secondsh = 0;
		}
	}
}
	void OnGUI (){
		GUI.DrawTexture (new Rect (Screen.width / 30, Screen.height / 16, Screen.width / 7f/FullDrink*DrinkPlayer, Screen.height / 70), Drink);

	}
}