using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _db;
        // public int MyProperty { get; set; }

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }
            //for CRUD Operation

            public List<EmployeeInfo> GetEmployee()
            {
                var empList = _db.Employees.ToList();
                return empList;
            }

        //Get Employee By ID

        public EmployeeInfo GetEmployeeById(int id)
        {
            EmployeeInfo employee = _db.Employees.FirstOrDefault(s => s.EmployeeId == id);
            return employee;
        }

        // update Employee info

        public string UpdateEmployee(EmployeeInfo objEmployee)
        {

            _db.Employees.Update(objEmployee);
            _db.SaveChanges();
            return "Update Successfuly";
        }
        //Delete Employee Record

        public string DeleteEmployee(EmployeeInfo objEmployee)
        {
            //EmployeeInfo employee=_db.Employees.DefaultIfEmpty()

            _db.Remove(objEmployee);
            _db.SaveChanges();
            return "Record Deleted Successfuly";
        }

        public string Create(EmployeeInfo objEmployee)
        {
            _db.Employees.Add(objEmployee);
            _db.SaveChanges();
            return "Saved Successfuly";
        }

        }
    }

