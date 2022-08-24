using UnityEngine;
using TMPro;

namespace Heal.Scoring
{
	public class ScoreUIUpdater : MonoBehaviour
	{
        [SerializeField] private TextMeshProUGUI[] scoreTexts;
        [SerializeField] private TextMeshProUGUI[] highScoreTexts;

        public void UpdateScoringUI (float score, float highScore)
        {
            for (int i = 0; i < scoreTexts.Length; i++)
            {
                scoreTexts[i].text = score.ToString("0");
            }

            for (int i = 0; i < highScoreTexts.Length; i++)
            {
                highScoreTexts[i].text = highScore.ToString("0");
            }
        }
    } 
}
