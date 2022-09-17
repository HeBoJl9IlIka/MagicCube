using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    public event UnityAction Moving;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddRelativeForce(Vector3.forward * _speed * Time.deltaTime, ForceMode.VelocityChange);
            Moving?.Invoke();
        }
    }
}
