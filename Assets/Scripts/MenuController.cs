using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator SceneTransition;

    public void StartGame()
    {
        StartCoroutine("LoadLevel");
    }

    IEnumerator LoadLevel()
    {
        SceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(1);
    }
}
