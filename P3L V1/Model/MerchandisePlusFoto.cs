using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class MerchandisePlusFoto
    {
        public int id_merchandise { get; set; }
        
        public string foto { get; set; }

        public string nama_merchandise { get; set; }

        public int poin { get; set; }

        public int stok { get; set; }

    }
}
