using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springyness;
    private float og_position;
    public float drop_speed;
    public bool on;
    private GameObject[] objects = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        og_position = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        if (on == true && pos.y < og_position + springyness && drop_speed > 0)
        {
            pos.y += drop_speed;
        }
        if (on == true && pos.y > og_position - springyness && drop_speed < 0)
        {
            pos.y += drop_speed;
        }
        if (on == false && pos.y > og_position)
        {
            pos.y -= Mathf.Abs(drop_speed);
        }
        if (on == false && pos.y < og_position)
        {
            pos.y += Mathf.Abs(drop_speed);
        }
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //GameObject g = other.gameObject;
        //add(g);
    }

    void add (GameObject g)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] == null)
            {
                objects[i] = g;
                return;
            }
        }
    }
}
