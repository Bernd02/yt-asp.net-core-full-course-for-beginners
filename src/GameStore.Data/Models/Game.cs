namespace GameStore.Data.Models;

public class Game(
	int Id,
	string Name,
	string Genre,
	decimal Price,
	DateOnly ReleaseDate)
{
	public int Id { get; set; } = Id;
	public string Name { get; set; } = Name;
	public string Genre { get; set; } = Genre;
	public decimal Price { get; set; } = Price;
	public DateOnly ReleaseDate { get; set; } = ReleaseDate;
}
