using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//using System.Media;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool condition=true;
            int turn = 1, plusdamagex1 = 0, gameisrunning = 0, attack, attackorno, plusdamagex2 = 0, health1 = 0;
            bool stun1 = false, stun2 = false, checkhealth1 = true, checkhealth2 = true;
            int[,] HealthEnergyDefense = new int[4, 3] { { 90, 70, 110 }, { 110, 90, 70 }, { 90, 90, 90 }, { 70, 110, 90 } };
            List<ConsoleColor> z = new List<ConsoleColor>();
            ConsoleColor[] color = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            ConsoleKeyInfo arrow;
            int index = 0, itemuse1 = 0, itemuse2 = 0, attackindex = 0, itemindex = 0;
            int[,] charHED = new int[4, 2] { { 4, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            int[,,] pixarray = new int[4, 27, 33] { { { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 15, 15, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 15, 15, 15, 0, 15, 15, 15, 15, 15, 0, 0, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 15, 15, 15, 15, 0, 0, 15, 15, 15, 15, 15, 15, 15, 0, 11, 11, 11, 11, 11, 11, 11 }, { 11, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 0, 11, 11, 11, 11, 11, 11, 11 }, { 12, 12, 12, 12, 11, 11, 11, 11, 11, 11, 11, 0, 15, 15, 15, 0, 15, 15, 15, 15, 15, 0, 15, 15, 15, 0, 11, 11, 11, 11, 11, 11, 11 }, { 12, 12, 12, 12, 12, 11, 11, 11, 11, 11, 11, 0, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 0, 11, 11, 11, 11, 11, 11, 11 }, { 12, 12, 12, 12, 12, 12, 12, 11, 11, 11, 11, 0, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 0, 11, 11, 11, 11, 11, 11, 11 }, { 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 11, 11, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 11, 11, 15, 15, 15, 15, 15, 15, 15, 11, 11, 9, 9, 9, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11, 11 }, { 11, 11, 11, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11 }, { 11, 11, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 12, 12, 12, 14, 14, 14, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11 }, { 11, 11, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 12, 12, 12, 14, 14, 14, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11 }, { 11, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11 }, { 12, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11 }, { 12, 12, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11, 11 }, { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11, 11, 11 }, { 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 9, 9, 15, 15, 15, 9, 9, 9, 9, 9, 9, 9, 15, 15, 15, 9, 9, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 9, 9, 15, 15, 15, 9, 9, 9, 9, 9, 9, 9, 15, 15, 15, 9, 9, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11, 11, 11 }, { 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 } }, { { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 2, 2, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 0, 2, 2, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 0, 0, 0, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0, 0, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 0, 2, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2, 2, 2, 0, 11, 11, 11, 11, 11 }, { 11, 11, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2, 0, 11, 11, 11, 11 }, { 11, 11, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 11, 11, 11, 11 }, { 11, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 11, 11, 11 }, { 11, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 11, 11, 11 }, { 11, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 0, 11, 11, 11 }, { 11, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 0, 11, 11, 11 }, { 11, 0, 2, 2, 2, 2, 2, 2, 0, 11, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 0, 11, 0, 2, 2, 2, 2, 0, 11, 11, 11 }, { 11, 11, 0, 0, 0, 0, 0, 0, 11, 11, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 11, 11, 0, 0, 0, 0, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 5, 0, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 } }, { { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 14, 14, 14, 12, 12, 12, 14, 14, 14, 12, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 14, 14, 14, 14, 12, 12, 12, 14, 14, 14, 14, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 14, 15, 15, 15, 15, 14, 14, 14, 15, 15, 15, 15, 14, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 14, 14, 14, 14, 14, 14, 14, 14, 14, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 14, 14, 14, 14, 14, 14, 14, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 11, 12, 12, 14, 14, 14, 14, 14, 12, 12, 11, 12, 12, 12, 12, 12, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 11, 11, 11 }, { 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 11, 11, 11 }, { 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 15, 15, 15, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 11, 11, 11 }, { 11, 11, 11, 11, 12, 12, 14, 14, 14, 12, 12, 12, 12, 12, 12, 15, 15, 15, 12, 12, 12, 12, 12, 12, 14, 14, 14, 12, 12, 11, 11, 11, 11 }, { 11, 11, 11, 11, 12, 12, 14, 14, 14, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 14, 14, 14, 12, 12, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 12, 14, 12, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 11, 12, 14, 12, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 12, 12, 12, 11, 11, 14, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 14, 11, 11, 12, 12, 12, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 12, 12, 12, 11, 12, 14, 14, 14, 12, 12, 12, 12, 12, 12, 12, 12, 12, 14, 14, 14, 12, 11, 12, 12, 12, 11, 11, 11, 11 }, { 11, 11, 11, 11, 12, 12, 12, 11, 12, 12, 14, 14, 12, 12, 12, 12, 12, 12, 12, 12, 12, 14, 14, 12, 12, 11, 12, 12, 12, 11, 11, 11, 11 }, { 11, 11, 11, 12, 12, 12, 12, 11, 12, 12, 12, 14, 12, 12, 12, 12, 12, 12, 12, 12, 12, 14, 12, 12, 12, 11, 12, 12, 12, 12, 11, 11, 11 }, { 11, 11, 11, 11, 15, 15, 15, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 11, 15, 15, 15, 11, 11, 11, 11 }, { 11, 11, 11, 15, 15, 15, 15, 15, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 15, 15, 15, 15, 15, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 } }, { { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 15, 15, 15, 15, 15, 0, 0, 0, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 0, 15, 15, 15, 15, 15, 15, 15, 15, 0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 0, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 6, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 11, 15, 11, 11, 11, 11, 11, 11, 11, 6, 6, 6, 6, 15, 15, 15, 15, 15, 15, 15, 15, 15, 6, 6, 11, 11, 11, 11, 11, 11, 11, 11 }, { 11, 15, 15, 15, 11, 11, 11, 6, 6, 6, 14, 14, 14, 14, 6, 15, 15, 15, 15, 15, 15, 6, 6, 14, 14, 6, 7, 11, 11, 11, 11, 11, 11 }, { 11, 15, 15, 15, 11, 11, 11, 6, 14, 14, 14, 14, 14, 14, 14, 6, 6, 15, 15, 15, 6, 6, 14, 14, 14, 7, 7, 7, 11, 11, 11, 11, 11 }, { 11, 15, 15, 15, 11, 11, 11, 6, 14, 14, 14, 14, 14, 14, 14, 6, 6, 15, 15, 15, 6, 6, 14, 14, 14, 7, 7, 7, 11, 11, 11, 11, 11 }, { 15, 15, 15, 15, 15, 11, 11, 6, 14, 14, 14, 14, 14, 14, 14, 14, 14, 6, 6, 6, 6, 14, 14, 7, 7, 7, 7, 7, 6, 11, 11, 11, 11 }, { 15, 15, 15, 15, 15, 15, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 7, 7, 7, 7, 7, 7, 14, 6, 11, 11, 11, 11 }, { 11, 15, 15, 15, 15, 15, 15, 14, 14, 14, 14, 14, 14, 6, 14, 14, 14, 14, 14, 14, 7, 7, 7, 7, 7, 7, 7, 14, 14, 14, 6, 11, 11 }, { 11, 15, 15, 15, 15, 15, 15, 14, 14, 14, 14, 14, 6, 14, 14, 14, 14, 14, 14, 7, 7, 7, 7, 7, 7, 7, 14, 14, 14, 14, 6, 11, 11 }, { 11, 11, 15, 15, 15, 15, 15, 14, 14, 14, 14, 14, 6, 14, 14, 14, 7, 7, 7, 7, 7, 7, 7, 7, 7, 14, 14, 14, 14, 14, 14, 6, 11 }, { 11, 11, 11, 15, 15, 15, 15, 15, 15, 14, 14, 6, 14, 7, 7, 7, 7, 7, 7, 7, 7, 7, 14, 14, 14, 14, 14, 14, 14, 14, 6, 11, 11 }, { 11, 11, 11, 6, 15, 15, 15, 15, 15, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 6, 11, 11, 11 }, { 11, 11, 11, 11, 6, 7, 15, 15, 15, 15, 15, 15, 7, 7, 7, 7, 7, 7, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 6, 11, 11 }, { 11, 11, 11, 11, 7, 7, 7, 15, 15, 15, 15, 15, 15, 15, 7, 7, 6, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 6, 11, 11, 11 }, { 11, 11, 11, 11, 7, 7, 7, 7, 15, 15, 15, 15, 15, 15, 15, 15, 15, 6, 14, 14, 14, 14, 14, 14, 14, 14, 6, 6, 6, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 7, 7, 7, 7, 7, 15, 15, 15, 15, 15, 15, 15, 15, 15, 6, 14, 14, 14, 14, 6, 6, 6, 14, 14, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 6, 6, 6, 6, 14, 14, 14, 14, 14, 11, 11, 11, 11 }, { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 } } };
            //supper bulk bakal villy
            string[,] description = new string[4, 24] { { "Supper Man", "It's a bird, it's a plane,", "no...wait...it's just the", "super strong, super fast,", "super duper SUPPER MAN.", "He is so super that he", "wears his underwear on the", "outside.Talk about fashion", "trends, am I right ?", "", "Stats", "Health 110", "Energy Points 90", "Defense 70", "", "Attacks", "Freeze breath", "Heat vision", "Super Speed", "X - ray Vision", "", "Items", "Underwear", "Glasses" }, { "The Bulk", "This green monster ", "was once a human ", "who had a PhD in ", "Chemistry, Physics, ", "and Biology, but he ", "was exposed to too ", "Much Teckno Parc ", "solar energy ", "", "Stats", "Health 110", "Energy Points 90", "Defense 70", "", "Attacks", "Smash", "Thunderclap,", "Physics question", "Body slam", "", "Items", "Strechable Pants", "PhD" }, { "Kapitan Bakal", "Not only is he a genius ", "and a billionaire, but ", "he is also a playboy ", "philanthropist. Kapitan ", "Bakal is never rusty ", "when it comes to a ", "fight, especially with ", "his high-tech suit. ", "", "Stats", "Health 90", "Energy Points 90", "Defense 90", "", "Attacks", "Unibeam", "Repulsion blast,", "Laser beam", "Fly", "", "Items", "Arc reactor", "Shawarma" }, { "Kuya Villy Rewillame", "This charismatic", "TV show host is", "the favorite of", "the masses. ", "He is also well ", "Known for his", "Hit songs and his", "signature jackets. ", "", "Stats", "Health: 70", "Energy Points 110", "Defense 90", "", "Attacks", "Solar energy", "Dubidubidapdap", "Help the poor", "Jatot", "", "Items", "Jacket", "Lychee Mobile" } };

            int[,] itemstats = new int[8, 3] { { 10, 0, 0 }/* supper underwear */, { 0, 0, 0 } /* supper glasses */, { 20, 0, 20 }, { 0, 30, 0 }, { 0, 10, 10 }, { 20, 0, 0 }, { 0, 30, 0 }, { 30, 0, 0 } };
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta; // temporary colors
            Console.WriteLine("████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            //var simpleSound = new
            //SoundPlayer(@"C:\Users\pauls\Desktop\trial\BUDOTS NONSTOP MIX.wav");
            //simpleSound.Play();
            setwritesleep(51, 1, "╔══╗            ╔══╗", 400);
            setwritesleep(51, 2, "╠═  ║   ║  ═╦═  ╠═", 400);
            setwritesleep(51, 3, "╚══╝╚══ ║   ║   ╚══╝ ", 400);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            setwritesleep(51, 4, "", 400);
            setwritesleep(37, 5, "111111    00000    1   1    0    0   111111", 400);
            setwritesleep(37, 6, "  1       000      1 1      0 0  0   1    1", 400);
            setwritesleep(37, 7, "  1       0        1 1      0  0 0   1    1", 400);
            setwritesleep(37, 8, "  1       00000    1   1    0    0   111111", 400);
            setwritesleep(37, 9, "", 400);
            setwritesleep(45, 10, "0000      1      0 000     11111", 400);
            setwritesleep(45, 11, "0  0    1  1     0   00    1", 400);
            setwritesleep(45, 12, "0000    1111     0000      1", 400);
            setwritesleep(45, 13, "0      1    1    0   0     11111", 400);
            Console.ForegroundColor = ConsoleColor.White;
            setwritesleep(45, 14, "", 400);
            Console.WriteLine();
            Console.SetCursorPosition(53, 17);
            Console.WriteLine("Press S to start!");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            // put d title animation hereq
            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                gameisrunning = 1;
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.Q)
            {
                gameisrunning = 0;
            }
            while (gameisrunning == 1)
            {
                setwritesleep(0, 0, "\t'This is a program that intends to help Filipinos, especially the poor.", 1000);
                setwritesleep(0, 0, "\tWe only wanted to make these people happy.' — Willie Revillame", 1000);
                setwritesleep(0, 0, "--------------------", 500);
                setwritesleep(0, 0, "\tYou and your friend went to the majestic ELITE Tekno Parc for an amazing field trip.", 500);
                setwritesleep(0, 0, "\tSadly, your trip in ELITE Tekno Parc is about to end because both of you have to go home.", 500);
                setwritesleep(0, 0, "\tUnfortunately, there is only one slot left in the first bus on the way home.", 500);
                setwritesleep(0, 0, "\tYou and your friend have to fight for the slot in the first bus.", 500);
                Console.WriteLine("\tBoth of you have to choose 1 character each and fight until one of the characters faints!");
                setwritesleep(0, 0, "--------------------", 100);
                setwritesleep(0, 0, "", 100);
                Console.WriteLine();
                Console.WriteLine("\tPress space twice to continue to character selection! Or press Q to exit");
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        while ((arrow = Console.ReadKey()).Key != ConsoleKey.Enter)
                        {
                            Console.Clear();

                            setwritesleep(5, 2, "Use the LEFT and RIGHT arrows", 0);
                            setwritesleep(5, 3, "to view other characters", 0);
                            setwritesleep(5, 5, "ENTER to select a character", 0);
                            setwritesleep(7, 8, "PLAYER 1:", 0);
                            setwritesleep(7, 11, "PLAYER 2:", 0);

                            setwritesleep(34, 11, @"///                                       \\\", 0);
                            setwritesleep(33, 12, @"///                                         \\\", 0);
                            setwritesleep(32, 13, @"///                                           \\\", 0);
                            setwritesleep(32, 14, @"\\\                                           ///", 0);
                            setwritesleep(33, 15, @"\\\                                         ///", 0);
                            setwritesleep(34, 16, @"\\\                                       ///", 0);

                            if (arrow.Key == ConsoleKey.RightArrow)
                            {
                                index++;
                            }
                            else if (arrow.Key == ConsoleKey.LeftArrow)
                            {
                                index--;
                            }

                            
                            for (int m = 0; m < 27; m++)
                            {
                                Console.SetCursorPosition(40, m + 1);
                                for (int j = 0; j < 33; j++)
                                {
                                    for (int k = 0; k < 33; k++)
                                    {
                                        if (pixarray[((index % 4 + 4) % 4), m, j] == k)
                                        {
                                            Console.ForegroundColor = color[k];
                                            Console.Write("█");
                                        }
                                    }
                                }
                            }

                            if (charHED[0, 0] == 4)
                            {
                                setwritesleep(7, 9, description[(index % 4 + 4) % 4, 0], 0);
                            }
                            else
                            {
                                setwritesleep(7, 9, description[charHED[0, 0], 0], 0);
                                setwritesleep(7, 12, description[(index % 4 + 4) % 4, 0], 0);
                            }

                            for (int l = 1; l < 24; l++)
                            {
                                setwritesleep(83, l + 1, description[(index % 4 + 4) % 4, l], 0);
                            }
                        }
                        setwritesleep(7, 12, description[(index % 4 + 4) % 4, 0], 0);
                        charHED[0, i] = (index % 4 + 4) % 4;
                        for (int m = 1; m < 4; m++)
                        {
                            charHED[m, i] = HealthEnergyDefense[i, m - 1];
                        }
                    }

                    ///////////////////////////////

                    index = 5;
                    Console.Clear();
                    Console.WriteLine("press any arrow to continue");
                    Thread.Sleep(3000);
                    Console.Clear();
                    while (condition== true)
                    {
                        turn += 1;
                        while ((arrow = Console.ReadKey()).Key != ConsoleKey.Enter)
                        {

                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            for (int r = 1; r < 9; r++)
                            {
                                setwritesleep(13, r, "                        ", 0);
                                setwritesleep(75, r, "                        ", 0);
                            }
                            for (int r = 10; r < 17; r++)
                            {
                                setwritesleep(13, r, "                                                                                      ", 0);
                            }

                            setwritesleep(15, 2, "Player 1", 0);
                            setwritesleep(15, 3, description[charHED[0, 0], 0], 0);
                            setwritesleep(15, 5, "Health: " + charHED[1, 0], 0);
                            setwritesleep(15, 6, "Energy Points: " + charHED[2, 0], 0);
                            setwritesleep(15, 7, "Defense: " + charHED[3, 0], 0);

                            setwritesleep(77, 2, "Player 2", 0);
                            setwritesleep(77, 3, description[charHED[0, 1], 0], 0);
                            setwritesleep(77, 5, "Health: " + charHED[1, 1], 0);
                            setwritesleep(77, 6, "Energy Points: " + charHED[2, 1], 0);
                            setwritesleep(77, 7, "Defense: " + charHED[3, 1], 0);

                            Console.BackgroundColor = ConsoleColor.Blue;
                            for (int r = 17; r < 23; r++)
                            {
                                setwritesleep(13, r, "                                                                                      ", 0);
                            }
                            setwritesleep(43, 6, "                           ", 0);

                            Console.BackgroundColor = ConsoleColor.DarkYellow;

                            setwritesleep(45, 1, "                     ", 0);
                            setwritesleep(45, 2, "   PLAYER " + (turn % 2 + 1) + "'S TURN   ", 0);
                            setwritesleep(45, 3, "                     ", 0);

                            Console.BackgroundColor = ConsoleColor.Red;

                            setwritesleep(20, 11, "        ", 0);
                            setwritesleep(20, 12, " ATTACK ", 0);
                            setwritesleep(20, 13, "        ", 0);

                            setwritesleep(53, 11, "       ", 0);
                            setwritesleep(53, 12, " ITEMS ", 0);
                            setwritesleep(53, 13, "       ", 0);

                            setwritesleep(86, 11, "      ", 0);
                            setwritesleep(86, 12, " PASS ", 0);
                            setwritesleep(86, 13, "      ", 0);

                            Console.BackgroundColor = ConsoleColor.DarkGray;

                            setwritesleep(22 + 33 * ((index % 3 + 3) % 3), 14, @"  ", 0);
                            setwritesleep(21 + 33 * ((index % 3 + 3) % 3), 15, @"    ", 0);

                            if (arrow.Key == ConsoleKey.RightArrow)
                            {
                                index++;
                            }

                            if (arrow.Key == ConsoleKey.LeftArrow)
                            {
                                index--;
                            }

                            setwritesleep(22 + 33 * ((index % 3 + 3) % 3), 14, @"/\", 0);
                            setwritesleep(21 + 33 * ((index % 3 + 3) % 3), 15, @"//\\", 0);

                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            if ((index % 3 + 3) % 3 == 0)
                            {
                                setwritesleep(20, 11, "        ", 0);
                                setwritesleep(20, 12, " ATTACK ", 0);
                                setwritesleep(20, 13, "        ", 0);
                            }

                            else if ((index % 3 + 3) % 3 == 1)
                            {
                                setwritesleep(53, 11, "       ", 0);
                                setwritesleep(53, 12, " ITEMS ", 0);
                                setwritesleep(53, 13, "       ", 0);
                            }

                            else if ((index % 3 + 3) % 3 == 2)
                            {
                                setwritesleep(86, 11, "      ", 0);
                                setwritesleep(86, 12, " PASS ", 0);
                                setwritesleep(86, 13, "      ", 0);
                            }

                        }

                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        setwritesleep(13, 14, "                                                                                      ", 0);

                        Console.BackgroundColor = ConsoleColor.Blue;
                        setwritesleep(13, 15, "                                                                                      ", 0);


                        Console.BackgroundColor = ConsoleColor.DarkMagenta; 
                        for (int p = 16; p < 23; p++)
                        {
                            setwritesleep(13, p, "                                                                                      ", 0);
                        }

                        if ((index % 3 + 3) % 3 == 0)
                        {

                            setwritesleep(20, 17 + ((attackindex % 5 + 5) % 5), ">>>", 0);
                            for (int t = 17; t < 21; t++)
                            {
                                setwritesleep(24, t, description[charHED[0, (turn % 2)], t - 1], 0);
                            }
                            setwritesleep(24, 21, "Cancel", 0);

                            while ((arrow = Console.ReadKey()).Key != ConsoleKey.Enter)
                            {
                                setwritesleep(20, 17 + ((attackindex % 5 + 5) % 5), "   ", 0);
                                if (arrow.Key == ConsoleKey.DownArrow)
                                {
                                    attackindex++;
                                }

                                if (arrow.Key == ConsoleKey.UpArrow)
                                {
                                    attackindex--;
                                }

                                setwritesleep(20, 17 + ((attackindex % 5 + 5) % 5), ">>>", 0);
                            }



                            if (charHED[0, turn % 2] == 0) // supper
                            {
                                if ((attackindex % 5 + 5) % 5 == 0)
                                {

                                    charHED[3, (turn + 1) % 2] -= 10; //[attack*(200-defense)/100]
                                    charHED[2, turn % 2] -= 20;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 1)
                                {
                                    charHED[1, (turn + 1) % 2] -= 20;
                                    charHED[2, turn % 2] -= 20;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 2)
                                {
                                    plusdamagex1 += 10;
                                    charHED[3, (turn + 1) % 2] += 10;
                                    charHED[2, turn % 2] -= 50;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 3)
                                {
                                    plusdamagex1 += 20;
                                    charHED[2, turn % 2] -= 20;
                                }
                            }

                            else if (charHED[0, turn % 2] == 1) //bulk
                            {
                                if ((attackindex % 5 + 5) % 5 == 0)
                                {
                                    charHED[1, (turn + 1) % 2] -= 20 * ((200 - charHED[3, (turn + 1) % 2]) / 100); //[attack*(200-defense)/100]
                                    charHED[2, turn % 2] -= 10;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 1)
                                {
                                    charHED[1, (turn + 1) % 2] -= 10 * ((200 - charHED[3, (turn + 1) % 2]) / 100);
                                    charHED[2, turn % 2] -= 10;
                                    //stun2 = 75;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 2)
                                {
                                    stun2 = true;
                                    //energy1 -= ;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 3)
                                {
                                    charHED[1, (turn + 1) % 2] -= 50;
                                    charHED[2, turn % 2] -= 30;
                                }
                            }
                            else if (charHED[0, turn % 2] == 2) // kap Bakal
                            {
                                if ((attackindex % 5 + 5) % 5 == 0)
                                {
                                    charHED[1, (turn + 1) % 2] -= 50 * ((200 - charHED[3, (turn + 1) % 2]) / 100); //[attack*(200-defense)/100]
                                    charHED[2, turn % 2] -= 70;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 1)
                                {
                                    charHED[1, (turn + 1) % 2] -= 20 * ((200 - charHED[3, (turn + 1) % 2]) / 100);
                                    charHED[2, turn % 2] -= 20;
                                    //stun2 = 75;                           
                                }
                                else if ((attackindex % 5 + 5) % 5 == 2)
                                {
                                    charHED[1, (turn + 1) % 2] -= 10 * ((200 - charHED[3, (turn + 1) % 2]) / 100); ;
                                    charHED[2, turn % 2] -= 5;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 3)
                                {
                                    charHED[3, turn % 2] += 10;
                                    charHED[2, turn % 2] -= 20;
                                }
                            }
                            else if (charHED[0, turn % 2] == 3) // Villie Rew
                            {
                                if ((attackindex % 5 + 5) % 5 == 0)
                                {
                                    charHED[1, (turn + 1) % 2] -= 20 * ((200 - charHED[3, (turn + 1) % 2]) / 100); //[attack*(200-defense)/100]
                                    charHED[2, turn % 2] -= 10;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 1)
                                {
                                    charHED[1, (turn + 1) % 2] -= 10 * ((200 - charHED[3, (turn + 1) % 2]) / 100);
                                    charHED[2, turn % 2] -= 10;
                                    //stun2 = 75;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 2)
                                {
                                    stun2 = true;
                                    charHED[2, turn % 2] -= 10;
                                }
                                else if ((attackindex % 5 + 5) % 5 == 3)
                                {
                                    charHED[1, (turn + 1) % 2] -= 30;
                                    charHED[2, turn % 2] -= 30;
                                }
                            }
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            setwritesleep(15, 5, "Health: " + charHED[1, 0] + "   ", 0);
                            setwritesleep(15, 6, "Energy Points: " + charHED[2, 0] + "   ", 0);
                            setwritesleep(15, 7, "Defense: " + charHED[3, 0] + "   ", 0);
                            setwritesleep(77, 5, "Health: " + charHED[1, 1] + "   ", 0);
                            setwritesleep(77, 6, "Energy Points: " + charHED[2, 1] + "   ", 0);
                            setwritesleep(77, 7, "Defense: " + charHED[3, 1] + "   ", 0);
                            setwritesleep(43, 6, "press any arrow to continue", 0);


                        }

                        else if ((index % 3 + 3) % 3 == 1)
                        {
                            setwritesleep(20, 17 + ((itemindex % 3 + 3) % 3), ">>>", 0);
                            setwritesleep(24, 17, description[charHED[0, turn % 2], 22], 0);
                            setwritesleep(24, 18, description[charHED[0, turn % 2], 23], 0);
                            setwritesleep(24, 19, "Cancel", 0);

                            while ((arrow = Console.ReadKey()).Key != ConsoleKey.Enter)
                            {
                                setwritesleep(20, 17 + ((itemindex % 3 + 3) % 3), "   ", 0);
                                if (arrow.Key == ConsoleKey.DownArrow)
                                {
                                    itemindex++;
                                }

                                if (arrow.Key == ConsoleKey.UpArrow)
                                {
                                    itemindex--;
                                }

                                setwritesleep(20, 17 + ((itemindex % 3 + 3) % 3), ">>>", 0);
                            }

                            if ((itemindex % 3 + 3) % 3 == 0)
                            {
                                charHED[1, turn % 2] += itemstats[charHED[0, turn % 2] * 2, 0];
                                charHED[2, turn % 2] += itemstats[charHED[0, turn % 2] * 2, 1];
                                charHED[3, turn % 2] += itemstats[charHED[0, turn % 2] * 2, 2];

                            }
                            else if ((itemindex % 3 + 3) % 3 == 1)
                            {
                                charHED[1, turn % 2] += itemstats[charHED[0, turn % 2] * 2 + 1, 0];
                                charHED[2, turn % 2] += itemstats[charHED[0, turn % 2] * 2 + 1, 1];
                                charHED[3, turn % 2] += itemstats[charHED[0, turn % 2] * 2 + 1, 2];
                                itemuse1++;
                            }
                            if (charHED[0, turn % 2] == 0)
                            {
                                itemuse1++;
                            }
                            if (charHED[0, turn % 2] == 1)
                            {
                                itemuse2++;
                            }

                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            setwritesleep(15, 5, "Health: " + charHED[1, 0] + "   ", 0);
                            setwritesleep(15, 6, "Energy Points: " + charHED[2, 0] + "   ", 0);
                            setwritesleep(15, 7, "Defense: " + charHED[3, 0] + "   ", 0);
                            setwritesleep(77, 5, "Health: " + charHED[1, 0] + "   ", 0);
                            setwritesleep(77, 6, "Energy Points: " + charHED[2, 0] + "   ", 0);
                            setwritesleep(77, 7, "Defense: " + charHED[3, 0] + "   ", 0);
                            setwritesleep(43, 6, "press any arrow to continue", 0);

                        }

                        else if ((index % 3 + 3) % 3 == 2)
                        {
                            setwritesleep(43, 6, "press any arrow to continue", 0);
                        }

                        if (charHED[1, 0] <= 0 || charHED[1, 1] <= 0 || charHED[2, 1] <= 0 || charHED[2, 1] <= 0)
                        {
                            condition = false;
                        }
                        
                    }

                    Console.Clear();

                    if (charHED[1, 0] <= 0)
                    {
                        Console.WriteLine(description[charHED[0, 0], 0] + " fainted! " + description[charHED[0, 1], 0] + " wins a seat on the first bus back!");
                    }

                    else if (charHED[1, 1] <= 0)
                    {
                        Console.WriteLine(description[charHED[0, 1], 0] + " fainted! " + description[charHED[0, 0], 0] + " wins a seat on the first bus back!");
                    }

                    Console.WriteLine("Play again? Y or N:");
                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        gameisrunning = 1;
                    }
                    else if (Console.ReadKey(true).Key == ConsoleKey.N)
                    {
                        gameisrunning = 0;
                    }

                    else if (Console.ReadKey(true).Key == ConsoleKey.Q)
                    {
                        gameisrunning = 0;
                    }
                }
            }
        }
        public static void setwritesleep(int x, int y, string str, int z)
        {
            if (x == 0 && y == 0) //since (0,0) won't be used
            {
                Console.WriteLine(str);
                Thread.Sleep(z);
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(str);
                Thread.Sleep(z);
            }
        }
    }
}
