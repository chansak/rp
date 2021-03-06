﻿namespace RP.Website.Models
{
    public class PrintOptionViewModel
    {
        public string Id { get; set; }
        public string PatternName { get; set; }
        public string PatternImagePath { get; set; }
        public string ColorName { get; set; }

        public int SelectedOption { get; set; }
        public string ColorId { get; set; }
        public string PatternId { get; set; }
    }
}