using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverText, RestartButton, LevelComplete;
    // public ShowScore showScore;
    
    public void CompleteLevel()
    {
        Debug.Log("Level Complete!!");
        
        LevelComplete.SetActive(true);
        
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        GameOverText.SetActive(true);
    }
    public void GameOver()
    {
        EndGame();
        Restart();
    }
    public void Restart()
    {
        RestartButton.SetActive(true);
    }

}
