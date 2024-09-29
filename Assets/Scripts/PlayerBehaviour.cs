using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
public class PlayerBehaviour : MonoBehaviour
{

    private Animator animator;
    public GameObject holdingGift;
    public GameObject legJoint;
    public GameObject aimLine;

    public Camera mainCamera;
    public GameObject originalTransform;
    public GameObject aimTransform;
    private Coroutine cameraTransition;

    public GameObject instantGift;

    private bool readyToDrop;
    private float horizontal;
    private float vertical;
    private float rotationDegreePerSecond = 500;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (animator)
        {
            // Get input
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            // Movement direction based on vertical input (forward/backward movement relative to the player's facing direction)
            Vector3 movementDirection = transform.forward * vertical;

            // Normalize movement direction if needed (to prevent diagonal speed boost, though this is vertical only now)
            if (movementDirection.sqrMagnitude > 1) movementDirection.Normalize();

            movementDirection *= 15.0f;
            // Apply rotation based on horizontal input (turning left/right)
            if (horizontal != 0)
            {
                // Rotate the player left/right based on horizontal input
                transform.Rotate(Vector3.up, horizontal * rotationDegreePerSecond * Time.deltaTime * 0.2f);
            }

            // Update Rigidbody velocity for forward/backward movement (based on vertical input)
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = movementDirection;
        }

        if (Input.GetKeyDown(KeyCode.Space) && holdingGift != null)
        {
            mainCamera.transform.position = aimTransform.transform.position;
            mainCamera.transform.rotation = aimTransform.transform.rotation;
            readyToDrop = true;
            aimLine.SetActive(true);
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && readyToDrop)
        {
            DropPresent(holdingGift);
            mainCamera.transform.position = originalTransform.transform.position;
            mainCamera.transform.rotation = originalTransform.transform.rotation;
            aimLine.SetActive(false);
            readyToDrop = false;
        }
    }

    //On pickup
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PostOffice" && !holdingGift)
        {
            holdingGift = Instantiate(instantGift,legJoint.transform.position,Quaternion.identity);
            holdingGift.transform.SetParent(legJoint.transform);
        }
    }

    public void DropPresent(GameObject gift)
    {
        gift.transform.position = this.transform.position;
        holdingGift.transform.SetParent(null);
        holdingGift = null;
        gift.AddComponent<Rigidbody>();
    }
}