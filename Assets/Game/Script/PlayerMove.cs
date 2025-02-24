using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void Update()
    {
        MyInput();
        if(Input.GetKey(KeyCode.F)){
            Scene currentScene=SceneManager.GetActiveScene();
            if(currentScene.name=="Deer3D"){
                SceneManager.LoadScene("Deer");
            }
            else if(currentScene.name=="Tiger3D"){
                SceneManager.LoadScene("Tiger");
            }
            else if(currentScene.name=="Chicken3D"){
                SceneManager.LoadScene("Chicken");
            }
            else if(currentScene.name=="Dog3D"){
                SceneManager.LoadScene("Dog");
            }
            else if(currentScene.name=="Cat3D"){
                SceneManager.LoadScene("Cat");
            }
            else if(currentScene.name=="Horse3D"){
                SceneManager.LoadScene("Horse");
            }
            else if(currentScene.name=="Penguin3D"){
                SceneManager.LoadScene("Penguin");
            }
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized*moveSpeed*10f,ForceMode.Force);
    }

}