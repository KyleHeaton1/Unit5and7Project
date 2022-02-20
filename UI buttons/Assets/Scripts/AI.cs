using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private float nextStateTimer;
    private string stateText;
    Animator anim;
    public float speed;
    private Quaternion _lookRotation;
    Rigidbody rb;

    enum States
    {
        Idle,
        Turn,
        Walk
    }

    States state;

    float x;
    float y;
    float z;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        nextStateTimer = 2;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ProcessStates();

    }
    // State logic - switch states depending on what logic we want to apply
    void ProcessStates()
    {
        nextStateTimer -= Time.deltaTime;

        if(state == States.Idle)
        {
            Idle();

            if( nextStateTimer < 0 )
            {
                state = States.Turn;
                nextStateTimer = 3;
            }
        }

        if(state == States.Turn)
        {

            Turn();
            if( nextStateTimer < 0 )
            {
                state = States.Walk;
                nextStateTimer = 1f;
            }

        }

        if(state == States.Walk)
        {
            if( nextStateTimer < 0 )
            {
                state = States.Idle;
                nextStateTimer = 3;
            }

            Walk();
        }

       

    }


    // Different AI Update methods
    void Idle()
    {
        
        stateText = "Idle";
        anim.SetBool("isRun", false);
        x = Random.Range(30.02f, -30.62f);
        z = Random.Range(20.48f, -20.48f);
        y = 0f;
        pos =  new Vector3(x, y, z);
        
    }

    void Turn()
    {
        print("Turn");
        stateText = "Turn";
        //transform.LookAt(pos);
        _lookRotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 4);
        Debug.Log(pos);
        
    }

    void Walk()
    {
        //anim.SetBool("isRun", true);

        //THIS IS FOR JOKES DELETE THIS FOR LATER LOL
        /*
        int randomNumber = Random.Range(1, 3);
        if(randomNumber == 1){
            FindObjectOfType<SoundManager>().Play("Click2");
            anim.SetBool("isFlip", true);
        }
        else{
            anim.SetBool("isRun", true);
            Debug.Log(randomNumber);
        }
        */
        anim.SetBool("isRun", true);

        
        stateText = "Walk";
        //transform.position = Vector3.MoveTowards(transform.position, pos, speed* Time.deltaTime);
        rb.velocity = pos;
        Debug.Log(pos);
    }

}