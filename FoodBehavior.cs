using UnityEngine;
using System.Collections;
public class FoodBehavior : MonoBehaviour {
	public static float FoodPlayer;
	public float seconds;
	public float secondsh;
	public Texture food;
	public int FullFood = 100;
	void Start (){
		FoodPlayer = FullFood;
	}
	void Update (){
		seconds +=Time.deltaTime;
		if (seconds >= 10) {
			FoodPlayer -= 1;
			seconds = 0;

			if (FoodPlayer >= FullFood) {
				FoodPlayer = FullFood;
			} else if (FoodPlayer <= 0) {
				FoodPlayer = 0;
			}
		}
		       if (FoodPlayer <= 0) {
				secondsh +=Time.deltaTime;
				if (secondsh >= 1) {
					HealthBehavior.HealthPlayer --;
					secondsh = 0;
			}
		}
	}
	void OnGUI (){
		GUI.DrawTexture (new Rect (Screen.width / 30, Screen.height / 23, Screen.width / 7f/FullFood*FoodPlayer, Screen.height / 70), food);
	}
}