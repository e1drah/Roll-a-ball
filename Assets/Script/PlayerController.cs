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
    public GameObject winText;

    public GameObject Player;
    public GameObject Key;
    //Spawnpoints
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public GameObject spawnPoint5;
    public GameObject spawnPoint6;
    public GameObject spawnPoint7;
    public GameObject spawnPoint8;
    public GameObject spawnPoint9;
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

    //private Vector3 stop = (0, 0, 0);

    private float movementX;
    private float movementY;

    private int count;
    private int lvlCount = 1;
    public int keyCount;

    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
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
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

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
        //if (other.gameObject.CompareTag("End"))
        //{
        //    lvlCount += 1;
        //}
        //Respawning the player
        if (other.gameObject.CompareTag("Respawn"))
        {
            if (lvlCount == 1)
            {
                Player.gameObject.transform.position = spawnPoint1.gameObject.transform.position;
            }
            if (lvlCount == 2)
            {
                Player.gameObject.transform.position = spawnPoint2.gameObject.transform.position;
            }
            if (lvlCount == 3)
            {
                Player.gameObject.transform.position = spawnPoint3.gameObject.transform.position;
            }
            if (lvlCount == 4)
            {
                Player.gameObject.transform.position = spawnPoint4.gameObject.transform.position;
            }
            if (lvlCount == 5)
            {
                Player.gameObject.transform.position = spawnPoint5.gameObject.transform.position;
            }
        }
        //sends the player to the next lvl
        if (other.gameObject.CompareTag("nextlvl"))
        {
            if (keyCount == 0)
            { 
                lvlCount += 1;

                if (lvlCount == 1)
                {
                    keyCount = lvl1Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint1.gameObject.transform.position;
                    rb.AddForce(0,0,0);
                }
                if (lvlCount == 2)
                {
                    keyCount += lvl2Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint2.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);
                }
                if (lvlCount == 3)
                {
                    keyCount = lvl3Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint3.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);
                }
                if (lvlCount == 4)
                {
                    keyCount = lvl4Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint4.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);

                }
                if (lvlCount == 5)
                {
                    keyCount = lvl5Keys;
                    winText.gameObject.SetActive(true);
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint5.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);
                }
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
