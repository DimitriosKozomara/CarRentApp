using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvpProj
{
    public class Offer
    {
        int offerID;
        int carID;
        DateTime fromDate;
        DateTime toDate;
        int pricePerDay;

        public Offer(int carID, DateTime fromDate, DateTime toDate, int pricePerDay)
        {
            this.carID = carID;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.pricePerDay = pricePerDay;
        }

        public override bool Equals(object obj)
        {
            Offer offer = obj as Offer;
            if (offer == null)
                return false;
             return (this.offerID == offer.offerID);
        }

        public override int GetHashCode()
        {
            return this.offerID.GetHashCode();
        }

        public int OfferID { get => offerID; set => offerID = value; }
        public int CarID { get => carID; set => carID = value; }
        public DateTime FromDate { get => fromDate; set => fromDate = value; }
        public DateTime ToDate { get => toDate; set => toDate = value; }
        public int PricePerDay { get => pricePerDay; set => pricePerDay = value; }

        public override string ToString()
        {
            return "Car ID: " + this.carID + " >> " + this.fromDate.ToString("dd.MM.yyyy") + " - " + 
                this.toDate.ToString("dd.MM.yyyy") + " Price: " + this.pricePerDay + " RSD per day.";
        }
    }
}
