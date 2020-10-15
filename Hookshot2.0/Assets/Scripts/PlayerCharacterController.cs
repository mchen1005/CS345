using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private float mouseSentitivity = 1f;
    [SerializeField] private Transform debugHitPointTransform;
    [SerializeField] private Transform hookshotTransform;


    private CharacterController characterController;
    private float cameraVerticalAngle;
    private float characterVelocityY;
    private Vector3 characterVelocityMomentum;
    private Camera playerCamera;
    private State state;
    private Vector3 hookshotPosition;
    private float hookshotSize;
    private bool unhookable;


    private enum State
    {
        Normal,
        HookshotThrown,
        HookshotFlyingPlayer,
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = transform.Find("Camera").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        state = State.Normal;
        hookshotTransform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HandleCharacterLook();
                HandleCharacterMovement();
                HandleHookshotStart();
                break;
            case State.HookshotThrown:
                HandleHookshotThrow();
                HandleCharacterLook();
                HandleCharacterMovement();
                break;
            case State.HookshotFlyingPlayer:
                HandleCharacterLook();
                HandleHookshotMovement();
                break;

        }

    }

    private void HandleCharacterLook()
    {
        float lookX = Input.GetAxisRaw("Mouse X");
        float lookY = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(new Vector3(0f, lookX * mouseSentitivity, 0f), Space.Self);

        cameraVerticalAngle -= lookY * mouseSentitivity;

        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);

        playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);


    }

    private void HandleCharacterMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        float moveSpeed = 20f;

        Vector3 characterVelocity = transform.right * moveX * moveSpeed + transform.forward * moveZ * moveSpeed;

        if (characterController.isGrounded)
        {
            characterVelocityY = 0f;

            if (TestInputJump())
            {
                float jumpSpeed = 30f;
                characterVelocityY = jumpSpeed;
            }
        }

        //Apply gracity to the velocity
        float gravityDownForce = -55f;
        characterVelocityY += gravityDownForce * Time.deltaTime;

        //Apply Y velocity to move vector 
        characterVelocity.y = characterVelocityY;

        //Apply momemtum
        characterVelocity += characterVelocityMomentum;

        //Move Character Controller
        characterController.Move(characterVelocity * Time.deltaTime);

        //damped momentum
        if (characterVelocityMomentum.magnitude > 0f)
        {
            float momentumDrag = 3f;
            characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;
            if (characterVelocityMomentum.magnitude < .0f)
            {
                characterVelocityMomentum = Vector3.zero;
            }
        }

    }

    private void ResetGravityEffect()
    {
        characterVelocityY = 0f;
    }

    private void HandleHookshotStart()
    {
        if (TestInputDownHookShot())
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit))
            {
                debugHitPointTransform.position = raycastHit.point;
                hookshotPosition = raycastHit.point;
                hookshotSize = 0f;
                hookshotTransform.gameObject.SetActive(true);
                hookshotTransform.localScale = Vector3.zero;
                unhookable = raycastHit.transform.CompareTag("unhookable") ? true : false;
                state = State.HookshotThrown;

            }
        }
    }

    private void HandleHookshotThrow()
    {
        hookshotTransform.LookAt(hookshotPosition);
        float hookshotThrownSPeed = 420f;
        hookshotSize += hookshotThrownSPeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if (hookshotSize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            state = State.HookshotFlyingPlayer;
            if (unhookable == true || hookshotSize > 150f)
            {
                //if target not hookable or over 150 unit long, cancel hook movement
                StopHookshot();
            }
        }
    }

    private void HandleHookshotMovement()
    {
        hookshotTransform.LookAt(hookshotPosition);

        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeedMin = 10f;
        float hookshotSpeedMax = 30f;
        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotSpeedMin, hookshotSpeedMax);
        float hookshotSpeedMutiplier = 5f;

        //Move character Controller
        characterController.Move(hookshotDir * hookshotSpeed * hookshotSpeedMutiplier * Time.deltaTime);
        hookshotSize -= hookshotSpeed * hookshotSpeedMutiplier * Time.deltaTime;

        float reachedHookshotPositionDistance = 2f;
        if (Vector3.Distance(transform.position, hookshotPosition) <= reachedHookshotPositionDistance)
        {
            //reached hookshot position
            StopHookshot();

        }

        if (TestInputDownHookShot())
        {
            //Cancel hookshot
            StopHookshot();
        }

        if (TestInputJump())
        {
            //cancellde with jump
            float momentumExtraSpeed = 7f;
            characterVelocityMomentum = hookshotDir * hookshotSpeed * momentumExtraSpeed;
            float jumpSpeed = 40f;
            characterVelocityMomentum += Vector3.up * jumpSpeed;
            StopHookshot();
        }

    }

    private void StopHookshot()
    {
        state = State.Normal;
        ResetGravityEffect();
        hookshotTransform.gameObject.SetActive(false);
    }

    private bool TestInputDownHookShot()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }

    private bool TestInputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
