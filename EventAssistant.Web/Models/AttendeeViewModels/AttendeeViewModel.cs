namespace EventAssistant.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AttendeeViewModel
    {
        public string EventName { get; set; }

        [Required(ErrorMessage = "Please provide a first name")]
        [MaxLength(100, ErrorMessage = "The first name cannot be more than 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide a last name")]
        [MaxLength(100, ErrorMessage = "The last name cannot be more than 100 characters")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The organisation cannot be more than 100 characters")]
        public string Organisation { get; set; }

        [MaxLength(100, ErrorMessage = "Nicknames cannot be more than 100 characters long.")]
        public string Nicknames { get; set; }

        [MaxLength(255, ErrorMessage = "Keep your custom message brief and to the point")]
        public string CustomWelcomeMessage { get; set; }
    }
}