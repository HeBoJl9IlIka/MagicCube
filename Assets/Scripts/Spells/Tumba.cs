using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Tumba : MonoBehaviour
{
    private const float Duration = 15f;

    [SerializeField] private ButtonTumbaSpawning _buttonTumbaSpawning;
    [SerializeField] private int _valueHeal;
    [SerializeField] private float _delay;
    [SerializeField] private float _positionY;
    [SerializeField] private float _defaultPositionY;

    private Camera _camera;
    private bool _isEnemyInZone;
    private bool _isActive;

    public event UnityAction Activated;
    public event UnityAction Deactivated;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_isActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Ground ground))
                {
                    transform.position = new Vector3(hit.point.x, _positionY, hit.point.z);
                    Activated?.Invoke();
                    _isActive = true;
                }
            }
        }
    }

    private void OnEnable()
    {
        _buttonTumbaSpawning.Pressed += OnPressed;
        Invoke(nameof(Disable), Duration);
    }

    private void OnDisable()
    {
        _buttonTumbaSpawning.Pressed -= OnPressed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _isEnemyInZone = true;

            StartCoroutine(Heal(enemy));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _isEnemyInZone = false;
        }
    }

    private void OnPressed()
    {
        _isActive = false;
    }

    private void Disable()
    {
        transform.position = new Vector3(transform.position.x, _defaultPositionY);
        Deactivated?.Invoke();
        gameObject.SetActive(false);
    }

    private IEnumerator Heal(Enemy enemy)
    {
        while (_isEnemyInZone)
        {
            enemy.TakeHealing(_valueHeal, transform);

            yield return new WaitForSeconds(_delay);
        }
    }
}
