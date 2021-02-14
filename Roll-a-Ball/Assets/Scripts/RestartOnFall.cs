using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    void Update()
    {
        if(gameObject.transform.position.y < -50)
            SceneManager.LoadScene("MiniGame");
    }
}
