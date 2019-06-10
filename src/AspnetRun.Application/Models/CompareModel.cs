using AspnetRun.Application.Models.Base;
using System.Collections.Generic;

namespace AspnetRun.Application.Models
{
    public class CompareModel : BaseModel
    {
        public string UserName { get; set; }
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
    }
}
