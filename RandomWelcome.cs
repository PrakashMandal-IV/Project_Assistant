using System;

namespace SampleAssistant
{
     class RandomWelcome
    {
        private Random welcome = new Random();
        private int Rand { get; set; }
        private string NewWelcome { get; set; }
        public RandomWelcome()
        {
            Rand = welcome.Next(1,5);
        }

        public string Welcome()
        {
            if(Rand == 1)
            {
                NewWelcome = "Welcome back sir ";
            }
            else if (Rand == 2)
            {
                
                NewWelcome = "Yeah  yeah i am up";
            }
            else if (Rand == 3)
            {
                NewWelcome = "OH you are back";
            }
            else if(Rand == 4)
            {
                NewWelcome = "I am always awake ";
            }
            return NewWelcome;
        }
        
    }
}
