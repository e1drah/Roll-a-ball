using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    //UI
    public TextMeshProUGUI countText;
    public TextMeshProUGUI keytext;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI levelCount;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finaleTime;
    public TextMeshProUGUI finalHighScore;
    public TextMeshProUGUI finalBestTime;
    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI bestTime;
    public GameObject winText;
    public GameObject resetButton;

    //audio
    public AudioSource winLevel;
    public AudioSource loseLevel;
    public AudioSource fallOffLevel;
    public AudioSource pickupCube;
    public AudioSource pickupKey;
    public AudioSource jump;

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
    //how high the bounce pad sends you
    public int bounce;

    public int levelAmount;

    private Rigidbody rb;

    //private Vector3 stop = (0, 0, 0);

    private float movementX;
    private float movementY;

    private int count;
    private int lvlCount = 1;

    private int secondTime;
    private int minuteTime;

    // High score
    private int minuteTimeFastest;
    private int secondTimeFastest;

    //use to determin Fastest Time
    private float totalTime;
    private float totalTimeFastest;

    //
    private int highScore;

    private float timer;
    //don't know why this is public but I'm to scared to change it
    public int keyCount;

    // Start is called before the first frame update
    void Start()
    {
        totalTimeFastest = PlayerPrefs.GetFloat("totalTimeFastest", 120);
        highScore = PlayerPrefs.GetInt("finalHighScore", 0);

        winText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);

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

    //Hud of the game 
    void SetHudText()
    {
        levelCount.text = "Level: " + lvlCount.ToString();
        keytext.text = "Keys left: " + keyCount.ToString();
        countText.text = "Score: " + count.ToString();
        highScoreDisplay.text = "HighScore: " + PlayerPrefs.GetInt("finalHighScore", 0).ToString();
        if (secondTimeFastest < 10)
        {
            bestTime.text = "Best Time: " + minuteTimeFastest.ToString() + ":0" + secondTimeFastest.ToString();
        }
        else
        {
            bestTime.text = "Best Time: " + minuteTimeFastest.ToString() + ":" + secondTimeFastest.ToString();
        }
        if (secondTime < 10)
        {
            Timer.text = "Time: " + minuteTime.ToString() + ":0" + secondTime.ToString();
        }
        else
        {
            Timer.text = "Time: " + minuteTime.ToString() + ":" + secondTime.ToString();
        }
    }
    //Win screen
    void SetWinText()
    {
        levelCount.text = "";
        keytext.text = "";
        countText.text = "";
        Timer.text = "";

        winText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);

        finalScore.text = "Your score: " + count.ToString();
        if (secondTime < 10)
        {
            finaleTime.text = "Your time: " + minuteTime.ToString() + ":0" + secondTime.ToString();
        }
        else
        {
            finaleTime.text = "Your time: " + minuteTime.ToString() + ":" + secondTime.ToString();
        }
        if (totalTime < totalTimeFastest)
        {
            PlayerPrefs.SetFloat("totalTimeFastest", totalTime);
            minuteTimeFastest = minuteTime;
            secondTimeFastest = secondTime;
        }
        if (secondTimeFastest < 10)
        {
            finalBestTime.text = "Fastest time: " + minuteTimeFastest.ToString() + ":0" + secondTimeFastest.ToString();
        }
        else
        {
            finalBestTime.text = "Fastest time: " + minuteTimeFastest.ToString() + ":" + secondTimeFastest.ToString();
        }
        if (count > highScore)
        {
            PlayerPrefs.SetInt("finalHighScore", count);
            highScore = count;
        }
        finalHighScore.text = "High score: " + highScore.ToString();
    }
    //moves the player
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        if (levelAmount != lvlCount)
        {
            totalTime += Time.deltaTime;
            secondTime = Mathf.RoundToInt(totalTime);
            if (secondTime >= 60)
            {
                totalTime = 0;
                minuteTime += 1;
            }
            SetHudText();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //player pick up an item
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            pickupCube.Play();
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
            fallOffLevel.Play();
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
                    winLevel.Play();
                }
                if (lvlCount == 2)
                {
                    keyCount += lvl2Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint2.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);
                    winLevel.Play();
                }
                if (lvlCount == 3)
                {
                    keyCount = lvl3Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint3.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);
                    winLevel.Play();
                }
                if (lvlCount == 4)
                {
                    keyCount = lvl4Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint4.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);
                    winLevel.Play();
                }
                if (lvlCount == 5)
                {
                    keyCount = lvl5Keys;
                    SetHudText();
                    Player.gameObject.transform.position = spawnPoint5.gameObject.transform.position;
                    rb.AddForce(0, 0, 0);
                    winLevel.Play();
                }
                if (lvlCount == levelAmount)
                {
                    SetWinText();
                    Player.gameObject.SetActive(false);
                }
            }
            else
            {
                loseLevel.Play(); 
            }
             
        }
            //send the player up
        if (other.gameObject.CompareTag("Bounce"))
        {
            jump.Play();
            rb.AddForce(Vector3.up * bounce);
        }
            //Player picking up the keys
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            keyCount -= 1;
            pickupKey.Play();
            SetHudText();
        }

        }
    public void Reset()
    {
        PlayerPrefs.SetFloat("totalTimeFastest", 120);
        PlayerPrefs.SetInt("finalHighScore", 0);
        loseLevel.Play();
    }
}
