using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame update

    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottonleft;
    public static Vector2 topRight;
    void Start()
    {
        //convert game screeen pixle coordinate into games cordinate
        bottonleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2( Screen.width, Screen.height));
        Instantiate(ball);


        //Instantiate(paddle);

        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init  (true);
        paddle2.Init  (false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
