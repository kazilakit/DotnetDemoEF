using DemoCrud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCrud.Service.Services
{
    public interface ICourseService
    {
        void Insert(Course course);
        void Update(Course course);
        void Delete(long id);
        Course Get(long id);
        IEnumerable<Course> Get();
    }
}
