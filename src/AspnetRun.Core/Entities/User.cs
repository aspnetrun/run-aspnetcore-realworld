using AspnetRun.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class User : BaseEntity
    {        
        public AdAccount AdAccount { get; set; }
    }
}
