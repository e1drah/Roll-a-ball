using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI keytext;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI levelCount;

    public GameObject Player;
    public GameObject Key;
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

    //Amount of keys needed to compleate the level
    public int lvl1Keys;
    public int lvl2Keys;
    public int lvl3Keys;
    public int lvl4Keys;
    public int lvl5Keys;
    public int lvl6Keys;
    public int lvl7Keys;
    public int lvl8Keys;
    public int lvl9Keys;
    public int lvl10Keys;

    public int bounce; 

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    private int count;
    private int lvlCount = 1;
    private int keyCount;
    
    // Start is called before the first frame update
    void Start()
    {
        keyCount = lvl1Keys;
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetHudText();
    }
    //Moves the player
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
     
    //counts how many cubes the player collected 
    void SetHudText()
    {
        levelCount.text = "Level: " + lvlCount.ToString();
        keytext.text = "Keys left: " + keyCount.ToString();
        countText.text = "Count: " + count.ToString();
    }
    //moves the player
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        //player pick up an item
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetHudText();
        }
        //counting which level the player will respawn to
        if (other.gameObject.CompareTag("End"))
        {
            lvlCount += 1;
        }
        //Respawning the player
        if (other.gameObject.CompareTag("Respawn"))
        {
            if (lvlCount == 1)
            {   
                Player.gameObject.transform.position = spawnPoint1.gameObject.transform.position;
            }
            if(lvlCount == 2)
            {
                Player.gameObject.transform.position = spawnPoint2.gameObject.transform.position;
            }

        }
        //sends the player to the next lvl
        if (other.gameObject.CompareTag("nextlvl"))
        {
            //if (lvlCount == 1)
            //{
            //    keyCount = lvl1Keys;
            //    SetHudText();
            //    Player.gameObject.transform.position = spawnPoint1.gameObject.transform.position;
            //}
            if (lvlCount == 2)
            {
                keyCount = lvl2Keys;
                SetHudText();
                Player.gameObject.transform.position = spawnPoint2.gameObject.transform.position;
            }

        }
        //send the player up
        if (other.gameObject.CompareTag("Bounce"))
        {
            rb.AddForce(Vector3.up * bounce);
        }
        //Player picking up the keys
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            keyCount -= 1;

            SetHudText();
        }

    }
}
