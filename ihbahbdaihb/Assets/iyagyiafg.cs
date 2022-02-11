using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iyagyiafg : MonoBehaviour
{
    float num = 0.5f;
    public Rigidbody2D rb;
    int i;
    SpriteRenderer sr;

    float x;
    Vector3 movement = Vector3.zero;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Wait());
        StartCoroutine(Fade());
        
    }
    void Update()
    {
        transform.position += movement*Time.deltaTime;
    }
    IEnumerator Wait()
    {
        while(i < 10)
        {
            movement.x = -1;
            yield return new WaitForSeconds(num);
            movement.x = 1;
            yield return new WaitForSeconds(num);
            Debug.Log(num);
            i++;
        }
    }

    IEnumerator Fade()
    {
        float red, green;
        int i;

        for(i = 0; i < 200; i++)
        {
            red = (20 - i) / 20.0f;
            sr.color = new Color(red, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        for (i = 0; i < 200; i++)
        {
            red = i / 20.0f;
            sr.color = new Color(red, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        for (i = 0; i < 200; i++)
        {
            green = (20 -i) / 20.0f;
            sr.color = new Color(green, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        for (i = 0; i < 200; i++)
        {
            green = i/ 20.0f;
            sr.color = new Color(green, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}

