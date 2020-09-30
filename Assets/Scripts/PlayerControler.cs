using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float movementSpeed = 5f;

    Rigidbody2D rb;

    public Text Hightext;
    public Text menuText1;
    public Text menuText2;

    public GameObject goButton;
    public GameObject shopButton;
    public GameObject GoldText;
    public GameObject RestartText;
    private Text restartText;
    private Text goldText;

    public GameObject RestartButton;

    public GameObject PlayerCamera;

    private SpriteRenderer sprite;

    private Vector2 HighVector = new Vector2(0f, 5f);

    private JumpState jumpState = JumpState.Stay;

    public AudioSource MusicSource;
    public AudioSource Kill1;
    public AudioSource Kill2;

    public AudioSource sfxCoin1;
    public AudioSource sfxCoin2;
    public AudioSource sfxCoin3;
    public AudioSource sfxCoin4;
    public AudioSource sfxCoin5;
    public AudioSource sfxCoin6;

    private float score;
    private float highscore = 0;
    private int gold = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        restartText = RestartText.GetComponent<Text>();
        goldText = GoldText.GetComponent<Text>();
        RestartButton.SetActive(false);
        RestartText.SetActive(false);
        gold = PlayerPrefs.GetInt("gold");
        highscore = PlayerPrefs.GetFloat("highscore");

    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Coins: " + gold.ToString();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * movementSpeed;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            if (touchPosition.x > 0 && rb.transform.position.x < 2f && jumpState == JumpState.Jumped)
            {
                transform.position += new Vector3(0.4f, 0f, 0f) * Time.deltaTime * movementSpeed;
                sprite.flipX = false;
            }
            else if (touchPosition.x < 0 && rb.transform.position.x > -2f && jumpState == JumpState.Jumped)
            {
                transform.position -= new Vector3(0.4f, 0f, 0f) * Time.deltaTime * movementSpeed;
                sprite.flipX = true;
            }
            
            Debug.Log(rb.transform.position.x);
        }

        if (rb.position.y > HighVector.y)
        {
            HighVector.y = rb.position.y;
            score = Mathf.Round(HighVector.y);
            Hightext.text = "DISTANCE: " + score.ToString();
        }

        if (score > highscore)
        {
            highscore = score;
        }

    }

    private void FixedUpdate()
    {
        if (PlayerCamera.transform.position.y < rb.position.y &&
            jumpState == JumpState.Jumped)
        {
            PlayerCamera.transform.position = new Vector3(0, rb.position.y, -10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyLvl1")
        {
            Jump();
            rb.AddTorque(Random.Range(-20f,20f));
            collision.gameObject.SetActive(false);
            RandomKillSound();
        }
        if (collision.tag == "Die")
        {
            RestartButton.SetActive(true);
            RestartText.SetActive(true);
            restartText.text = "YOUR SCORE\n"+score+"\nHIGHSCORE\n"+highscore;
            PlayerPrefs.SetFloat("highscore", highscore);
            PlayerPrefs.SetInt("gold", gold);
        }
        if (collision.tag == "Coin")
        {
            gold++;
            collision.gameObject.SetActive(false);
            RandomCoinSound();
        }
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * 25f;
    }

    public void StartGame()
    {
        if (jumpState == JumpState.Stay)
        {
            menuText1.text = "";
            menuText2.text = "";
            Jump();
            jumpState = JumpState.Jumped;
            MusicSource.mute = false;
            goButton.SetActive(false);
            shopButton.SetActive(false);
        }
        
    }

    void RandomKillSound()
    {
        float weirdCoding = Random.Range(0, 20);
        if (weirdCoding > 10 )
            Kill2.Play();
        else
            Kill1.Play();
    }

    void RandomCoinSound()
    {
        float weirdCoding = Random.Range(0, 60);
        if (weirdCoding < 10)
            sfxCoin1.Play();
        if (weirdCoding < 20 && weirdCoding >= 10)
            sfxCoin2.Play();
        if (weirdCoding < 30 && weirdCoding >= 20)
            sfxCoin3.Play();
        if (weirdCoding < 40 && weirdCoding >= 30)
            sfxCoin4.Play();
        if (weirdCoding < 50 && weirdCoding >= 40)
            sfxCoin5.Play();
        if (weirdCoding <= 60 && weirdCoding >= 50)
            sfxCoin6.Play();
    }

    enum JumpState
    {
        Jumped,
        Stay
    }
}
