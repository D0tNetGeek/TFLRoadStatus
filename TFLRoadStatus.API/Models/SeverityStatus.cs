﻿namespace TFLRoadStatus.API.Models
{
    public class SeverityStatus
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string statusSeverity { get; set; }
        public string statusSeverityDescription { get; set; }
        public string bounds { get; set; }
        public string envelope { get; set; }
        public string url { get; set; }
    }
}
