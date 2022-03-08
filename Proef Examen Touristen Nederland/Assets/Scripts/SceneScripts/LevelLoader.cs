using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator anim;

    void StartFade()
    {
    }


    public void LoadScene(int id)
    {
        StartCoroutine(LoadLevel(id));
    }

    IEnumerator LoadLevel(int id)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(id);
    }

}
