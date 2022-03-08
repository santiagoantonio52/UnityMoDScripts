using UnityEngine;
using System.Collections;
public class HealthBehavior : MonoBehaviour {
    public static float HealthPlayer;
	public Texture health;
	public int FullHealth = 100;
	void Start (){
		HealthPlayer = FullHealth;
	}
	void Update (){
		if (HealthPlayer >= FullHealth) {
			HealthPlayer = FullHealth;
		} else if (HealthPlayer <= 0) {
			HealthPlayer = 0;
		}
	}
	void OnGUI (){
		GUI.DrawTexture (new Rect (Screen.width / 30, Screen.height / 40, Screen.width / 7f/FullHealth*HealthPlayer, Screen.height / 70), health);
	}
}