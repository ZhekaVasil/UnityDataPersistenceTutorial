using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScoreText;
    private void Start()
    {
        if (GameController.Instance.BestScoreValue > 0)
        {
            bestScoreText.text = "Best Score: " + GameController.Instance.BestScoreValue;
        }
       
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnNameChange(string name)
    {
        GameController.Instance.CurrentUserName = name;
    }
}
