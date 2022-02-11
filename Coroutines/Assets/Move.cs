using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRB;
    int i;


    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        Moving();
    }

    private void Update()
    {

    }
    public void Moving()
    {
        while(i < 5)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        transform.position += transform.right * -speed * Time.deltaTime;
        yield return new WaitForSeconds(0.5f);
        transform.position += transform.right * speed * Time.deltaTime;
        yield return new WaitForSeconds(0.5f);
        i += 1;
    }
}
