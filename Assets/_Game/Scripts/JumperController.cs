using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    // Start is called before the first frame updaxste
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    public int currentPosition = 0;

    float lastMoveTime;
    float moveDelay = 1.0f;
    
    private void Start()
    {
        transform.position = positions[currentPosition].position;
        lastMoveTime = Time.time;
        StartCoroutine (Move());
    }



    //private void Update()
    //{
    //  if (Time.time > lastMoveTime + moveDelay)
    //{
    //  MoveToNextPosition();
    //lastMoveTime = Time.time;
    // }
    //}


    IEnumerator Move()
    {
        while (true)
        {

            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }

       
    }


    void MoveToNextPosition()
    {
        currentPosition++;

        if (currentPosition >= positions.Count)
        {


            //currentPosition = 0;

            //ta bort vår jumper och eventuellt ge poäng
            //gameObject.SetActive(false);

            GameObject parent = transform.parent.gameObject;
            Destroy(parent);



        }


        else
        {
            transform.position = positions[currentPosition].position;

        }

    }
}
