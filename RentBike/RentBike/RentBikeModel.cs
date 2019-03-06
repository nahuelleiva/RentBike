using System;
using System.Collections.Generic;
using System.Text;

namespace RentBike
{
    /// <summary>
    /// Base clase to store rents.
    /// </summary>
    public class RentBikeModel
    {
        private int bikes; // How many bikes the user wants to rent
        private double total; // Total of the rent
        private int isFamily; // If is a family group, there will be discounts!
        private string rentType; // Rent type, could be Hourly, Daily, or Weekly
        private int d; // Variable to catch the amount of hours/days/weeks the user wants to rent bikes
        private int chargeByRentType; // How much will be the charge depending on the rent type

        /// <summary>
        /// Creates a new RentBike object
        /// </summary>
        /// <param name="pBikes">How many bikes the user wants to rent</param>
        /// <param name="pTotal">Total of the rent</param>
        /// <param name="pIsFamily">If is a family group, there will be discounts!</param>
        /// <param name="pRentType">Rent type, could be Hourly, Daily, or Weekly</param>
        /// <param name="chargeByRentType_">How much will be the charge depending on the rent type</param>
        public RentBikeModel(int pBikes, int pTotal, int pIsFamily, string pRentType, int chargeByRentType_) {
            this.bikes = pBikes;
            this.total = pTotal;
            this.isFamily = pIsFamily;
            this.rentType = pRentType;
            this.chargeByRentType = chargeByRentType_;
        }

        public RentBikeModel() { }

        public void MakeFamilyDiscount() {
            if (this.isFamily == 1)
            {
                double total_;
                total_ = total * 30 / 100;
                this.total = this.total - total_;
            }
        }

        /// <summary>
        /// Get how many bikes the user wants to rent
        /// </summary>
        /// <returns>int</returns>
        public int getBikes() { return this.bikes; }

        /// <summary>
        /// Set the total of the rent
        /// </summary>
        /// <returns>int</returns>
        public double getTotal() { return this.total; }

        /// <summary>
        /// Return true or false in case it is a family group or not
        /// </summary>
        /// <returns>True/False</returns>
        public int getIsFamily() { return this.isFamily; }

        /// <summary>
        /// Get the rent type that the user has choosen
        /// </summary>
        /// <returns>string</returns>
        public string getRentType() { return this.rentType; }

        /// <summary>
        /// Get the amount of hours/days/weeks that the user wants to rent bikes.
        /// </summary>
        /// <returns>int</returns>
        public int getD() { return this.d; }

        /// <summary>
        /// Get the charge of the rent depending on the rent type.
        /// </summary>
        /// <returns>int</returns>
        public int getChargeByRentType() { return this.chargeByRentType; }

        /// <summary>
        /// Set how many bikes the user wants to rent
        /// </summary>
        /// <returns>int</returns>
        public void setBikes(int bikes_) { this.bikes = bikes_; }

        /// <summary>
        /// Sets the total of the rent
        /// </summary>
        /// <returns>int</returns>
        public void setTotal(int total_) { this.total = total_; }

        /// <summary>
        /// Set true or false in case it is a family group or not
        /// </summary>
        /// <returns>int</returns>
        public void setIsFamily(int isFamily_) { this.isFamily = isFamily_; }

        /// <summary>
        /// Set the rent type that the user has choosen
        /// </summary>
        /// <returns>int</returns>
        public void setRentType(string rentType_) { this.rentType = rentType_; }

        /// <summary>
        /// Set the amount of hours/days/weeks that the user wants to rent bikes.
        /// </summary>
        /// <returns>int</returns>
        public void setD(int d_) { this.d = d_; }

        /// <summary>
        /// Set the charge of the rent depending on the rent type.
        /// </summary>
        /// <returns>int</returns>
        public void setChargeByRentType(int chargeByRentType_) { this.chargeByRentType = chargeByRentType_; }



    }
}
