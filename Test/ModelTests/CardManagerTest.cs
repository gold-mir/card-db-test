using System;
using MySql.Data.MySqlClient;
using Application.Models;
using Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests
{
    [TestClass]
    public class CardManagerTest : DBTest, IDisposable
    {
        public void Dispose()
        {
            CardManager.DestroyAll();
        }

        [TestMethod]
        public void CardManager_GetAllWorks()
        {
            Card[] cards = CardManager.GetAll();

            Assert.IsNotNull(cards);
            if(cards != null)
            {
                Assert.AreEqual(0, cards.Length);
            }
        }

        [TestMethod]
        public void CardManager_AddsCards()
        {
            Card card = CardManager.CreateCard("Squire");

            Assert.IsNotNull(card);
            Assert.AreEqual(1, CardManager.GetAll().Length);
            Assert.AreEqual("Squire", card.GetName());
        }

        [TestMethod]
        public void CardManager_GetsCardByID()
        {
            Card card = CardManager.CreateCard("Underground Sea");
            int cardID = card.GetID();

            Card saved = CardManager.GetCard(cardID);

            Assert.AreEqual(cardID, saved.GetID());
            Assert.AreEqual("Underground Sea", saved.GetName());
        }

        [TestMethod]
        public void CardManager_GetsCardByName()
        {
            Card card = CardManager.CreateCard("Counterspell");

            Card saved = CardManager.GetCard("Counterspell");

            Assert.AreEqual("Counterspell", saved.GetName());
            Assert.AreEqual(card.GetID(), saved.GetID());
        }

        [TestMethod]
        public void CardManager_GetsMultipleCardsByID()
        {
            Card card1 = CardManager.CreateCard("Splinter Twin");
            Card card2 = CardManager.CreateCard("Deceiver Exarch");

            Card[] cards = CardManager.GetCardsByID(new int[] {card1.GetID(), card2.GetID()});

            Assert.AreEqual(2, cards.Length);
            Assert.IsTrue(cards[0].GetName() == "Splinter Twin" || cards[1].GetName() == "Splinter Twin");
            Assert.IsTrue(cards[0].GetName() == "Deceiver Exarch" || cards[1].GetName() == "Deceiver Exarch");
        }

        [TestMethod]
        public void CardManager_RemovesCards()
        {
            Card card = CardManager.CreateCard("Show and Tell");
            Card card2 = CardManager.CreateCard("Omniscience");
            Card card3 = CardManager.CreateCard("Emrakul, the Aeons Torn");

            CardManager.DestroyCard(card);
            CardManager.DestroyCard(card2.GetID());
            CardManager.DestroyCard(card3.GetName());

            Assert.IsNull(CardManager.GetCard("Show and Tell"));
            Assert.IsNull(CardManager.GetCard("Omniscience"));
            Assert.IsNull(CardManager.GetCard("Emrakul, the Aeons Torn"));
        }
        [TestMethod]
        public void CardManager_ErrorsWhenTryingToCreateDuplicate()
        {
            Card card = CardManager.CreateCard("Clone");
            Exception expectedException = null;
            try
            {
                Card card2 = CardManager.CreateCard("Clone");
            } catch(Exception ex)
            {
                expectedException = ex;
                Assert.AreEqual("Duplicate entry 'Clone' for key 'name'", ex.Message);
            }
            Assert.IsNotNull(expectedException);
        }
    }
}
