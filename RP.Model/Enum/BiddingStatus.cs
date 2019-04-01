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
        [Description("Undefined")]
        undefined =0,
        [Description("Waiting")]
        Waiting=1,
        [Description("Win")]
        Win=2,
        [Description("Lose")]
        Lose=3
    }
}
