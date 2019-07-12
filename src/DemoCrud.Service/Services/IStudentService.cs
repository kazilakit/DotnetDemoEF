using DemoCrud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCrud.Service.Services
{
    public interface IStudentService
    {
        void Insert(Student student);
        void Update(Student student);
        void Delete(long id);
        Student Get(long id);
        IEnumerable<Student> Get();
    }
}
