using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier = 9.8f;

    private bool grounded = true;

    public bool gameIsActive = true;

    private Animator playerAnimator;

    public bool gameOver;

    [SerializeField] private float _speed;
    public float speed
    {
        get
        {
            return _speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameIsActive = false;
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }

    }
}
