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
        public void CardManager_AddsCards()
        {
            Card card = CardManager.CreateCard("Squire");

            Assert.AreEqual(1, CardManager.GetAll().Length);
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

            Card[] cards = CardManager.GetCardsByID(new int[] {card1.GetID(), card2.GetId()});

            Assert.AreEqual("Splinter Twin", cards[0].GetName());
            Assert.AreEqual("Deceiver Exarch", cards[1].GetName());
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
            Assert.IsNUll(CardManager.GetCard("Emrakul, the Aeons Torn"));
        }

        public void CardManager_ErrorsWhenTryingToCreateDuplicate()
        {
            Card card = CardManager.CreateCard("Clone");
            Card card2;
            try
            {
                card2 = CardManager.CreateCard("Clone");
            } catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, CardManager.DuplicateCardCreationMessage);
            }
            Assert.IsNull(card2);
        }
    }
}