using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject winUI; 
    [SerializeField] private GameObject pauseUI; 
    [SerializeField] private GameObject loseUI; 
    [SerializeField] private GameObject gameUI; 

    private void Start ()
    {
        gameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged (GameState obj)
    {
        winUI.SetActive(obj switch
        {
            GameState.Win => true,
            _ => false,
        });

        pauseUI.SetActive(obj switch
        {
            GameState.Paused => true,
            _ => false,
        });

        loseUI.SetActive(obj switch
        {
            GameState.Lose => true,
            _ => false,
        });

        gameUI.SetActive(obj switch
        {
            GameState.Normal => true,
            _ => false,
        });
    }

    private void OnDestroy ()
    {
        gameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
}
