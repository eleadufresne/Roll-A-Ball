using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    [SerializeField] private Animator transitionAnim;

    private void Start()
    {
        transitionAnim = GameObject.Find("BlackFade").GetComponent<Animator>();
    }

    void Update()
    {
        if (gameObject.transform.position.y < -50)
        {
            transitionAnim.SetTrigger("fadeIn");
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
