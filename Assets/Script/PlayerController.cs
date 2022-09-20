using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;
    public GameObject Player;
    //Spawnpoints
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;
    public GameObject SpawnPoint5;
    public GameObject SpawnPoint6;
    public GameObject SpawnPoint7;
    public GameObject SpawnPoint8;
    public GameObject SpawnPoint9;
    public GameObject SpawnPoint10;


    private Rigidbody rb;

    private float movementX;
    private float movementY;

    private int count;
    private int lvlCount;
    private int keyCount;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 28)
        {
            winTextObject.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
        if (other.gameObject.CompareTag("End"))
        {
            lvlCount += 1;
        }
        if (other.gameObject.CompareTag("Respawn"))
        {
            if (lvlCount == 0)
            {
            Player.gameObject.transform.position = spawnPoint1.gameObject.transform.position;
            }
            if(lvlCount == 1)
            {
                Player.gameObject.transform.position = spawnPoint2.gameObject.transform.position;
            }

        }
        if (other.gameObject.CompareTag("nextlvl"))
        {
            if (lvlCount == 0)
            {
                Player.gameObject.transform.position = spawnPoint1.gameObject.transform.position;
            }
            if (lvlCount == 1)
            {

                Player.gameObject.transform.position = spawnPoint2.gameObject.transform.position;
            }

        }
    }
}
