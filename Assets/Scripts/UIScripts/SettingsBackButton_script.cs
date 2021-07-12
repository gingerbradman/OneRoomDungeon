using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBackButton_script : MonoBehaviour
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
        mainMenu.SetActive(true);
        settingsPanel.SetActive(false);
    }

}
