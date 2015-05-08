using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao CourseDao { get; set; }


        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Course course = new Course();
            course.Id = 1;
            course.Name = "";
            course.Description = "";
            CourseDao.AddCourse(course);

            Course dbCourse = CourseDao.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Id, dbCourse.Id);

            Console.WriteLine("課程編號為 = " + dbCourse.Id);
            Console.WriteLine("課程名稱為 = " + dbCourse.Name);
            Console.WriteLine("課程描述為 = " + dbCourse.Description);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseById(course.Id);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_UpdateCourse()
        {
            // 取得資料
            Course course = CourseDao.GetCourseById("dennis_yen");
            Assert.IsNotNull(course);

            // 更新資料
            course.Name = "單元測試";
            CourseDao.UpdateCourse(course);

            // 再次取得資料
            Course dbCourse = CourseDao.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Name, dbCourse.Name);

            Console.WriteLine("課程編號為 = " + dbCourse.Id);
            Console.WriteLine("課程名稱為 = " + dbCourse.Name);
            Console.WriteLine("課程描述為 = " + dbCourse.Description);

            Console.WriteLine("================================");

            // 將資料改回來
            course.Name = "嚴志和";
            CourseDao.UpdateCourse(course);

            // 再次取得資料
            dbCourse = CourseDao.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Name, dbCourse.Name);

            Console.WriteLine("課程編號為 = " + dbCourse.Id);
            Console.WriteLine("課程名稱為 = " + dbCourse.Name);
            Console.WriteLine("課程描述為 = " + dbCourse.Description);
        }


        [TestMethod]
        public void TestCourseDao_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.Id = "UnitTests";
            newCourse.Name = "單元測試";
            newCourse.Description = 15;
            CourseDao.AddCourse(newCourse);

            Course dbCourse = CourseDao.GetCourseById(newCourse.Id);
            Assert.IsNotNull(dbCourse);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseById(newCourse.Id);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_GetCourseById()
        {
            Course course = CourseDao.GetCourseById("dennis_yen");
            Assert.IsNotNull(course);
            Console.WriteLine("課程編號為 = " + course.Id);
            Console.WriteLine("課程名稱為 = " + course.Name);
            Console.WriteLine("課程描述為 = " + course.Description);
        }

    }
}

