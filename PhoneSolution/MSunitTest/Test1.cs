using ClassLibrary;

namespace MSunitTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Konstruktor_dane_poprawne()
        {
            // Arrange
            string owner = "John Doe";
            string phoneNumber = "123456789";
            // Act
            Phone phone = new(owner, phoneNumber);
            // Assert
            Assert.AreEqual(owner, phone.Owner);
            Assert.AreEqual(phoneNumber, phone.PhoneNumber);
        }
        [TestMethod]
        public void Konstruktor_dane_niepoprawne()
        {
            // Arrange
            string owner = "";
            string phoneNumber = "123456789";
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        [TestMethod]
        public void Phone_Capacity_100()
        {
            var phone = new Phone("John Doe", "123456789");
            Assert.AreEqual(100, phone.PhoneBookCapacity);
        }
        [TestMethod]
        public void ZlejDlugosciNumerTelefonu_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("John Doe", "3456789"));
        }
        [TestMethod]
        public void NiecyfrowyNumerTelefonu_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("John Doe", "12345678a"));
        }
        [TestMethod]
        public void PustyNumerTelefonu_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("John Doe", ""));
        }
        //testy count
        [TestMethod]
        public void Count_PustyPhoneBook_DajeZero()
        {
            var phone = new Phone("John Doe", "123456789");
            Assert.AreEqual(0, phone.Count);
        }

        [TestMethod]
        public void AddContact_PhoneBookJestPelny()
        {
            var phone = new Phone("John Doe", "123456789");
            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Contact{i}", $"12345678{i}");
            }
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("ExtraContact", "123456789"));
        }
        [TestMethod]
        public void AddContact_PhoneBook_False()
        {
            var phone = new Phone("Joe Doe", "123456789"); 
            Assert.IsTrue(phone.AddContact("Joe Doe", "123456789"));
            Assert.IsFalse(phone.AddContact("Joe Doe", "123456789"));
        }
    }
}
