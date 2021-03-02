using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DotnetCoreApi.Controllers;
using DotnetCoreApi.Dtos;

namespace DotnetCoreApi.Models
{
    public class CementConcrete:TableHead, BaseData<CementConcrete, ShuiNiHunLingTu>
    {
        [Description("数据列表")]
        public List<ShuiNiHunLingTu> Data { get; set; }
    }
}
