using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGameOver : MonoBehaviour
{
    public Text winText, scoreText;
    GameObject player;
    bool isWinner;
    Vector3 pos, moveDir;
    CharacterController con;

    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
        con = player.GetComponent<CharacterController>();
        pos = new Vector3(100f, 2f, -5.5f);
        if (scoreText == null)
            Debug.LogError("ERROR: ScoreText is null on GameOver scene");
        if (gm == null)
        {
            Debug.LogError("ERROR: GameManager is null on GameOver scene. Perhaps you didn't load the menu scene?");
            return;
        }
        if (winText == null)
            Debug.LogError("ERROR: WinText is null on GameOver scene");

        isWinner = gm.didWin;

        Destroy(gm);

        if (isWinner)
        {
            winText.text = "YOU WIN!";
            scoreText.text = "Score: " + gm.getScore();
        }
        else
        {
            winText.text = "GAME OVER!";
            scoreText.text = "";
        }
        player.transform.position = new Vector3(100f, 0.5f, -1.34f);
        Camera.main.transform.position = pos;
        Destroy(GameObject.Find("GM"));
    }
   
}
