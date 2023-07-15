using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScript : MonoBehaviour
{
    void Switch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void onSwitch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name + "Dark");
    }
}
