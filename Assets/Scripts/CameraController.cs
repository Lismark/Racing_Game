using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerPos;

    private void Start()
    {

    }
    void Update()
    {
        gameObject.transform.position = new Vector3(playerPos.position.x, playerPos.transform.position.y, -10);
        // gameObject.transform.rotation = playerPos.transform.rotation;
        
    }
}
