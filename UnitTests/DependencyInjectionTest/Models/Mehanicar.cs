namespace DependencyInjectionTest.Models
{
	public class Mehanicar
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Struka { get; set; }

		public List<Mehanicar> Mehanicars;



		public override string ToString()
		{
			return "Mehanicar ID: " + Id + ", mehanicar ime: " + Name + ", mehanicar struka: " + Struka;
		}

	}
}
