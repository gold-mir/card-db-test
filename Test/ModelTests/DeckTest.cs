using System;
using MySql.Data.MySqlClient;
using Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests
{
    [TestClass]
    public class DeckTest
    {

        [TestMethod]
        public void Deck_

        [TestMethod]
        public void Deck_CanAddCard()
        {
            Deck twin = new Deck("U/R Twin");

            twin.AddCard("Splinter Twin");

            Assert.AreEqual(1, twin.AllCards().Length);
        }

        [TestMethod]
        public void Deck_CanAddMultipleCards()
        {
            Deck twin = new Deck("Grixis Twin");

            twin.AddCard("Lightning Bolt", 4);

            Assert.AreEqual()
        }

        // [TestMethod]
        // public void Deck_CanAddMultipleCards()
        // {
        //     Deck myDeck = new Deck("Death and Taxes");
        //
        //     myDeck.AddCards(new string[] {"Mother of Runes", "Thalia, Guardian of Thraben",
        //     "Stoneforge Mystic", "Plains", "Aether Vial", "Swords to Plowshares"});
        //
        //     Assert.AreEqual(6, myDeck.AllCards().Length);
        // }
        //
        // [TestMethod]
        // public void Deck_ChecksIfContainsCard()
        // {
        //     Deck myDeck = new Deck("5c Fold into Bring to Seance");
        //
        //     myDeck.AddCards(new string[] {"Fold into Aether", "Seance", "Bring to Light"});
        //
        //     Assert.IsTrue(myDeck.ContainsCard("Fold into Aether"));
        //     Assert.IsFalse(myDeck.ContainsCard("Splinter Twin"));
        // }
    }
}
