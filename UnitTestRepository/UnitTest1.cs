
using Microsoft.EntityFrameworkCore;
using respositorUnitSw.Implementation;
using respositorUnitSw.Interface;
using respositorUnitSw.Model;
using respositorUnitSw.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTestRepository
{
    public class UnitTest1
    {
        public List<string> MyProperty { get; set; }
        private IUnitOfWork _unitOfWork;
     
        DbContextOptions<DatabaseContext> options;

        public IPersonService _IPService { get; set; }
        public UnitTest1()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>()
       .UseInMemoryDatabase(databaseName: "Test_With_In_Memory_Database")
       .Options;
          
            MyProperty = new List<string>() { "a", "b" };

            _unitOfWork = new UnitOfWork(new DatabaseContext(options));
            _unitOfWork.PersonRepository.Insert(new Person() { Name = "33", Age = 1 });
            _unitOfWork.Save();
            _IPService  = new PersonService(_unitOfWork);
        }
        [Fact]
        public void Test1()
        {
            var result = _IPService.GetPerson().Result.ToList();
            Assert.Equal(2, Add());
        }

        private int Add()
        {
            return MyProperty.Count;
        }
    }
}
