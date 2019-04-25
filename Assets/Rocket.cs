using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody; // Do it like this. Simply put, the function is Rigidbody and the variable is rigidBody. This simply tells the
                         // class to look in unity for rigidbody. It will use what is attached to this class.
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        rigidBody = GetComponent<Rigidbody>(); //GetComponent will now look for Rigidbody making the variable rigidBody usable.
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) // You can thrust while rotating.
        {
            rigidBody.AddRelativeForce(Vector3.up); //Vector3 gives you a X,Y,Z position. We use it to give position and then create
                                                    //movement. See more here - https://docs.unity3d.com/ScriptReference/Vector3.html
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }

        if (Input.GetKey(KeyCode.A)) // Turn left
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D)) // Turn right
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
