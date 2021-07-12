using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_script : MonoBehaviour
{
    public static Music_script instance = null;

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
