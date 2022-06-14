using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class Player //ABSTRACT CLASS to build the players name
    {
        //PROPERTIES
        public string UserName { get; set; }
       
        //constrcutor

        protected Player(string username)
        {
            this.UserName = username;//THIS reference
        }

        public string getName()
        {
            return UserName;
        }

    }

    class GamePlayer : Player, IGame//OVERLOAD CONSTRUCTOR METHOD
    {
        //intialize varibale
        private int score = 0;

        //constructore
        public GamePlayer() :
        base("")
        {
            this.score = score;//THIS referece, holds score
        }
               
        public int Game()//executes multpiplication game
        {
            //initialize game variables
            int attempt = 0;
            int num1 = 0;
            int num2 = 0;
            int answer = 0 ;
            int guess = 0;
            while(attempt<3)//LOOP 3 attempts
            {
                Console.WriteLine("Welcome to the Math Game, press ENTER to submit answers");
                Random rand = new Random();//instance to generate random number
                num1 = rand.Next(-100, 100);//random number
                num2 = rand.Next(-100, 100);//random number
                Console.WriteLine(num1 + "*" + num2);
                answer = num1 * num2;
                string line = Console.ReadLine();//stores as string
                try//TRY BLOCK, tests conversion
                {
                    guess = Int32.Parse(line);
                }
                catch(FormatException fe)//CATCH BLOCK handles non-number input
                {
                    Console.WriteLine("ERROR! {0} is not an integer!", line);//error message
                    attempt--;//offsets incorrect score
                }
                if(guess == answer)//IF-ELSE STATEMENT correct branch
                {
                    Console.WriteLine("Correct!");
                    score++;
                    Console.WriteLine("Score: " + score + "Attempts: " + attempt);
                }
                else if(guess != answer)//IF-ELSE STATEMENT incorrect branch
                {
                    Console.WriteLine("Incorrect!");
                    attempt++;
                    Console.WriteLine("Score: " + score + " Attempts: " + attempt);
                }
            }
            return score;
        }
        public override string ToString()//OVERRIDE PARENT CLASS formats output
        {
            return getName() + "'s Score: " + score ;
        }

    }
    interface IGame //INTERFACE passes along data between classes
    {
        int Game();
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] recentScores =new string[4];//ARRAY for storing scores of players
            string hold = "";
            //1st player
            GamePlayer player1 = new GamePlayer();//builds object
            Console.WriteLine("Welcome to Multiplication game, Enter a username: ");//DISPLAYING DATA
            player1.UserName = Console.ReadLine();//ACCEPTS INPUT and creates player
            player1.Game();//Starts game
            hold = player1.ToString();
            Console.WriteLine(hold);//DISPLAYS DATA by giving player feedback
            recentScores[0] = hold;//USING ARRAY holds record of game
            //2nd Player
            GamePlayer player2 = new GamePlayer();
            Console.WriteLine("Welcome to Multiplication game, Enter a username: ");
            player2.UserName = Console.ReadLine();
            player2.Game();
            hold = player2.ToString();
            Console.WriteLine(hold);
            recentScores[1] = hold;
            //3rd Player
            GamePlayer player3 = new GamePlayer();
            Console.WriteLine("Welcome to Multiplication game, Enter a username: ");
            player3.UserName = Console.ReadLine();
            player3.Game();
            hold = player3.ToString();
            Console.WriteLine(hold);
            recentScores[2] = hold;
            //4th Player
            GamePlayer player4 = new GamePlayer();
            Console.WriteLine("Welcome to Multiplication game, Enter a username: ");
            player4.UserName = Console.ReadLine();
            player4.Game();
            hold = player4.ToString();
            Console.WriteLine(hold);
            recentScores[3] = hold;
            //Score Sheet
            Console.WriteLine("---RECENT SCORES-------");
            for (int i = 0; i<4;i++)//LOOP to show user scores of all players
            {
                Console.WriteLine((i+1)+". " + recentScores[i]);
                Console.WriteLine("-------------------------------");
            }
            Console.ReadLine();
   //Id love to further this project by using lists to create a high score table, and rotate between =,-,/, and *. I loved this class thank you Mrs.Rhodes and Mr.Torres!
        }

    }
}
