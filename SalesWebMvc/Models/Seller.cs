using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define o formato de exibição da data no padrão brasileiro (dia/mês/ano)
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        // Especifica que o campo deve ser tratado como um tipo de dado Data (sem horário)
        [DataType(DataType.Date)]
        // Define o nome que será exibido na interface (label do campo)
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Base Salary")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Departments")]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            // Filtra as vendas (Sales) considerando apenas aquelas
            // cuja data (Date) esteja entre a data inicial (initial)
            // e a data final (final). Em seguida, soma o valor (Amount)
            // de todas essas vendas filtradas.
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }


    }
}
