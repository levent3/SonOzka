namespace MvcWuıLayer.Models
{
    public class ApiUrl
    {

        public string GetById { get; set; }
        public string GetAll { get; set; }

        public string Post { get; set; }
        public string Put { get; set; }
        public string Delete { get; set; }
        public string GetAllInclude { get; set; }
        public ApiUrl(string TableName)
        {

            GetById = @"https://localhost:7229/api/" + TableName;
            GetAll = @"https://localhost:7229/api/" + TableName;
            GetAllInclude = @"https://localhost:7229/api/" + TableName + "/FindAllInclude";
            Post = @"https://localhost:7229/api/" + TableName;
            Put = @"https://localhost:7229/api/" + TableName;
            Delete = @"https://localhost:7229/api/" + TableName;
        }
    }
}
