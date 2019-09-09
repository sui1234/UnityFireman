using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSignController : MonoBehaviour
{

    public GameManager gameManager;
    private void OnMouseDown()
    {
        Debug.Log("Restart");
        gameManager.RestartGame();
    }
}
