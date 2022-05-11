using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки стамины")]
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private float staminaValue;
    [SerializeField] private float minValueStamina;
    [SerializeField] private float maxValueStamina;
    [SerializeField] private float staminaReturn;
    //private Text staminaText;

    [Header("Настройки скорости")]
    [SerializeField] private float current_speed;
    [SerializeField] private float walk_speed;
    [SerializeField] private float run_speed;
    [Range(0, 10)] [SerializeField] private float smooth_Speed;
    [Header("Остальное")]
    [SerializeField] private float gravity = -9.8f;
    private Animator anim;
    Vector3 movement;

    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //staminaText = staminaSlider.transform.GetChild(3).GetComponent<Text>();
    }

    void Update()
    {
        Move();
        Stamina();
    }

    void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * current_speed;
        float deltaZ = Input.GetAxis("Vertical") * current_speed;
        if (characterController.isGrounded)
        {
            movement = new Vector3(deltaX, 0, deltaZ);
            movement = transform.TransformDirection(movement);
            if (Input.GetKey(KeyCode.LeftControl)) //присесть
            {
                characterController.height = 1.2f;
            }
            else
            {
                characterController.height = 1.8f;
            }
        }
        //movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, current_speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        //movement = transform.TransformDirection(movement);
        if (Input.GetKey(KeyCode.LeftShift) && staminaValue > 0) //бег
        {
            current_speed = Mathf.Lerp(current_speed, run_speed, Time.deltaTime * smooth_Speed);
            staminaValue -= staminaReturn * Time.deltaTime * 5;
        }
        else
        {
            current_speed = Mathf.Lerp(current_speed, walk_speed, Time.deltaTime * smooth_Speed);
            staminaValue += staminaReturn * Time.deltaTime * 2;
        }
        characterController.Move(movement);
    }

    private void Stamina()
    {
        if (staminaValue > 100f) staminaValue = 100f;
        //staminaText.text = staminaSlider.value.ToString();
        staminaSlider.value = staminaValue;
    }
}
