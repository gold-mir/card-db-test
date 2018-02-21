namespace Application.Models
{
    public static class CardManager
    {

        public const string DuplicateCardCreationMessage = "A card with that name already exists.";

        public static Card CreateCard(string name)
        {
            return null;
        }

        public static Card GetCard(string name)
        {
            return null;
        }

        public static Card GetCard(int id)
        {
            return null;
        }

        public static Card[] GetCardsByID(int[] ids)
        {
            return new Card[1];
        }

        public static void DestroyCard(Card card)
        {

        }

        public static void DestroyCard(string name)
        {

        }

        public static void DestroyCard(int id)
        {

        }

        public static void DestroyAll()
        {
            
        }

        public static Card[] GetAll()
        {
            return null;
        }
    }
}
