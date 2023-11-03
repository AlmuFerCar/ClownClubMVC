namespace ClownClubMVC.Models.person
{
	public class administratorApp: person
	{
		public int id { get; set; }
		public int person_id { get; set; }
		public string permissionsAdmin { get; set; }
	}
}
