using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoNames
{
    public class Adresa
    {
        public string geonameid { get; set; }
        public string name { get; set; }
        public string asciiname { get; set; }
        public string alternatenames { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string feature_class { get; set; }
        public string feature_code { get; set; }
        public string country_code { get; set; }
        public string cc2 { get; set; }
        public string admin1_code { get; set; }
        public string admin2_code { get; set; }
        public string admin3_code { get; set; }
        public string admin4_code { get; set; }
        public string population { get; set; }
        public string elevation { get; set; }
        public string dem { get; set; }
        public string timezone { get; set; }
        public string modification_date { get; set; }
    }
}
