using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;
    GameObject start, player, levelGO;
    GameManager gm;
    
    void Start()
    {
        level = 1;
        gm = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
        levelGO = GameObject.Find("Level 1");
        start = levelGO.transform.Find("LevelStart").gameObject;
        respawn();
       
    }

    public void switchLevel()
    {
        switchLevel(++level);
    }

    public void switchLevel(int num)
    {
        level = num;
        if(level > 3)
        {
            gm.gameOver(true);   
        }
        else
        {
            Debug.Log("Executing level switch to level " + level);
            levelGO = GameObject.Find("Level " + level);
            start = levelGO.transform.Find("LevelStart").gameObject;
            //   start.transform.position = levelGO.transform.Find("LevelStart").position;
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            respawn();
            cc.enabled = true;
        }
    }

    public void respawn()
    {
        player.transform.position = start.transform.position;
        player.transform.rotation = start.transform.rotation;

        //update camera
     //   cam.updatePosition(player.transform);
    }

   
}
