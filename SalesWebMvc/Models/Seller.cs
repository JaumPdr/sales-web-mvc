using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {

        public int Id { get; set; }

        // Nome do usuário
        // - Obrigatório
        // - Deve ter entre 3 e 60 caracteres
        [Required(ErrorMessage = "{0} requeired")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        // Email do usuário
        // - Obrigatório
        // - Deve estar em um formato válido de email
        // - Define o tipo como Email para validações e UI
        [Required(ErrorMessage = "{0} requeired")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Data de nascimento
        // - Obrigatória
        // - Exibida no formato brasileiro (dd/MM/yyyy)
        // - Tratada como data (sem horário)
        // - Define o nome exibido na interface
        [Required(ErrorMessage = "{0} requeired")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        // Salário base do usuário
        // - Obrigatório
        // - Deve estar entre 100.0 e 100000.0
        // - Exibido com duas casas decimais
        // - Define o nome exibido na interface
        [Required(ErrorMessage = "{0} requeired")]
        [Range(100.0, 100000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Base Salary")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        // Chave estrangeira do departamento
        // - Define o nome exibido na interface
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
