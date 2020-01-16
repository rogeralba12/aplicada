using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eljuego
{
    class game
    {
       



        #region "enums"
        public enum egamestate
        {

            starting, playing, over
        }
        public enum attemptresult
        {

            guessed,
            lower,
            greater
        }

        #endregion


        #region "attributes"

        const int MIN = 1, MAX = 1001;
        const string DEFAULTPATH = "score.txt";
        public int secretnumber { get; set; }
        public int Lasttry { get; set; }
        //random 1y 1000
        
        public int attempts { get; set; }
        public egamestate currentstate { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        public TimeSpan TimeSpent
        {

            get
            {
                return endtime.Subtract(starttime);
            }
        }

        public string scorepath { get; set; }

        #endregion

        #region "behaviours"
        public void Gameinit()
        {

            scorepath = DEFAULTPATH;
            secretnumber = generate(MIN, MAX);

            currentstate = egamestate.starting;
            attempts = 0;
            starttime = DateTime.Now;
            Console.WriteLine(read());
        }
        private int generate(int min, int max)
        {


            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public attemptresult Checkifguessed()
        {

            attempts++;
            if (Lasttry == secretnumber)
            {
                savestate();
                return attemptresult.guessed;
            }
            else if (Lasttry > secretnumber)
           
                return attemptresult.greater;
            
          


                return attemptresult.lower;
            
        }


        public void savestate()
        {


            var streamwrite = File.AppendText(scorepath);
            streamwrite.Write($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {attempts}");
            streamwrite.Flush();
            streamwrite.Close();
        }

        public string read()
        {
            if (File.Exists(scorepath))
                return File.ReadAllText(scorepath);
            else
                return "";
        }
        #endregion

    }

        

    

    
}
