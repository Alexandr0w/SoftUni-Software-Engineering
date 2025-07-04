﻿namespace Homies.Models.Event
{
    public class EventInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Organiser { get; set; } = null!;
    }
}
