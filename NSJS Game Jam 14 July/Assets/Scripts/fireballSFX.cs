using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballSFX : MonoBehaviour
{
    public AudioSource shootFireball;
    public AudioSource destroyObject;

    public void playShoot()
    {
        shootFireball.Play();
    }
    public void playCollision()
    {
        destroyObject.Play();
    }
}
