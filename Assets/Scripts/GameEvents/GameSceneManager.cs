using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(index);
    }

    public void MainMenu()
    {
        LoadScene(0);
    }

    public void Game()
    {
        LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame(TextMeshProUGUI input)
    {
        PlayerPrefs.SetString("PlayerName", input.text);
        Game();
    }
}