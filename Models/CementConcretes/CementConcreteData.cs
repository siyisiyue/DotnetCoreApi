using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi.Models
{
    public class CementConcreteData
    {

        public int Id { get; set; }
        public int CementConcreteId { get; set; }
        /// <summary>
        /// 测点桩号
        /// </summary>
        [Description("测点桩号")]
        public string Mark { get; set; }
        /// <summary>
        /// 板厚度
        /// </summary>
        [Description("板厚度设计值")]
        public string BanHouDuSj { get; set; }
        [Description("板厚度实测值")]
        public string BanHouDuSc { get; set; }
        [Description("板厚度偏差值")]
        public string BanHouDuPc { get; set; }
        /// <summary>
        /// 抗滑构造深度
        /// </summary>
        [Description("抗滑构造深度设计值")]
        public string ShenDuSj { get; set; }
        [Description("抗滑构造深度实测值")]
        public string ShenDuSc { get; set; }
        [Description("抗滑构造深度偏差值")]
        public string ShenDuPc { get; set; }
        /// <summary>
        /// 相邻板高差
        /// </summary>
        [Description("相邻板高差设计值")]
        public string GaoChaSj { get; set; }
        [Description("相邻板高差实测值")]
        public string GaoChaSc { get; set; }
        [Description("相邻板高差偏差值")]
        public string GaoChaPc { get; set; }
        /// <summary>
        /// 纵、横缝顺直度
        /// </summary>
        [Description("纵、横缝顺直度设计值")]
        public string ShunZhiDuSj { get; set; }
        [Description("纵、横缝顺直度实测值")]
        public string ShunZhiDuSc { get; set; }
        [Description("纵、横缝顺直度偏差值")]
        public string ShunZhiDuPc { get; set; }
        /// <summary>
        /// 横向力系数 SFC
        /// </summary>
        [Description("横向力系数 SFC")]
        public string XiShu { get; set; }
        /// <summary>
        /// 断板率
        /// </summary>
        [Description("断板率")]
        public string DuanBanLv { get; set; }
    }
}
