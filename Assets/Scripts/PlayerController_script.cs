using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController_script : MonoBehaviour
{
    public float fireRate = 1f;
    public float rotateRate = 30f;
    bool allowFire = true;
    bool allowRotate = true;
    PlayerAimWeapon_script aimWeapon_Script;
    RoomRotation_script roomRotation_Script;
    TMP_Text fireBallText;
    TMP_Text rotateText;

    // Start is called before the first frame update
    void Start()
    {
        aimWeapon_Script = this.GetComponent<PlayerAimWeapon_script>();
        roomRotation_Script = GameObject.Find("Room").GetComponent<RoomRotation_script>();
        fireBallText = GameObject.Find("FireballReadyText").GetComponent<TextMeshProUGUI>();
        rotateText = GameObject.Find("RotateReadyText").GetComponent<TextMeshProUGUI>();
        fireBallText.text = "Fireball: Ready";
        rotateText.text = "Rotate: Ready";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && (allowFire))
        {
            StartCoroutine(Fire());
        }
        if(Input.GetKeyDown(KeyCode.Q) && (allowRotate) && (!roomRotation_Script.GetIsRotating()))
        {
            StartCoroutine(Rotate(1f));
        }
        else if(Input.GetKeyDown(KeyCode.E) && (allowRotate) && (!roomRotation_Script.GetIsRotating()))
        {
            StartCoroutine(Rotate(0f));
        }
    }

    IEnumerator Fire()
    {
        allowFire = false;
        fireBallText.text = "Fireball: Not Ready";
        aimWeapon_Script.HandleShooting();
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
        fireBallText.text = "Fireball: Ready";
    }

    IEnumerator Rotate(float x)
    {
        allowRotate = false;
        rotateText.text = "Rotate: Not Ready";
        roomRotation_Script.StartRotation(x);
        yield return new WaitForSeconds(rotateRate);
        allowRotate = true;
        rotateText.text = "Rotate: Ready";
    }
}
