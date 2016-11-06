namespace EventAssistant.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EventViewModel
    {
        [Required(ErrorMessage = "You must provide a description for the event")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a description for the event")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select a date for this event in the UK format dd/mm/yyyy")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public List<AttendeeViewModel> Attendees { get; internal set; } = new List<AttendeeViewModel>();
    }
}