using DependencyInjectionTest.Contracts;
using DependencyInjectionTest.Models;
using System.Runtime.CompilerServices;

namespace DependencyInjectionTest.Services
{
	public class MehanicarService : IMehanicarContract
	{
		public List<Mehanicar> mehanicari = new List<Mehanicar>();

		public MehanicarService()
		{
			Mehanicar m1 = new Mehanicar();
			Mehanicar m2 = new Mehanicar();
			Mehanicar m3 = new Mehanicar();
			
			m1.Id = 1;
			m1.Name = "Petar";
			m1.Struka = "Elektricar";

			m2.Id = 2;
			m2.Name = "Malisa";
			m2.Struka = "Autoelektricar";

			m3.Id = 3;
			m3.Name = "Mića";
			m3.Struka = "Serviser kamiona";

			mehanicari.Add(m1);
			mehanicari.Add(m2);
			mehanicari.Add(m3);
			//mehanicari.Add(new Mehanicar { Id = 1, Name = "Petar", Struka = "Elektricar" });
			//mehanicari.Add(new Mehanicar { Id = 2, Name = "Mirko", Struka = "Neovlasceni" });
		}

		public void DodajMehanicara()
		{
			Mehanicar mehanicar = new Mehanicar();
			Console.WriteLine("Unesite ID: ");
			int id = int.Parse(Console.ReadLine());
			Console.WriteLine("Unesite ime: ");
			string name = Console.ReadLine();
			Console.WriteLine("Unesite struku: ");
			string struka = Console.ReadLine();
			mehanicar.Id = id;
			mehanicar.Name = name;
			mehanicar.Struka = struka;
			mehanicari.Add(mehanicar);
		}

		public List<string> GetMehanicars()
		{
			List<string> mehanicariString = new List<string>();
			string mehanicarString = "";
			foreach(var m in mehanicari)
			{
				mehanicarString = m.ToString();
				mehanicariString.Add(mehanicarString);
			}
			return mehanicariString;

		}

		public string Index()
		{
			return "Dobrodosli u aplikaciju za pregled mehanicara";
		}

		public string PrikaziMehanicara(int id)
		{
			foreach(var m in mehanicari)
			{
				if(m.Id == id)
				{
					return m.ToString();
				}
			}
			return "Nije pronadjen majstor sa tim ID-em";
		}
	}
}
