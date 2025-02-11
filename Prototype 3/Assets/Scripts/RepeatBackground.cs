using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;

    private float repeatwidth;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatwidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPosition.x - 50)
        {
            transform.position = startPosition;
        }
        
    }
}
