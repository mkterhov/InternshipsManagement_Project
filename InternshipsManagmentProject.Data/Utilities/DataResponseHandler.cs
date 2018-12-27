using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipsManagmentProject.Data.Utilities
{
    public class DataResponseHandler<T>
    {
            public T Container { get; set; }
            public bool Succes { get; set; }
    }
}
