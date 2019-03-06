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
        private string rentType;
        private int d;
        private int chargeByRentType;

        public RentBikeModel(int pBikes, int pTotal, bool pIsFamily, string pRentType, int chargeByRentType_) {
            this.bikes = pBikes;
            this.total = pTotal;
            this.isFamily = pIsFamily;
            this.rentType = pRentType;
            this.chargeByRentType = chargeByRentType_;
        }

        public void MakeFamilyDiscount() {
            if (this.isFamily)
            {
                double total_;
                total_ = total * 30 / 100;
                this.total = this.total - total_;
            }
        }

        public int getBikes() { return this.bikes; }

        public double getTotal() { return this.total; }

        public bool getIsFamily() { return this.isFamily; }

        public string getRentType() { return this.rentType; }

        public int getD() { return this.d; }

        public int getChargeByRentType() { return this.chargeByRentType; }


        public void setBikes(int bikes_) { this.bikes = bikes_; }

        public void setTotal(int total_) { this.total = total_; }

        public void setIsFamily(bool isFamily_) { this.isFamily = isFamily_; }

        public void setRentType(string rentType_) { this.rentType = rentType_; }

        public void setD(int d_) { this.d = d_; }

        public void setChargeByRentType(int chargeByRentType_) { this.chargeByRentType = chargeByRentType_; }



    }
}
