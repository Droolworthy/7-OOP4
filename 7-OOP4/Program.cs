using System;
using System.Collections.Generic;

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

            bool isWorking = true;

            ShowMenu();

            deck.MixDeckCards();

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                string userInput = Console.ReadLine();

                Console.Clear();
                ShowMenu();

                switch (userInput)
                {
                    case CommandTakeСard:
                        deck.TakeCardUser();
                        break;

                    case CommandTakeСards:
                        deck.TakeCardsUser();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine($"\nВведите {CommandTakeСard}, {CommandTakeСards} или {CommandExit}");
                        break;
                }
            }

            static void ShowMenu()
            {
                Console.WriteLine($"{CommandTakeСard} - ВЗЯТЬ КАРТУ");
                Console.WriteLine($"{CommandTakeСards} - ВЗЯТЬ НЕСКОЛЬКО КАРТ");
                Console.WriteLine($"{CommandExit} - ВЫХОД");
            }
        }
    }

    class Deck
    {
        private List<Card> _cardDeck = new();
        private List<Card> _userDeck = new();

        public Deck()
        {
            _cardDeck.Add(new Card("Two", "Diamonds"));
            _cardDeck.Add(new Card("Three", "Spades"));
            _cardDeck.Add(new Card("Four", "Hearts"));
            _cardDeck.Add(new Card("Five", "Clubs"));
            _cardDeck.Add(new Card("Six", "Diamonds"));
            _cardDeck.Add(new Card("Seven", "Spades"));
            _cardDeck.Add(new Card("Eight", "Hearts"));
            _cardDeck.Add(new Card("Nine", "Clubs"));
            _cardDeck.Add(new Card("Ten", "Diamonds"));
        }

        public void TakeCardsUser()
        {
            Console.Write("\nСколько карт вам нужно: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int cardInput);

            for (int i = 0; i < cardInput; i++)
            {
                if (isSuccess)
                {
                    TakeCardUser();
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }
            }
        }

        public void TakeCardUser()
        {
            if (0 >= 0 && 0 < _cardDeck.Count)
            {
                _userDeck.Add(_cardDeck[0]);
                _cardDeck.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("\nВ колоде больше нет карт. Колода пуста.");
            }

            ShowInfoPlayer();
        }

        public void MixDeckCards()
        {
            for (int cards = _cardDeck.Count - 1; cards > 0; cards--)
            {
                Random random = new();
                int tempArray = random.Next(cards + 1);
                (_cardDeck[cards], _cardDeck[tempArray]) = (_cardDeck[tempArray], _cardDeck[cards]);
            }
        }

        public void ShowInfoPlayer()
        {
            for (int i = 0; i < _userDeck.Count; i++)
            {
                Console.WriteLine("\nВаша карта - " + _userDeck[i].Cards + ", " + _userDeck[i].Value);
            }
        }
    }

    class Card
    {
        public Card(string cardNumbers, string valueСards)
        {
            Cards = cardNumbers;
            Value = valueСards;
        }

        public string Cards { get; private set; }

        public string Value { get; private set; }
    }
}
