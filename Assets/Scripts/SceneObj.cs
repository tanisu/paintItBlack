using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneObj : MonoBehaviour
{
    [SerializeField] GameObject frontImage;

    void Start()
    {
        StartCoroutine(_flashLogo());
    }

    IEnumerator _flashLogo()
    {
        while (true)
        {
            frontImage.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            frontImage.SetActive(false);
            yield return new WaitForSeconds(0.15f);
        }
    }


    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

}
