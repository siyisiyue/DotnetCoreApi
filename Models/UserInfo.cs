﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; }
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
