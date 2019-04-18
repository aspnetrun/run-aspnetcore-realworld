using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Configuration
{
    public interface IShoppingCartConfiguration
    {
        int MaxItemCountForAUser { get; set; }

    }
}
