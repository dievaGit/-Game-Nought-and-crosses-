using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCeroX
{
    class Program    
    {
        //Creando el tablero
        static int[,] tablero = new int[3, 3];

        //Creando arreglo para para escribir en el tablero: espacio, x o O.
        static char[] simbolo = {' ', 'O', 'X'};

        //Funcion Dibujar tablero
        static void Dibujar()
        {
            int fila = 0, columna = 0;

            Console.WriteLine();
            Console.WriteLine(" -------------");

            for(fila = 0; fila < 3; fila ++)
            {
                Console.Write(" |");
                for(columna = 0; columna < 3; columna++)
                {
                    //if(fila == i && columna == j)
                    //{
                    //    tablero[fila, columna] = x;
                   // }
                    
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine(" -------------");
            }

        }

        // Funcion que halla el ganador
        static bool HallarGanador()
        {
            int fila = 0, columna = 0;
            for (fila = 0; fila < 3; fila++)
            {
                //buscando ganador para cada fila
                if ((tablero[fila, 0] != 0) && (tablero[fila, 0] == tablero[fila, 1]) && (tablero[fila, 0] == tablero[fila, 2]))
                {
                    return true;
                }
            }

            //buscando ganador para cada columna
            for (columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] != 0) && (tablero[0, columna] == tablero[1, columna]) && (tablero[0, columna] == tablero[2, columna]))
                {
                    return true;
                }
            }

            //Comprovando en cruces
            if (((tablero[0, 0] != 0) && (tablero[0, 0] == tablero[1, 1]) && (tablero[0, 0] == tablero[2, 2])) || ((tablero[0, 2] != 0 )&& (tablero[0, 2] == tablero[1, 1]) && (tablero[0, 2] == tablero[2, 0])))
            {
                return true;
            }

            return false;

        }

        //Preguntar Posicion al jugador
        static void PreguntarPosicion(int jugador)
        {
            int fila = 0, columna = 0;

            //Pedimos la posicion en la fila

            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador {0}", jugador);

             
                do
                {
                    Console.Write("Seleciones la fila (1 de 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());
                }
                while ((fila < 1) || (fila > 3));

                //Pedimos la posicion en la columna
                do
                {
                    Console.Write("Seleciones la columna (1 de 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());
                }
                while ((columna < 1) || (columna > 3));
                
                if(tablero[fila - 1, columna - 1] != 0)
                {
                    Console.WriteLine("Casilla ocupada!");
                }
            }
            while (tablero[fila - 1, columna - 1] != 0);

            //Si los datos son correctos se le asigna el jugador
            tablero[fila - 1, columna - 1] = jugador;
        }
          
        //Programa principal del juego
        static void Main(string[] args)
        {
            int jg = 0;

            Dibujar();
            Console.WriteLine(" Jugador 1 = O\n Jugador 2 = X");
            Console.WriteLine();

            for(int x = 1; x <= 9; x ++)
            {
                if (x % 2 != 0)
                {
                    jg = 1;
                    PreguntarPosicion(jg);
                    Dibujar();
                    if (HallarGanador() == true)
                    {
                        Console.Write("EL JUGADOR 1 HA GANADO");
                    }
                    else
                    {
                        jg = 2;
                        PreguntarPosicion(jg);
                        Dibujar();
                        if (HallarGanador() == true)
                        {
                            Console.Write("EL JUGADOR 2 HA GANADO");
                        }
                    }
                }
                
            }
         
           Console.ReadKey();
        }
    }
}
