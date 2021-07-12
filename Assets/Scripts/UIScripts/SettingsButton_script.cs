using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton_script : MonoBehaviour
{

    GameObject mainMenu;
    GameObject settingsPanel;

    private void Start() 
    {
        mainMenu = GameObject.Find("Canvas").transform.Find("MainMenuPanel").gameObject;
        settingsPanel = GameObject.Find("Canvas").transform.Find("SettingsPanel").gameObject;
    }

    public void OnClick()
    {
        settingsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
}
