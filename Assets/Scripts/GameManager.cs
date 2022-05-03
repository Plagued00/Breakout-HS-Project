using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static List<HighScore> highScores = new List<HighScore>();
    public static HighScore topScore = new HighScore();
    public static string playerName { get; set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScores();
    }

    public void GetTopScore()
    {
        topScore = highScores.Count > 0 ? highScores[0] : new HighScore() { Name = playerName, Score = 0 };
    }

    public void SaveScores()
    {
        var data = new SaveData() { scores = highScores };
        var json = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScores()
    {
        var file = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(file))
        {
            var json = File.ReadAllText(file);
            var data = JsonConvert.DeserializeObject<SaveData>(json);
            highScores = data.scores;
        }
    }

    public void AddHighScore(float score)
    {
        highScores.Add(new HighScore() { Name = playerName, Score = score });
        highScores.Sort(SortHighScoreDescending);
        if (highScores.Count > 5)
        {
            highScores = highScores.GetRange(0, 5);
        }
    }

    [System.Serializable]
    public class HighScore
    {
        public float Score { get; set; }
        public string Name { get; set; }
    }

    [System.Serializable]
    class SaveData
    {
        public List<HighScore> scores = new List<HighScore>();
    }

    static int SortHighScoreDescending(HighScore hs1, HighScore hs2)
    {
        return hs2.Score.CompareTo(hs1.Score);
    }

}
