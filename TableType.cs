using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi
{
    public enum TableType
    {
        [Description("记录表")]
        JLB =0,
        [Description("评定表")]
        PDB =1

    }
}
