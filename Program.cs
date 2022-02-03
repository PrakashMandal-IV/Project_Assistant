using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SampleAssistant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer talk = new SpeechSynthesizer();
             talk.SelectVoiceByHints(VoiceGender.Female);
            talk.Rate=1;
             talk.Speak("Hello Sir, "+Greet()+ ", This is Lacia, your Assistant, How can i help you ");
          //  talk.SpeakAsync("This is Lacia, your Assistant, How can i help you ");

            bool off = true;
             boot:    //Restart point
            
            do
            {
                string getInput = Console.ReadLine();

                string input = getInput.ToLower();
                if (input.Contains("time"))
                {
                    talk.SpeakAsync("It's,"+DateTime.Now.ToString("h:mm tt"));
                }
                else if (input.Contains("date"))
                {
                    talk.SpeakAsync("It's," + DateTime.Now.ToString("dd/MM/yyyy"));
                }
                else if (input.Contains("who are you") || input.Contains("tell me about yourself"))
                {
                    talk.SpeakAsync("My Name is Lacia. Virtual Assistant. Just a sample for now");
                }
                else if ((input.Contains("you") && input.Contains("go off") || input.Contains("lacia") && input.Contains("go off")) && Greet() == "Good Evening")
                {
                    talk.SpeakAsync("Going off, Good Night Sir");
                    off= false;
                    GC.Collect();
                }
                else if (input.Contains("you") && input.Contains("go off") || input.Contains("lacia") && input.Contains("go off"))
                {
                    talk.SpeakAsync("Going off, Have a nice day sir");
                    off = false;
                    GC.Collect();
                }
            } while(off);

            restart:
            string tempreboot = Console.ReadLine();
            string reboot = tempreboot.ToLower();
            if (reboot.Contains("lacia")&& (reboot.Contains("wakeup")|| reboot.Contains("wake up")))
            {
                RandomWelcome welcome = new RandomWelcome();  //random welcome speech
                talk.SpeakAsync(welcome.Welcome() +",   how can i help you"); 
                off = true;
                goto boot;
            }
            else { goto restart; }
            
            
            
        }

        //Methods
        public static string Greet()
        {
            DateTime current = DateTime.Parse(DateTime.Now.ToString("h tt"));
            DateTime morning = DateTime.Parse("12 PM");
            DateTime afternoon = DateTime.Parse("4 PM");
            DateTime evening = DateTime.Parse("7 PM");
            DateTime night = DateTime.Parse("4 AM");

            int m1 = DateTime.Compare(current, night);     // 1 
            int m2 = DateTime.Compare(current, morning);   // -1

            int a1 = DateTime.Compare(current, morning);  //1
            int a2 = DateTime.Compare(current, afternoon); //-1

            int e1 = DateTime.Compare(current, afternoon); //1
            int e2 = DateTime.Compare(current, evening); //-1


            string result;

            if (m1 > 0 && m2 < 0)
            {
                result = "Good morning";
            }
            else if (a1 > 0 && a2 < 0)
            {
                result = "Good Afternoon";
            }
            else if (e1 > 0 && e2 < 0)
            {
                result = "Good Evening";
            }
            else { result = " Good Evening"; }
            return result;



        }
    }
}






