using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{

    public enum Button
    {
        left,
        right
    }
    //public bool left;
    public Button button;



    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;

    //public FiremanController fireman;

    private void OnMouseDown()
    {
        if (OnLeft != null && button == Button.left)// minst en prenumerant på vårt event
        {
            OnLeft();
            //fireman.OnLeftPressed();
        }
        else if(OnRight != null&& button == Button.right)
        {
            OnRight();
            //fireman.OnRightPressed();
        }
        
    }
}
