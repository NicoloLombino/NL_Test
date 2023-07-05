using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void OpenPortfolio()
    {
        Application.OpenURL("https://niclombportfolio.altervista.org/");
    }
}
