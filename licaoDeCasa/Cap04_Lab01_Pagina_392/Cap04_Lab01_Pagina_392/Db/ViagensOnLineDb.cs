using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cap04_Lab01_Pagina_392;
using Cap04_Lab01_Pagina_392.Models;

namespace Cap04_Lab01_Pagina_392.Db
{ 
    public class ViagensOnLineDb:DbContext
    {
        private const string conexao =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
            C:\FlavioLopes\Aula8\Impacta.Asp.Net\licaoDeCasa\Cap04_Lab01_Pagina_392\Cap04_Lab01_Pagina_392\App_Data\ViagensOnLineDb.mdf;
            Integrated Security=True";

       // C:\Users\flavio\Dropbox\20200306\Cap04_Lab01_Pagina_392\Cap04_Lab01_Pagina_392\App_Data\ViagensOnLineDb.mdf;
            

        public ViagensOnLineDb()
        : base(conexao)
        { }

        public DbSet<Destino> Destinos { get; set; }
    }
}
