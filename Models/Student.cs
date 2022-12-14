using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_course_management.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
      //  public List<Section> Sections { get; set; }
      //  public List<Club> Clubs { get; set; }
    }
}