using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _duration;
    [SerializeField] private float _repulsiveForce;
    [SerializeField] private float _attractionForce;

    private Rigidbody _rigidbody;
    private Enemy _enemy;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();

        _enemy.Damaged += OnDamaged;
        _enemy.Healed += OnHealed;
    }

    private void OnDisable()
    {
        _enemy.Damaged -= OnDamaged;
        _enemy.Healed -= OnHealed;
    }

    private void OnDamaged(Transform targetPosition)
    {
        _rigidbody.AddRelativeForce((targetPosition.position - transform.position) * _repulsiveForce * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnHealed(Transform targetPosition)
    {
        _rigidbody.AddRelativeForce((targetPosition.position - transform.position) * _attractionForce * Time.deltaTime, ForceMode.VelocityChange);
    }
}
