using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, -90, 0));
        }
    }
}
