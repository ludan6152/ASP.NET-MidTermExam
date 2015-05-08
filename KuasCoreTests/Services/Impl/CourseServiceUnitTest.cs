using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course course = new Course();
            course.Id = 1;
            course.Name = "";
            course.Description = "";
            CourseService.AddCourse(course);

            Course dbCourse = CourseService.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Id, dbCourse.Id);

            Console.WriteLine("課程編號為 = " + dbCourse.Id);
            Console.WriteLine("課程名稱為 = " + dbCourse.Name);
            Console.WriteLine("課程描述為 = " + dbCourse.Description);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(course.Id);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_UpdateCourse()
        {
            // 取得資料
            Course course = CourseService.GetCourseById("1");
            Assert.IsNotNull(course);

            // 更新資料
            course.Name = "單元測試";
            CourseService.UpdateCourse(course);

            // 再次取得資料
            Course dbCourse = CourseService.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Name, dbCourse.Name);

            Console.WriteLine("課程編號為 = " + dbCourse.Id);
            Console.WriteLine("課程名稱為 = " + dbCourse.Name);
            Console.WriteLine("課程描述為 = " + dbCourse.Description);

            Console.WriteLine("================================");

            // 將資料改回來
            course.Name = "嚴志和";
            CourseService.UpdateCourse(course);

            // 再次取得資料
            dbCourse = CourseService.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Name, dbCourse.Name);

            Console.WriteLine("課程編號為 = " + dbCourse.Id);
            Console.WriteLine("課程名稱為 = " + dbCourse.Name);
            Console.WriteLine("課程描述為 = " + dbCourse.Description);
        }


        [TestMethod]
        public void TestCourseService_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.Id = 1;
            newCourse.Name = "";
            newCourse.Description = "";
            CourseService.AddCourse(newCourse);

            Course dbCourse = CourseService.GetCourseById(newCourse.Id);
            Assert.IsNotNull(dbCourse);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(newCourse.Id);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_GetCourseById()
        {
            Course course = CourseService.GetCourseById("dennis_yen");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.Id);
            Console.WriteLine("課程名稱為 = " + course.Name);
            Console.WriteLine("課程描述為 = " + course.Description);
        }

    }
}
