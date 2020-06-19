using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    private GameObject playerObj;

    public int cameraDistance = 2;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = PlayerController.instance.transform;
    }

    
    void LateUpdate()
    {
        Vector2 offset = PlayerController.instance.GetComponent<PlayerController>().movement * cameraDistance;
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        temp.x += offset.x;
        temp.y += offset.y;

        transform.position = Vector3.SmoothDamp(transform.position, temp, ref velocity, 0.3f);
    }
}//end class
