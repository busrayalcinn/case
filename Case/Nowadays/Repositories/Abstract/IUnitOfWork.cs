﻿using Nowadays.Models;
using Nowadays.Repositories.Abstract.Base;

namespace Nowadays.Repositories.Abstract
{
    public interface IUnitOfWork 
    {
        void CompleteTask();
        public IBaseRepository<Company> compannyRepo { get; }
        public IBaseRepository<Employee> employeeRepo { get; }
        public IBaseRepository<Issue> issueRepo { get; }
        public IBaseRepository<Project> projectRepo { get; }
        public IBaseRepository<Report> reportRepo { get; }


    }
}
