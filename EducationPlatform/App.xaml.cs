using EducationPlatform.Models;
using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EducationPlatform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static UserDAL _userDAL { get; set; }
        private static StudentDAL _studentDAL { get; set; }
        private static TeacherDAL _teacherDAL { get; set; }
        private static ClassDAL _classDAL { get; set; }
        private static GradeDAL _gradeDAL { get; set; }
        private static SubjectDAL _subjectDAL { get; set; }
        private static AbsenceDAL _absenceDAL { get; set; }
        private static ClassSubjectDAL _classSubjectDAL { get; set; }

        private static SpecializationDAL _specializationDAL { get; set; }
        public static UserBLL UserBLL { get; set; }
        public static StudentBLL StudentBLL { get; private set; }
        public static TeacherBLL TeacherBLL { get; private set; }
        public static ClassBLL ClassBLL { get; private set; }
        public static SpecializationBLL SpecializationBLL { get; private set; }
        public static GradeBLL GradeBLL { get; private set; }
        public static SubjectBLL SubjectBLL { get; private set; }
        public static ClassSubjectBLL ClassSubjectBLL { get; private set; }
        public static AbsenceBLL AbsenceBLL { get; private set; }

        public App()
        {
            EducationPlatformDbContext dbContext = new EducationPlatformDbContext();
            _userDAL = new UserDAL(dbContext);
            UserBLL = new UserBLL(_userDAL);
            UserBLL.GetAllUsers();
            _studentDAL = new StudentDAL(dbContext);
            StudentBLL = new StudentBLL(_studentDAL);
            StudentBLL.GetAllStudents();
            _teacherDAL = new TeacherDAL(dbContext);
            TeacherBLL = new TeacherBLL(_teacherDAL);
            TeacherBLL.GetAllTeachers();
            _classDAL = new ClassDAL(dbContext);
            ClassBLL = new ClassBLL(_classDAL);
            ClassBLL.GetAllClasses();
            _specializationDAL = new SpecializationDAL(dbContext);
            SpecializationBLL = new SpecializationBLL(_specializationDAL);
            SpecializationBLL.GetAllSpecializations();
            _gradeDAL = new GradeDAL(dbContext);
            GradeBLL = new GradeBLL(_gradeDAL);
            GradeBLL.GetAllGrades();
            _subjectDAL = new SubjectDAL(dbContext);
            SubjectBLL = new SubjectBLL(_subjectDAL);
            SubjectBLL.GetAllSubjects();
            _classSubjectDAL = new ClassSubjectDAL(dbContext);
            ClassSubjectBLL = new ClassSubjectBLL(_classSubjectDAL);
            ClassSubjectBLL.GetAllClassSubjects();
            _absenceDAL = new AbsenceDAL(dbContext);
            AbsenceBLL = new AbsenceBLL(_absenceDAL);
            AbsenceBLL.GetAllAbsences();
        }
    }
}


