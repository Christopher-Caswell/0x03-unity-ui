using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    public Color colorblindMat = new Color32(255, 112, 0, 1);

    /// <summary>
    /// Start is called on the frame when a script is enabled
    /// </summary>
    void Start()
    {
        quitButton.onClick.AddListener(QuitMaze);
        playButton.GetComponent<Button>().onClick.AddListener(PlayMaze);
    }
    
    /// <summary>
    /// Control option for colorblind mode
    /// </summary>
    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = colorblindMat;
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        /// <summary>
        /// Loads the maze scene
        /// </summary>
        SceneManager.LoadScene("Maze");
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
