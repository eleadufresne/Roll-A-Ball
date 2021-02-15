using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    private Animator animator;

    private void Start()
    {
        animator = GameObject.Find("BlackFade").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                animator.SetTrigger("Fade_out");
                LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Maze");
    }
}
