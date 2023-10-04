using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCLab.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Phải nhập")]
        [RegularExpression(@"[1-9]*[0-9].01.10[34].\d{3}", ErrorMessage ="Không đúng định dạng mã sinh viên")]
        [Remote(action:"CheckStudentExist", controller:"Student", ErrorMessage ="Mã này đã có")]
        public string StudentId { get; set; }

        [StringLength(150, MinimumLength = 5, ErrorMessage ="Từ 5 - 150 kí tự")]
        public string FullName { get; set; }

        [EmailAddress]
        [RegularExpression(@"\d{10}@student.hcmue.edu.vn")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [CheckBirthDateInRange]
        public DateTime BirthDate { get; set; }

        [Range(18, 60, ErrorMessage ="Tuổi từ 18 - 60")]
        public int Age { get; set; }
    }
}
