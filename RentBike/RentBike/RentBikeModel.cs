using System;
using System.Collections.Generic;
using System.Text;

namespace RentBike
{
    public class RentBikeModel
    {
        private int bikes;
        private double total;
        private bool isFamily;

        public RentBikeModel(int pBikes, int pTotal, bool pIsFamily) {
            this.bikes = pBikes;
            this.total = pTotal;
            this.isFamily = pIsFamily;
        }

        public void MakeFamilyDiscount() {
            double total_;
            total_ = total * 30 / 100;
            this.total = this.total - total_;
        }

        public int getBikes() { return this.bikes; }

        public double getTotal() { return this.total; }

        public bool getIsFamily() { return this.isFamily; }


    }
}
