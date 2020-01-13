using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform ballHold;
    SphereCollider[] colls;
    GameManager gm;
    public AudioClip hitClip;

    private void Start()
    {
        colls = GetComponents<SphereCollider>();
        gm = FindObjectOfType<GameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        //Trigger spawning ball
        if (other.gameObject.name == "Player" && ballHold.gameObject != null)
        {
            Destroy(ballHold.gameObject);
            if (colls[1].isTrigger)
                colls[1].enabled = false;
            else
                colls[0].enabled = false;
        }
        else if (other.gameObject.name == "Void")
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            gm.respawn(collision.gameObject.transform);
            collision.gameObject.GetComponent<AudioSource>().clip = hitClip;
            collision.gameObject.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }

}

