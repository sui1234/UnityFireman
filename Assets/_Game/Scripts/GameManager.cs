using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    string sceneName = "Main";
    
    public int startLives = 3;
    private int points = 0;
    StartButtonController startButtonController;



    public TextMeshPro ScoreText;
    public LivesController livesController;
    JumperSpawner jumperSpawner;
    

    public GameObject gameOverSign;
    public GameObject input;



    private void OnEnable()
    {
        JumperController.OnJumperCrash += JumperCrashed;
        JumperController.OnJumperSave += JumperSaved;
    }

    private void OnDisable()
    {
        JumperController.OnJumperCrash -= JumperCrashed;
        JumperController.OnJumperSave -= JumperCrashed;
    }


    private void Start()
    {
        UpdateScoreLabel();
        gameOverSign.SetActive(false);
        livesController.InitLives(startLives);

        //if (Input.GetMouseButtonDown(0))
        //{
        //StartAfterButtonIsClicked();
        //}
        jumperSpawner = GetComponent<JumperSpawner>();
      
        // can use public to show in inspector.
    }

   /* private void StartAfterButtonIsClicked()
    {
        jumperSpawner = GetComponent<JumperSpawner>();// can use public to show in inspector.

    }*/

    //get points
    public int Points()
    {
        return points;
    }



    public void JumperCrashed()
    {
        if (!livesController.RemoveLife())
        {
            GameOver();
            
        }
        
       
    }

    
    public void JumperSaved()
    {
        points++;
        UpdateScoreLabel();
    }

    void UpdateScoreLabel()
    {
        ScoreText.text = points.ToString();
    }

    private void GameOver()
    {
        gameOverSign.SetActive(true);
        //Debug.Log("Game Over!");
        jumperSpawner.Stop();
        input.SetActive(false);
    }

    public void RestartGame() {
        //restart
        SceneManager.LoadScene(sceneName);
    }

    

   
    

  
  
}
