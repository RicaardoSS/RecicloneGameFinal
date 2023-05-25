using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string level1;

    public void Jogar()
    {
        SceneManager.LoadScene("lvl_1");
        Debug.Log("teste");
    }
}
