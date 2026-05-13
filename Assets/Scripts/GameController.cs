using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public string CurrentUserName;
    public string BestScoreUserName;
    public int BestScoreValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadBestScoreData();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class ScoreData
    {
        public string name;
        public int score;
    }

    public void LoadBestScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            BestScoreUserName = data.name;
            BestScoreValue = data.score;
        }
    }

    public void SaveBestScoreData(int score)
    {
        ScoreData data = new ScoreData();
        data.name = CurrentUserName;
        data.score = score;
        BestScoreUserName = CurrentUserName;
        BestScoreValue = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void HandleCurrentPoints(int points)
    {
        if (points > BestScoreValue)
        {
            SaveBestScoreData(points);
        }
    }
}
