using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> positions = new List<Transform>();

    private int currentPosition = 1;


    private void OnEnable()
    {
        ButtonInput.OnLeft += OnLeftPressed;
        ButtonInput.OnRight += OnRightPressed;
    }

    private void OnDisable()
    {
        ButtonInput.OnLeft -= OnLeftPressed;
        ButtonInput.OnRight -= OnRightPressed;
    }

    public void Start()
    {
         UpdatePosition();
    }

    public void OnLeftPressed()
    {
        //Debug.Log("move left");
        //gräns for left
        if (currentPosition > 0)
        {
            currentPosition--;
            UpdatePosition();
        }
       
       
    }

    public void OnRightPressed()
    {
        //Debug.Log("move right");
        //gräns for right
        if (currentPosition < positions.Count - 1)
        {
            currentPosition++;
            UpdatePosition();
        }
        
    }


    //   give transform middle's position to fireman. 
    private void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;
    }
}

