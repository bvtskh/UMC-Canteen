using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanTeenManagement.Utils
{
    public class IngredientInfo
    {
        public string IngredientCode { get; set; }
        public string IngredientName { get; set; }
        public string Price { get; set; }
        public double SLCM { get; set; }
        public double Bill { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Unit { get; set; }
        public float? Stock { get; set; } //kho
        public float? PreOrder { get; set; } //dat truoc
        public DateTime? DateOrder { get; set; } // dat cho ngày nào
        public DateTime? PreDateOrder { get; set; } // đặt trước cho ngày nào?
        public string DateOrderFor { get; set; } // đặt cho ngày nào nhưng là hiển thị trên datagridview
        public double? SLQuyetDinhMua { get; set; } // quyết định mua với sl...
    }
}
