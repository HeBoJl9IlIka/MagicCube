using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, _speed * Time.deltaTime, 0), Space.Self);
        else if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, -_speed * Time.deltaTime, 0), Space.Self);
    }
}
