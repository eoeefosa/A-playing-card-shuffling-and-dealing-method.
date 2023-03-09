using System;
using System.Collections.Generic;

public class Card
{
    public int value;
    public int suit;
    
    // constructor
    public Card(int value, int suit)
    {
        this.value = value;
        this.suit = suit;
    }
    // override the Object class’s version of toString by
// writing your own implementation of toString, and thus
// customize how your own object will print out.
    public override string ToString()
    {
        string[] values = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string[] suits = {"Clubs", "Diamonds", "Hearts", "Spades"};
        return values[value] + " of " + suits[suit];
    }
}

public class Pack
{
    private Card[] cards;
    private int nextCardIndex;

    public Pack()
    {
        cards = new Card[52];
        for (int suit = 0; suit < 4; suit++)
        {
            for (int value = 0; value < 13; value++)
            {
                cards[suit * 13 + value] = new Card(value, suit);
            }
        }
        nextCardIndex = 0;
    }

    public bool shuffleCardPack(int typeOfShuffle)
    {
        switch (typeOfShuffle)
        {
            case 1: // Fisher-Yates Shuffle
                Random rnd = new Random();
                for (int i = 51; i >= 1; i--)
                {
                    int j = rnd.Next(i + 1);
                    Card temp = cards[j];
                    cards[j] = cards[i];
                    cards[i] = temp;
                }
                break;
            case 2: // Riffle Shuffle
                // TODO: implement Riffle Shuffle
                break;
            case 3: // No Shuffle
                // Do nothing
                break;
            default:
                return false; // invalid shuffle type
        }
        nextCardIndex = 0; // reset the next card index
        return true; // shuffle successful
    }

    public Card? dealCard()
    {
        if (nextCardIndex >= 52)
        {
            return null; // no more cards in the pack
        }
        else
        {
            Card card = cards[nextCardIndex];
            nextCardIndex++;
            return card;
        }
    }

    public List<Card> dealCard(int amount)
    {
        List<Card> cardsToDeal = new List<Card>();
        for (int i = 0; i < amount; i++)
        {
            Card? card = dealCard();
            if (card == null)
            {
                break; // no more cards in the pack
            }
            else
            {
                cardsToDeal.Add(card);
            }
        }
        return cardsToDeal;
    }
}

public class Testing
{
    public static void Main()
    {
        Pack pack = new Pack();
        Console.WriteLine("Initial pack:");
        printPack(pack);

        pack.shuffleCardPack(1); // Fisher-Yates Shuffle
        Console.WriteLine("Shuffled pack (Fisher-Yates Shuffle):");
        printPack(pack);

        pack.shuffleCardPack(2); // Riffle Shuffle
        Console.WriteLine("Shuffled pack (Riffle Shuffle):");
        printPack(pack);

        pack.shuffleCardPack(3); // No Shuffle
        Console.WriteLine("Shuffled pack (No Shuffle):");
        printPack(pack);

        Card? card = pack.dealCard();
        Console.WriteLine("Dealt card: " + card);

        List<Card> cards = pack.dealCard(5);
        Console.WriteLine("Dealt cards:");
        foreach (Card c in cards)
        {
            Console.WriteLine(c);
        }
    }

    private static void printPack(Pack pack)
    {
        for (int i = 0; i < 52; i++)
        {
            Console.WriteLine(pack.dealCard());
        }
        Console.WriteLine();
    }
}
