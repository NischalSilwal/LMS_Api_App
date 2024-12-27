using System;

namespace LMS_Api_App.Application.DTOs.Student
{
    public class AddStudentDto
    {
        public string? Name { get; set; } // Changed to nullable to handle optional updates
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? Department { get; set; }
    }
}
