using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(CharacterController))]

public class ColliderFollowHeadset : MonoBehaviour
{
    private CharacterController charController;

    [Tooltip("Your VR Camera should be tied to the variable below")]
    public Transform centerEye;

     [Tooltip("The Gimme variable defines the maximum distance the camera is allowed to move from the character controller before the character controller is teleported to the Center Eye.\n\nThis allows you to lean over tables without being blocked. Setting this value to 0 removes the \"Gimme\" and the charController follows you always")]
    public float gimme = 0.5f;

    [Header("Smooth Locomotion")]

    [Tooltip("Whether or not you want to enable constant teleportation of the charController when using Smooth Locomotion")]
    public bool useSmoothLocomotion = true;

    [Tooltip("Should be bound to your smooth locomotion movement action (Vector2)")]
    public SteamVR_Action_Vector2 input;

    [Tooltip("How much the input needs to move before the charController is constantly teleported")]
    public float minJoystickMove = 0.1f;

    [Tooltip("Should be tied to the HeadCollider object under Player/FollowHead")]
    public GameObject HeadCollider;

    // Reference to the HeadCollider objects CollisionFade script
    CollisionFade collFade;

    private void Start()
    {
        // Assigns the local Character Controller component (the component in the object this script is tied to) to the struct-based variable charController
        charController = GetComponent<CharacterController>();
        collFade = HeadCollider.GetComponent<CollisionFade>();
    }

    private void LateUpdate()
    {
        // Calculates a new center value of the player collider so that it is in the same position as the camera
        Vector3 newCenter = transform.InverseTransformVector(centerEye.position - transform.position);
        // Only teleports the charController when head is not stuck in a collider
        if (!collFade.inCollider)
        {
            // If you use smooth locomotion this constantly teleports the character controller to the camera while moving the joystick/move input method
            if (useSmoothLocomotion && input.axis.magnitude > minJoystickMove)
            {
                charController.center = new Vector3(newCenter.x, charController.center.y, newCenter.z);
            }
            // This only teleports the character controller to the camera when either the x or z values between the charController.center and newCenter differ by more than the value of gimme
            if (Mathf.Abs(newCenter.x - charController.center.x) >= gimme || Mathf.Abs(newCenter.z - charController.center.z) >= gimme)
            {
                charController.center = new Vector3(newCenter.x, charController.center.y, newCenter.z);
            }
        }
    }
}
