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
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        Debug.Log("you lost");
    }
}
