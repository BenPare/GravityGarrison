using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    public float speed = 20f; //speed of barrel rotation

    public GameObject projectile;

    public float launch = 500f; //impulse force on projectile

    public float wait = 3f; //shoot every three seconds max
    public float wFlag = 0f;

    public GameObject ball; //declare ball here so that we can check for it and destroy it before creating a new one

    // Start is called before the first frame update
    void Start()
    {
        ball = Instantiate(projectile, transform.position, transform.rotation);

        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launch, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //rotate barrel
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D)) //rotate barrel
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) && Time.time > wFlag) //fire on W, don't fire if we haven't waited long enough
        {
            Destroy(ball);

            wFlag = Time.time + wait; //set wait and flag to be zero

            ball = Instantiate(projectile, transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launch, 0)); //instantiate the ball then add the impulse force
        }
    }
}
