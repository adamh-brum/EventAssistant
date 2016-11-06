namespace EventAssistant.Models
{
    using System.Collections.Generic;

    public class UserData
    {
        public string UserName { get; set; }

        public List<EventViewModel> Events { get; set; }
    }
}