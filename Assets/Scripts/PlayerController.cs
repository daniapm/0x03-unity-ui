using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 5;
    private int score = 0;


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
        if (health == 0)
        {
            Debug.Log("Game Over!");
            // Loads the Scene by its name or index in Build Settings
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //Object wit the tag Pickup
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log($"Score: {score}");
            // Destroy after touch the coin.
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
