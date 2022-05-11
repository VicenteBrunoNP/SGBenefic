using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGBenefic.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Beneficit> Beneficities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Beneficit>()
                .HasData(new List<Beneficit>(){
                    new Beneficit(1,"71.096.708/0001-36","Martin e Emily Comercio de Bebidas ME","1","1","Benefício 1","1",DateTime.Now.AddDays(-1),0),
                    new Beneficit(2,"30.531.043/0001-64","Andrea e Levi Lavanderia ME","2","1","Benefício 1","1",DateTime.Now,0),
                    new Beneficit(3,"69.790.315/0001-86","Kauê e Rodrigo Telas Ltda","2","2","Benefício 2","1",DateTime.Now.AddDays(-2),1),
                    new Beneficit(4,"65.529.487/0001-40","Gustavo e Manoel Ferragens Ltda","2","2","Benefício 2","1",DateTime.Now.AddDays(-3),1),
                    new Beneficit(5,"53.512.884/0001-20","Emanuelly e Kauê Locações de Automóveis Ltda","1","3","Benefício 3","1",DateTime.Now.AddDays(-5),0),
                    new Beneficit(6,"92.591.075/0001-02","Juliana e Agatha Eletrônica ME","2","3","Benefício 3","1",DateTime.Now.AddDays(-1),0),
                    new Beneficit(7,"94.135.435/0001-97","Eloá e Fábio Filmagens Ltda","1","4","Benefício 4","1",DateTime.Now.AddDays(-1),0),
                    new Beneficit(8,"20.479.947/0001-34","Cecília e Calebe Advocacia ME","1","1","Benefício 1","1",DateTime.Now,1),
                    new Beneficit(9,"46.015.455/0001-81","Marlene e Letícia Assessoria Jurídica Ltda","2","5","Benefício 5","1",DateTime.Now.AddDays(-6),0),
                    new Beneficit(10,"95.985.809/0001-26","Sara e Sara Pães e Doces Ltda","2","1","Benefício 1","1",DateTime.Now.AddDays(-1),0),
                });
        }

    }
}
