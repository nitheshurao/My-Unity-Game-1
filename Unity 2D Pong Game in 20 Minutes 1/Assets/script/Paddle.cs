using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    float height;
    string input;
 public   bool isRight;

    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;

    }

    public void Init(bool isRightpaddle)
    {
        isRight = isRightpaddle;

        Vector2 pos = Vector2.zero;
        if (isRightpaddle)
        {
            //place in right side
            pos = new Vector2(GameManeger.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            input = "PaddelRight";
        }
        else
        {
            //place in left side
            pos = new Vector2(GameManeger.bottonleft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "PaddelLeft";
        }
        transform.position = pos;
        transform.name = input;

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
     
        //padel ids too low
        if(transform.position.y < GameManeger.bottonleft.y+ height/2 && move < 0)
        {
            move = 0;
        }
        //padel to heigh
        if (transform.position.y > GameManeger.topRight.y -height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
}
