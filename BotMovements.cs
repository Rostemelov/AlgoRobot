using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class BotMovements : MonoBehaviour
{
    public float step; //size of step defined;
    public Rigidbody2D rb;

    public void moveAhead() //Robot Moves Ahead by a step
    {
        transform.Translate(0,step,0);
    }

    public void moveBehind() //Robot Moves Behind by a step
    {   
        transform.Translate(0,-step,0);
    }

    public void turnRight() //Robot Turns right 90 degrees
    {
        transform.Rotate(0,0,-90);
    }

    public void turnLeft() //Robot Turns left 90 degrees
    {
        transform.Rotate(0,0,90);
    }
 
 
}
