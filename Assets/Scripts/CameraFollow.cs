using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find ("playman").transform;
        //transform.position = playerTransform.position;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
