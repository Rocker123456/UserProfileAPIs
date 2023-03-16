using System.ComponentModel.DataAnnotations;

namespace UserProfileAPIs.Database.Models
{
    public class UserData
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNo { get; set; }
        public string HomeAddress { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
    }
}
