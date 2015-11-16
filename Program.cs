using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee()
            {
                FirstName = "Julius",
                LastName = "Bacosa",
                taxStatus = TaxStatus.Married,
                MonthlySalary = 18000,                
                NumberOfDependents = 2,                
            };

            Attendance employeeAttendance = new Attendance()
            {
                NumberOfDaysWorked = 20,
                TotalWorkingDays = 20,
                NightDifferentialNumberofHours = 0,
                NightDifferentialRate = 0,
                TotalOverTimeWorked = 0,
                OverTimeRate = 0
            };

            SalaryCalculator salary = new SalaryCalculator(employee, employeeAttendance);
            Pay pay = salary.Compute();


            Console.WriteLine("Tax Status: " + employee.taxStatus + "\t");
            Console.WriteLine("-----------------------------------------------------------\t");
            Console.WriteLine("Basic Pay: " + pay.BasicPay + "\t");
            Console.WriteLine("-----------------------------------------------------------\t");
            Console.WriteLine("Gross Pay: " + pay.GrossPay + "\t");
            Console.WriteLine("-----------------------------------------------------------\t");
            Console.WriteLine("WithHolding Tax: " + pay.WithHoldingTax + "\t");
            Console.WriteLine("SSS Contribution: " + pay.SSSContribution + "\t");
            Console.WriteLine("PhilHeal Contribution: " + pay.PhilHealthContribution + "\t");
            Console.WriteLine("Pagibig Contribution: " + pay.PagIbigContribution + "\t");
            Console.WriteLine("-----------------------------------------------------------\t");
            Console.WriteLine("Total Deduction: " + pay.TotalDeduction + "\t");
            
            Console.WriteLine("Net Pay: " + pay.NetPay + "\t");
            Console.ReadLine();
        }

       
        public class withHoldingTaxRow
        {
            public double baseSalary { get; set; }
            public double rangeSalary { get; set; }
            public double taxAmount { get; set; }
            public double excessRate { get; set; }
        }

        public class sssRow
        {
            public double FromSalaryCredit { get; set; }
            public double ToSalaryCredit { get; set; }
            public double ee { get; set; }            
        }

        public class phRow
        {
            public double baseSalary { get; set; }
            public double rangeSalary { get; set; }
            public double employeeShare { get; set; }
        }

        public class pagibigRow
        {
            public double baseSalary { get; set; }
            public double rangeSalary { get; set; }
            public double EmployeeShareRate { get; set; }
        }

        public interface IWithHoldingTaxTable
        {
            List<withHoldingTaxRow> getTable();
        }

        public class zeroWithHoldingTaxTable : IWithHoldingTaxTable
        {
            public List<withHoldingTaxRow> getTable()
            {
             
                return new List<withHoldingTaxRow>()
                {
                     new withHoldingTaxRow() { baseSalary=0, rangeSalary=0, excessRate=5, taxAmount=0  },
                     new withHoldingTaxRow() { baseSalary=833, rangeSalary=2499.99, excessRate=10, taxAmount=41.67  },
                     new withHoldingTaxRow() { baseSalary=2500, rangeSalary=5832.99, excessRate=15, taxAmount=208.33  },
                     new withHoldingTaxRow() { baseSalary=5833, rangeSalary=11666.99, excessRate=20, taxAmount=708.33  },
                     new withHoldingTaxRow() { baseSalary=11667, rangeSalary=20832.99, excessRate=25, taxAmount=1875.00  },
                     new withHoldingTaxRow() { baseSalary=20833, rangeSalary=41666.99, excessRate=30, taxAmount=4166.67  },
                     new withHoldingTaxRow() { baseSalary=41667, rangeSalary=1000000, excessRate=32, taxAmount=10416.67  },

                };
            
            }
        }

        public class smeWithHoldingTaxTable : IWithHoldingTaxTable
        {
            public List<withHoldingTaxRow> getTable()
            {

                return new List<withHoldingTaxRow>()
                {
                     new withHoldingTaxRow() { baseSalary=4167, rangeSalary=4999.99, excessRate=5, taxAmount=0  },
                     new withHoldingTaxRow() { baseSalary=5000, rangeSalary=6666.99, excessRate=10, taxAmount=41.67  },
                     new withHoldingTaxRow() { baseSalary=6667, rangeSalary=9999.99, excessRate=15, taxAmount=208.33  },
                     new withHoldingTaxRow() { baseSalary=10000, rangeSalary=15832.99, excessRate=20, taxAmount=708.33  },
                     new withHoldingTaxRow() { baseSalary=15833, rangeSalary=24999.99, excessRate=25, taxAmount=1875.00  },
                     new withHoldingTaxRow() { baseSalary=25000, rangeSalary=45832.99, excessRate=30, taxAmount=4166.67  },
                     new withHoldingTaxRow() { baseSalary=45833, rangeSalary=1000000, excessRate=32, taxAmount=10416.67  },

                };

            }
        }

        public class me1s1WithHoldingTaxTable : IWithHoldingTaxTable
        {
            public List<withHoldingTaxRow> getTable()
            {

                return new List<withHoldingTaxRow>()
                {
                     new withHoldingTaxRow() { baseSalary=6250, rangeSalary=7082.99, excessRate=5, taxAmount=0  },
                     new withHoldingTaxRow() { baseSalary=7083, rangeSalary=8749.99, excessRate=10, taxAmount=41.67  },
                     new withHoldingTaxRow() { baseSalary=8750, rangeSalary=12082.99, excessRate=15, taxAmount=208.33  },
                     new withHoldingTaxRow() { baseSalary=12083, rangeSalary=17916.99, excessRate=20, taxAmount=708.33  },
                     new withHoldingTaxRow() { baseSalary=17917, rangeSalary=27082.99, excessRate=25, taxAmount=1875.00  },
                     new withHoldingTaxRow() { baseSalary=27083, rangeSalary=47916.99, excessRate=30, taxAmount=4166.67  },
                     new withHoldingTaxRow() { baseSalary=47917, rangeSalary=1000000, excessRate=32, taxAmount=10416.67  },

                };

            }
        }

        public class me2s2WithHoldingTaxTable : IWithHoldingTaxTable
        {
            public List<withHoldingTaxRow> getTable()
            {

                return new List<withHoldingTaxRow>()
                {
                     new withHoldingTaxRow() { baseSalary=8333, rangeSalary=9166.99, excessRate=5, taxAmount=0  },
                     new withHoldingTaxRow() { baseSalary=9167, rangeSalary=10832.99, excessRate=10, taxAmount=41.67  },
                     new withHoldingTaxRow() { baseSalary=10833, rangeSalary=14166.99, excessRate=15, taxAmount=208.33  },
                     new withHoldingTaxRow() { baseSalary=14167, rangeSalary=19999.99, excessRate=20, taxAmount=708.33  },
                     new withHoldingTaxRow() { baseSalary=20000, rangeSalary=29166.99, excessRate=25, taxAmount=1875.00  },
                     new withHoldingTaxRow() { baseSalary=29167, rangeSalary=49999.99, excessRate=30, taxAmount=4166.67  },
                     new withHoldingTaxRow() { baseSalary=50000, rangeSalary=1000000, excessRate=32, taxAmount=10416.67  },

                };

            }
        }

        public class me3s3WithHoldingTaxTable : IWithHoldingTaxTable
        {
            public List<withHoldingTaxRow> getTable()
            {

                return new List<withHoldingTaxRow>()
                {
                     new withHoldingTaxRow() { baseSalary=10417, rangeSalary=11249.99, excessRate=5, taxAmount=0  },
                     new withHoldingTaxRow() { baseSalary=11250, rangeSalary=12916.99, excessRate=10, taxAmount=41.67  },
                     new withHoldingTaxRow() { baseSalary=12917, rangeSalary=16249.99, excessRate=15, taxAmount=208.33  },
                     new withHoldingTaxRow() { baseSalary=16250, rangeSalary=22082.99, excessRate=20, taxAmount=708.33  },
                     new withHoldingTaxRow() { baseSalary=22083, rangeSalary=31249.99, excessRate=25, taxAmount=1875.00  },
                     new withHoldingTaxRow() { baseSalary=31250, rangeSalary=52082.99, excessRate=30, taxAmount=4166.67  },
                     new withHoldingTaxRow() { baseSalary=52083, rangeSalary=1000000, excessRate=32, taxAmount=10416.67  },

                };

            }
        }

        public class me4s4WithHoldingTaxTable : IWithHoldingTaxTable
        {
            public List<withHoldingTaxRow> getTable()
            {

                return new List<withHoldingTaxRow>()
                {
                     new withHoldingTaxRow() { baseSalary=12500, rangeSalary=13332.99, excessRate=5, taxAmount=0  },
                     new withHoldingTaxRow() { baseSalary=13333, rangeSalary=14999.99, excessRate=10, taxAmount=41.67  },
                     new withHoldingTaxRow() { baseSalary=15000, rangeSalary=18332.99, excessRate=15, taxAmount=208.33  },
                     new withHoldingTaxRow() { baseSalary=18333, rangeSalary=24166.99, excessRate=20, taxAmount=708.33  },
                     new withHoldingTaxRow() { baseSalary=24167, rangeSalary=33332.99, excessRate=25, taxAmount=1875.00  },
                     new withHoldingTaxRow() { baseSalary=33333, rangeSalary=54166.99, excessRate=30, taxAmount=4166.67  },
                     new withHoldingTaxRow() { baseSalary=54167, rangeSalary=1000000, excessRate=32, taxAmount=10416.67  },

                };

            }
        }

        public class PagibigTable
        {
            public List<pagibigRow> getTable()
            {
                return new List<pagibigRow>()
                {
                     new pagibigRow() { baseSalary=0, rangeSalary=1499.99 , EmployeeShareRate = 1 },
                     new pagibigRow() { baseSalary=1500, rangeSalary=100000000, EmployeeShareRate= 2 }
                };
            }
        }

        public class PHTable
        {
            public List<phRow> getTable()
            {
                return new List<phRow>()
                {
                    new phRow() { baseSalary=0, rangeSalary=8999.99, employeeShare=100 },
                    new phRow() { baseSalary=9000, rangeSalary=9999.99, employeeShare=112.50 },
                    new phRow() { baseSalary=10000, rangeSalary=10999.99, employeeShare=125.00 },
                    new phRow() { baseSalary=11000, rangeSalary=11999.99, employeeShare=137.50 },
                    new phRow() { baseSalary=12000, rangeSalary=12999.99, employeeShare=150.00 },
                    new phRow() { baseSalary=13000, rangeSalary=13999.99, employeeShare=162.50 },
                    new phRow() { baseSalary=14000, rangeSalary=14999.99, employeeShare=175.00 },
                    new phRow() { baseSalary=15000, rangeSalary=15999.99, employeeShare=187.50 },
                    new phRow() { baseSalary=16000, rangeSalary=16999.99, employeeShare=200.00 },
                    new phRow() { baseSalary=17000, rangeSalary=17999.99, employeeShare=212.50 },
                    new phRow() { baseSalary=18000, rangeSalary=18999.99, employeeShare=225.00 },
                    new phRow() { baseSalary=19000, rangeSalary=19999.99, employeeShare=237.50 },
                    new phRow() { baseSalary=20000, rangeSalary=20999.99, employeeShare=250.00 },
                    new phRow() { baseSalary=21000, rangeSalary=21999.99, employeeShare=262.50 },
                    new phRow() { baseSalary=22000, rangeSalary=22999.99, employeeShare=275.00 },
                    new phRow() { baseSalary=23000, rangeSalary=23999.99, employeeShare=287.50 },
                    new phRow() { baseSalary=24000, rangeSalary=24999.99, employeeShare=300.00 },
                    new phRow() { baseSalary=25000, rangeSalary=25999.99, employeeShare=312.50 },
                    new phRow() { baseSalary=26000, rangeSalary=26999.99, employeeShare=325.00 },
                    new phRow() { baseSalary=27000, rangeSalary=27999.99, employeeShare=337.50 },
                    new phRow() { baseSalary=28000, rangeSalary=28999.99, employeeShare=350.00 },
                    new phRow() { baseSalary=29000, rangeSalary=29999.99, employeeShare=362.50 },
                    new phRow() { baseSalary=30000, rangeSalary=30999.99, employeeShare=375.00 },
                    new phRow() { baseSalary=31000, rangeSalary=31999.99, employeeShare=387.50 },
                    new phRow() { baseSalary=32000, rangeSalary=32999.99, employeeShare=400.00 },
                    new phRow() { baseSalary=33000, rangeSalary=33999.99, employeeShare=412.50 },
                    new phRow() { baseSalary=34000, rangeSalary=34999.99, employeeShare=425.00 },
                    new phRow() { baseSalary=35000, rangeSalary=1000000000, employeeShare=437.50 },
                    
                };
            }
        }

        public class SssTable
        {
           
            public List<sssRow> getTable()
            {
                return new List<sssRow>()
                {
                   new sssRow() { FromSalaryCredit=1000, ToSalaryCredit=1249.99, ee=36.30 },
                   new sssRow() { FromSalaryCredit=1250, ToSalaryCredit=1749.99, ee=54.50 },
                   new sssRow() { FromSalaryCredit=1750, ToSalaryCredit=2249.99, ee=72.70 },
                   new sssRow() { FromSalaryCredit=2250, ToSalaryCredit=2749.99, ee=90.80 },
                   new sssRow() { FromSalaryCredit=2750, ToSalaryCredit=3249.99, ee=109.00 },
                   new sssRow() { FromSalaryCredit=3250, ToSalaryCredit=3749.99, ee=127.20 },
                   new sssRow() { FromSalaryCredit=3750, ToSalaryCredit=4249.99, ee=145.30 },
                   new sssRow() { FromSalaryCredit=4250, ToSalaryCredit=4749.99, ee=163.50 },
                   new sssRow() { FromSalaryCredit=4750, ToSalaryCredit=5249.99, ee=181.70 },
                   new sssRow() { FromSalaryCredit=5250, ToSalaryCredit=5749.99, ee=199.80 },
                   new sssRow() { FromSalaryCredit=5750, ToSalaryCredit=6249.99, ee=218.00 },
                   new sssRow() { FromSalaryCredit=6250, ToSalaryCredit=6749.99, ee=236.20 },
                   new sssRow() { FromSalaryCredit=6750, ToSalaryCredit=7249.99, ee=254.30 },
                   new sssRow() { FromSalaryCredit=7250, ToSalaryCredit=7749.99, ee=272.50 },
                   new sssRow() { FromSalaryCredit=7750, ToSalaryCredit=8249.99, ee=290.70 },
                   new sssRow() { FromSalaryCredit=8250, ToSalaryCredit=8749.99, ee=308.80 },
                   new sssRow() { FromSalaryCredit=8750, ToSalaryCredit=9249.99, ee=327.00 },
                   new sssRow() { FromSalaryCredit=9250, ToSalaryCredit=9749.99, ee=345.20 },
                   new sssRow() { FromSalaryCredit=9750, ToSalaryCredit=10249.99, ee=363.30 },
                   new sssRow() { FromSalaryCredit=10250, ToSalaryCredit=10749.99, ee=381.50 },
                   new sssRow() { FromSalaryCredit=10750, ToSalaryCredit=11249.99, ee=399.70 },
                   new sssRow() { FromSalaryCredit=11250, ToSalaryCredit=11749.99, ee=417.80 },
                   new sssRow() { FromSalaryCredit=11750, ToSalaryCredit=12249.99, ee=436.00 },
                   new sssRow() { FromSalaryCredit=12250, ToSalaryCredit=12749.99, ee=454.20 },
                   new sssRow() { FromSalaryCredit=12750, ToSalaryCredit=13249.99, ee=472.30 },
                   new sssRow() { FromSalaryCredit=13250, ToSalaryCredit=13749.99, ee=490.50 },
                   new sssRow() { FromSalaryCredit=13750, ToSalaryCredit=14249.99, ee=508.70 },
                   new sssRow() { FromSalaryCredit=14250, ToSalaryCredit=14749.99, ee=526.80 },
                   new sssRow() { FromSalaryCredit=14750, ToSalaryCredit=15249.99, ee=545.00 },
                   new sssRow() { FromSalaryCredit=15250, ToSalaryCredit=15749.99, ee=563.20 },
                   new sssRow() { FromSalaryCredit=15750, ToSalaryCredit=1000000000, ee=581.30 },                   
                };

            }
        }
        

        public class SalaryCalculator
        {
            private Employee employee;
            private Attendance attendance;
           
            

            public SalaryCalculator(Employee _employee, Attendance _attendance)
            {
                employee = _employee;
                attendance = _attendance;

                
            }

            public double computeWithHoldingTax<T>(T TaxTable) where T : IWithHoldingTaxTable
            {

                double withHoldingTax = 0; 
                double taxAmount = 0;
                double excess = 0;
                double taxRate = 0;
                
                var taxRows = TaxTable.getTable();
                foreach (withHoldingTaxRow row in taxRows)
                {
                    if (row.baseSalary < employee.MonthlySalary && row.rangeSalary >= employee.MonthlySalary)
                    {
                        taxAmount = row.taxAmount;
                        excess = employee.MonthlySalary - row.baseSalary;
                        taxRate = row.excessRate / 100;

                        withHoldingTax = taxAmount + (excess * taxRate);
                    }
                }

                return withHoldingTax;
            }

            public Pay Compute()
            {

                var taxStatus = employee.taxStatus;
                
                var totalWorkingDays = attendance.TotalWorkingDays;
                var totalDaysWorked = attendance.NumberOfDaysWorked;
                var Salary = employee.MonthlySalary;

                double basicPay = (Salary / totalWorkingDays) * totalDaysWorked;

                double taxableAllowance = attendance.TaxableAllowance;
                double nonTaxableAllowance = attendance.NonTaxableAllowance;

                double nightDifferential = attendance.NightDifferentialNumberofHours;
                double overTimePay = attendance.TotalOverTimeWorked * attendance.OverTimeRate;

                double grossPay = basicPay + taxableAllowance + nonTaxableAllowance + nightDifferential + overTimePay;

                double withHoldingTax = 0; // how to compute withholding

              
                if (employee.NumberOfDependents > 0)
                {


                    if (employee.NumberOfDependents==1)
                    {
                        me1s1WithHoldingTaxTable taxTable = new me1s1WithHoldingTaxTable();
                        withHoldingTax = computeWithHoldingTax<me1s1WithHoldingTaxTable>(taxTable);
                    }
                    if (employee.NumberOfDependents == 2)
                    {
                        me2s2WithHoldingTaxTable taxTable = new me2s2WithHoldingTaxTable();
                        withHoldingTax = computeWithHoldingTax<me2s2WithHoldingTaxTable>(taxTable);
                    }
                    if (employee.NumberOfDependents == 3)
                    {
                        me3s3WithHoldingTaxTable taxTable = new me3s3WithHoldingTaxTable();
                        withHoldingTax = computeWithHoldingTax<me3s3WithHoldingTaxTable>(taxTable);
                    }
                    if (employee.NumberOfDependents >= 4)
                    {
                        me4s4WithHoldingTaxTable taxTable = new me4s4WithHoldingTaxTable();
                        withHoldingTax = computeWithHoldingTax<me4s4WithHoldingTaxTable>(taxTable);
                    }

                }
                else
                {
                    withHoldingTax = 0;
                    if (employee.taxStatus == TaxStatus.Zero)
                    {

                        zeroWithHoldingTaxTable taxTable = new zeroWithHoldingTaxTable();
                        withHoldingTax = computeWithHoldingTax<zeroWithHoldingTaxTable>(taxTable);
                        
                    }
                    else
                    {
                        smeWithHoldingTaxTable taxTable = new smeWithHoldingTaxTable();
                        withHoldingTax = computeWithHoldingTax<smeWithHoldingTaxTable>(taxTable);
                        
                    }
                    
                }


                var sssTable = new SssTable();
                var sssRows = sssTable.getTable();

                double sssContribution = 0; //how to compute sss
                foreach (sssRow row in sssRows)
                {
                    if (row.FromSalaryCredit < employee.MonthlySalary && row.ToSalaryCredit>=employee.MonthlySalary)
                    {
                        sssContribution = row.ee;
                    }
                }


                var phTable = new PHTable();
                var phRows = phTable.getTable();

                double PhilHealthContribution = 0; //how to compute philhealth
                foreach (phRow row in phRows)
                {
                    if (row.baseSalary <= employee.MonthlySalary && row.rangeSalary > employee.MonthlySalary)
                    {
                        PhilHealthContribution = row.employeeShare;
                    }
                }

                double pagIbigCOntribution = 0; //how to compute pagibig
                var pagibigTable = new PagibigTable();
                var pagibigRow = pagibigTable.getTable();

                double pagIbigShareRate = 1;
                foreach (pagibigRow row in pagibigRow)
                {
                    if (row.baseSalary < employee.MonthlySalary && row.rangeSalary >= employee.MonthlySalary)
                    {
                        pagIbigShareRate = row.EmployeeShareRate;
                    }
                }

                pagIbigCOntribution = employee.MonthlySalary * (pagIbigShareRate / 100); 
                

                var totalDeduction = withHoldingTax + sssContribution + PhilHealthContribution + pagIbigCOntribution;

                var netPay = grossPay - totalDeduction;

                Pay pay = new Pay()
                {
                    BasicPay = basicPay,
                    EmployeeName = employee.FirstName + " " + employee.LastName,
                    TaxableAllowance = taxableAllowance,
                    NonTaxableAllowance = nonTaxableAllowance,
                    NightDifferential = nightDifferential,
                    OverTimePay = overTimePay,
                    GrossPay = grossPay,
                    WithHoldingTax = withHoldingTax,
                    SSSContribution = sssContribution,
                    PhilHealthContribution = PhilHealthContribution,
                    PagIbigContribution = pagIbigCOntribution,
                    TotalDeduction = totalDeduction,
                    NetPay = netPay,
                  
                };

                return pay;
            }
        }

        public class Attendance
        {
            public int ID { get; set; }
            public double NumberOfHoursWorked { get; set; }
            public int NumberOfDaysWorked { get; set; }
            public int NightDifferentialNumberofHours { get; set; }
            public int NightDifferentialRate { get; set; }
            public int TotalOverTimeWorked { get; set; }
            public int OverTimeRate { get; set; }

            public double TaxableAllowance { get; set; }
            public double NonTaxableAllowance { get; set; }

            public int TotalWorkingDays { get; set; }
        }

        public enum TaxStatus
        {
            Zero, Single, Married
        }

        public class Employee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            
            public int NumberOfDependents { get; set; }
            public TaxStatus taxStatus { get; set; }
            public double MonthlySalary { get; set; }
            public double SemiMonthlySalary { get { return MonthlySalary / 2; } }
          
            
        }

        public class Pay
        {
            
            public int ID { get; set; }
            public string EmployeeName { get; set; }
            public double BasicPay { get; set; }
            public double TaxableAllowance { get; set; }
            public double NonTaxableAllowance { get; set; }
            public double NightDifferential { get; set; }
            public double OverTimePay { get; set; }
            public double GrossPay { get; set; }
            public double WithHoldingTax { get; set; }
            public double SSSContribution { get; set; }
            public double PhilHealthContribution { get; set; }
            public double PagIbigContribution { get; set; }
            public double TotalDeduction { get; set; }
            public double NetPay { get; set; }
            public DateTime Created { get; set; }
        }
    }
}
