using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zebra : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;//速度
    float speed = 0.005f;
    float timer_f = 0f;
    int timer_i = 0;
    int x = 0;


    public Vector3 Velocity { get; private set; }
    public Vector3 GameObject;
    private void Update()
    {
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.0f, 10.0f), transform.position.y,
    transform.Translate(0, 0, 0.05f);
        Debug.Log(x);
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        Debug.Log(timer_i);
        transform.Translate(0, 0, 0.05f);
        if (Random.value < 0.8f)
        { 
            x = 15;
        }
        else
        {
            x = -15;
        }

        if (timer_f > 2)
        {
            transform.Rotate(0, x, 0);
            timer_f = 0;
        }
    }
}