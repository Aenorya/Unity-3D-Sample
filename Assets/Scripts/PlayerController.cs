using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _rotationSpeed = 3f;
    private Vector2 _direction;
    private Vector2 _rotation;
    private Rigidbody _rigidbody;
    private Camera _camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }
    private void Update()
    {
        //Two different ways to rotate
        //Rotations are applied by multiplication NOT addition
        transform.rotation *= Quaternion.Euler(0, _rotation.x * _rotationSpeed * Time.fixedDeltaTime, 0);

        //TO DO Clamp rotation in x
        _camera.transform.Rotate(-_rotation.y * _rotationSpeed * Time.fixedDeltaTime, 0, 0);
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition((transform.position +
            ((transform.forward * _direction.y * _speed)
            + (transform.right * _direction.x * _speed)) * Time.fixedDeltaTime));
    }

    public void Move(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void LookAt(InputAction.CallbackContext context)
    {
        _rotation = context.ReadValue<Vector2>();
    }
}
