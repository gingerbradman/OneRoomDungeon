using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_script : MonoBehaviour
{
    public static SFX_script instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);    
    }
}
