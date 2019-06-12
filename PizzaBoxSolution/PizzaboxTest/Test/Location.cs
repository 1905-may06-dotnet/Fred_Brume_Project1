using NUnit.Framework;
using PizzaBox.Data.Model;


namespace PizzaboxTest.Test
{
    [TestFixture]
    class Location
    {
        [Test]
        public void TestLocationData()
        {
            Repository repo = new Repository();
            int locationId = 1;
            PizzaBox.Domain.Model.Plocation location = repo.GetLocation(locationId);

            string actualCity = location.City;
            string expectedCityValue = "Brookyln";

            string actualStreet = location.Street; 
            string expectedStreetValue = "14141 E98ST";

            string actualState = location.PState;
            string expectedStateValue = "NY";

            string actualZipcode = location.Zipcode;
            string expectedZipcodeValue = "11236";

            Assert.AreEqual(actualCity, expectedCityValue);
            Assert.AreEqual(actualStreet, expectedStreetValue);
            Assert.AreEqual(actualState, expectedStateValue);
            Assert.AreEqual(actualZipcode, expectedZipcodeValue);

        }

    }
}
