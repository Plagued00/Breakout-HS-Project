using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public void StartNew()
    {
        GameManager.playerName = playerName.text;
        GameManager.instance.GetTopScore();
        SceneManager.LoadScene(1);
    }

    public void ShowHighscores()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        GameManager.instance.SaveScores();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

