using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;


public class MainMenu : MonoBehaviour
{

    public TMP_Text highScoreUI;

    string newGameScene = "SampleScene";
    void Start()
    {
        int highScore = SaveLoadManager.Instance.LoadHighScore();
        highScoreUI.text = $"Top Wave Survived:{highScore}";
    }
   
    public void StartNewGame()
{
    
    SceneManager.LoadScene(1);
}

    public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

        Application.Quit();
#endif
    }


    
}
