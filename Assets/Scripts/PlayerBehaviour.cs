using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{

    private Animator animator;

    public float walkspeed = 5;
    private float horizontal;
    private float vertical;
    private float rotationDegreePerSecond = 500;
    private bool isAttacking = false;

    private bool dead;


    public GameObject[] characters;
    public int currentChar = 0;

    public UnityEngine.UI.Text nameText;


    void Start()
    {
        setCharacter(0);
    }

    void FixedUpdate()
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

            movementDirection *= 10.0f;
            // Apply rotation based on horizontal input (turning left/right)
            if (horizontal != 0 && !isAttacking)
            {
                // Rotate the player left/right based on horizontal input
                transform.Rotate(Vector3.up, horizontal * rotationDegreePerSecond * Time.deltaTime * 0.2f);
            }
            
            // Update Rigidbody velocity for forward/backward movement (based on vertical input)
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = movementDirection;

        }
    }

    public void DropPresent(GameObject gift)
    {
        GameObject instance = Instantiate(gift, Vector3.zero, Quaternion.identity);
    }

    GameObject target = null;
    
    public void setCharacter(int i)
    {
        currentChar += i;

        if (currentChar > characters.Length - 1)
            currentChar = 0;
        if (currentChar < 0)
            currentChar = characters.Length - 1;

        foreach (GameObject child in characters)
        {
            if (child == characters[currentChar])
            {
                child.SetActive(true);
                if (nameText != null)
                    nameText.text = child.name;
            }
            else
            {
                child.SetActive(false);
            }
        }
        animator = GetComponentInChildren<Animator>();
    }

    public bool ContainsParam(Animator _Anim, string _ParamName)
    {
        foreach (AnimatorControllerParameter param in _Anim.parameters)
        {
            if (param.name == _ParamName) return true;
        }
        return false;
    }
}