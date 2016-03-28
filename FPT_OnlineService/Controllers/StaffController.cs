using FPT_OnlineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using PagedList;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FPT_OnlineService.Controllers
{
    [Authorize(Roles = "FPT-Staff,HeadOfAcademicDepartment-Staff,AcademicHead-Staff,CampusDirector-Staff,Academic-Staff")]
    public class StaffController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET All Forms
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var forms = from f in db.Forms
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.StudentRollNo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult New(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; 
            var forms = from f in db.Forms
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.StudentRollNo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Approved(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var forms = from f in db.Forms
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.StudentRollNo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Rejected(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; 
            var forms = from f in db.Forms
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.StudentRollNo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult InProgress(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string id = User.Identity.GetUserId();
            //DAL.DALUser.GetStudent(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; 
            var forms = from f in db.Forms
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.StudentRollNo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "type_desc":
                    forms = forms.OrderByDescending(f => f.Type);
                    break;
                case "Date":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
                default:
                    forms = forms.OrderByDescending(f => f.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(forms.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult StaffEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //string formType = CheckFormType(id);
            Form form = db.Forms.Find(id);
            string formType = form.Type;

            switch (formType)
            {
                case ("Course Registration"):
                    return RedirectToAction("CourseRegEndorsement", new { id = id });
                case ("Suspend Subject"):
                    return RedirectToAction("SuspendSubjectEndorsement", new { id = id });
                case ("Suspend Semester"):
                    return RedirectToAction("SuspendSemesterEndorsement", new { id = id });
                case ("Drop Out"):
                    return RedirectToAction("DropOutEndorsement", new { id = id });
                case ("Request"):
                    return RedirectToAction("RequestEndorsement", new { id = id });
                /*
            case (""):
                break;*/
                default:
                    break;
            }
            return View();
        }

        public ActionResult SuspendSemesterEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendSemesterForm suspendSemesterForm = db.SuspendSemesterForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (suspendSemesterForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSemesterForm.FormID);
            return View(suspendSemesterForm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SuspendSemesterEndorsement([Bind(Include = "FormID,PreviousSemester,TuitionFee,TwoPrevSemester")] 
            SuspendSemesterForm suspendSemesterForm, FormCollection collection)
        {
            string ForwardTo = collection["ForwardTo"];
            string IsWeekBefore = collection["IsWeekBefore"];
            string FormStatus = collection["FormStatus"];
            string Life = collection["Life"];
            //string TuitionFee = collection["TuitionFee"];
            string formComment = collection["formComment"];
            SuspendSemesterForm ssf = db.SuspendSemesterForms.Find(suspendSemesterForm.FormID);
            Form f = db.Forms.Find(suspendSemesterForm.FormID);
            FormComment fC = new FormComment();
            fC.FormID = suspendSemesterForm.FormID;
            fC.Comment = formComment;
            fC.RoleID = Helper.Help.GetRoleId(DAL.UserInfo.Role);
            if (FormStatus.Equals(""))
                f.Status = "Inprogress";
            else
                f.Status = FormStatus;
            string getCurrentDesk = Helper.Help.GetCurrentDesk(Int32.Parse(ForwardTo));
            if (getCurrentDesk.Length > 4)
            {
                f.CurrentDesk = getCurrentDesk;
                f.Flow = f.Flow + f.CurrentDesk + ",";
            }
            if (IsWeekBefore.Equals("on"))
                ssf.IsWeekBefore = true;
            else
                ssf.IsWeekBefore = false;
            
                

            //if (TuitionFee.Equals("true"))
            //    ssf.TuitionFee = true;
            //else
            //    ssf.TuitionFee = false;
            ssf.PreviousSemester = suspendSemesterForm.PreviousSemester;
            ssf.TwoPrevSemester = suspendSemesterForm.TwoPrevSemester;
            db.Entry(ssf).State = EntityState.Modified;
            db.FormComments.Add(fC);
            db.SaveChanges();
            if (f.Status.Equals("Approved") || f.Status.Equals("Rejected"))
            {
                f.ApprovalDate = DateTime.Now.ToString();
                f.ApprovalBy = DAL.UserInfo.Role;
                Helper.Notify notify = new Helper.Notify();

                string notifyMessage = "Your " + f.Type + " for " + ssf.SemesterName + " has been " + f.Status;
                await SendNotification(notifyMessage, DAL.UserInfo.Email, f.StudentRollNo);
            }
            return RedirectToAction("Index", "Staff");
        }

        
        public ActionResult SuspendSubjectEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendSubjectForm suspendSubjectForm = db.SuspendSubjectForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };


            if (suspendSubjectForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", suspendSubjectForm.FormID);
            return View(suspendSubjectForm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SuspendSubjectEndorsement([Bind(Include = "FormID,NotAllSubject")] 
            SuspendSubjectForm suspendSubjectForm, FormCollection collection)
        {
            string ForwardTo = collection["ForwardTo"];            
            string FormStatus = collection["FormStatus"];
            string IsWeekBefore = collection["IsWeekBefore"];
            //string NotAllSubject = collection["NotAllSubject"];
            string formComment = collection["formComment"];
            SuspendSubjectForm ssf = db.SuspendSubjectForms.Find(suspendSubjectForm.FormID);
            Form f = db.Forms.Find(suspendSubjectForm.FormID);
            FormComment fC = new FormComment();
            fC.FormID = suspendSubjectForm.FormID;
            fC.Comment = formComment;
            fC.RoleID = Helper.Help.GetRoleId(DAL.UserInfo.Role);
            if (FormStatus.Equals(""))
                f.Status = "Inprogress";
            else
                f.Status = FormStatus;
            string getCurrentDesk = Helper.Help.GetCurrentDesk(Int32.Parse(ForwardTo));
            if (getCurrentDesk.Length > 4)
            {
                f.CurrentDesk = getCurrentDesk;
                f.Flow = f.Flow + f.CurrentDesk + ",";
            }
            if (IsWeekBefore.Equals("on"))
                ssf.IsWeekBefore = true;
            else
                ssf.IsWeekBefore = false;

            //if (NotAllSubject.Equals("true"))
            //    ssf.NotAllSubject = true;
            //else
            //    ssf.NotAllSubject = false;
            db.Entry(ssf).State = EntityState.Modified;
            db.FormComments.Add(fC);
            db.SaveChanges();
            if(f.Status.Equals("Approved") || f.Status.Equals("Rejected"))
            {
                f.ApprovalDate = DateTime.Now.ToString();
                f.ApprovalBy = DAL.UserInfo.Role;
                Helper.Notify notify = new Helper.Notify();
                
                string notifyMessage = "Your " +f.Type+" for "+ ssf.SubjectName + " has been "+f.Status;
                await SendNotification(notifyMessage, DAL.UserInfo.Email, f.StudentRollNo);
            }
            return RedirectToAction("Index", "Staff");
        }

        public ActionResult CourseRegEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegForm courseRegForm = db.CourseRegForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (courseRegForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", courseRegForm.FormID);
            return View(courseRegForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CourseRegEndorsement([Bind(Include = "FormID,TuitionFee")] 
            CourseRegForm courseRegForm, FormCollection collection)
        {
            string ForwardTo = collection["ForwardTo"];
            string FormStatus = collection["FormStatus"];
            string IsWeekBefore = collection["IsWeekBefore"];
            string NotAllSubject = collection["NotAllSubject"];
            string formComment = collection["formComment"];
            //string TuitionFee = collection["TuitionFee"];
            string CoursesAvailable = collection["CoursesAvailable"];

            CourseRegForm crf = db.CourseRegForms.Find(courseRegForm.FormID);
            Form f = db.Forms.Find(courseRegForm.FormID);
            FormComment fC = new FormComment();
            fC.FormID = courseRegForm.FormID;
            fC.Comment = formComment;
            fC.RoleID = Helper.Help.GetRoleId(DAL.UserInfo.Role);
            if (FormStatus.Equals(""))
                f.Status = "Inprogress";
            else
                f.Status = FormStatus;
            string getCurrentDesk = Helper.Help.GetCurrentDesk(Int32.Parse(ForwardTo));
            if (getCurrentDesk.Length > 4)
            {
                f.CurrentDesk = getCurrentDesk;
                f.Flow = f.Flow + f.CurrentDesk + ",";
            }
            if (IsWeekBefore.Equals("on"))
                crf.IsWeekBefore = true;
            else
                crf.IsWeekBefore = false;
            

            //if (TuitionFee.Equals("true"))
            //    crf.TuitionFee = true;
            //else
            //    crf.TuitionFee = false;
            crf.CoursesAvailable = CoursesAvailable;
            db.Entry(crf).State = EntityState.Modified;
            db.FormComments.Add(fC);
            db.SaveChanges();
            if (f.Status.Equals("Approved") || f.Status.Equals("Rejected"))
            {
                f.ApprovalDate = DateTime.Now.ToString();
                f.ApprovalBy = DAL.UserInfo.Role;
                Helper.Notify notify = new Helper.Notify();

                string notifyMessage = "Your " + f.Type + " for " + crf.Subject + " has been " + f.Status;
                await SendNotification(notifyMessage, DAL.UserInfo.Email, f.StudentRollNo);
            }
            return RedirectToAction("Index", "Staff");
        }

        public ActionResult DropOutEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropOutForm dropOutForm = db.DropOutForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (dropOutForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", dropOutForm.FormID);
            return View(dropOutForm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DropOutEndorsement([Bind(Include = "FormID")] 
            DropOutForm dropOutForm, FormCollection collection)
        {
            string ForwardTo = collection["ForwardTo"];
            string FormStatus = collection["FormStatus"];
            string IsWeekBefore = collection["IsWeekBefore"];
            string AcademicHeadEndorse = collection["AcademicHeadEndorse"];
            string formComment = collection["formComment"];
            string TuitionFee = collection["TuitionFee"];
            string AccountStatus = collection["AccountStatus"];
            string LibraryStatus = collection["LibraryStatus"];
            DropOutForm dof = db.DropOutForms.Find(dropOutForm.FormID);
            Form f = db.Forms.Find(dropOutForm.FormID);
            FormComment fC = new FormComment();
            fC.FormID = dropOutForm.FormID;
            fC.Comment = formComment;
            fC.RoleID = Helper.Help.GetRoleId(DAL.UserInfo.Role);
            if (FormStatus.Equals(""))
                f.Status = "Inprogress";
            else
                f.Status = FormStatus;
            string getCurrentDesk = Helper.Help.GetCurrentDesk(Int32.Parse(ForwardTo));
            if (getCurrentDesk.Length > 4)
            {
                f.CurrentDesk = getCurrentDesk;
                f.Flow = f.Flow + f.CurrentDesk + ",";
            }
            
            dof.AcademicHeadEndorse = AcademicHeadEndorse;
            dof.AccountStatus = AccountStatus;
            dof.LibraryStatus = LibraryStatus;

            if (f.Status.Equals("Approved"))
                f.ApprovalDate = DateTime.Now.ToString();

            db.Entry(dof).State = EntityState.Modified;
            db.FormComments.Add(fC);
            db.SaveChanges();
            if (f.Status.Equals("Approved") || f.Status.Equals("Rejected"))
            {
                f.ApprovalDate = DateTime.Now.ToString();
                f.ApprovalBy = DAL.UserInfo.Role;
                Helper.Notify notify = new Helper.Notify();

                string notifyMessage = "Your " + f.Type + " has been " + f.Status;
                await SendNotification(notifyMessage, DAL.UserInfo.Email, f.StudentRollNo);
            }
            return RedirectToAction("Index", "Staff");
        }

        public ActionResult Drafts()
        {
            return View();
        }
        
        public ActionResult Trash()
        {
            return View();
        }

        public ActionResult RequestEndorsement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.RequestForms.Find(id);

            AllFormModel allFormModels = new AllFormModel()
            {
                Form = db.Forms.Find(id),
                SuspendSubjectForm = db.SuspendSubjectForms.Find(id)
            };

            if (requestForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Type", requestForm.FormID);
            return View(requestForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RequestEndorsement([Bind(Include = "FormID")] 
            RequestForm requestForm, FormCollection collection)
        {
            string ForwardTo = collection["ForwardTo"];
            string FormStatus = collection["FormStatus"];
            string ReceivedBy = collection["ReceivedBy"];
            string formComment = collection["formComment"];
            string ToDepartment = collection["ToDepartment"];
            string ProcessedBy = collection["ProcessedBy"];
            string ApprovalReason = collection["ApprovalReason"];
            RequestForm rf = db.RequestForms.Find(requestForm.FormID);
            Form f = db.Forms.Find(requestForm.FormID);
            FormComment fC = new FormComment();
            fC.FormID = requestForm.FormID;
            fC.Comment = formComment;
            fC.RoleID = Helper.Help.GetRoleId(DAL.UserInfo.Role);
            rf.ReceivedBy = ReceivedBy;
            rf.ProcessedBy = ProcessedBy;
            rf.ToDepartment = ToDepartment;
            if (FormStatus.Equals(""))
                f.Status = "Inprogress";
            else
                f.Status = FormStatus;
            string getCurrentDesk = Helper.Help.GetCurrentDesk(Int32.Parse(ForwardTo));
            if (getCurrentDesk.Length > 4)
            {
                f.CurrentDesk = getCurrentDesk;
                f.Flow = f.Flow + f.CurrentDesk + ",";
            }
            
            rf.ApprovalReason = ApprovalReason;

            db.Entry(rf).State = EntityState.Modified;
            db.FormComments.Add(fC);
            db.SaveChanges();
            if (f.Status.Equals("Approved") || f.Status.Equals("Rejected"))
            {
                f.ApprovalDate = DateTime.Now.ToString();
                f.ApprovalBy = DAL.UserInfo.Role;
                Helper.Notify notify = new Helper.Notify();

                string notifyMessage = "Your " + f.Type + " for " + rf.RequestTitle + " has been " + f.Status;
                await SendNotification(notifyMessage, DAL.UserInfo.Email, f.StudentRollNo);
            }
            return RedirectToAction("Index", "Staff");
        }


        // GET: Semesters
        public ActionResult Semester()
        {
            return View(db.Semesters.ToList());
        }

        // GET: Semesters/Details/5
        public ActionResult SemesterDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // GET: Semesters/Create
        public ActionResult CreateSemester()
        {
            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSemester([Bind(Include = "StartDate,EndDate,Year,NoOfWeeks,NoOfMonths,Season")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                semester.Name = " " + semester.Year;
                db.Semesters.Add(semester);
                db.SaveChanges();
                return RedirectToAction("Semester");
            }

            return View(semester);
        }

        // GET: Semesters/Edit/5
        public ActionResult EditSemester(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSemester([Bind(Include = "StartDate,EndDate,Year,NoOfWeeks,NoOfMonths,Season")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                semester.Name = " "+semester.Year;
                db.Entry(semester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Semester");
            }
            return View(semester);
        }

        // GET: Semesters/Delete/5
        public ActionResult DeleteSemester(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("DeleteSemester")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Semester semester = db.Semesters.Find(id);
            db.Semesters.Remove(semester);
            db.SaveChanges();
            return RedirectToAction("Semester");
        }

        public async Task<ActionResult> SendNotification(string NotificationMessage, string NotifyFrom, string NotifyTo)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            string ToEmail = DAL.Users.GetStudent(NotifyTo);
            message.To.Add(new MailAddress(ToEmail));  // replace with valid value 
            //message.Bcc.Add(new MailAddress(NotifyFrom + "@fpt.edu.vn"));
            message.From = new MailAddress("fuonlineservice2016@gmail.com");  // replace with valid value
            message.Subject = "FU - Notification";
            message.Body = string.Format(body, "FU - Online Service", "fuonlineservice2016@gmail.com", NotificationMessage);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "fuonlineservice2016@gmail.com",  // replace with valid value
                    Password = "ATS3...."  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
            return RedirectToAction("Index", "Staff");
        }
    }
}