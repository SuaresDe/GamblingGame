
class Guy
{
    public string Name;
    public int Cash;

    public void WritePlayerInfo()
    {
        Console.WriteLine("You have " + Cash + " bucks.");
    }

    public int GiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " says: " + amount + " isn't a valid amount.");
            return 0;
        }
        if (amount > Cash)
        {
            Console.WriteLine(Name + " says: " + "I don't have enough to give you " + amount);
            return 0;
        }
        Cash -= amount;
        return amount;
    }

    public void ReceiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take.");
        }
        else
        {
            Cash += amount;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        double odds = .75;

        Guy player = new Guy() { Name = "The player", Cash = 100 };

        Console.WriteLine("Welcome to the GamblingGame! Your odds are " + odds);
       
        while (player.Cash > 0)
        {
            player.WritePlayerInfo();
            Console.Write("How much do you want to bet: ");
            string howMuch = Console.ReadLine();
            if (int.TryParse(howMuch, out int amount))
            {
                int pot = player.GiveCash(amount) * 2;
                if (pot > 0)
                {
                    if (random.NextDouble() > odds)
                    {
                        int winnings = pot;
                        Console.WriteLine("YOU WIN " +  winnings + "!");
                        player.ReceiveCash(winnings);

                    }else
                    {
                        Console.WriteLine("Bad luck, you lose... :(");
                    }
                }
            } else
            {
                Console.WriteLine("Please enter a valid number.");
            }

        }
        Console.WriteLine("The GamblingGame Always win... >:)");
    }
}

