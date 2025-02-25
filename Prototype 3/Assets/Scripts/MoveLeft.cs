using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private float speed = 15f;

    [SerializeField] private float leftBound = -15;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(!playerController.gameIsActive)
        return;
        transform.Translate(speed * Time.deltaTime * Vector3.left);

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        Destroy(gameObject);
    }
}
