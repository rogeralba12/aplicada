using System;
using System.Threading;

namespace eljuego
{
	class Program
	{

		static game currentgame = new game();
		static Thread inputThread;
		
		static void Main(string[] args)
		{


			
			
		currentgame.Gameinit();
		inputThread = new Thread(input);
		inputThread.Start();
			while(currentgame.currentstate != game.egamestate.over)
        {

            switch (currentgame.currentstate)
            {
				case game.egamestate.starting:
					Console.WriteLine("Digite un valor entre 1 y 1000:");
						currentgame.currentstate = game.egamestate.playing;
						break;
				case game.egamestate.playing:
					if (currentgame.Lasttry == 0)
						continue;

					switch (currentgame.Checkifguessed()) {
						case game.attemptresult.greater:
							Console.WriteLine("El numero secreto es menor");
							break;
						case game.attemptresult.lower:
							Console.WriteLine("El numero secreto es mayor");
							break;
							default:
						Console.WriteLine("Ha adivinao'");
							currentgame.currentstate = game.egamestate.over;
							break;

					}


					if(currentgame.currentstate != game.egamestate.over)
						Console.WriteLine("dIGITE OTRO VALOR");

					currentgame.Lasttry = 0;
					break;
            }

        }
		
		

		

	//inputThread.Abort();
	//inputThread.Join();
			
		Console.WriteLine("Gracias por jugar");
	}

		static void input()
{

	int currentvalue = 0;
	while (currentgame.currentstate != game.egamestate.over)
	{
				
		currentvalue = Convert.ToInt32(Console.ReadLine());
		currentgame.Lasttry = currentvalue;
	}


}
    }
}
