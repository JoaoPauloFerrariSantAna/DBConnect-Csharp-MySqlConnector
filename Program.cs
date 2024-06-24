using MySqlConnector;
using Database.Connect;

namespace Program;

public class Program {
	public static void Main(string[] args) {
		var builder = new MySqlConnectionStringBuilder {
			Server = "localhost",
			UserID = "root",
			Password = "ghostlyTr1nk37",
			Database = "cs_db",
		};

		// open a connection asynchronously
		using var connection = new MySqlConnection(builder.ConnectionString);
		connection.Open();

		// create a DB command and set the SQL statement with parameters
		using var command = connection.CreateCommand();
		command.CommandText = @"SELECT * FROM Dal;";

		// execute the command and read the results
		using var reader = command.ExecuteReader();
		while (reader.Read()) {
			var id = reader.GetValue(0);
			var carro = reader.GetValue(1);

			Console.WriteLine(carro);
		}
	}
}
