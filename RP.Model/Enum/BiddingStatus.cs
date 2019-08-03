using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Model
{
    public enum BiddingStatus
    {
        [Description("รออัพสถานะ")]
        undefined =0,
        [Description("รอยืนยัน")]
        Waiting=1,
        [Description("Win")]
        Win=2,
        [Description("Lose")]
        Lose=3
    }
}
