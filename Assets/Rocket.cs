using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody; // Do it like this. Simply put, the function is Rigidbody and the variable is rigidBody. This simply tells the
                         // class to look in unity for rigidbody. It will use what is attached to this class.
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        rigidBody = GetComponent<Rigidbody>(); //GetComponent will now look for Rigidbody making the variable rigidBody usable.
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":  //Do nothing
                print("Okay");
                break;

            default: //Die
                print("Dead");
                break;
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        
        float rotationThisFrame = rcsThrust * Time.deltaTime;
       
        if (Input.GetKey(KeyCode.A)) // Turn left
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D)) // Turn right
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {

        if (Input.GetKey(KeyCode.Space)) // You can thrust while rotating.
        {
            //print("Space bar pressed");
            rigidBody.AddRelativeForce(Vector3.up * mainThrust); //Vector3 gives you a X,Y,Z position. We use it to give position and then create
                                                                 //movement. See more here - https://docs.unity3d.com/ScriptReference/Vector3.html
            //Debug.Log("Sound is not playing. Sound started");
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            //Debug.Log("Space Bar not pressed. Sound Stopped");
            audioSource.Stop();
        }
        
    }
}
