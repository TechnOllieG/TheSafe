using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    //-----------------------------------------------------------------------------
    // Visible in Inspector
    //-----------------------------------------------------------------------------
    [Tooltip("Vector2 action to use for smooth locomotion movement")]
    public SteamVR_Action_Vector2 input;

    [Tooltip("Boolean action to use for sprint toggle")]
    public SteamVR_Action_Boolean sprintInput;
    

    [Tooltip("Walking speed (Smooth Locomotion)")]
    public float speed = 1;

    [Tooltip("Sprint speed (Smooth Locomotion)")]
    public float sprintSpeed = 2;

    [Tooltip("Speed of the gravity")]
    public float gravity = 9.81f;

    [Tooltip("Minimum magnitude you have to move joystick before running smooth locomotion code")]
    public float minJoystickMove = 0.1f;
    //-----------------------------------------------------------------------------

    private CharacterController characterController;
    private bool sprintEnabled = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        // Make the characterController obey gravity when not grounded
        if (!characterController.isGrounded)
        {
            characterController.Move(-new Vector3(0, gravity, 0) * Time.deltaTime);
        }
    }
    void Update()
    {
        // Toggle sprinting when sprint button is clicked
        if(sprintInput.state)
        {
            sprintEnabled = true;
        }
        // Disable Smooth Locomotion code when not moving joystick over the magnitude of minJoyStickMove
        if (input.axis.magnitude > minJoystickMove)
        {
            // Calculate direction of movement
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            // Move multiplied by sprintSpeed
            if (sprintEnabled)
            {
                characterController.Move(sprintSpeed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up));
            }
            // Move multiplied by speed
            else
            {
                characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up));
            }
        }
        else
        {
            sprintEnabled = false;
        }
    }
}