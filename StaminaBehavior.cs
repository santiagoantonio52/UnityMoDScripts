using UnityEngine;
using System.Collections;
public class StaminaBehavior : MonoBehaviour {
public Texture Stamina;
public float FullStamina = 5;
private float Energy;
void Start (){
	Energy = FullStamina;
}
void Update (){
	if (Input.GetKey (KeyCode.LeftShift)) {
		Energy -= Time.deltaTime;
	} else {
		Energy += Time.deltaTime;
	}
	if (Energy > FullStamina) {
		Energy = FullStamina;
	} else if (Energy < 0) {
		Energy = 0;
		}
	}
	void OnGUI (){
		GUI.DrawTexture (new Rect (Screen.width / 30, Screen.height / 12, Screen.width / 10f/FullStamina*Energy, Screen.height / 70), Stamina);
	}
}