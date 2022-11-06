﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class Collaboration
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Keyword { get; set; }
        [StringLength(255)]
        public string Route { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public List<User> User { get; set; }

    }
}
