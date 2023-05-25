using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenPlatform : MonoBehaviour
{
    public float tempoPlat;
    
    
    
    private TargetJoint2D target;
    private BoxCollider2D boxColl;
    
    
    
    
    
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
                if(collision.gameObject.tag == "Player")
                {
                    Invoke("Falling", tempoPlat);
                }
        }


        void Falling()
        {
            target.enabled = false;
            boxColl.isTrigger = true;
        }
}
