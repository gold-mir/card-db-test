using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Application.Models
{
    public static class CardManager
    {
        public static Card CreateCard(string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"INSERT INTO cards (name) VALUES ('{name}');";
            cmd.ExecuteNonQuery();

            cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"SELECT * FROM cards WHERE (name='{name}');";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            Card output = null;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string cardName = rdr.GetString(1);
                output = new Card(cardName, id);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return output;
        }

        public static Card GetCard(string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"SELECT * FROM cards WHERE (name='{name}');";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            Card output = null;
            while(rdr.Read())
            {
                int cardID = rdr.GetInt32(0);
                string cardName = rdr.GetString(1);
                output = new Card(cardName, cardID);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return output;
        }

        public static Card GetCard(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"SELECT * FROM cards WHERE (id={id});";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            Card output = null;
            while(rdr.Read())
            {
                int cardID = rdr.GetInt32(0);
                string cardName = rdr.GetString(1);
                output = new Card(cardName, cardID);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return output;
        }

        public static Card[] GetCardsByID(int[] ids)
        {

            string idStrings = "";
            for(int i = 0; i < ids.Length; i++)
            {
                idStrings += ids[i];
                if(i < ids.Length - 1)
                {
                    idStrings += ", ";
                }
            }

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"SELECT * FROM cards WHERE id IN ({idStrings});";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            List<Card> output = new List<Card>();
            while(rdr.Read())
            {
                int cardID = rdr.GetInt32(0);
                string cardName = rdr.GetString(1);
                output.Add(new Card(cardName, cardID));
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return output.ToArray();
        }

        public static void DestroyCard(Card card)
        {
            DestroyCard(card.GetID());
        }

        public static void DestroyCard(string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"DELETE FROM cards WHERE (name = '{name}');";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DestroyCard(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = $"DELETE FROM cards WHERE (id = {id});";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DestroyAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM cards;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Card[] GetAll()
        {
            List<Card> cards = new List<Card>();

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "SELECT * FROM cards;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Card newcard = new Card(name, id);
                cards.Add(newcard);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return cards.ToArray();
        }
    }

    // public class DuplicatecardException : Exception
    // {
    //     public DuplicatecardException(string cardname)
    //     : base($"A card with the name '{cardname}' already exists.")
    //     {
    //
    //     }
    // }
}
