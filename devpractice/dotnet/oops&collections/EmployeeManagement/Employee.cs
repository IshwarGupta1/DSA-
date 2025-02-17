namespace EmployeeManagement
{
    public abstract class Employee
    {
        private string _name;
        private int _empId;
        public Employee(string name, int empId)
        {
            _name = name;
            _empId = empId;
        }

        public abstract void workToDo();
    }
}
