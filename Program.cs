using System;

decimal balance = 0.0M; // Player starts with $0

while (true)
{
    // Show the current balance
    Console.WriteLine($"Your current balance is ${balance}");

    // Show the available actions
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Deposit money");
    Console.WriteLine("2. Withdraw money");
    Console.WriteLine("3. Play the game");
    Console.WriteLine("4. Exit");

    // Get the user's choice
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("How much would you like to deposit?");
            decimal depositAmount = Decimal.Parse(Console.ReadLine());
            balance += depositAmount;
            break;
        case "2":
            Console.WriteLine("How much would you like to withdraw?");
            decimal withdrawAmount = Decimal.Parse(Console.ReadLine());
            if (withdrawAmount > balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                balance -= withdrawAmount;
            }
            break;
        case "3":
            PlayGame(ref balance);
            break;
        case "4":
            Console.WriteLine("Thanks for playing. Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

void PlayGame(ref decimal balance)
{
    Console.WriteLine("How much would you like to bet? (Between $1 and $10)");
    decimal betAmount = Decimal.Parse(Console.ReadLine());

    if (betAmount < 1 || betAmount > 10)
    {
        Console.WriteLine("Invalid bet amount. Try again.");
        return;
    }

    if (betAmount > balance)
    {
        Console.WriteLine("Insufficient balance to place the bet!");
        return;
    }

    // Determine the outcome of the game
    Random rng = new Random();
    decimal winAmount = 0;
    double outcome = rng.NextDouble();

    if (outcome < 0.5) // 50% chance of losing
    {
        Console.WriteLine("You lost the bet.");
    }
    else if (outcome < 0.9) // 40% chance of winning up to x2
    {
        winAmount = betAmount * 2;
        Console.WriteLine($"You won! Your win amount is ${winAmount}");
    }
    else // 10% chance of winning between x2 and x10
    {
        winAmount = betAmount * (2 + (decimal)(rng.NextDouble() * 8));
        Console.WriteLine($"Jackpot! Your win amount is ${winAmount}");
    }

    balance = balance - betAmount + winAmount;
}
