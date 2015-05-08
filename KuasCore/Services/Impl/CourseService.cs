﻿using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class CourseService : ICourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void AddCourse(Course course)
        {
            CourseDao.AddCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            CourseDao.UpdateCourse(course);
        }

        public void DeleteCourse(Course course)
        {
            course = CourseDao.GetCourseById(course.Id);

            if (course != null)
            {
                CourseDao.DeleteCourse(course);
            }
        }

        public IList<Course> GetAllCourse()
        {
            return CourseDao.GetAllCourse();
        }

        public Course GetCourseById(int id)
        {
            return CourseDao.GetCourseById(id);
        }

    }

}
