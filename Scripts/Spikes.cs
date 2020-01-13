using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Transform[] spikes;
    float timer;
    bool up;
    void Start()
    {
        spikes = GetComponentsInChildren<Transform>();
        for(int i = 1; i < spikes.Length; i++)
            spikes[i].position = new Vector3(spikes[i].position.x, -1.5f, spikes[i].position.z);

        timer = Random.Range(4f, 8f);
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            for (int i = 1; i < spikes.Length; i++)
            {
                if (up)
                    spikes[i].Translate(0, -1.3f, 0);
                else
                    spikes[i].Translate(0, 1.3f, 0);
            }
            if (up)
                timer = 4f;
            else
                timer = 2f;
            up = !up;
        }
    }
}
