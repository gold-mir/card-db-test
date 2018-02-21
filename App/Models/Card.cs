namespace Application.Models
{
    public class Card
    {

        private string _name;
        private int _id;

        public Card(string cardName)
            : this(cardName, -1)
        {

        }

        public Card(string cardName, int ID)
        {
            _name = cardName;
            _id = ID;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetID()
        {
            return _id;
        }
    }
}
