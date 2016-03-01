using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPT_OnlineService.Models
{
    public class Form
    {
        [Key]
        public int ID { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string CurrentDesk { get; set; }

        public string Flow { get; set; }

        public string Status { get; set; }

        [ForeignKey("Student")]
        public string RollNo { get; set; }

        public virtual Student Student { get; set; }
        public virtual CourseRegForm CourseRegForm { get; set; }
        public virtual DropOutForm DropOutForm { get; set; }
        public virtual SuspendSemesterForm SuspendSemesterForm { get; set; }
        public virtual SuspendSubjectForm SuspendSubjectForm { get; set; }
        public virtual RequestForm RequestForm { get; set; }
    }


    public class DropOutForm
    {
        [Key]
        [ForeignKey("Form")]
        public int FormID { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Please input your correct rollno", MinimumLength = 6)]
        [Display(Name = "Class (Lớp)")]
        public string Class { get; set; }

        [Required]
        [Display(Name = "Method of payment (Trạng thái học phí)")]
        public string MethodPayment { get; set; }

        [Required]
        [Display(Name = "Date of dropping out (Ngày thôi học)")]
        public string DropOutDate { get; set; }

        [Required]
        [Display(Name = "Reason (Lý do)")]
        public string Reason { get; set; }
        
        public virtual Form Form { get; set; }
    }

    public class SuspendSemesterForm
    {
        [Key]
        [ForeignKey("Form")]
        public int FormID { get; set; }

        [Required]
        [Display(Name = "Phone(Số điện thoại)")]
        public int StudentPhone { get; set; }

        [Required]
        [Display(Name = "Semester no")]
        public int SemesterNo { get; set; }

        [Required]
        [Display(Name = "Semester season")]
        public string SemesterSeason { get; set; }

        [Required]
        [Display(Name = "Semester year")]
        public string SemesterYear { get; set; }

        public virtual Form Form { get; set; }
    }

    public class SuspendSubjectForm
    {
        [Key]
        [ForeignKey("Form")]
        public int FormID { get; set; }

        [Required]
        [Display(Name = "Phone(Số điện thoại)")]
        public int StudentPhone { get; set; }

        [Required]
        [Display(Name = "Semester no")]
        public int SemesterNo { get; set; }

        [Required]
        [Display(Name = "Block no")]
        public int BlockNo { get; set; }

        [Required]
        [Display(Name = "Semester season")]
        public string SemesterSeason { get; set; }

        [Required]
        [Display(Name = "Semester year")]
        public string SemesterYear { get; set; }

        public virtual Form Form { get; set; }

    }

    public class RequestForm
    {
        [Key]
        [ForeignKey("Form")]
        public int FormID { get; set; }

        [Required]
        [Display(Name = "REQUEST FOR: )")]
        public string RequestTitle { get; set; }
        
        [Required]
        [Display(Name = "Phone(Số điện thoại)")]
        public int StudentPhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        public int StudentEmail { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Please input your correct details", MinimumLength = 6)]
        [Display(Name = "Course name/Class (Lớp)")]
        public string Class { get; set; }

        [Required]
        [Display(Name = "I am requesting for/I would like to explain my problem as followed:")]
        public string Batch { get; set; }

        public virtual Form Form { get; set; }
    }

    public class CourseRegForm
    {
        [Key]
        [ForeignKey("Form")]
        public int FormID { get; set; }
        
        [Required]
        [Display(Name = "Phone(Số điện thoại)")]
        public int StudentPhone { get; set; }

        [Required]
        [Display(Name = "Subject Code(Mã môn)")]
        public string SubjectCode { get; set; }

        [Required]
        [Display(Name = "Subject(Môn đăng ký)")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Status(Tình trạng môn học)")]
        public string Status { get; set; }

        [Display(Name = "Class/time (optional)")]
        public string Class { get; set; }
        
        public virtual Form Form { get; set; }
    }

}