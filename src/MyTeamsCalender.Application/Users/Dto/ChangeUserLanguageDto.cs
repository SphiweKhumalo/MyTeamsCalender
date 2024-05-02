using System.ComponentModel.DataAnnotations;

namespace MyTeamsCalender.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}