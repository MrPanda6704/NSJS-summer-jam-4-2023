using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repairScript : MonoBehaviour
{
    [SerializeField] float range = 4f;
    private GameObject[] repairables;
    private float min;
    private float itemDistance;
    private GameObject selectedObj;
    // Start is called before the first frame update
    void Start()
    {
        repairables = GameObject.FindGameObjectsWithTag("destructible");
        min = Vector2.Distance(transform.position, repairables[0].transform.position);
        selectedObj = repairables[0];
        foreach (var item in repairables)
        {
            item.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in repairables)
        {
            itemDistance = Vector2.Distance(transform.position, item.transform.position);
            if (min > itemDistance)
            {
                min = itemDistance;
                selectedObj = item;
            }
        }
    }

    public void OnRepair()
    {
        if (itemDistance < range)
        {
            selectedObj.SetActive(true);

        }
    }
}
