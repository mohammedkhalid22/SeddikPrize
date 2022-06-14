using System.Collections.Generic;

namespace FinalProjectSeddik.Models
{
    public class UserVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }

        public IEnumerable<string> Roles { get; set; }
        public ApplicationUser user { get; set; }
    }
}
