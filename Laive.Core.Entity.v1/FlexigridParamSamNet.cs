using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laive.Core.Entity
{
    public class FlexigridParamSamNet
    {
        public int page { get; set; }
        public int rp { get; set; }
        public string letter_pressed { get; set; }
        public string qtype { get; set; }
        public string query { get; set; }
        public string sortname { get; set; }
        public string sortorder { get; set; }
    }
}
