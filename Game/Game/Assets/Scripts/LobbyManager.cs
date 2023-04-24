using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
