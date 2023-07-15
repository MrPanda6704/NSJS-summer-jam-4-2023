using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    public GameObject bullet;
    public movementScript player;
    private float dir;
    [SerializeField] float summonDistance = 2f;
    
    // Start is called before the first frame update

    
    public void OnFire()
    {
        if (player.on)
        {
            if(player.isFacingRight)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }
         Instantiate(bullet, transform.position + new Vector3(summonDistance * dir, 0, 0), transform.rotation);
        }
    }
}
