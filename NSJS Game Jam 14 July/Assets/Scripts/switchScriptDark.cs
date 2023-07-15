using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScriptDark : MonoBehaviour
{
    public void onSwitch()
    {
        string LightScene = SceneManager.GetActiveScene().name.Replace("Dark", "");
        SceneManager.LoadScene(LightScene);
    }
}
