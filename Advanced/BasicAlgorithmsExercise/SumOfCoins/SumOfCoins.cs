using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    static void Main(string[] args)
    {
        var coins = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .ToArray();
        int sum = Console.ReadLine()
            .Split()
            .Skip(1)
            .Select(int.Parse)
            .ToArray()[0];
        
        try
        {
            var result = ChooseCois(coins, sum);
            Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");
            foreach (var coin in result)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static Dictionary<int, int> ChooseCois(IList<int> coins, int targetSum)
    {
        var temp = new Dictionary<int, int>();

        while (targetSum > 0 && coins.Count != temp.Count)
        {
            int maxCoin = coins.Where(x => !temp.Keys.Contains(x)).Max();
            int coinCount = targetSum / maxCoin;
            targetSum -= maxCoin * coinCount;

            if (!temp.ContainsKey(maxCoin))
                temp[maxCoin] = 0;

            temp[maxCoin] = coinCount;
        }

        temp = temp
            .Where(x => x.Value != 0)
            .ToDictionary(x => x.Key, x => x.Value);

        if (targetSum > 0)
            throw new InvalidOperationException("Error");
        
        return temp;
    }
}
