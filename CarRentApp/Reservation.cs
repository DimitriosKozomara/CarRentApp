using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvpProj
{
    public class Reservation
    {
        int reservationID;
        int carID;
        int clientID;
        DateTime fromDate;
        DateTime toDate;
        int price;

        public Reservation(int carID, int clientID, DateTime fromDate, DateTime toDate, int price)
        {
            this.carID = carID;
            this.clientID = clientID;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.price = price;
        }
        public int ReservationID { get => reservationID; set => reservationID = value; }
        public int CarID { get => carID; set => carID = value; }
        public int ClientID { get => clientID; set => clientID = value; }
        public DateTime FromDate { get => fromDate; set => fromDate = value; }
        public DateTime ToDate { get => toDate; set => toDate = value; }
        public int Price { get => price; set => price = value; }

        public void AppointmentOccupation(Offer chosenOffer)
        {
            List<Offer> allOffers = Data.ReadAll<Offer>();
            Offer linq = allOffers.Where(x => x.CarID == this.CarID && x.OfferID == chosenOffer.OfferID).FirstOrDefault();

            if (this.fromDate.Date == chosenOffer.FromDate && this.toDate.Date == chosenOffer.ToDate)
            {
                allOffers.Remove(linq);
                Data.Update<Offer>(allOffers);
            }
            else if (this.toDate.Date == chosenOffer.ToDate)
            {
                linq.ToDate = this.ToDate.AddDays(-1).Date;
                Data.Update<Offer>(allOffers);
            }
            else if (this.fromDate == chosenOffer.FromDate)
            {
                linq.FromDate = this.toDate.AddDays(1).Date;
                Data.Update<Offer>(allOffers);
            }
            else
            {
                DateTime dt = chosenOffer.ToDate;
                linq.ToDate = this.fromDate.AddDays(-1).Date;
                Data.Update(allOffers);
                Data.Save<Offer>(new Offer(chosenOffer.CarID, this.toDate.AddDays(1).Date, dt, chosenOffer.PricePerDay));
            }
        }

        public void ReturnAppointment()
        {
            ComparerClass cc = new ComparerClass();
            Offer tmp = null;
            Offer next = null;
            bool between = false;

            List<Offer> offers = Data.ReadAll<Offer>();
            if(offers == null)
                return;

            List<Offer> chosenOffers = offers.Where(x => x.CarID == this.CarID).ToList();
            chosenOffers.Sort(cc);

            for (int i = 0; i < chosenOffers.Count; i++)
            {
                next = chosenOffers[i];
                if (i < chosenOffers.Count - 1)
                    next = chosenOffers[i + 1];

                if(this.fromDate.Date.AddDays(-1) == chosenOffers[i].ToDate.Date &&
                    this.toDate.Date.AddDays(1) == next.FromDate.Date &&
                    chosenOffers[i].PricePerDay == next.PricePerDay)
                {
                    chosenOffers[i].ToDate = next.ToDate;
                    between = true;
                    break;
                }
            }

            bool change = false;
            
            if(between)
            {
                offers.Remove(next);
                chosenOffers.Remove(next);
            }
            else
            {
                for (int i = 0; i < chosenOffers.Count; i++)
                {
                    int price = this.price / (int)((this.toDate.Date - this.fromDate.Date).TotalDays + 1);
                    if (this.fromDate.Date.AddDays(-1) == chosenOffers[i].ToDate.Date && price == chosenOffers[i].PricePerDay)
                    {
                        change = true;
                        chosenOffers[i].ToDate = this.toDate;
                        break;
                    }
                    else if (this.toDate.Date.AddDays(1) == chosenOffers[i].FromDate.Date &&
                        price == chosenOffers[i].PricePerDay && this.toDate >= DateTime.Now.Date)
                    {
                        change = true;
                        chosenOffers[i].FromDate = this.fromDate;
                        break;
                    }
                }
                if (!change && this.toDate >= DateTime.Now.Date)
                    tmp = new Offer(this.carID, this.fromDate, this.toDate, price);
            }

            Data.Update(offers);
            if (tmp != null)
                Data.Save(tmp);
        }
    }
}
