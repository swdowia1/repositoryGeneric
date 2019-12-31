using respositorUnitSw.Interface;
using respositorUnitSw.Model;
using respositorUnitSw.View;
using System.Collections.Generic;
using System.Linq;

namespace respositorUnitSw.Service
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ServiceListResponse<VM> GetPerson()
        {
            ServiceListResponse<VM> result = new ServiceListResponse<VM>() {};
            result.Result = _unitOfWork.PersonRepository.Get(null,null,e=>e.Orders).Select(k => new VM() { Name = k.Name, Id = k.Id ,Zam=k.Orders.Select(i=>i.Name).ToList()});
            return result;
        }

        public ServiceListResponse<VMM> GetOrder()
        {
            ServiceListResponse<VMM> result = new ServiceListResponse<VMM>() { };
            result.Result = _unitOfWork.OrderRepository.Get(includes:i=>i.Person).Select(w=>new VMM()
            { Id=w.Id,
                OrderName =w.Name,
                PersonName =w.Person.Name,
            PersonId=w.Person.Id});
            return result;
        }
    }
}
