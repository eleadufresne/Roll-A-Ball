using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public KeyCode PlayAgainKeyboardInput = KeyCode.Escape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PlayAgainKeyboardInput))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
    }
}
