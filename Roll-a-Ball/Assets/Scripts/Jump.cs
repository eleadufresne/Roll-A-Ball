using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI jumpText;
    private float disapearTime;

    // Start is called before the first frame update
    void Start()
    {
        jumpText.text = "You must Jump!";
        disapearTime = Time.time + 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpText.text == "You must Jump!" && (Time.time >= disapearTime))
        {
            jumpText.text = " ";
        }
    }
}
