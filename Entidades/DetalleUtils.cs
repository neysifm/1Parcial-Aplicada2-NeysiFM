using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class DetalleUtils
    {
        [Key]
        public int DetalleID { get; set; }
        public int UtilsID { get; set; }
        [ForeignKey("UtilsID")]
        public virtual Utils Utilidades { get; set; }

        public DetalleUtils(int detalleID, int utilsID)
        {
            DetalleID = detalleID;
            UtilsID = utilsID;
        }

        public DetalleUtils()
        {
            DetalleID = 0;
            UtilsID = 0;
        }
    }
}
