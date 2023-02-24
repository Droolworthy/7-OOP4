using System;

namespace OOP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandTakeСard = "1";
            const string CommandTakeСards = "2";
            const string CommandExit = "3";

            Deck deck = new();
            Player player = new();

            bool isWorking = true;

            ShowMenu();

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                string userInput = Console.ReadLine();

                ShowMenu();
                Console.Clear();

                switch (userInput)
                {
                    case CommandTakeСard:
                        deck.ShufflePackCards();
                        player.TakeCardUser(deck);
                        break;

                    case CommandTakeСards:
                        deck.ShufflePackCards();
                        player.TakeCardsUser(deck);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine($"\nВведите {CommandTakeСard}, {CommandTakeСards} или {CommandExit}");
                        break;
                }
            }

            void ShowMenu()
            {
                Console.WriteLine($"{CommandTakeСard} - ВЗЯТЬ КАРТУ");
                Console.WriteLine($"{CommandTakeСards} - ВЗЯТЬ НЕСКОЛЬКО КАРТ");
                Console.WriteLine($"{CommandExit} - ВЫХОД");
            }
        }
    }

    class Player
    {
        private List<Card> _userDeck = new();

        public void TakeCardUser(Deck deck)
        {
            int index = 0;

            if (index >= 0 && index < deck.GetCardCount())
            {
                _userDeck.Add(deck.GetCardByIndex(index));
            }
            else
            {
                Console.WriteLine("\nВ колоде больше нет карт. Колода пуста.");
            }

            ShowInfoPlayer();
        }

        public void TakeCardsUser(Deck deck)
        {
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

            ShowInfoPlayer();
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
            for (int i = 0; i < _suit.Length; i++)
            {
                for (int j = 0; j < _value.Length; j++)
                {
                    _cardPack.Add(new Card(_suit, _value));
                }
            }
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

            for (int cards = _value.Length - 1; cards >= 1; cards--)
            {
                int tempArraySuit = random.Next(cards + 1);
                (_value[cards], _value[tempArraySuit]) = (_value[tempArraySuit], _value[cards]);
            }

            for (int cards = _suit.Length - 1; cards >= 1; cards--)
            {
                int tempArrayValue = random.Next(cards + 1);
                (_suit[cards], _suit[tempArrayValue]) = (_suit[tempArrayValue], _suit[cards]);
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
    }
}
