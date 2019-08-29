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

    public LayerMask layerMask;

    private bool dead = false;
    float deathDelay = 0.5f;
    
    private void Start()
    {
        UpdatePosition();
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
        while (!dead)
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


            DestroyJumper();

        }


        else
        {
            UpdatePosition();

        }

    }


    void UpdatePosition()
    {


        transform.position = positions[currentPosition].position;
        //if (transform.position.y < -2.7)

        if(positions[currentPosition].gameObject.tag=="DangerPosition")
        {
            //Debug.Log("Danger!!!");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);


            //on ingen fireman finns under oss.
            if (hit.collider == null)
            {
                StartCoroutine(Crash());
                //Debug.Log("Saved!" + hit.collider.gameObject.name);
            }
            else
            {
                //säg till game manager att vi räddats.
            }
            
        }


    }

    IEnumerator Crash()
    {
        dead = true;

        // säg till gamemanager att vi crashat

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(deathDelay);

        DestroyJumper();

    }
    void DestroyJumper()
    {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);

    }
}
