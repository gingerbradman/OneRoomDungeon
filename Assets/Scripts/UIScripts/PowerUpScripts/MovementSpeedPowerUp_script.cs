using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedPowerUp_script : MonoBehaviour
{
    Inventory_script inventory_Script;
    GameManager_script gameManager_Script;

    private void Start() 
    {
        gameManager_Script = GameObject.Find("GameManager").GetComponent<GameManager_script>();    
        inventory_Script = GameObject.Find("Inventory").GetComponent<Inventory_script>();
    }

    public void OnClick()
    {
        inventory_Script.setFasterSpeed(true);
        gameManager_Script.PowerUpSelected();
    }
}
