using UnityEngine;

namespace Heal.Scoring
{
	public class ScoreCounter : MonoBehaviour
	{
        [SerializeField] private Transform scorersTransform;

        private float _score;
        private static float _highestScore;

        private Vector3 _position;
        private Vector3 _startingPosition;
        private float _distance;
        private float _farthestDistance;

        public static float HighestScore => _highestScore;

        private void Awake ()
        {
            _startingPosition = scorersTransform.position;
            Count();
        }

        public void Count ()
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
        }

        public float GetScore () => _score;
        public float GetHighScore () => _highestScore;
        public float SetHighScore (float newScore) => _highestScore = newScore;
	} 
}
