using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }

        // Nome do departamento
        // - Obrigatório
        [Required(ErrorMessage = "{0} requeired")]
        public string Name { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            // Para cada vendedor (Seller) na coleção Sellers,
            // chama o método TotalSales(initial, final),
            // que calcula o total de vendas dele no período informado.
            // Em seguida, soma o resultado de todos os vendedores,
            // retornando o total geral de vendas no intervalo.
            return Sellers.Sum(Seller => Seller.TotalSales(initial, final));
        }
    }
}
