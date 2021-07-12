using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBackButton_script : MonoBehaviour
{
    public PauseMenu_script pauseMenu_Script;

    public void Resume()
    {
        pauseMenu_Script.Resume();
    }

}
