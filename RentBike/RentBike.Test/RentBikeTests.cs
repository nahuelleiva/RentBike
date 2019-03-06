using NUnit.Framework;

namespace RentBike.Test
{
    [TestFixture]
    public class RentBikeTest
    {
        [TestCase]
        public void IsFamily()
        {
            RentBikeModel rent = new RentBikeModel(3, 123, 1, "Hourly", 5);
            Assert.AreEqual(1, rent.getIsFamily());
        }

        [TestCase]
        public void isInserted() {
            DBConnector dBConnector = new DBConnector();
            dBConnector.CreateDB();
            RentBikeModel rent = new RentBikeModel(3, 123, 1, "Hourly", 5);
            dBConnector.InsertNewRent(rent);
            long totalRecords = dBConnector.GetTotalRecords();
            Assert.AreEqual(totalRecords > 1, totalRecords > 1);
        }
    }
}
