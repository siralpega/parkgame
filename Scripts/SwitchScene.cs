using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "MenuScene")
                SceneManager.LoadScene("GameScene");
            else if (SceneManager.GetActiveScene().name == "EndScene")
            {
                if (GameObject.Find("GM") != null)
                    Destroy(GameObject.Find("GM"));
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}
