using Employee.RequestDto;

namespace Employee.RequestDto
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }

        public string ResponseMessage { get; set; }

       

        public List<GetEmployeeDto> dataList { get; set; }
    }
    public class ResponseModel2
    {
        public int StatusCode { get; set; }

        public string ResponseMessage { get; set; }

        public GetEmployeeDto data { get; set; }



    }


}
