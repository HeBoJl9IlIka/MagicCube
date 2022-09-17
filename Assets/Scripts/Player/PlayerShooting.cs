using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private ButtonSelectingSpell[] _buttons;
    [SerializeField] private float _delay;

    private Camera _camera;
    private Spell _spell;
    private Coroutine _currentCoroutine;
    private bool _isShooting;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_spell == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    _currentCoroutine = StartCoroutine(Shoot(enemy));
                }
            }
        }
    }

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.Pressed += OnPressed;
        }

        _playerMovement.Moving += OnMoving;
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.Pressed -= OnPressed;
        }
        _playerMovement.Moving -= OnMoving;
    }

    private void OnPressed(Spell spell)
    {
        _spell = spell;
        _isShooting = true;
    }
    
    private void OnMoving()
    {
        _isShooting = false;
    }

    private IEnumerator Shoot(Enemy enemy)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        while (_isShooting)
        {
            if (_spell.Type == Spell.SpellType.Wound)
                enemy.TakeDamage(_spell.Value, transform);
            else
                enemy.TakeHealing(_spell.Value, transform);

            yield return new WaitForSeconds(_delay);
        }
    }
}
