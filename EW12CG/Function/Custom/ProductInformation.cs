using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EW12CG.Function.Custom {

    public class ProductInformation {

        public string name { get; set; }
        public string number { get; set; }
        public string code { get; set; }
        public string color { get; set; }
        public string weight { get; set; }
        public string bias { get; set; }
        public string lotqty { get; set; }
        public string substamp { get; set; }

        public override string ToString() {
            return string.Format("< {0},{1},{2},{3} >", number, code, color, substamp);
        }

    }
}
