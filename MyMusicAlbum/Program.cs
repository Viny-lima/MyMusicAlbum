using MyMusicAlbum.Models;
using MyMusicAlbum.Models.Beans;
using MyMusicAlbum.Models.Enums;
using MyMusicAlbum.Models.Repositorys;
using System;

namespace MyMusicAlbum
{
    internal class Program
    {       
		static RepositoryMusic repository = new RepositoryMusic();

		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ReadAllMusic();
						break;
					case "2":
						CreateMusic();
						break;
					case "3":
						UpdateMusic();
						break;
					case "4":
						DeleteMusic();
						break;
					case "5":
						ReadMusic();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void DeleteMusic()
		{
			Console.Write("Digite o id da música: ");
			int idMusic = int.Parse(Console.ReadLine());

			repository.Delete(idMusic);
		}

		private static void ReadMusic()
		{
			Console.Write("Digite o id da música: ");
			int IdMusic = int.Parse(Console.ReadLine());

			var music = repository.Read(IdMusic);

			Console.WriteLine(music);
		}

		private static void UpdateMusic()
		{
			Console.Write("Digite o id da música: ");
			int idMusic = int.Parse(Console.ReadLine());
			
			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int genre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da Música: ");
			string name = Console.ReadLine();

			Console.Write("Digite o Ano da Música: ");
			int releaseYear = int.Parse(Console.ReadLine());

			Console.Write("Digite o Cantor da Música: ");
			string singer = Console.ReadLine();

			var music = new Music(  id: idMusic,
									genre: (Genre)genre,
									name: name,
									singer: singer,
									releaseYear: releaseYear) ;

			repository.Update(music);
		}

		private static void ReadAllMusic()
		{
			Console.WriteLine("Listar Músicas");

			var list = repository.ReadAll();

			if (list.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var music in list)
			{
				var excluido = music.Actived;

                if (music.Actived)
                {
					Console.WriteLine(music);
				}
				
			}
		}

		private static void CreateMusic()
		{
			Console.WriteLine("Inserir nova música");

			
			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int genre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da Música: ");
			string name = Console.ReadLine();

			Console.Write("Digite o Ano da Música: ");
			int releaseYear = int.Parse(Console.ReadLine());

			Console.Write("Digite o Cantor da Música: ");
			string singer = Console.ReadLine();

			var music = new Music(  id: repository.NextId(),
									genre: (Genre)genre,
									name: name,
									singer: singer,
									releaseYear: releaseYear);

			repository.Create(music);
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("MyMusicAlbum a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Músicas");
			Console.WriteLine("2- Inserir nova Música");
			Console.WriteLine("3- Atualizar música");
			Console.WriteLine("4- Excluir música");
			Console.WriteLine("5- Visualizar música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper().Trim();
			Console.WriteLine();

			return opcaoUsuario;
		}
	}
}
