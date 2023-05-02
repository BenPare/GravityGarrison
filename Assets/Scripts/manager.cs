using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class manager : MonoBehaviour
{

    public GameObject ball;

    public TextMeshPro winText;
    public TextMeshPro reText;
    public TextMeshPro conText;

    public float posY;
    public float posX;

    public float wait = 0f; //wait and flag will keep track of shooting cooldown
    public float wFlag = 10f;

    public bool sFlag = false;

    public bool winFlag = false;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {

        wait = wait + 1;

        wFlag = wait * Time.deltaTime;

        if (Input.GetKey(KeyCode.W) && wFlag >= 10) //with this check taken from cannon, it only throws a null pointer on the frame before the user presses w rather than every single frame before the user presses w
        {
            sFlag = true;
        }

        if (sFlag == true)
        {
            ball = GameObject.Find("Ball(Clone)");

            posY = ball.transform.position.y;
            posX = ball.transform.position.x;
        }

        if (sceneName == "Level 1")
        {
            if (posX >= 8 && posX <= 11 && posY <= -3 && posY >= -5)//these should be coordinates for where the goal is
            {
                winText.gameObject.SetActive(true);
                reText.gameObject.SetActive(true);
                conText.gameObject.SetActive(true);
                winFlag = true;
            }
        }

        if (sceneName == "Level 2")
        {
            if (posX >= 8 && posX <= 11 && posY <= 4.5 && posY >= 2.5)//these should be coordinates for where the goal is
            {
                winText.gameObject.SetActive(true);
                reText.gameObject.SetActive(true);
                conText.gameObject.SetActive(true);
                winFlag = true;
            }
        }

        if (sceneName == "Level 3")
        {
            if (posX >= 7 && posX <= 10 && posY <= 0.5 && posY >= -1)//these should be coordinates for where the goal is
            {
                winText.gameObject.SetActive(true);
                reText.gameObject.SetActive(true);
                conText.gameObject.SetActive(true);
                winFlag = true;
            }
        }

        if (sceneName == "Level 4")
        {
            if (posX >= 7 && posX <= 10 && posY <= 0.5 && posY >= -1)//these should be coordinates for where the goal is
            {
                winText.gameObject.SetActive(true);
                reText.gameObject.SetActive(true);
                conText.gameObject.SetActive(true);
                winFlag = true;
            }
        }

        if (winFlag == true) //set the winflag true when we win, if we have won then the user has the ability to reload the scene
        {
            if (Input.GetKey(KeyCode.R) && sceneName == "Level 1")
            {
                SceneManager.LoadScene("Level 1");
            }

            if (Input.GetKey(KeyCode.C) && sceneName == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }

            if (Input.GetKey(KeyCode.R) && sceneName == "Level 2")
            {
                SceneManager.LoadScene("Level 2");
            }

            if (Input.GetKey(KeyCode.C) && sceneName == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }

            if (Input.GetKey(KeyCode.R) && sceneName == "Level 3")
            {
                SceneManager.LoadScene("Level 3");
            }

            if (Input.GetKey(KeyCode.C) && sceneName == "Level 3")
            {
                SceneManager.LoadScene("Level 4");
            }

            if (Input.GetKey(KeyCode.R) && sceneName == "Level 4")
            {
                SceneManager.LoadScene("Level 4");
            }
        }

    }
}
