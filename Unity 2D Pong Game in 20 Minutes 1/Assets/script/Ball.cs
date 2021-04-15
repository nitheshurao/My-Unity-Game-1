using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    float radius;
    Vector2 deirction;

    void Start()
    {
        deirction = Vector2.one.normalized; //dirion (1,1)
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(deirction * speed * Time.deltaTime);
        //ball hit back to wall up and down
        if (transform.position.y < GameManeger.bottonleft.y + radius &&deirction.y<0)
        {
            deirction.y = - deirction.y;
        }
        //padel to heigh
        if (transform.position.y > GameManeger.topRight.y - radius && deirction.y > 0)
        {
            deirction.y = - deirction.y;
        }


        //Gam over
        if (transform.position.x < GameManeger.bottonleft.x + radius && deirction.x < 0)
        {
            Debug.Log("right side is won");
            Time.timeScale = 0;//freze the geame
            enabled = false;
        }
        if (transform.position.x > GameManeger.topRight.x - radius && deirction.x > 0)
        {
            Debug.Log("left side is won");
            Time.timeScale = 0;//freze the geame
            enabled = false; //stop updating scrpt
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddel")
        {
            //boll is hit paddel and hit back 
            bool isRight = other.GetComponent<Paddle>().isRight;

            if(isRight ==true&& deirction.x > 0)
            {
                deirction.x = - deirction.x;
            }
            if (isRight ==false && deirction.x < 0)
            {
                deirction.x = - deirction.x;
            }
        }
    }
}
