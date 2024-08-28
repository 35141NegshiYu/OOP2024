using System;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text.Json.Serialization;



namespace Exercise01 {
    public class Employee {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("hireDate")]
        public DateTime HireDate { get; set; }
    }
}