using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject winUI; 
    [SerializeField] private GameObject pauseUI; 
    [SerializeField] private GameObject loseUI; 

    private void Start ()
    {
        gameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged (GameState obj)
    {
        switch (obj)
        {
            case GameState.Normal:
            winUI.SetActive(false);
            pauseUI.SetActive(false);
            loseUI.SetActive(false);
            break;

            case GameState.Paused:
            winUI.SetActive(false);
            pauseUI.SetActive(true);
            loseUI.SetActive(false);
            break;

            case GameState.Lose:
            winUI.SetActive(false);
            pauseUI.SetActive(false);
            loseUI.SetActive(true);
            break;

            case GameState.Win:
            winUI.SetActive(true);
            pauseUI.SetActive(false);
            loseUI.SetActive(false);
            break;
        }
    }

    private void OnDestroy ()
    {
        gameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
}
