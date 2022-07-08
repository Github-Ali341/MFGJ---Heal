using UnityEngine;
using CodeMonkey.HealthSystemCM;
using System;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public event Action OnDestroyed;
    public event Action OnReachedGoal;

    [SerializeField] private float damagePerFrame;

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
        _healthSystem.Damage(damagePerFrame * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        CheckForHealers(collision);
        CheckForFinishZone(collision);
    }

    private void CheckForHealers (Collider2D collision)
    {
        if (!collision.TryGetComponent(out Healer healer)) return;

        _healthSystem.Heal(healer.GetHealAmount());
        healer.OnHealerUsed();
    }

    private void CheckForFinishZone (Collider2D collision)
    {
        if (!collision.CompareTag("Finish")) return;

        OnReachedGoal?.Invoke();
    }
}
