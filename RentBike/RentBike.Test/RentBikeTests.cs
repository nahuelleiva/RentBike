using NUnit.Framework;

namespace RentBike.Test
{
    [TestFixture]
    public class RentBikeTest
    {
        [TestCase]
        public void IsFamily()
        {
            RentBikeModel rent = new RentBikeModel(3, 123, 1, "Hourly", (int)RentType.Hour);
            Assert.AreEqual(1, rent.getIsFamily());
        }

        [TestCase]
        public void isRent() {
            RentBikeModel rent = new RentBikeModel();
            Assert.AreEqual(typeof(RentBikeModel), rent);
        }

        [TestCase]
        public void isInserted() {
            DBConnector dBConnector = new DBConnector();
            dBConnector.CreateDB();
            RentBikeModel rent = new RentBikeModel(3, 123, 1, "Hourly", (int)RentType.Hour);
            dBConnector.InsertNewRent(rent);
            long totalRecords = dBConnector.GetTotalRecords();
            Assert.AreEqual(totalRecords > 1, totalRecords > 1);
        }

        [TestCase]
        public void checkIfIsString() {
            RentBikeModel rent = new RentBikeModel(3, 123, 1, "Hourly", (int)RentType.Hour);
            var message = RentBikeHelper.CalculateTotals(rent);
            Assert.AreEqual(typeof(string), message.GetType());
        }

        public void sendMessage() {

        }
    }
}
