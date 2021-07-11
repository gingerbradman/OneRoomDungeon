using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_script : MonoBehaviour
{
    public int NextScene;

    public List<Enemy_script> enemiesLeftList;
    public GameObject[] enemiesLeftArray;
    public int enemiesLeftInt;
    Flag_script flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("flag").gameObject.GetComponent<Flag_script>();
        
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
        
    }

    public void CallLevelComplete()
    {
        LevelComplete();
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(NextScene);
    }

    public void EnemyDied()
    {
        enemiesLeftInt -= 1;
        if(enemiesLeftInt == 0)
        {
            flag.gameObject.SetActive(true);
        }
    }
}
