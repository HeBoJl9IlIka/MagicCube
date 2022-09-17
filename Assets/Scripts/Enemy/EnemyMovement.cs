using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _duration;
    [SerializeField] private float _force;

    private Rigidbody _rigidbody;
    private Enemy _enemy;
    private Tween _currentTween;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();

        _enemy.Damaged += OnDamaged;
        _enemy.Healed += OnHealed;
        _playerMovement.Moving += OnMoving;
    }

    private void OnDisable()
    {
        _enemy.Damaged -= OnDamaged;
        _enemy.Healed -= OnHealed;
        _playerMovement.Moving -= OnMoving;
    }

    private void OnDamaged(Transform targetPosition)
    {
        _rigidbody.AddRelativeForce(transform.position + targetPosition.position * _force * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnHealed(Transform targetPosition)
    {
        _currentTween = transform.DOMove(targetPosition.transform.position, _duration);
    }
    
    private void OnMoving()
    {
        _currentTween.Pause();
    }
}
