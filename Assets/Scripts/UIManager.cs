using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel;
    public TextMeshProUGUI highscoreText; 

    private void Start()
    {
        menuPanel.SetActive(true);
        UpdateHighscoreText(PlayerPrefs.GetInt("HighScore", 0)); 
    }

    public void StartEasyGame()
    {
        SceneManager.LoadScene("EasyModeScene");
        Debug.Log("test");
    }

    public void StartHardGame()
    {
        SceneManager.LoadScene("HardModeScene");
    }

    public void UpdateHighscoreText(int highscore)
    {
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
}
