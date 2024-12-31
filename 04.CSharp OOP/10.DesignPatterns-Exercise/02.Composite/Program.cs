namespace Composite
{
    public static class Program
    {
        public static void Main()
        {
            Gift perfume = new Gift("Perfume", 15);
            Gift shampoo = new Gift("Shampoo", 10);
            Gift toy = new Gift("Toy", 5);
            Gift money = new Gift("Money", 20);

            CompositeGift cosmeticBox = new CompositeGift("Cosmetic Box");
            cosmeticBox.AddGift(perfume);
            cosmeticBox.AddGift(shampoo);

            CompositeGift giftsFromRelatives = new CompositeGift("Gifts from relatives");
            giftsFromRelatives.AddGift(cosmeticBox);
            giftsFromRelatives.AddGift(toy);
            giftsFromRelatives.AddGift(money);

            CompositeGift giftsFromFriends = new CompositeGift("Gifts from friends");

            CompositeGift allGifts = new CompositeGift("All gifts");
            allGifts.AddGift(giftsFromRelatives);
            allGifts.AddGift(giftsFromFriends);

            Console.WriteLine(allGifts);
        }
    }
}
