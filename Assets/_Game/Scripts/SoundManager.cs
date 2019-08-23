using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        ButtonInput.OnLeft += ButtonInput_OnLeft;
        ButtonInput.OnRight += ButtonInput_OnRight;

    }

    private void OnDisable()
    {
        ButtonInput.OnLeft -= ButtonInput_OnLeft;
        ButtonInput.OnRight -= ButtonInput_OnRight;

    }

    private void ButtonInput_OnRight()
    {
        Debug.Log("PIP- Right");
    }

    private void ButtonInput_OnLeft()
    {
        Debug.Log("PIP- left");
    }
}
