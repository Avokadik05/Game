using UnityEngine;
using UnityEngine.UI;

// ���������� ����� �������� ������� � �������� ������ ���������
public class CustomCharacterController : MonoBehaviour
{

    [Header("��������� �������")]
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private float staminaValue;
    [SerializeField] private float minValueStamina;
    [SerializeField] private float maxValueStamina;
    [SerializeField] private float staminaReturn;
    //private Text staminaText;

    [Header("������ �� �������")]
    public Animator anim;
    public Rigidbody rig;
    public Transform mainCamera;
    AudioSource _playerAudio;
    RaycastHit _hit;
    public LayerMask _floormask;
    public LayerMask _forestmask;

    [Header("��������� ���������")]
    public float jumpForce = 3.5f;
    public float walkingSpeed = 2f;
    public float runningSpeed;
    public float stamina_speed = 2f; 
    public float currentSpeed;
    private float animationInterpolation = 1f;
    public CapsuleCollider playerCollider;
    public AudioClip[] _floor;
    public AudioClip[] _forest;

    void Start()
    {
        // ����������� ������ � �������� ������
        Cursor.lockState = CursorLockMode.Locked;
        // � ������ ��� ���������
        Cursor.visible = false;
        GameInput.Key.LoadSettings();
    }
    
    void Seat()
    {
        currentSpeed = 1.2f;
        playerCollider.height = 1.3f;
        playerCollider.radius = 0.35f;
        playerCollider.center = new Vector3(0.001656413f, 0.651f, 0.16f);

    }

    void NoSeat()
    {
        playerCollider.height = 1.797984f;
        playerCollider.radius = 0.2622133f;
        playerCollider.center = new Vector3(0.001656413f, 0.9060238f, 0.1008566f);
    }

    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
        anim.SetFloat("x", Input.GetAxis("Horizontal") * animationInterpolation);
        anim.SetFloat("y", Input.GetAxis("Vertical") * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
        staminaValue -= staminaReturn * Time.deltaTime * 5;

    }
    void Walk()
    {
        // Mathf.Lerp - ������� �� ��, ����� ������ ���� ����� animationInterpolation(� ������ ������) ������������ � ����� 1 �� ��������� Time.deltaTime * 3.
        // Time.deltaTime - ��� ����� ����� ���� ������ � ���������� ������. ��� ��������� ������ ���������� � ������ ����� �� ������� ���������� �� ������ � ������� (FPS)!!!
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);
        anim.SetFloat("x", Input.GetAxis("Horizontal") * animationInterpolation);
        anim.SetFloat("y", Input.GetAxis("Vertical") * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
        staminaValue += staminaReturn * Time.deltaTime * 2;
    }
    private void Update()
    {
        Stamina();

        // ������������� ������� ��������� ����� ������ �������������� 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        // ������ �� ������ W � Shift?
        if (Input.GetKey(KeyCode.W) && GameInput.Key.GetKey("Run") && staminaValue > 0)
        {
            // ������ �� ��� ������ A S D?
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || GameInput.Key.GetKey("Crouch"))
            {
                // ���� ��, �� �� ���� ������
                Walk();
            }
            // ���� ���, �� ����� �����!
            else
            {
                Run();
            }
        }
        // ���� W & Shift �� ������, �� �� ������ ���� ������
        else
        {
            Walk();
        }

        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = 1.3f;
        }

        if (GameInput.Key.GetKey("Crouch"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                Seat();
                anim.SetBool("Crouch", false);
                anim.SetBool("WalkCrouch", true);
                currentSpeed = 1.2f;
            }
            else
            {
                anim.SetBool("Crouch", true);
                anim.SetBool("WalkCrouch", false);
                Seat();
            }
        }
        else
        {
            anim.SetBool("Crouch", false);
            anim.SetBool("WalkCrouch", false);
            NoSeat();
        }
        //���� ����� ������, �� � ��������� ���������� ��������� �������, ������� ���������� �������� ������
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            Jump();    
        }*/
    }

    void FixedUpdate()
    {
        // ����� �� ������ �������� ��������� � ����������� �� ����������� � ������� ������� ������
        // ��������� ����������� ������ � ������ �� ������ 
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        // ����� ����������� ������ � ������ �� �������� �� ���� ������� �� ������ ����� ��� ����, ����� ����� �� ������� ������, �������� ����� ���� ������� ��� ����� ������� ����� ��� ����
        // ������ ���� ��������� ��� ����� ����� camF.y = 0 � camR.y = 0 :)
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        // ��� �� �������� ���� ������� �� ������ W & S �� ����������� ������ ������ � ���������� � �������� �� ������ A & D � �������� �� ����������� ������ ������
        movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * currentSpeed + camR.normalized * Input.GetAxis("Horizontal") * currentSpeed, currentSpeed);
        // Magnitude - ��� ������ �������. � ���� ������ �� currentSpeed ��� ��� �� �������� ���� ������ �� currentSpeed �� 86 ������. � ���� �������� ����� �������� 1.
        anim.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
        //Debug.Log(movingVector.magnitude / currentSpeed);
        // ����� �� ������� ���������! ������������� �������� ������ �� x & z ������ ��� �� �� ����� ����� ��� �������� ������� � ������
        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
        // � ���� ��� ���, ��� �������� �������� �� ����� � ��� �������� � ������� ���� ������
        rig.angularVelocity = Vector3.zero;
    }
    /*public void Jump()
    {
        // ��������� ������ �� ������� ��������.
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }*/
    private void Stamina()
    {
        if (staminaValue > 300f) staminaValue = 300f;
        //staminaText.text = staminaSlider.value.ToString();
        staminaSlider.value = staminaValue;

        if (staminaValue <= 0.5f)
        {
            currentSpeed = 2;
        }
    }

    private void Awake()
    {
        _playerAudio = GetComponent<AudioSource>();
    }

    void Footstep()
    {
        if(Physics.Raycast (transform.position, -transform.up, out _hit, _floormask))
        {
            int randInd = Random.Range(0, _floor.Length);

            _playerAudio.PlayOneShot(_floor[randInd]);
        }
        else
        {
            int randInd = Random.Range(0, _forest.Length);

            _playerAudio.PlayOneShot(_forest[randInd]);
        }
    }

    public void OffEffects()
    {
        _playerAudio.enabled = false;
    }

    public void OnEffects()
    {
        _playerAudio.enabled = true;
    }
}