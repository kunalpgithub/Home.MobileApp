using System;
using System.Collections.Generic;
using System.Text;
//http://www.zankavtaskin.com/2013/09/applied-domain-driven-design-ddd-part-1.html
namespace Home.AppCore.Entities
{
    public class Employer
    {
        public int EmployerId { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }

        public void AddEmployee(Employee employee) {
            employee.Add();
        }

        public void JobStarted(Employee employee) {
            employee.SetStartDate();
        }

        public void JobEnded(Employee employee) {
            employee.SetEndDate();
        }

        public void LogAttendance(Employee employee,bool IsPresent) {
            employee.AddAttendance(IsPresent);
        }
    }

    public class Employee
    {
        public int EmployeeId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public string JobTitle { get; protected set; }
        public EmployeeRate Rate { get; protected set; }
        private List<EmployeeAttendance> _attendance;
        public IReadOnlyCollection<EmployeeAttendance> Attendance => _attendance;
        private List<EmployeeLeave> _leave;
        private IReadOnlyCollection<EmployeeLeave> Leave => _leave;
        private List<EmployeePayment> _payment;
        public IReadOnlyCollection<EmployeePayment> Payment => _payment;
        internal void Add() {
        }

        internal void SetStartDate() {
        }

        internal void SetEndDate() {
        }

        internal void AddAttendance(bool IsPresent) {
            if (IsPresent)
            {
                if (_attendance == null)
                {
                    _attendance = new List<EmployeeAttendance>();
                }
                _attendance.Add(new EmployeeAttendance(DateTime.Now));
            }
            else {
                if (_leave == null)
                {
                    _leave = new List<EmployeeLeave>();
                }
                LeaveType leave = LeaveType.NotWorkingDay;//todo:add logic to check leave type.
                _leave.Add(new EmployeeLeave(leave));
            }
        }

        //internal double CalculateSalary() {
        //    switch (Rate.Rate)
        //    {
        //        case RateType.Daily:
        //            return Rate.Amount* DaysToPay();
        //        case RateType.Monthly:
        //            return Rate.Amount * DaysToPay();
        //        case RateType.Yearly:
        //            return Rate.Amount * DaysToPay();
        //        default:
        //            return Rate.Amount * DaysToPay();
        //    } 
        //}

        //internal DateTime GetLastPaidDate() {
        //    if (Payment !=  null)
        //    {
        //        return Payment[Payment.Count - 1].LastPaidDate;
        //    }
        //    return StartDate;
        //}
    }

    public class EmployeeRate {
        public int EmployeeRateId { get; protected set; }
        public RateType Rate { get; protected set; }
        public double Amount { get; protected set; }
    }

    public class EmployeeAttendance {
        public int EmployeeAttendanceId { get; protected set; }
        public EmployeeAttendance(DateTime Date) {
            this.Date = Date;
        }

        public DateTime Date { get; protected set; }   
    }

    public class EmployeeLeave {
        public int EmployeeLeaveId { get; protected set; }
        public EmployeeLeave(LeaveType leave) {
            this.Leave = leave;
        }
        public LeaveType Leave { get; protected set; }
    }

    public class EmployeePayment {
        public int EmployeePaymentId { get; protected set; }
        public EmployeePayment() { }
        public DateTime LastPaidDate { get;protected set; }
    }

    public enum LeaveType {
        NotWorkingDay,
        Holiday,
        Festival
    }

    public enum RateType {
        Yearly,
        Monthly,
        Daily
    }
}
