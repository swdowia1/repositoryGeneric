using System.Collections.Generic;

namespace respositorUnitSw.View
{
    public class ServiceBaseResponse
    {
        public bool isError { get; set; }

        public string ErrorMessage { get; set; }
        public string InfoMessage { get; set; }
    }
    public class ServiceResponse<T> : ServiceBaseResponse
    {
        public T Result { get; set; }

    }

    public class ServiceListResponse<T> : ServiceResponse<IEnumerable<T>>
    {
        public int TotalCount { get; set; }

    }
}
