using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.transform.position;
        Vector3 new_pos = new Vector3(pos.x,pos.y,-10);
        transform.position = new_pos;
    }
}
