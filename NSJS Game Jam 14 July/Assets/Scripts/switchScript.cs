using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class switchScript : MonoBehaviour
{
    public movementScript angel;
    public movementScript devil;
    public GameObject d;
    public GameObject a;
    public CinemachineVirtualCamera camera;
    void Switch()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        swap();
    }

    public void onSwitch()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name + "Dark");
        swap();
    }

    void swap()
    {
        if (angel.on == true)
        {
            angel.on = false;
            devil.on = true;
            camera.Follow = d.transform;
        } else {
            angel.on = true;
            devil.on = false;
            camera.Follow = a.transform;
        }
    }
}
