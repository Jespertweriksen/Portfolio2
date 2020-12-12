﻿using System.Collections.Generic;
using DataService.Objects;

namespace WebService.ObjectDto
{
    public class TitleDto
    {
        public string Id { get; set; }
        public int TypeId { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string Type { get; set; }
        public string TypeUrl { get; set; }
        public string poster  {get; set;}
        
        public int runtime { get; set; }
        
        //URL
        public string Url { get; set; }
        
        public string plot { get; set; }
        
        
        // Mangler
        public double Rating { get; set; }
        
      
    }
}