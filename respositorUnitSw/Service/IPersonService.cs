using respositorUnitSw.View;

namespace respositorUnitSw.Service
{
    public interface IPersonService
    {
        ServiceListResponse<VM> GetPerson();
        ServiceListResponse<VMM> GetOrder();
    }
}
