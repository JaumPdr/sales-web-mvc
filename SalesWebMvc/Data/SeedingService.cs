using System;
using System.Linq;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Popular a base de Dados
        public void Seed()
        {
            //Testa se existe algum registro nas tabela (Usando Linq)
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //DB ja foi populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "João Pedro", "joao@gmail.com", new DateTime(2002, 11, 5), 3000.0, d1);
            Seller s2 = new Seller(2, "emily Beatriz", "emily@gmail.com", new DateTime(2004, 5, 27), 4000.0, d3);
            Seller s3 = new Seller(3, "Alex Gray", "alex@gmail.com", new DateTime(1998, 6, 11), 2500.0, d4);
            Seller s4 = new Seller(4, "Maria Eugenia", "maria@gmail.com", new DateTime(1975, 2, 3), 6000.0, d2);
            Seller s5 = new Seller(5, "Eduardo Rogerio", "eduardo@gmail.com", new DateTime(2000, 10, 19), 1900.0, d1);
            Seller s6 = new Seller(6, "Jorge Aparecido", "jorge@gmail.com", new DateTime(1990, 4, 24), 4500.0, d2);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 9, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 9, 4), 7000.0, SaleStatus.Billed, s5);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018, 9, 13), 4000.0, SaleStatus.Canceled, s4);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2018, 9, 1), 8000.0, SaleStatus.Billed, s1);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2018, 9, 21), 3000.0, SaleStatus.Billed, s3);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2018, 9, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2018, 9, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2018, 9, 11), 4000.0, SaleStatus.Billed, s4);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2018, 9, 14), 11000.0, SaleStatus.Pending, s6);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2018, 9, 7), 9000.0, SaleStatus.Billed, s6);
            SalesRecord sr11 = new SalesRecord(11, new DateTime(2018, 9, 13), 6000.0, SaleStatus.Billed, s2);
            SalesRecord sr12 = new SalesRecord(12, new DateTime(2018, 9, 25), 7000.0, SaleStatus.Pending, s3);
            SalesRecord sr13 = new SalesRecord(13, new DateTime(2018, 9, 29), 10000.0, SaleStatus.Billed, s4);
            SalesRecord sr14 = new SalesRecord(14, new DateTime(2018, 9, 4), 3000.0, SaleStatus.Billed, s1);
            SalesRecord sr15 = new SalesRecord(15, new DateTime(2018, 9, 12), 4000.0, SaleStatus.Billed, s5);
            SalesRecord sr16 = new SalesRecord(16, new DateTime(2018, 9, 5), 2000.0, SaleStatus.Billed, s4);
            SalesRecord sr17 = new SalesRecord(17, new DateTime(2018, 9, 1), 12000.0, SaleStatus.Billed, s1);
            SalesRecord sr18 = new SalesRecord(18, new DateTime(2018, 9, 24), 6000.0, SaleStatus.Billed, s3);
            SalesRecord sr19 = new SalesRecord(19, new DateTime(2018, 9, 22), 8000.0, SaleStatus.Billed, s5);
            SalesRecord sr20 = new SalesRecord(20, new DateTime(2018, 9, 15), 9000.0, SaleStatus.Canceled, s2);
            SalesRecord sr21 = new SalesRecord(21, new DateTime(2018, 9, 17), 4000.0, SaleStatus.Billed, s6);
            SalesRecord sr22 = new SalesRecord(22, new DateTime(2018, 9, 3), 11000.0, SaleStatus.Billed, s2);
            SalesRecord sr23 = new SalesRecord(23, new DateTime(2018, 9, 26), 7000.0, SaleStatus.Pending, s3);
            SalesRecord sr24 = new SalesRecord(24, new DateTime(2018, 9, 8), 5000.0, SaleStatus.Billed, s4);
            SalesRecord sr25 = new SalesRecord(25, new DateTime(2018, 9, 10), 3000.0, SaleStatus.Billed, s1);
            SalesRecord sr26 = new SalesRecord(26, new DateTime(2018, 9, 19), 6000.0, SaleStatus.Billed, s5);
            SalesRecord sr27 = new SalesRecord(27, new DateTime(2018, 9, 20), 8000.0, SaleStatus.Billed, s6);
            SalesRecord sr28 = new SalesRecord(28, new DateTime(2018, 9, 27), 2000.0, SaleStatus.Billed, s2);
            SalesRecord sr29 = new SalesRecord(29, new DateTime(2018, 9, 30), 9000.0, SaleStatus.Billed, s3);
            SalesRecord sr30 = new SalesRecord(30, new DateTime(2018, 9, 18), 10000.0, SaleStatus.Billed, s4);

            //Adiciona os Departments no DB
            _context.Department.AddRange(d1, d2, d3, d4);

            //Adiciona os Sellers no DB
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            //Adiciona os SalesRecords no DB
            _context.SalesRecord.AddRange(
                sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10,
                sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20,
                sr21, sr22, sr23, sr24, sr25, sr26, sr27, sr28, sr29, sr30 
             );

            //Salva as alterações no DB
            _context.SaveChanges();

        }

    }
}
