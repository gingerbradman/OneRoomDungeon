using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_script : MonoBehaviour
{
    GameManager_script gameManager_Script;
    private void Start()
    {
        gameManager_Script = GameObject.Find("GameManager").GetComponent<GameManager_script>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 9)
        {
            gameManager_Script.CallLevelComplete();
        }
    }
}
