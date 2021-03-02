using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi.Models
{
    /// <summary>
    /// 甘特图连线类
    /// </summary>
    public class GanttLine
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 连接线起点Id
        /// </summary>
        [JsonProperty("source")]
        public int Source { get; set; }
        /// <summary>
        /// 连接线终点ID
        /// </summary>
        [JsonProperty("target")]
        public int Target { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }
    }
}
