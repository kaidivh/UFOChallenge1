using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives = 5;
    private int lvlcount = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        SetLivesText();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
            if (lives == 0)
            {
                winText.text = "You lose :-( Game created by Collin Conner!";
                gameObject.SetActive(false);
                //endgame
            }
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12 && lvlcount == 1)
        {
            lvlcount = lvlcount + 1;
            count = 0;
            transform.position = new Vector3(50, 50, 0);
            //set movement 0
            rb2d.velocity = new Vector2(0,0);
            rb2d.angularVelocity = 0;
            countText.text = "Count: " + count.ToString();
        }
        if (count >= 12 && lvlcount == 2)
        {
            countText.text = "Count: " + count.ToString();
            winText.text = "You win! Game created by Collin Conner!";
        }
    }

}
