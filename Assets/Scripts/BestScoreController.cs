using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreController : MonoBehaviour
{
    private Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateBestScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBestScoreUI()
    {
        if (GameController.Instance.BestScoreUserName != "")
        {
            scoreText.text = "Best Score : " + GameController.Instance.BestScoreUserName + " : " + GameController.Instance.BestScoreValue;
        }
    }
}
