using System;
using System.Collections.Generic;

public static class GiftCreator
{
    private static readonly List<Phone> Phones = new List<Phone>();
    private static readonly List<PlayStation> PlayStations = new List<PlayStation>();

    public static Gift CreateGift(string giftName)
    {
        Gift gift;
        switch (giftName)
        {
            case "Phone":
                var phone = new Phone(Phones.Count);

                Phones.Add(phone);
                gift = phone;
                break;
            case "PlayStation":
                var playStation = new PlayStation(PlayStations.Count);

                PlayStations.Add(playStation);
                gift = playStation;
                break;

            default:
                gift = null;
                break;
        }

        return gift;
    }
}

public class Phone : Gift
{
    public Phone(int id) : base(id)
    {
    }
}

public class PlayStation : Gift
{
    public PlayStation(int id) : base(id)
    {
    }
}