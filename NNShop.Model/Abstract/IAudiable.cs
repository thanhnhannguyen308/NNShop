using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNShop.Model.Abstract
{
    public interface IAudiable
    {
        DateTime? CreateDate { set; get; }

        string CreateBy { set; get; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }

        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }

        bool Status { get; set; }

    }
}
