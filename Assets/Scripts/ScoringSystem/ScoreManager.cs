using UnityEngine;
using Heal.Serialization;

namespace Heal.Scoring
{
    public class ScoreManager : MonoBehaviour
    {
        private ScoreCounter _scoreCounter;
        private ScoreUIUpdater _uiUpdater;

        private const string SCORE_KEY = "SCORE";
        public const string HIGHSCORE_KEY = "HIGHSCORE";

        private void Awake ()
        {
            _scoreCounter = GetComponent<ScoreCounter>();
            _uiUpdater = GetComponent<ScoreUIUpdater>();
        }

        private void Start ()
        {
            LoadScoreFromPlayerPrefs();
            _scoreCounter.Count();
            _uiUpdater.UpdateScoringUI(_scoreCounter.GetScore(), _scoreCounter.GetHighScore());
        }

        private void Update ()
        {
            _scoreCounter.Count();
            _uiUpdater.UpdateScoringUI(_scoreCounter.GetScore(), _scoreCounter.GetHighScore());
        }

        public void SaveScoreToPlayerPrefs ()
        {
            PlayerPrefsSaveSystem.SaveFloatToPlayerPrefs(ScoreCounter.HighestScore, HIGHSCORE_KEY);
        }

        private void LoadScoreFromPlayerPrefs ()
        {
            _scoreCounter.SetHighScore(PlayerPrefs.GetFloat(HIGHSCORE_KEY, 0));
        }

        private void OnApplicationQuit ()
        {
            SaveScoreToPlayerPrefs();
        }
        
        public static void ResetHighScore ()
        {
            PlayerPrefsSaveSystem.SaveFloatToPlayerPrefs(0, HIGHSCORE_KEY);
        }
    } 
}
