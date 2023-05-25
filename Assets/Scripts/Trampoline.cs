using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Start is called before the first frame update



    private Animator anim;
    void Start()
    {
     anim =  GetComponent<Animator>();   
    }


    public float JumpForce; 
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"  )
        {

            anim.SetTrigger("Jump");

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

        }
    }
}
