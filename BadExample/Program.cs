using System;

namespace NoChain.RealWorld
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Account account = new Account();

			Console.WriteLine("Enter username or space to quit:");
			string username = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(username))
			{
				Console.WriteLine("Program quitted!");
			}
			else
			{
				account.Username = username;

				Console.WriteLine("Enter password or space to quit:");
				string password = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(password))
				{
					Console.WriteLine("Program quitted!");
				}
				else
				{
					account.Password = password;

					Console.WriteLine("Enter your country or space to quit:");
					string country = Console.ReadLine();
					if (string.IsNullOrWhiteSpace(country))
					{
						Console.WriteLine("Program quitted!");
					}
					else
					{
						account.Country = country;

						while (account.Birthday == null)
						{
							Console.WriteLine("Enter your birthday or space to quit:");
							string birthday = Console.ReadLine();
							if (string.IsNullOrWhiteSpace(birthday))
							{
								Console.WriteLine("Program quitted!");
							}
							else
							{
								if (int.TryParse(birthday, out int birthdayInt))
								{
									if (birthdayInt <= 0)
									{
										Console.WriteLine("Non-positive input!");
									}
									else
									{
										account.Birthday = birthdayInt;
									}
								}
								else
								{
									Console.WriteLine("Invalid input!");
								}
							}
						}

						Console.WriteLine("Registration is done!");
					}
				}
			}

			Console.ReadKey();
		}
	}

	public class Account
	{
		public string? Username { get; set; }
		public string? Password { get; set; }
		public string? Country { get; set; }
		public int? Birthday { get; set; }
	}
}