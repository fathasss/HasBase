using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasB4bBase.Models.Interfaces
{
    interface IOrder
    {
        int Insert();
        bool Update();
        bool Delete();

    }
}
