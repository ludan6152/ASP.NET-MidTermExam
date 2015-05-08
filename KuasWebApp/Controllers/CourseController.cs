using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class CourseController : ApiController
    {

        public ICourseService CourseService { get; set; }

        [HttpPost]
        public Course AddCourse(Course course)
        {
            CheckCourseIsNotNullThrowException(course);

            try
            {
                CourseService.AddCourse(course);
                return CourseService.GetCourseById(course.Id);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Course UpdateCourse(Course course)
        {
            CheckCourseIsNullThrowException(course);

            try
            {
                CourseService.UpdateCourse(course);
                return CourseService.GetCourseById(course.Id);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteCourse(Course course)
        {
            try
            {
                CourseService.DeleteCourse(course);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Course> GetAllCourses()
        {
            return CourseService.GetAllCourse();
        }

        [HttpGet]
        [ActionName("byId")]
        public Course GetCourseById(Int32 id)
        {
            var course = CourseService.GetCourseById(id);

            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return course;
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     員工資料.
        /// </param>
        private void CheckCourseIsNullThrowException(Course course)
        {
            Course dbCourse = CourseService.GetCourseById(course.Id);

            if (dbCourse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     員工資料.
        /// </param>
        private void CheckCourseIsNotNullThrowException(Course course)
        {
            Course dbCourse = CourseService.GetCourseById(course.Id);

            if (dbCourse != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }

}
