using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditScript : MonoBehaviour
{
    public GameManager gameManager;

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("BEGIN");
    }
}
