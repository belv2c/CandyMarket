using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	class Program
	{
		static void Main(string[] args)
		{

			var db = SetupNewApp();

			var run = true;
			while (run)
			{
				ConsoleKeyInfo userInput = MainMenu();

                int numberOfCandies = 0;
                switch (userInput.KeyChar)
				{
					case '0':
						run = false;
						break;

					case '1': 
						var selectedCandyType = AddNewCandyType(db);
						db.SaveNewCandy(selectedCandyType.KeyChar);
						break;

					case '2':
						 var selectedCandyType2 = EatNewCandyType(db);
                         db.SaveNewCandy(selectedCandyType.KeyChar);
						break;

					case '3':
                        var selectedCandyType3 = ThrowAwayCandyType(db);
                        db.SaveNewCandy(selectedCandyType.KeyChar);
						break;

					case '4':
                        var selectedCandyType4 = GiveAwayCandyType(db);
                        SelectUser(db);
                        db.GoodbyeCandy(selectedCandyType.KeyChar, numberOfCandies);
						break;

					case '5':
						/** trade candy
						 * this is the next logical step. who wants to just give away candy forever?
						 */
						break;
					default: // what about requesting candy? like a wishlist. that would be cool.
						break;
				}
			}
		}

        static void SelectUser(DatabaseContext db)
        {
            var selectedUser = TradeWithUser(db);
        }

        // CONSOLE APP SETUP
        static DatabaseContext SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";

			var cSharp = 554;
			var db = new DatabaseContext(tone: cSharp);

			Console.SetWindowSize(60, 30);
			Console.SetBufferSize(60, 30);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			return db;
		}

        // ADD OPTIONS TO MAIN MENU
        // WRITE MENU TO THE CONSOLE
        // ASSIGN READKEY TO USEROPTION VARIABLE
        // RETURN VALUE
		static ConsoleKeyInfo MainMenu()
		{
			View mainMenu = new View()
					.AddMenuOption("Did you just get some new candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Do you want to throw away candy? I guess do that here.")
                    .AddMenuOption("Do you want to give candy to someone? Give it away here.")
					.AddMenuText("Press 0 to exit.");

			Console.Write(mainMenu.GetFullMenu());
			ConsoleKeyInfo userOption = Console.ReadKey();
			return userOption;
		}

        // ADD NEW CANDY TYPE TO DATABASE CONTEXT
        // ASSIGN CANDY TYPES TO GETCANDYTYPES ENUM
        // NEW OPTION MENU WRITES TO THE CONSOLE
		static ConsoleKeyInfo AddNewCandyType(DatabaseContext db)
		{
			var candyTypes = db.GetCandyTypes();

			var newCandyMenu = new View()
					.AddMenuText("What type of candy did you get?")
					.AddMenuOptions(candyTypes);

			Console.Write(newCandyMenu.GetFullMenu());

			ConsoleKeyInfo selectedCandyType = Console.ReadKey();
			return selectedCandyType;
		}

        // EAT NEW CANDY TYPE
        static ConsoleKeyInfo EatNewCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                .AddMenuText("What type of candy do you want to eat?")
                .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        // THROW AWAY CANDY
        static ConsoleKeyInfo ThrowAwayCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                    .AddMenuText("Do you really want to throw away the candy?")
                    .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        // GIVE AWAY CANDY
        static ConsoleKeyInfo GiveAwayCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();
            var newCandyMenu = new View()
                .AddMenuText("Select the candy you want to give away.")
                .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        static ConsoleKeyInfo TradeWithUser(DatabaseContext db)
        {
            var users = db.GetUserTypes();
            var userMenu = new View()
                .AddMenuText("Select a user to trade with:")
                .AddMenuOptions(users);

            Console.Write(userMenu.GetFullMenu());
            ConsoleKeyInfo selectedUser = Console.ReadKey();
            return selectedUser;
        }
    }
}
