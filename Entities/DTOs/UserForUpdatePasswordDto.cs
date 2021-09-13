using Core.Entities;

namespace Entities.DTOs
{
    public class UserForUpdatePasswordDto : IDto
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }


    }


}