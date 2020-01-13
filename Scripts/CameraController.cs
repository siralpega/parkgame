using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform[] targets;
    public GameObject posParent;
    Vector3 pos;
    int index = 1;
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        targets = posParent.GetComponentsInChildren<Transform>();
        pos = new Vector3(-79f, 10f, -146f);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targets[index].position, step);
        transform.LookAt(pos);
        if (Vector3.Distance(transform.position, targets[index].position) < 0.001f)
        {
            if (index == targets.Length - 1)
                index = 1;
            else
                index++;
        }
    }

    //happens after all other update functions have ran
    /*  private void LateUpdate()
      {
          Vector3 pos = transform.position;
          if (target.position.x > -5)  //camera doesn't center on player @ start & doesn't follow if goes left of start area
              pos.x = target.position.x;

          if (currlevel == 3 && target.position.y > -64)
                  pos.y = target.position.y;

          transform.position = pos;
      }

      //on respawn and level switch
      public void updatePosition(Transform player)
      {
          Vector3 pos = transform.position;

          pos.x = -5;
          pos.y = player.position.y + 5;

          transform.position = pos;

          currlevel = lm.level;
      } */
}
