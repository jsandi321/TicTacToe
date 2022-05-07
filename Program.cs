using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        //Matriz tablero
        static int[,] tablero = new int[3, 3];

        //Arreglo de simbolos
        static char[] simbolo = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {
            bool terminado = false;

            //Dibujo de tablero
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O \nJugador 2 = X");
            do
            {
                PreguntarPos(1); //Envia valor 1 al metodo PreguntarPos
                //Dibujar la casilla del jugador 1
                DibujarTablero();

                //Se comprueba si hay victoria de jugador 1
                terminado = ComprobarGanador();
                if (terminado == true)
                {
                    Console.WriteLine("El jugador 1 ha ganado!!!");
                }
                else
                {
                    terminado = ComprobarEmpate();
                    if (terminado == true)
                    {
                        Console.WriteLine("Esto es un empate!!!");
                    }
                    else
                    {
                        //Turno de jugador 2
                        PreguntarPos(2);
                        //Dibujar Casilla de jugador 2
                        DibujarTablero();
                        //Se comprueba si hay victoria de jugador 2
                        terminado = ComprobarGanador();
                        if (terminado == true)
                        {
                            Console.WriteLine("El jugador 2 ha ganado!!!");
                        }
                    }
                }

            } while (!terminado); /*Mientas la variable terminado = false 
                                   * el ciclo de juego continiara hasta que
                                   * terminado = true ya sea por victoria o
                                   * empate*/

        }

        //Se dibuja el trablero en consola
        static public void DibujarTablero()
        {
            //Variables
            int fila = 0;
            int columna = 0;

            Console.WriteLine();
            Console.WriteLine("----------");

            for(fila =0; fila < 3; fila++)
            {
                Console.Write("|");
                for(columna = 0; columna < 3; columna++)
                {
                    //Asigna un espacio, O, X segun sea necesario
                    Console.Write("{0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("----------");
            }
        }

        static void PreguntarPos(int jugadorPa) //1 = jugador1 & 2 = jugador2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador {0}", jugadorPa);
                //Pedimos el numero de fila
                do
                {
                    Console.Write("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila < 1 ) || (fila > 3));

                //Pedimos la columna
                do
                {
                    Console.Write("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3)) ;

                if(tablero[fila -1, columna-1] != 0)
                {
                    Console.WriteLine("La casilla ya esta ocupada!!!");
                }
            } while (tablero[fila - 1, columna - 1] != 0);

            //Si todo es correcto asignamos el signo al jugador en turno
            tablero[fila - 1, columna - 1] = jugadorPa;
        }

        //Metodo compueba las casillas buscando combinaciones de victoria
        static bool ComprobarGanador()
        {
            //Devuelve True cuadno hay un ganador con 3 en linea
            int fila, columna;
            bool tictactoe = false;

            for(fila = 0; fila < 3; fila++)
            {
                //Si en alguna fila todas las casillas son iguales y no vacias 
                if ((tablero[fila, 0] == tablero[fila, 1]) && (tablero[fila, 0] == tablero[fila, 2]) && (tablero[fila, 0] != 0))
                {
                    tictactoe = true;

                }
            }
            for(columna = 0; columna < 3; columna++)
            {
                //Si en alguna columna todas las casillas son iguales y no vacias 
                if ((tablero[0, columna] == tablero[1,columna]) && (tablero[0, columna] == tablero[2, columna]) && (tablero[0,columna] != 0))
                {
                    tictactoe = true;

                }
            }
            //Comprueba la diagonal hacia la derecha
            if ((tablero[0, 0] == tablero[1, 1]) && (tablero[0, 0] == tablero[2, 2]) && (tablero[0, 0] != 0))
            {
                tictactoe = true;

            }
            //Comprueba la diagonal izquierda
            if ((tablero[0, 2] == tablero[1, 1]) && (tablero[0, 2] == tablero[0, 0]) && (tablero[0, 2] != 0))
            {
                tictactoe = true;

            }
            return tictactoe;
        }

        //Metodo de empate, True = empate y fin de partida y False = No empate continuamos
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila, columna;

            for(fila = 0; fila < 3; fila++)
            {
                for(columna = 0; columna < 3; columna++)
                {
                    if(tablero[fila, columna] == 0)
                    {
                        hayEspacio = true;
                    }
                }
            }
            return !hayEspacio;
        }
    }
}
