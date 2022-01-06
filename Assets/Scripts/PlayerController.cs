using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 5;
    private int score = 0;
    public Text scoreText;
    public Text healthText;
    public Text winlosetext;
    public GameObject winloseBG;

    //3D vectors and points.
    Vector3 translateObj;
    Vector3 rotateObj;
    
    //Rigidbody component
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        translateObj.x = Input.GetAxis("Horizontal");
        translateObj.z = Input.GetAxis("Vertical");
        rb.AddForce(translateObj * speed * Time.deltaTime) ; 
        
        rotateObj.x = Input.GetAxis("Vertical");
        rotateObj.z = Input.GetAxis("Horizontal");
        rb.transform.Rotate(rotateObj * speed * Time.deltaTime) ;
    }

    // Reload the scene when Health player is over
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        if (health == 0)
        {
            winloseBG.SetActive(true);
            winloseBG.GetComponent<Image>().color = Color.red;
            winlosetext.GetComponent<UnityEngine.UI.Text>().text = "Game Over!";
            winlosetext.GetComponent<Text>().color =  Color.white;
            // Loads the Scene by its name or index in Build Settings
            StartCoroutine(LoadScene(3f));
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //Object wit the tag Pickup
        if (other.CompareTag("Pickup"))
        {
            score++;
            //update the Score
            SetScoreText();
            // Destroy after touch the coin.
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }

        if (other.CompareTag("Goal"))
        {
            winloseBG.SetActive(true);
            winloseBG.GetComponent<Image>().color = Color.green;
            winlosetext.GetComponent<UnityEngine.UI.Text>().text = "You Win!";
            winlosetext.GetComponent<Text>().color =  Color.black;
            StartCoroutine(LoadScene(3f));
        }
    }

    //Update the ScoreText object with the Player‘s current score.
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    //Update the healtext object with the Player‘s current health.
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    //wait 3 seconds to reload the scene when game over!
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
