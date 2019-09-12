using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    public delegate void Jumper();
    public static event Jumper OnJumperCrash;
    public static event Jumper OnJumperSave;


    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    public int currentPosition = 0;

    float lastMoveTime;
    float moveDelay = 1.0f;

    public LayerMask layerMask;

    private bool dead = false;
    float deathDelay = 0.5f;

    

    //[HideInInspector]
    //public GameManager gameManager;


    [HideInInspector]
    public JumperSpawner jumperSpawner;


    private void Start()
    {
        UpdatePosition();
        /*if (Input.GetMouseButtonDown(0))
        {

        StartAfterButtonIsClicked();
    
        }*/
        lastMoveTime = Time.time;
        StartCoroutine(Move());

    }
    /*private void StartAfterButtonIsClicked()
    {
        lastMoveTime = Time.time;
        StartCoroutine(Move());
    }*/



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

        if(positions[currentPosition].gameObject.tag == "DangerPosition")
        {
            //Debug.Log("Danger!!!");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);


            //on ingen fireman finns under oss.
            if (hit.collider == null)
            {
                StartCoroutine(Crash());
                if (OnJumperCrash != null)
                    OnJumperCrash();

                //gameManager.JumperCrashed();
                //Debug.Log("Saved!" + hit.collider.gameObject.name);
            }
            else
            {
                OnJumperSave();

                //gameManager.JumperSaved();
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
        jumperSpawner.DestroyJumper(parent);
        //GameObject parent = transform.parent.gameObject;
        //Destroy(parent);

    }
}
