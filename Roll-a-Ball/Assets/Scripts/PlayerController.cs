using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject restartTextObject;
    public GameObject missingTextObject;

    private Rigidbody rb;
    private int count; //score
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        restartTextObject.SetActive(false);
        missingTextObject.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {//function body

        //Vector2 data from the movement value
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 27)
        {
            missingTextObject.SetActive(true);
        }
        if (count >= 28)
        {
            missingTextObject.SetActive(false);
            winTextObject.SetActive(true);
            restartTextObject.SetActive(true);
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
