﻿using MVCWebNTier.Models;

namespace MVCWebNTier.ViewModel.School
{
    public class SchoolViewModel
    {
        public string SchoolID { get; set; }
        public string SchoolName { get; set; }
        ICollection<StudentViewModel> Students { get; set; }
    }
}
