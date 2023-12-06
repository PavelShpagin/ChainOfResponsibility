using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace Chain.RealWorld
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Account account = new Account();
			Handler usernameHandler = new UsernameHandler();
			Handler passwordHandler = new PasswordHandler();
			Handler countryHandler = new CountryHandler();
			Handler birthdayHandler = new BirthdayHandler();
			usernameHandler.NextHandler = passwordHandler;
			passwordHandler.NextHandler = countryHandler;
			countryHandler.NextHandler = birthdayHandler;
			usernameHandler.ProcessRequest(account);
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

	public class Handler
	{
		public Handler? NextHandler { get; set; }
		public virtual void ProcessRequest(Account account) 
		{
			if (NextHandler == null)
			{
				Console.WriteLine("Registration is done!");
			}
			else
			{
				NextHandler.ProcessRequest(account);
			}
		}
	}

	public class UsernameHandler : Handler
	{
		public override void ProcessRequest(Account account)
		{
			Console.WriteLine("Enter username or space to quit:");
			string username = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(username))
			{
				Console.WriteLine("Program quitted!");
			}
			else 
			{
				account.Username = username;
				base.ProcessRequest(account);
			}
		}
	}

	public class PasswordHandler : Handler
	{
		public override void ProcessRequest(Account account)
		{
			Console.WriteLine("Enter password or space to quit:");
			string password = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(password))
			{
				Console.WriteLine("Program quitted!");
			}
			else
			{
				account.Password = password;
				base.ProcessRequest(account);
			}
		}
	}
	public class CountryHandler : Handler
	{
		public override void ProcessRequest(Account account)
		{
			Console.WriteLine("Enter your country or space to quit:");
			string country = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(country))
			{
				Console.WriteLine("Program quitted!");
			}
			else
			{
				account.Country = country;
				base.ProcessRequest(account);
			}
		}
	}

	public class BirthdayHandler : Handler
	{
		public override void ProcessRequest(Account account)
		{
			while (account.Birthday == null) 
			{
				Console.WriteLine("Enter your birthday or space to quit:");
				string birthday = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(birthday))
				{
					Console.WriteLine("Program quitted!");
					return;
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
			base.ProcessRequest(account);
		}
	}
}