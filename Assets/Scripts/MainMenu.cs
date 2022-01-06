using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button play;
    public Button quit;
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(PlayMaze);
        quit.onClick.AddListener(QuitMaze);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Loading scene when touch the play button
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");

        if (colorblindMode.isOn)
        {
            goalMat.color = Color.blue;
            trapMat.color = new Color32(255, 112, 0, 1);
        }
        else
        {
            goalMat.color = Color.green;
            trapMat.color = Color.red;
        }
    }

    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");

    }
}
