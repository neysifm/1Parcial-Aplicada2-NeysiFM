using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Utils
    {
        [Key]
        public int UtilsID { get; set; }
        public virtual List<DetalleUtils> DetalleUtils { get; set; }

        public Utils(int utilsID)
        {
            UtilsID = utilsID;
        }

        public Utils()
        {
            UtilsID = 0;
        }
    }
}
