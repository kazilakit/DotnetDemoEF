using System;
using System.Collections.Generic;
using System.Text;
using DemoCrud.Repository;
using DemoCrud.Repository.Models;

namespace DemoCrud.Service.Services
{
    public class CourseService : ICourseService
    {
        private IRepository<Course> _repo;
        public CourseService(IUnitOfWork unitOfWork)
        {
            _repo = unitOfWork.Repository<Course>();
        }
        public void Delete(long id)
        {
            _repo.Delete(id);
        }

        public Course Get(long id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<Course> Get()
        {
            return _repo.GetAll();
        }

        public void Insert(Course course)
        {
            _repo.Insert(course);
        }

        public void Update(Course course)
        {
            _repo.Update(course);
        }
    }
}
