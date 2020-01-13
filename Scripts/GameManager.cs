using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives, score;
    public bool didWin;
    public Image heartPrefab;
    LevelManager lm;
    public Canvas parent;
    Image[] hearts;
    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        parent = FindObjectOfType<Canvas>();
        lm = GetComponent<LevelManager>();
 
        lives = 3;
        score = 0;
        //Draw 3 hearts
        hearts = new Image[3];
        Vector2 pos = new Vector2(490, 365);
        int HEART_SPACE = 35;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = heartPrefab;
            hearts[i] = Instantiate(hearts[i], pos, Quaternion.identity);
            hearts[i].transform.SetParent(parent.transform, false);
            pos.x -= HEART_SPACE;
        }
    }

    public void respawn(Transform p)
    {
        respawn(p.gameObject.GetComponent<CharacterController>());
    }

    public void respawn(CharacterController controller)
    {
        Debug.Log("Respawning player and removing a life.");
        removeLife();

        //teleport to checkpoint/level start 
        controller.enabled = false;
        lm.respawn();
        controller.enabled = true;
    }

    public void removeLife()
    {
        lives--;

        if (lives == 0)
            gameOver(false);

        //UI
        Destroy(hearts[lives]);
    }

    public void addScore()
    {
        score++;
        scoreText.text = score + "";
    }

    public int getLives()
    {
        return lives;
    }

    public int getScore()
    {
        return score;
    }

    public void gameOver(bool win)
    {
        if (win)
            didWin = true;
        else
            didWin = false;

        for (int i = 0; i < hearts.Length; i++)
            Destroy(hearts[i]);

        SceneManager.LoadScene("EndScene");
    }
}
