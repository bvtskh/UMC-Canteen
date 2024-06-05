using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanTeenManagement.Bussiness.ENUM
{
    public class OrderEnum
    {
        public enum ValidIngredient
        {
            OK,
            InvalidName,
            NoPrice,
        };

        public enum MenuType
        {
            Main =1,
            Side =2
        };
    }
}
