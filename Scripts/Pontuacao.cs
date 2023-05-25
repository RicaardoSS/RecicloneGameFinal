using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public int  totalScore;
    
    public static Pontuacao instance;



    void Start()
    {
        instance = this;
    }

   
}
