﻿using System.ComponentModel.DataAnnotations;

namespace Cities.Models {

    public class City {
        public string Name { get; set; }

        [Display(Name = "Cntry")]
        public string Country { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public int? Population { get; set; }
    }
}
