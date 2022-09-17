using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeHealing(10, transform);
                }
            }
        }
    }
}
