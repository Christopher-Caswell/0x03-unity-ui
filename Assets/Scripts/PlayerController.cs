using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/// <summary>
/// Start and update the Player
/// </summary>
public class PlayerController : MonoBehaviour
{
    public int health = 5;
    private int score = 0;
    public float speed = 5000f;
    public Rigidbody x;
    public Text scoreText;
    public Text healthText;
    public Image WinLoseBG;
    public Text WinLoseText;
    

    /// <summary>
    /// Hardbody setup
    /// </summary>
    void Start()
    {
        x = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /// <summary>
        /// Update the vitality of the player
        /// </summary>
        if (health <= 0)
        {
            WinLoseBG.gameObject.SetActive(true);
            WinLoseBG.color = UnityEngine.Color.red;
            WinLoseText.color = UnityEngine.Color.white;
            WinLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
        }

        /// <summary>
        /// Take key input and open menu
        /// </summary>
        if (Input.GetKey("w"))
        {
            x.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            x.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            x.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            x.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    /// <summary>
    /// Trigger collision with elements of the game
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        /// <summary>
        /// If the player collides with a pickup, add to score
        /// </summary>
        if (other.GetComponent<Collider>().tag == "Pickup")
        {
            // other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            Object.Destroy(other.gameObject);

            if (score == 69 && health >= 5)
            {
                WinLoseText.color = UnityEngine.Color.red;
                WinLoseText.text = "EfFoRT!!1!";
                WinLoseBG.color = new Color32(0, 0, 0, 255);
                WinLoseBG.gameObject.SetActive(true);
                StartCoroutine(LoadScene(4));
            }
            
            else if (score == 69)
            {
                WinLoseText.color = UnityEngine.Color.white;
                WinLoseText.text = "NICE!";
                WinLoseBG.color = new Color32(143, 0, 143, 170);
                WinLoseBG.gameObject.SetActive(true);
                StartCoroutine(LoadScene(4));
            }
        }
        /// <summary>
        /// If the player collides with an enemy, take damage
        /// </summary>
        if (other.GetComponent<Collider>().tag == "Trap")
        {
            health--;
            SetHealthText();
        }

        if (other.GetComponent<Collider>().tag == "Goal")
        {
            WinLoseText.color = UnityEngine.Color.black;
            WinLoseText.text = "You Win!";
            WinLoseBG.color = UnityEngine.Color.green;
            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }
    /// <summary>
    /// Set the score text in string form
    /// </summary>
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    /// <summary>
    /// Set the health text in string form
    /// </summary>
    void SetHealthText()
    {
        healthText.text = ($"Health: {health}");
    }

    /// <summary>
    /// Loads the next scene, the menu, or the game over screen
    /// </summary>
    IEnumerator LoadScene(float seconds)
    {
    yield return new WaitForSeconds(seconds);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
