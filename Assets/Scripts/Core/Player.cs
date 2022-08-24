using UnityEngine;
using CodeMonkey.HealthSystemCM;
using System;

namespace Heal.Components
{
    public class Player : StaticInstanceSingleton<Player>
    {
        public event Action OnDestroyed;
        public event Action OnReachedGoal;

        [SerializeField] private float damage;
        [SerializeField] private AudioSource healSoundSource;

        private IGetHealthSystem _iGetHealthSystem;
        private HealthSystem _healthSystem;

        protected override void Awake ()
        {
            base.Awake();
            _iGetHealthSystem = GetComponent<IGetHealthSystem>();
        }

        private void Start ()
        {
            _healthSystem = _iGetHealthSystem.GetHealthSystem();
            _healthSystem.OnDead += (object o, EventArgs e) =>
            {
                OnDestroyed?.Invoke();
                Destroy(gameObject);
            };
        }

        private void Update ()
        {
            _healthSystem.Damage(damage * Time.deltaTime);

            const float threshold = -20f;
            if (transform.position.y < threshold)
            {
                OnDestroyed?.Invoke();
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D (Collider2D collision)
        {
            CheckForHealers(collision);
            CheckForFinishZone(collision);
            CheckForSpike(collision);
        }

        private void CheckForHealers (Collider2D collision)
        {
            if (!collision.TryGetComponent(out Healer healer)) return;

            _healthSystem.Heal(healer.GetHealAmount());
            healer.OnHealerUsed();

            healSoundSource.Play();
        }

        private void CheckForFinishZone (Collider2D collision)
        {
            if (!collision.CompareTag("Finish")) return;

            OnReachedGoal?.Invoke();
        }

        private void CheckForSpike (Collider2D collision)
        {
            if (!collision.CompareTag("Spike")) return;

            _healthSystem.Die();
        }
    } 
}
