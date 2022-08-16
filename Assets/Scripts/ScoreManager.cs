using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float Score => _score;

    [SerializeField] private TextMeshProUGUI[] _scoreTexts;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private Transform scorersTransform;

    private float _score;
    private static float _highestScore;

    private Vector3 _position;
    private Vector3 _startingPosition;
    private float _distance;
    private float _farthestDistance;

    private const string SCORE_KEY = "SCORE";

    private void Start ()
    {
        LoadScoreFromPlayerPrefs();

        if (scorersTransform != null) _startingPosition = scorersTransform.position;

        for (int i = 0; i < _scoreTexts.Length; i++)
        {
            _scoreTexts[i].SetText("0"); 
        }

        UpdateScore();
    }

    private void Update ()
    {
        UpdateScore();
    }

    private void UpdateScore ()
    {
        if (scorersTransform != null) _position = scorersTransform.position;

        // To prevent getting score for going backwards.
        Vector3 direction = (_position - _startingPosition).normalized;
        if (direction.x < 0) return;

        _distance = Vector3.Distance(_position, _startingPosition);

        if (_distance > _farthestDistance)
        {
            _farthestDistance = _distance;
            _score = _farthestDistance;

            if (_score > _highestScore)
            {
                _highestScore = _score;
            }
        }

        for (int i = 0; i < _scoreTexts.Length; i++)
        {
            _scoreTexts[i].SetText(_score.ToString("0"));
        }

        _highScoreText.SetText(_highestScore.ToString("0"));
    }

    public void SaveScoreToPlayerPrefs ()
    {
        Save();
    }

    private static void Save ()
    {
        PlayerPrefs.SetFloat(SCORE_KEY, _highestScore);
        PlayerPrefs.Save();
    }

    private void LoadScoreFromPlayerPrefs ()
    {
        _highestScore = PlayerPrefs.GetFloat(SCORE_KEY, 0);
    }

    private void OnApplicationQuit ()
    {
        SaveScoreToPlayerPrefs();
    }

    public static void ResetHighScore ()
    {
        _highestScore = 0;
        Save();
    }
}
