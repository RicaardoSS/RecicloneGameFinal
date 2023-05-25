
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameOver;
    public static GameManager instance;
    void Start()
    {
        
    }

    void Awake()
{
    instance = this;
}

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        
    }

    public void RestartGame (string lvlName)
    {
     
          SceneManager.LoadScene("lvl_1");
    }

    public void LoadNextLevel()
{
    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    SceneManager.LoadScene(nextSceneIndex);
}
}
