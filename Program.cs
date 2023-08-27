using System;

decimal balance = 0M;
Random rng = new();

while (true)
{
    Console.WriteLine($"Your current balance is ${balance}\n1. Deposit money\n2. Withdraw money\n3. Play the game\n4. Exit");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Deposit amount: ");
            balance += decimal.Parse(Console.ReadLine());
            break;

        case "2":
            Console.Write("Withdraw amount: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            balance = (withdrawAmount > balance) ? balance : balance - withdrawAmount;
            if (withdrawAmount > balance) Console.WriteLine("Not enough mopney in your balance!");
            break;

        case "3":
            Play();
            break;

        case "4":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

void Play()
{
    Console.Write("Bet amount (Between $1 and $10): ");
    decimal bet = decimal.Parse(Console.ReadLine());

    if (bet < 1 || bet > 10 || bet > balance)
    {
        Console.WriteLine("Invalid bet amount, bet must be Between $1 and $10. Try again.");
        return;
    }

    double outcome = rng.NextDouble();
    decimal win = 0;

    if (outcome >= 0.5)
    {
        win = (outcome < 0.9) ? bet * 2 : bet * (2 + (decimal)(rng.NextDouble() * 8));
        Console.WriteLine($"You won! Win amount: ${win}");
    }
    else
    {
        Console.WriteLine("You lost the bet.");
    }

    balance += win - bet;
}