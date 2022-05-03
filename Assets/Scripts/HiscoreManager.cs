using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiscoreManager : MonoBehaviour
{
    public TextMeshProUGUI Names;
    public TextMeshProUGUI Scores;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var item in GameManager.highScores)
        {
            Names.text += item.Name + System.Environment.NewLine;
            Scores.text += item.Score + System.Environment.NewLine;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
