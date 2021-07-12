using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_script : MonoBehaviour
{
    public int NextScene;

    public bool powerUp;
    public Sprite tombStone;
    public List<Enemy_script> enemiesLeftList;
    public GameObject[] enemiesLeftArray;
    public int enemiesLeftInt;
    Object explosionRef;
    GameObject player;
    PlayerController_script playerController_Script;
    Flag_script flag;
    GameObject gameOverPanel;
    GameObject powerUpPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel = GameObject.Find("Canvas").gameObject.transform.Find("GameOverMenu").gameObject;
        explosionRef = Resources.Load("Explosion");
        player = GameObject.Find("Player").gameObject;
        playerController_Script = player.GetComponent<PlayerController_script>();
        flag = GameObject.Find("flag").gameObject.GetComponent<Flag_script>();
        
        if(powerUp)
        {
            powerUpPanel = GameObject.Find("Canvas").gameObject.transform.Find("PowerUpMenu").gameObject;
        }
        
        enemiesLeftArray = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < enemiesLeftArray.Length; i++)
        {
           enemiesLeftList.Add(enemiesLeftArray[i].GetComponent<Enemy_script>());
        } 
        enemiesLeftInt = enemiesLeftList.Count;

        if(enemiesLeftInt > 0)
        {
            flag.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesLeftInt == 0)
        {
            playerController_Script.rotateRate = 1f;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
        player.transform.Find("PlayerSprite").GetComponent<SpriteRenderer>().sprite = tombStone;
    }

    public void CallLevelComplete()
    {
        if(!powerUp){
            LevelComplete();
        }
        else
        {
            powerUpPanel.SetActive(true);
        }
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(NextScene);
    }

    public void PowerUpSelected()
    {
        LevelComplete();
    }

    public void EnemyDied()
    {
        enemiesLeftInt -= 1;
        if(enemiesLeftInt == 0)
        {
            playerController_Script.rotateRate = 1f;
            flag.gameObject.SetActive(true);
        }
    }
}
