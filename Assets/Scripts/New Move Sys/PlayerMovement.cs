using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float speed;
    public float runSpeed = 20f;
    public float walkSpeed = 12f;
    public float crouchSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float jumpButtonGracePeriod;
    private float? jumpButtonPressedTime;
    private float? lastGroundedTime;

    public Volume Volume;
    public float crouchIntensity = 0.5f;
    public float lerpSpeed = 5f;
    // vigpublic Vignette vignette;
    private float targetIntensity;


  
    // VFX for sprint
    public VisualEffect sprintVisualEffect;

    // Ground check
    public Transform groundCheck;
    public float groundDistance = 2f;
    public LayerMask groundMask;

    // refference camera to change fov while sprinting
    public Camera myCamera;
    public float sprintFOV = 75f;
    public float normalFOV = 60f;
    public float FOVLerpSpeed = 0.5f;

    Vector3 velocity;
    bool isGrounded;

    // get refference for cansprint var
    GameObject canSprintObj;
    ListenForTrash canSprintVar;
    bool sprintEnabled;


    void Start()
    {
        //refference canSprintVar
        canSprintObj = GameObject.Find("TrashOMeter");
        canSprintVar = canSprintObj.GetComponent<ListenForTrash>();

        //GlobalVolume = GetComponent<Volume>();
        //GlobalVolume.profile.TryGet(out vignette);
        Volume volume = gameObject.GetComponent<Volume>();
        targetIntensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        sprintEnabled = canSprintVar.canSprint;

        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        if (Input.GetKey(KeyCode.LeftShift) && !(Input.GetKey(KeyCode.LeftControl)) && sprintEnabled)
        {
            
            speed = runSpeed;
            transform.localScale = new Vector3(1, 1, 1);
            //vignetterColor.value = new Color(0f, 255f, 255f);
            //vignette.color.Override(Color.red);
            targetIntensity = 0f;
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.S)))
            {
                sprintVisualEffect.enabled = true;
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, sprintFOV, FOVLerpSpeed);
            }
            else
            {
                sprintVisualEffect.enabled = false;
            }
            
        }
        else if (Input.GetKey(KeyCode.LeftControl)) 
        { 
            speed = crouchSpeed;
            transform.localScale = new Vector3(1, 0.5f, 1);
            //vignetterColor.value = new Color(0f, 0f, 0f);
            //vignette.color.Override(Color.black);
            targetIntensity = crouchIntensity;
            sprintVisualEffect.enabled = false;
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, normalFOV, FOVLerpSpeed);
        }
        else
        {
            speed = walkSpeed;
            transform.localScale = new Vector3(1, 1, 1);
            targetIntensity = 0f;
            sprintVisualEffect.enabled = false;
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, normalFOV, FOVLerpSpeed);
        }

        //vignette.intensity.Override(Mathf.Lerp(vignette.intensity.value, targetIntensity, Time.deltaTime * lerpSpeed));

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed *Time.deltaTime);

        if (isGrounded) 
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            if(Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }


       /* if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        } */


    velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
