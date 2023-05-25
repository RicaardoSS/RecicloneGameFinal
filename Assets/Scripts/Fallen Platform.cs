using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen : MonoBehaviour
{
    public float tempoPlat;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;
    private Vector2 startPos;
    private bool isFalling;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
        startPos = transform.position;
        isFalling = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isFalling)
        {
            Invoke("Falling", tempoPlat);
        }

        if(collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        isFalling = true;
        target.enabled = false;
        boxColl.isTrigger = true;

        Invoke("ResetPlatform", 2f);
    }

    void ResetPlatform()
    {
        isFalling = false;
        transform.position = startPos;
        target.enabled = true;
        boxColl.isTrigger = false;
    }
}
