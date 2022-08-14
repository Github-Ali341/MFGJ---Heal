using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject winUI; 
    [SerializeField] private GameObject pauseUI; 
    [SerializeField] private GameObject loseUI; 
    [SerializeField] private GameObject gameUI; 
    [SerializeField] private GameObject optionsUI; 

    private void Start ()
    {
        gameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged (GameState obj)
    {
        GameObject objToSetactiveTrue = obj switch
        {
            GameState.Win => winUI,
            GameState.Lose => loseUI,
            GameState.Paused => pauseUI,
            _ => null
        };

        if (objToSetactiveTrue == null)
        {
            winUI.SetActive(false);
            loseUI.SetActive(false);
            pauseUI.SetActive(false);
            optionsUI.SetActive(false);
            return;
        }

        objToSetactiveTrue.SetActive(true);
    }

    private void OnDestroy ()
    {
        gameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
}
