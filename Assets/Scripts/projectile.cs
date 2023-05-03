using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class projectile : MonoBehaviour
{
    Vector3 invert = new Vector3(0, 5.0f, 0); //inverted gravity happens when y is positive
    Vector3 norm = new Vector3(0, -5.0f, 0); //gravity is normal when y is negative

    public string sceneName;

    public float shift = 0.25f; //shift every quarter second max
    public float shiftFlag = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;

        if (sceneName == "Level 1" || sceneName == "Level 2" || sceneName == "Level 3" || sceneName == "Level 5") //we can set the gravity to default on startup just for the levels with cannon in white just to be safe
            Physics.gravity = norm;
        else
            Physics.gravity = invert;
    }

    // Update is called once per frame
    void Update()
    {

        float posY = transform.position.y;
        float posX = transform.position.x; //not being used here


        if (sceneName == "Level 1" || sceneName == "Level 2") //level 1 and 2 split on the x axis in the same way
        {
            if (posY >= 0)//invert the gravity if we are above 0 on the Y axis
                Physics.gravity = invert;

            else//gravity is normal if we are below 0 on the X axis
                Physics.gravity = norm;
        }

        if (sceneName == "Level 3") //level 3 splits on the y axis instead of on the x axis
        {
            if (posX >= 0)//invert the gravity if we are above 0 on the Y axis
                Physics.gravity = invert;

            else//gravity is normal if we are below 0 on the X axis
                Physics.gravity = norm;
        }

        if (sceneName == "Level 4") //level 4 splits on the y axis but the colors are reversed from level 3
        {
            if (posX <= 0)//invert the gravity if we are above 0 on the Y axis
                Physics.gravity = invert;

            else//gravity is normal if we are below 0 on the X axis
                Physics.gravity = norm;
        }

        if (sceneName == "Level 5" || sceneName == "Level 6") //level 5 does not split.  Inverse the gravity when the player presses s with a cooldown of a quarter second
        {
            if (Input.GetKey(KeyCode.S) && Time.time > shiftFlag)
            {
                if (Physics.gravity == invert)//invert the gravity if we are above 0 on the Y axis
                    Physics.gravity = norm;

                else//gravity is normal if we are below 0 on the X axis
                    Physics.gravity = invert;

                shiftFlag = Time.time + shift;
            }
        }
    }
}
