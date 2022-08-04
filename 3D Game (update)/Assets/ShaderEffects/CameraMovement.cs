using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private float _rotationSpeed = 3.0f;
    
    public GameObject _camera;
    public CustomCharacterController _controller;
    CameraMovement _freeCamera;
    [HideInInspector]
    public bool useFreeCam;

    private Vector2 _rotation = Vector2.zero;
    private Vector3 _moveVector = Vector3.zero;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        Cursor.lockState = CursorLockMode.Locked;
        _freeCamera.enabled = false;
    }
    
    private void Update()
    {
        _rotation += new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        transform.eulerAngles = _rotation * _rotationSpeed;

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        _moveVector = new Vector3(x, 0, z) * _moveSpeed;

        if (useFreeCam)
        {
            if (GameInput.Key.GetKey("Run"))
            {
                _moveSpeed = 20f;
            }
            else
            {
                _moveSpeed = 10f;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.TransformDirection(_moveVector);
    }

}
