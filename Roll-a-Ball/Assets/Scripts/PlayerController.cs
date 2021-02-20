using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private GameObject winTextObject;
    [SerializeField] private GameObject restartTextObject;
    [SerializeField] private GameObject missingTextObject;
    [SerializeField] private GameObject bigPickUp;

    private Rigidbody rb;
    private int count; //score
    private float movementX;
    private float movementY;
    
    private float displayTime;
    private float disapearTime;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        if(SceneManager.GetActiveScene().buildIndex == 1)
            count = 28;
        else
            count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        restartTextObject.SetActive(false);
        missingTextObject.SetActive(false);
        bigPickUp.SetActive(false);
        displayTime = 5.0f;
    }
    void OnMove(InputValue movementValue)
    {//function body

        //Vector2 data from the movement value
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Update()
    {
        if (missingTextObject.activeSelf && (Time.time >= disapearTime) )
        {
            missingTextObject.SetActive(false);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 27)
        {
            missingTextObject.SetActive(true);
            disapearTime = Time.time + displayTime;
            bigPickUp.SetActive(true);
        }
        else if (count == 29)
        {
            speed *= 4.0f;
        }
        else if (count >= 30)
        {
            Time.timeScale = 0.01f;
            winTextObject.SetActive(true);
            restartTextObject.SetActive(true);
            countText.text = " ";
        }
    }
    
    //FixedUpdate when we use forces
    void FixedUpdate() 
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //makes it so we can adjust the speed for the Unity editor
        rb.AddForce(movement * speed);
    }
    //To interact with pick up objects
    void OnTriggerEnter(Collider other)
    {
        //If it is a collectible up object, deactivate it  
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
            ++count;
            SetCountText();
        }
    }
}
