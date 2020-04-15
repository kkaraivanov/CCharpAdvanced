using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine()); // count bullet in barrel
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var intelligence = int.Parse(Console.ReadLine());

            int countBullet = bullets.Count;
            int counterBullet = 0;
            ;
            while (true)
            {
                if(bullets.Count == 0 || locks.Count == 0)
                    break;

                var bullet = bullets.Peek();
                var lok = locks.Peek();

                if (bullet <= lok)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                counterBullet++;
                if (counterBullet == gunBarrelSize && bullets.Count != 0)
                {
                    counterBullet = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            countBullet -= bullets.Count;
            var bulletsCost = countBullet * priceOfBullet;

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - bulletsCost}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
