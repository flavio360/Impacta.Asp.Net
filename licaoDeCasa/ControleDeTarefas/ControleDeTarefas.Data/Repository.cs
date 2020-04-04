using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleDeTarefas.Model;

namespace ControleDeTarefas.Data
{
    public static class Repository
    {
		//porpfull
		private static string conexao = @"Data Source=nflopes\sqlexpress;
                                    Initial Catalog=pubs;
                                    Integrated Security=True";

		public static string Conexao
		{
			get { return conexao; }
		}

		//
		// Incluir
		//
		public static int Incluir(Tarefas objTarefa)
		{

			string sql = @"INSERT INTO Tarefas
						(Nome,Prioridade, Concluida, Obs)
						VALUES (@Nome, @Prioridade, @Concluida, @Observacoes);
						SELECT @@IDENTITY";


			int novoId = 0;


			// é uma boa pratica utilizar o using, pois apos a utilizacao do banco de dados
			// e a execucao encerrar o escopo do using, é garantido pelo using que
			// sua conexao com banco de dados sera encerrada
			// outra forma seria utilizar o bloco FINALLY do bloco try catch para encerrar
			// a conexao com banco de dados

			using (var cn = new SqlConnection(Repository.Conexao))
			{
				var cmd = new SqlCommand(sql, cn);

				cmd.Parameters.AddWithValue("@Nome", objTarefa.Nome);
				cmd.Parameters.AddWithValue("@Prioridade", objTarefa.Prioridade);
				cmd.Parameters.AddWithValue("@Concluida", objTarefa.Concluida);
				cmd.Parameters.AddWithValue("@Observacoes", objTarefa.Obs);

				//abre conexão com o DB
				cn.Open();

				//diferente do executenonquery ele retorna a quantidade de inclusoões , mas retorna a primeira coluna da tabela.
				novoId = Convert.ToInt32(cmd.ExecuteScalar());
			}
			return novoId;
		}

		public static List<Tarefas> ObterTodasTarefas()
		{
			var lista = new List<Tarefas>();
			string sql =
			@"SELECT Id,Nome,Prioridade,Concluida, Obs FROM Tarefas ORDER BY Concluida,Prioridade";

			using (var cn = new SqlConnection(Conexao))
			{
				using (var cmd = new SqlCommand(sql, cn))
				{
					cn.Open();
					using (var dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							var tarefa = new Tarefas();
							tarefa.Id = Convert.ToInt32(dr["Id"]);
							tarefa.Nome = Convert.ToString(dr["Nome"].ToString());
							tarefa.Prioridade = Convert.ToInt32(dr["Prioridade"]);
							tarefa.Concluida = Convert.ToBoolean(dr["Concluida"]);
							tarefa.Obs = Convert.ToString(dr["Obs"]);
							lista.Add(tarefa);
						}
					}
				}

			}

			return lista;
		}

		public static bool AtualizarTarefa(Tarefas tarefa)
		{
			string sql = @"UPDATE Tarefas	SET Nome=@Nome,Prioridade=@Prioridade, Concluida=@Concluida, Obs=@Obs WHERE Id=@Cod";
			bool retorno = false;

			using (var cn = new SqlConnection(Repository.Conexao))
			{
				var cmd = new SqlCommand(sql, cn);

				cmd.Parameters.AddWithValue("@Cod", tarefa.Id);
				cmd.Parameters.AddWithValue("@Nome", tarefa.Nome);
				cmd.Parameters.AddWithValue("@Prioridade", tarefa.Prioridade);
				cmd.Parameters.AddWithValue("@Concluida", tarefa.Concluida);
				cmd.Parameters.AddWithValue("@Obs", tarefa.Obs);

				//abre conexão com o DB
				cn.Open();

				retorno = cmd.ExecuteNonQuery() > 0 ? true : false;
			}
			return retorno;

		}

		public static Tarefas ObterTarefa(int id)
		{
			//vamos criar o modelo para retornalo
			Tarefas tarefaMOD = new Tarefas();
			string sql = @"SELECT * FROM TAREFAS WHERE ID = @Id";

			using (var cn = new SqlConnection(Conexao))
			{
				using (var cmd = new SqlCommand(sql, cn))
				{
					cmd.Parameters.AddWithValue("@Id", id);

					cn.Open();

					using (var dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							tarefaMOD.Id = Convert.ToInt32(dr["Id"]);
							tarefaMOD.Nome = Convert.ToString(dr["Nome"].ToString());
							tarefaMOD.Prioridade = Convert.ToInt32(dr["Prioridade"]);
							tarefaMOD.Concluida = Convert.ToBoolean(dr["Concluida"]);
							tarefaMOD.Obs = Convert.ToString(dr["Obs"]);
						}
					}
				}
			}

			return tarefaMOD;
		}
	}
}
