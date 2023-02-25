using System;

namespace OOP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandTakeСard = "1";
            const string CommandTakeСards = "2";
            const string CommandShowСards = "3";
            const string CommandExit = "4";

            Deck deck = new();
            Player player = new();

            bool isWorking = true;

            Console.WriteLine($"{CommandTakeСard} - ВЗЯТЬ КАРТУ");
            Console.WriteLine($"{CommandTakeСards} - ВЗЯТЬ НЕСКОЛЬКО КАРТ");
            Console.WriteLine($"{CommandShowСards} - ПОКАЗАТЬ КАРТЫ ИГРОКА");
            Console.WriteLine($"{CommandExit} - ВЫХОД");

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTakeСard:
                        player.TakeCardUser(deck);
                        break;

                    case CommandTakeСards:
                        player.TakeCardsUser(deck);
                        break;

                    case CommandShowСards:
                        player.ShowInfoPlayer();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine($"\nВведите {CommandTakeСard}, {CommandTakeСards}, {CommandShowСards} или {CommandExit}");
                        break;
                }
            }
        }
    }

    class Player
    {
        private List<Card> _userDeck = new();

        public void TakeCardUser(Deck deck)
        {
            deck.ShufflePackCards();

            int index = 0;

            if (index < deck.GetCardCount())
            {
                _userDeck.Add(deck.GetCardByIndex(index));
            }
            else
            {
                Console.WriteLine("\nВ колоде больше нет карт. Колода пуста.");
            }
        }

        public void TakeCardsUser(Deck deck)
        {
            deck.ShufflePackCards();

            Console.Write("\nСколько карт вам нужно: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int cardInput);

            int index = 0;

            for (int i = 0; i < cardInput; i++)
            {
                if (isSuccess)
                {
                    if (index >= 0 && index < deck.GetCardCount())
                    {
                        _userDeck.Add(deck.GetCardByIndex(index));
                    }
                    else
                    {
                        Console.WriteLine("\nВ колоде больше нет карт. Колода пуста.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }
            }
        }

        public void ShowInfoPlayer()
        {
            foreach (Card card in _userDeck)
            {
                Console.WriteLine("\nВы взяли карту: " + card);
            }
        }
    }

    class Deck
    {
        private List<Card> _cardPack = new();
        private string[] _suit = { "Clubs", "Spades", "Hearts", "Diamonds" };
        private string[] _value = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "Кing", "Ace" };

        public Deck()
        {
            FillingPackCards();
        }

        public void ShowInfoCards()
        {
            foreach (Card card in _cardPack)
            {
                Console.WriteLine("Колода карт: " + card);
            }
        }

        public void ShufflePackCards()
        {
            Random random = new();

            for (int cards = _cardPack.Count - 1; cards >= 1; cards--)
            {
                int tempListIndex = random.Next(cards + 1);
                (_cardPack[cards], _cardPack[tempListIndex]) = (_cardPack[tempListIndex], _cardPack[cards]);
            }
        }

        public Card GetCardByIndex(int index)
        {
            if (index >= 0 && index < _cardPack.Count)
            {
                Card card = _cardPack[index];
                _cardPack.Remove(card);
                return card; 
            }

            return _cardPack[index];
        }

        public int GetCardCount()
        {
            return _cardPack.Count;
        }

        private void FillingPackCards()
        {
            for (int i = 0; i < _suit.Length; i++)
            {
                for (int j = 0; j < _value.Length; j++)
                {
                    _cardPack.Add(new Card(_suit, _value));
                }
            }
        }
    }

    class Card
    {
        public Card(string[] cardNumbers, string[] valuesСards)
        {
            Suit = cardNumbers;
            Value = valuesСards;
        }

        public string[] Suit { get; private set; }

        public string[] Value { get; private set; }

        public override string ToString()
        {
            string suitArray = string.Join(" ", Suit[0]);
            string valueArray = string.Join(" ", Value[0]);
            return suitArray + " " + valueArray;
        }
