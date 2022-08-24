using UnityEngine;
using Heal.Scoring;
using UnityEngine.SceneManagement;

public class UIMethods : MonoBehaviour
{
    public void ResetHighScore ()
    {
        ScoreManager.ResetHighScore();
    }

    public void LoadScene (int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadNext ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPrevious ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadCurrent ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitApp ()
    {
        Application.Quit();
    }
}
