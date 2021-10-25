using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    private float timer;
    private float timerDuration = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
