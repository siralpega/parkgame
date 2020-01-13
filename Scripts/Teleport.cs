using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
 //   public Transform Destination;
    LevelManager lm;
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //  other.gameObject.transform.position = Destination.position;
            lm.switchLevel();
        }
    }

}
