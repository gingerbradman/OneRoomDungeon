using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerController_script : MonoBehaviour
{
    GameManager_script gameManager_Script;
    Inventory_script inventory_Script;
    PlayerMovement_script playerMovement_Script;
    AudioSource hurtSFX;
    public float fireRate;
    public float rotateRate;
    bool allowFire = true;
    bool allowRotate = true;
    public int speed;
    public int fireBallDamage;
    PlayerAimWeapon_script aimWeapon_Script;
    RoomRotation_script roomRotation_Script;
    TMP_Text fireBallText;
    Image playerFireballImage;
    public Sprite playerFireballReadySprite;
    public Sprite playerFireballNotReadySprite;
    Image playerRotationImage;
    public Sprite playerRotationReadySprite;
    public Sprite playerRotationNotReadySprite;

    // Start is called before the first frame update
    void Start()
    {
        aimWeapon_Script = this.GetComponent<PlayerAimWeapon_script>();
        playerMovement_Script = this.GetComponent<PlayerMovement_script>();
        hurtSFX = transform.Find("HurtSFX").GetComponent<AudioSource>();
        inventory_Script = GameObject.Find("Inventory").GetComponent<Inventory_script>();
        gameManager_Script = GameObject.Find("GameManager").GetComponent<GameManager_script>();
        roomRotation_Script = GameObject.Find("Room").GetComponent<RoomRotation_script>();
        playerFireballImage = GameObject.Find("Canvas").transform.Find("PlayerFireBallImage").GetComponent<Image>();
        playerRotationImage = GameObject.Find("Canvas").transform.Find("PlayerRotationImage").GetComponent<Image>();
        playerFireballImage.sprite = playerFireballReadySprite;
        playerRotationImage.sprite = playerRotationReadySprite;

        CheckInventory();
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

    public void Die()
    {
        gameManager_Script.GameOver();

        hurtSFX.Play();

        Destroy(this.gameObject.GetComponent<PlayerController_script>());
        Destroy(this.gameObject.GetComponent<PlayerMovement_script>());
        Destroy(this.gameObject.GetComponent<PlayerCollider_script>());
        Destroy(this.gameObject.transform.Find("Aim").gameObject);
        Destroy(this.gameObject.GetComponent<PlayerAimWeapon_script>());

    }

    public void CheckInventory()
    {
        if(inventory_Script.getFasterRate())
        {
            fireRate = fireRate / 2;
        }

        if(inventory_Script.getFasterRotation())
        {
            rotateRate = Mathf.RoundToInt(rotateRate / 2);
        }

        if(inventory_Script.getFasterSpeed())
        {
            playerMovement_Script.SetSpeed(speed + 3);
        }
        else
        {
            playerMovement_Script.SetSpeed(speed);
        }

        if(inventory_Script.getStrongerFireball())
        {
            fireBallDamage = fireBallDamage + 1;
        }
    }

    IEnumerator Fire()
    {
        allowFire = false;
        playerFireballImage.sprite = playerFireballNotReadySprite;
        aimWeapon_Script.HandleShooting();
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
        playerFireballImage.sprite = playerFireballReadySprite;
    }

    IEnumerator Rotate(float x)
    {
        allowRotate = false;
        playerRotationImage.sprite = playerRotationNotReadySprite;
        roomRotation_Script.StartRotation(x);
        yield return new WaitForSeconds(rotateRate);
        allowRotate = true;
        playerRotationImage.sprite = playerRotationReadySprite;
    }
}
