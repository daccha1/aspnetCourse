using DependencyInjectionTest.Models;

namespace DependencyInjectionTest.Contracts
{
	public interface IMehanicarContract
	{
		public string Index();
		public List<string> GetMehanicars();
		public void DodajMehanicara();
		public string PrikaziMehanicara(int id);
	}
}
