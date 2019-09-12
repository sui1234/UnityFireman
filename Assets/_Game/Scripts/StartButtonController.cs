using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    //private bool started;

    private void Awake()
    {
        Time.timeScale = 0;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            Debug.Log("Start button is clicked!!");

       

            gameObject.SetActive(false);
        }
    }
}
