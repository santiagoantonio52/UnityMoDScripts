using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightController : MonoBehaviour
{
    private Light flashLight;
    public Text BatteryLevelIndicator; //controla o indicador de bateria mostrado na UI.

    private bool isAutoBool = false; //controla se o modo de luz alta está ativado/desativado.
    private bool isFailEffectBool = false; //controla se o efeito da lanterna falhando está ativado/desativado.
    private bool isFailJumpScareBool = true; //controla a ativação/desativação via tempo do efeito da lanterna falhando.

    private float isFailEffectCounter; //contador de tempo do efeito da lanterna falhando.
    private float isFailJumpScareCounter; //contador de tempo para ativação/desativação do efeito da laterna falhando.
    private float isBatteryLevelCounter; //contador de tempo para descarregamento da bateria da lanterna.

    public static int isBatteryLevel;//controla o nível de bateria da lanterna.


    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
        isBatteryLevel = 100; //bateria com 100% de carga.
    }
    public void BatteryLevel() //função que controla a carga na bateria da lanterna.
    {
        if (flashLight.enabled)
        {
            isBatteryLevelCounter += Time.deltaTime;
            if (isBatteryLevelCounter > 5)
            {
                isBatteryLevel -= 1;
                isBatteryLevelCounter = 0;
            }
            if (isBatteryLevel <= 0)// desativa a lanterna caso a carga seja menor que 1.
            {
                flashLight.enabled = false;
                BatteryLevelIndicator.text = ""; //desativa o indicador de bateria da tela.
            }
            if (isBatteryLevel >= 100)// não deixa a bateria exceder 100% de limite.
            {
                isBatteryLevel = 100;
            }
            else if (isBatteryLevel <= 0)//não deixa a bateria ter menos que 0% de carga.
            {
                isBatteryLevel = 0;
            }
            BatteryLevelIndicator.text = "BATERIA: " + isBatteryLevel + "%"; //indicador de texto sobre o nível de carga da bateria.
        }
    }
    // Update is called once per frame
    void Update()
    {
        BatteryLevel();//execução da função de carga na bateria da lanterna.

        if (Input.GetKeyDown("f")) //controla a ativação/desativação da lanterna.
        {
            if (isBatteryLevel <= 0 )// não ativa a laterna quando a carga for menor que 1.
            {
                flashLight.enabled = false;
                BatteryLevelIndicator.text = ""; //desativa o indicador de bateria da tela.

            }
            if (isBatteryLevel >= 1)//só ativa a laterna quando a carga for maior que 1.
            {
                flashLight.enabled = !flashLight.enabled;
                flashLight.intensity = 3;
            }
            if (!flashLight.enabled)
            {
                BatteryLevelIndicator.text = ""; //desativa o indicador de bateria da tela.
            }
        }

        if (Input.GetKeyDown("r")) //controla a ativação/desativação do modo de luz alta da lanterna.
        {
            (isAutoBool) = (!isAutoBool);
        }
        if (Input.GetKeyDown("t"))
        {
        }
        if (isFailJumpScareBool) //controla a ativação/desativação do efeito de falha na luz da lanterna.
        {
            isFailJumpScareCounter += Time.deltaTime;
            if (isFailJumpScareCounter > 25)
                isFailEffectBool = true;
            if (isFailJumpScareCounter > 30)
            {
                isFailEffectBool = false;
                isFailJumpScareCounter = 0;
            }
        }
        if (isAutoBool) //ativa o modo de luz alta da lanterna.
        {
            flashLight.spotAngle = 40;
            flashLight.range = 30;
        }
        if (!isAutoBool) //desativa o modo de luz alta da lanterna.
        {
            flashLight.spotAngle = 30;
            flashLight.range = 25;
        }
        if (isFailEffectBool) //ativa o efeito da laterna falhando.
        {
            isFailEffectCounter += Time.deltaTime;
            if (isFailEffectCounter > 1)
                flashLight.intensity = 0;
            if (isFailEffectCounter > 1.2f)
                flashLight.intensity = 0.5f;
            if (isFailEffectCounter > 1.8f)
                flashLight.intensity = 1.2f;
            if (isFailEffectCounter > 1.9f)
                flashLight.intensity = 0f;
            if (isFailEffectCounter > 2)
                flashLight.intensity = 0.5f;
            if (isFailEffectCounter > 2.2f)
            {
                flashLight.intensity = 3;
                isFailEffectCounter = 0;
            }
        }
    }
}