using DemoCrud.Repository;
using DemoCrud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCrud.Service.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Student> _repo;
        public StudentService(IUnitOfWork unitOfWork)
        {
            //_repo = repo;
            
            _repo = unitOfWork.Repository<Student>();
            _unitOfWork = unitOfWork;
        }

        public void Delete(long id)
        {
            
            _repo.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public Student Get(long id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<Student> Get()
        {
            return _repo.GetAll();
        }

        public void Insert(Student student)
        {
            _repo.Insert(student);
            _unitOfWork.SaveChanges();
        }

        public void Update(Student student)
        {
            _repo.Update(student);
            _unitOfWork.SaveChanges();
        }
    }
}
