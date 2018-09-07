using Home.AppCore.Repository;
using Home.Infrastructure;
using Home.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Home.Test
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private IEmployeeRepository empRepo;
        [TestInitialize]
        public void TestSetup() {
            empRepo = GetInMemoryEmployeeRepository();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var result = empRepo.GetEmployee();
            Assert.IsNotNull(result);
            var numberofRecords = result.ToList().Count;
            Assert.AreEqual(2, numberofRecords);
        }

        private IEmployeeRepository GetInMemoryEmployeeRepository() {
            DbContextOptions<HomeContext> options;
            var builder = new DbContextOptionsBuilder<HomeContext>();
            builder.UseInMemoryDatabase("Home");
            options = builder.Options;
            HomeContext homecontext = new HomeContext(options);
            homecontext.Database.EnsureDeleted();
            homecontext.Database.EnsureCreated();
            return new EmployeeRepository(homecontext);

        }
    }
}
