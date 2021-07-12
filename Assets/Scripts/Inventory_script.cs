using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_script : MonoBehaviour
{

    public static Inventory_script instance = null;
    [SerializeField] private bool fasterRate = false;
    public void setFasterRate(bool x){ fasterRate = x;}
    public bool getFasterRate(){return fasterRate;}
    [SerializeField] private bool strongerFireball = false;
    public void setStrongerFireball(bool x){ strongerFireball = x;}
    public bool getStrongerFireball(){return strongerFireball;}
    [SerializeField] private bool fasterRotation = false;
    public void setFasterRotation(bool x){ fasterRotation = x;}
    public bool getFasterRotation(){return fasterRotation;}
    [SerializeField] private bool fasterSpeed = false;   
    public void setFasterSpeed(bool x){ fasterSpeed = x;}
    public bool getFasterSpeed(){return fasterSpeed;}

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
