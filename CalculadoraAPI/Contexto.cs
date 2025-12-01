using CalculadoraAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalculadoraAPI
{
    public class Contexto : DbContext
    {


        public Contexto() : base("name=DefaultConnection") { }

        public DbSet<OperacionesLog> OperacionesLog { get; set; }



    }
}