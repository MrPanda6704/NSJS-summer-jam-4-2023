using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    //public AudioSource[] footsteps;
    public AudioSource foot;
    public AudioSource Jump;
    public AudioSource Glide;
    public AudioSource Land;
    public AudioSource Drop;

    public void walk()
    {
        //int randomIndex = Random.Range(0, footsteps.Length);
        //foot = footsteps[randomIndex];
        foot.Play();

    }
    public void PlayerJump()
    {
        Jump.Play();
    }
    public void PlayerAngelGlide()
    {
        Glide.Play();
    }

    public void stopGlide()
    {
        Glide.Stop();
    }
    public void PlayerLand()
    {
        Land.Play();
    }
    public void PlayerDrop()
    {
        Drop.Play();
    }



}
