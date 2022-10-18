using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        //
        Vector3 mousePos = Input.mousePosition;
        mousePos.x = 5.23f;

        Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);

        mousePos.z = mousePos.z - objectPos.z;
        mousePos.y = mousePos.y - objectPos.y;
        
        float angle = Mathf.Atan2(mousePos.y, mousePos.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle - 90, 0));
        //

        if (Input.GetMouseButton(0))
        {
            Debug.Log("swing");
            
        }
    }

}

