using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f, rotateSpeed = 2.5f, jump = 5f, gravity = 15f;
    Vector3 moveDir;
    Animator ani;
    CharacterController controller;
    GameManager gm;
    AudioSource audioSrc;
    public AudioClip coinClip, jumpClip, hitClip;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        audioSrc = GetComponent<AudioSource>();
        moveDir = Vector3.zero;

    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= moveSpeed;
            ani.SetBool("Grounded", true);
            if (Input.GetKeyDown(KeyCode.Space))
                moveDir.y = jump;
        }
        //Control while jumping
        else
        {
            moveDir = new Vector3(0, moveDir.y, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir.x *= moveSpeed;
            moveDir.z *= moveSpeed;
            ani.SetBool("Grounded", false);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        //Since we aren't using an RB, we make our own gravity:
        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);

        //Walking Animation
        if (moveDir.x == 0)
            ani.SetFloat("MoveSpeed", 0);
        else
            ani.SetFloat("MoveSpeed", moveDir.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        //   Debug.Log("DEBUG:Object " + gameObject.name + " has entered collider " + other.name);

        if (other.gameObject.name == "Void" || other.gameObject.name == "spike")
        {
            gm.respawn(controller);
            audioSrc.clip = hitClip;
            audioSrc.Play();
        }
        else if (other.gameObject.tag == "Coin")
        {
            gm.addScore();
            audioSrc.clip = coinClip;
            audioSrc.Play();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "JumpPad")
        {
            moveDir = new Vector3(transform.forward.x, jump * 3f, transform.forward.z);

            controller.Move(moveDir * Time.deltaTime);
            ani.SetBool("Grounded", false);
            audioSrc.clip = jumpClip;
            audioSrc.Play();
        }
    }
}

