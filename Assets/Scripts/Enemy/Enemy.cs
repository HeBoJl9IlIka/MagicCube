using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _defaultHealth;

    private int _health;

    public event UnityAction Deaded;
    public event UnityAction<Transform> Damaged;
    public event UnityAction<Transform> Healed;

    private void Start()
    {
        _health = _defaultHealth;
    }

    public void TakeDamage(int value, Transform position)
    {
        _health -= value;

        Damaged?.Invoke(position);

        if (_health <= 0)
            Deaded?.Invoke();
    }

    public void TakeHealing(int value,Transform position)
    {
        _health += value;

        Healed?.Invoke(position);

        if (_health >= _defaultHealth)
            _health = _defaultHealth;
    }
}
