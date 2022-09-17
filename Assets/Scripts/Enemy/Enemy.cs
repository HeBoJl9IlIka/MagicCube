using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _defaultHealth;
    [SerializeField] private Player _player;

    private int _health;

    public event UnityAction Deaded;
    public event UnityAction<Player> Damaged;
    public event UnityAction<Player> Healed;

    private void Start()
    {
        _health = _defaultHealth;
    }

    public void TakeDamage(int value)
    {
        _health -= value;

        Damaged?.Invoke(_player);

        if (_health <= 0)
            Deaded?.Invoke();
    }

    public void TakeHealing(int value)
    {
        _health += value;

        Healed?.Invoke(_player);

        if (_health >= _defaultHealth)
            _health = _defaultHealth;
    }
}
