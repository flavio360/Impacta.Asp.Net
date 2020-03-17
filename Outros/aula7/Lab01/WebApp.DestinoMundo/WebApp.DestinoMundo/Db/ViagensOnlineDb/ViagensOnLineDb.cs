using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.DestinoMundo;
using System.Data.Entity;
using WebApp.DestinoMundo.Models;

namespace WebApp.DestinoMundo.Db
{
    public class ViangesOnlineDb : DbContext
    {
        private const string conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\FlavioLopes\Aula7\Lab01\WebApp.DestinoMundo\WebApp.DestinoMundo\App_Data\ViagensOnLineDb.mdf;Integrated Security=True";

        public ViangesOnlineDb()
                :base (conexao)
        { }

        public DbSet<Destino> Destinos { get; set; }

    }
}