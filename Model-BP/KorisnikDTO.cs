using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model_BP
{
    [DataContract]
    public class KorisnikDTO
    {
        [DataMember]
        public int IDKorisnikaDTO { get; set; }

        [DataMember]
        public string ImeDTO { get; set; }

        [DataMember]
        public string AdresaDTO { get; set; }
        [DataMember]
        public string PrezimeDTO { get; set; }
        [DataMember]
        public string BrojTelefonaDTO { get; set; }
        [DataMember]
        public string UsernameDTO { get; set; }
        [DataMember]
        public string SifraDTO { get; set; }

    }
}