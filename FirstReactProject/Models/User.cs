using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstReactProject.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string firstName { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string lastName { get; set; }
        
        public int Age { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string locationCountry { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string locationCity { get; set; }
    }
}