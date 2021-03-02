using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi.Models
{
    /// <summary>
    /// 甘特图任务类
    /// </summary>
    public class GanttTask
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("text")]
        [MaxLength(100)]
        public string Text { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonProperty("start_date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [JsonProperty("parent")]
        public int Parent { get; set; }
        /// <summary>
        /// 进度
        /// </summary>
        [JsonProperty("progress")]
        public decimal Progress { get; set; }
        /// <summary>
        /// 是否打开
        /// </summary>
        [JsonProperty("open")]
        public bool Open { get; set; }
    }
}
