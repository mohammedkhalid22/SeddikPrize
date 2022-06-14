using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProjectSeddik.Models
{
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Result { get; set; }
        public string Specialization { get; set; }
        [Required(ErrorMessage = "برجاء ادخال رابط درايف الخاص بك")]
        public string DriveLink { get; set; }
        public int CompId { get; set; }
        public compRegs CompReg { get; set; }
    }
}
