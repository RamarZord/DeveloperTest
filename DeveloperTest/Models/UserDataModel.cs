using System.ComponentModel.DataAnnotations;
using System.Security;

namespace DeveloperTest.Models
{
    /// <summary>
    /// User Data Model
    /// </summary>
    public class UserDataModel
    {
        /// <summary>
        /// Email address of the User
        /// </summary>
        [Required(ErrorMessage = "An email address is required")]
        [EmailAddress(ErrorMessage = "Please supply a valid email address")]
        public string Email { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}