//Code by: Sai Harshit B, IndieHarshit!
//Email: sai.harshitb.24@gmail.com
//Phone: +91-843-100-3590

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotInstructor : MonoBehaviour
{
//_________________________________________________________________________________________________________________________________________________
    //Declaration of Global variables:
    public Text moves,sequence, moves1,sequence1;
    public int n,m;
    private bool f;
    private string order="",tempal="",forder="",num,num2;
    BotMovements bot;       //Object which refers to the Robot which is being controlled.
    [SerializeField]GameObject box;     //An object of GameObject Class is used to link BotMovements script to the instructor

//_________________________________________________________________________________________________________________________________________________
//The queues here store the 
    private Queue<string> main=new Queue<string>();  //This Queue stores the main sequence of instructions.
    private Queue<string> func=new Queue<string>();  // This Queue stores sequence of function area.
    private Stack<Queue> functii=new Stack<Queue>();
//_______________________________________________________________________________________________________________________________________________
   //Scene Setup:
    void Awake()    //Called as soon as the Scene is loaded.
    {
        f=false;
        bot=box.GetComponent<BotMovements>(); //The connection to the Robot is established
        nomove();  //Max no. of moves allowed is displayed.
        nomovef();
    }

//________________________________________________________________________________________________________________________________________________
// Encoding
//Functions up(),down(),left() and right() add the instructions to the instruction Queue.

    public void up()
    {
        if(f==false) 
        {
            if(n>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                main.Enqueue("Forward");  //Instruction added
                n=n-1; //Player has one move less now
                nomove(); //no. of moves updated
                order=order+"1 step ahead, ";
                sequence.text=order; //Sequence Display updated
            }
        }

        else
        {
            if(m>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                func.Enqueue("Forward");  //Instruction added
                m=m-1; //Player has one move less now
                nomovef();
                forder=forder+"1 step ahead, ";
                sequence1.text=forder; //Sequence Display updated
            } 
        }
    }

    public void down()
    {
        if(f==false) 
        {
            if (n>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                main.Enqueue("Behind"); //Instruction added
                n=n-1; //Player has one move less now
                nomove(); //no. of moves updated
                num=n.ToString();
                order=order+"1 step back, ";
                sequence.text=order; //Sequence Display updated
            }
        }

        else
        {
            if(m>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                func.Enqueue("Behind");  //Instruction added
                m=m-1; //Player has one move less now
                nomovef();
                forder=forder+"1 step back, ";
                sequence1.text=forder; //Sequence Display updated
            } 
        }
    }

    public void left()
    {
        if (f==false)
        {
            if(n>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                main.Enqueue("Left");   //Instruction added
                n=n-1; //Player has one move less now
                nomove(); //no. of moves updated
                order=order+"Turn left, ";
                sequence.text=order; //Sequence Display updated
            }
        }

        else
        {
            if(m>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                func.Enqueue("Left");  //Instruction added
                m=m-1; //Player has one move less now
                nomovef();
                forder=forder+"Turn left, ";
                sequence1.text=forder; //Sequence Display updated
            } 
        }
    }

    public void right()
    {
        if(f==false) 
        {
            if(n>0)  //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                main.Enqueue("Right");  //Instruction added
                n=n-1; //Player has one move less now
                nomove(); //no. of moves updated
                order=order+"Turn right, ";
                sequence.text=order; //Sequence Display updated
            }
        }

        else
        {
            if(m>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                func.Enqueue("Right");  //Instruction added
                m=m-1; //Player has one move less now
                nomovef();
                forder=forder+"Turn right, ";
                sequence1.text=forder; //Sequence Display updated
            } 
        }
    }

    public void funcCall()
    {
        if(f==false) 
        {
            if(n>0)  //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                main.Enqueue("Function");  //Instruction added
                n=n-1; //Player has one move less now
                nomove(); //no. of moves updated
                order=order+"Call Function, ";
                sequence.text=order; //Sequence Display updated
            }
        }

        else
        {
            if(m>0) //Instruction can be added only max no. of moves hasn't been enqueued.
            {
                func.Enqueue("Function");  //Instruction added
                m=m-1; //Player has one move less now
                nomovef();
                forder=forder+"Call Function, ";
                sequence1.text=forder; //Sequence Display updated
            } 
        }
    }

//_______________________________________________________________________________________________________________________________________________
//Switching between main area and function area
    public void funcSelect()
    {f=true;}
    public void mainSelect()
    {f=false;}

//________________________________________________________________________________________________________________________________________________
//Execution of coded instructions:

    public void execute()      //Dequeues the Queue containing the instructions
    {                    //The Bot is instructed to perform the functions as per the instruction queue.
        func.Enqueue("Return");
        while(main.Count!=0)
        {
            order=main.Dequeue();
            decideMove(order);
        }
    }

    public void execFunc()
    {
        while(true)
        {
            tempal=func.Dequeue();
            if(tempal=="Return"){func.Enqueue(tempal);return;}
            else{ decideMove(tempal);}
            func.Enqueue(tempal);    
        }
    }

    public void decideMove(string order)
    {
        if(order=="Forward")
        {bot.moveAhead();}
        else if(order=="Behind")
        {bot.moveBehind();}
        else if(order=="Left")
        {bot.turnLeft();}
        else if(order=="Right")
        {bot.turnRight();}
        else if(order=="Function")
        {execFunc();}
    }

//____________________________________________________________________________________________________________________
    //updating no. of moves left

    private void nomove()     //Main Area
    {
        num=n.ToString();
        moves.text=num;
    }

    private void nomovef()     //Function Area
    {
        num2=m.ToString();
        moves1.text=num2;
    }

}