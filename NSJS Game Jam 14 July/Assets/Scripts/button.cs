using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public float depth;
    private bool on;
    public float timer;
    private float time;
    public Collision2D c;
    public float range;
    public Spring[] springs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 c_pos = c.transform.position;
        Vector3 pos = transform.position;
        Vector3 diff = c_pos - pos;
        float mag = diff.magnitude;
        if (time > 0 && on == true && mag > range)
        {
            time --;
            if (time == 0)
            {
                turn_off();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (on == false)
        {
            turn_on(other);
        }
        time = timer;
    }

    public void turn_on(Collision2D other)
    {
        Vector3 pos = transform.position;
        pos.y -= depth;
        transform.position = pos;
        on = true;
        time = timer;
        c = other;
        for (int i = 0; i < springs.Length; i ++)
        {
            springs[i].on = true;
        }
    }

    public void turn_off()
    {
        Vector3 pos = transform.position;
        pos.y += depth;
        transform.position = pos;
        on = false;
        for (int i = 0; i < springs.Length; i ++)
        {
            springs[i].on = false;
        }
    }
}
