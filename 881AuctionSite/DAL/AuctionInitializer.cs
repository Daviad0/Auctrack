using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DemoAuctrack.Models;

namespace DemoAuctrack.DAL
{
    public class AuctionInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AuctionContext>
    {
        protected override void Seed(AuctionContext context)
        {
            var bidders = new List<Bidder>
            {
            new Bidder{
                BidderNum = 1,
                Name ="David R.",
                ContactInfo ="-",
            },
            new Bidder{
                BidderNum = 2,
                Name ="John D.",
                ContactInfo ="-",
            },
            new Bidder{
                BidderNum = 3,
                Name ="Ima P.",
                ContactInfo ="-",
            },
            new Bidder{
                BidderNum = 4,
                Name ="Place H.",
                ContactInfo ="-",
            },
            new Bidder{
                BidderNum = 5,
                Name ="Example C.",
                ContactInfo ="-",
            },
            new Bidder{
                BidderNum = 6,
                Name ="Game T.",
                ContactInfo ="-",
            },
            new Bidder{
                BidderNum = 7,
                Name ="Google C.",
                ContactInfo ="-",
            },

            /*new Item{
                ItemID = 2,
                ItemName ="My Hopes and Dreams",
                Description ="Decided to sell on website. Don't @ Me",
                Value ="$00.00",
                Current ="$4.00",
                Winner ="Bidder 85",
                Donator ="(Willingly?) Me",
                TimeFrame =new TimeSpan(8,30,00)
            },
            new Item{
                ItemID = 3,
                ItemName ="Proof of Purchase Recipt",
                Description ="If you buy this, you get proof that you bought it",
                Value ="$70.00",
                Current ="$64.50",
                Winner ="Bidder 1",
                Donator ="Bottom of the Third Drawer in my Desk",
                TimeFrame =new TimeSpan(8,30,00)
            },*/

            };

            bidders.ForEach(s => context.Bidders.Add(s));
            context.SaveChanges();
        }
    }
}