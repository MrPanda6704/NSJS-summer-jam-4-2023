using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repairScript : MonoBehaviour
{
    public movementScript angelPlayerScript;
    [SerializeField] float range = 4f;
    public GameObject[] repairables;
    private float min;
    private float itemDistance;
    private GameObject selectedObj;
    // Start is called before the first frame update
    void Awake()
    {
        selectedObj = repairables[0];
    }

    // Update is called once per frame
    void Update()
    {
        min = float.MaxValue;
        foreach (GameObject obj in repairables)
        {
            itemDistance = Vector2.Distance(transform.position, obj.transform.position);
            if (itemDistance < min && obj.activeSelf == false)
            {
                min = itemDistance;
                selectedObj = obj;
            }
        }
    }

    public void OnRepair()
    {
        if (angelPlayerScript.on)
        {
            if (min <= range)
            {
                selectedObj.SetActive(true);

            }
        }

    }
}
