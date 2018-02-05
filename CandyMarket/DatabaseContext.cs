using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	internal class DatabaseContext
	{
		private int _countOfTaffy;
		private int _countOfCandyCoated;
		private int _countOfChocolateBar;
		private int _countOfZagnut;

		public DatabaseContext(int tone) => Console.Beep(tone, 2500);

		internal List<string> GetCandyTypes()
		{
			return Enum
				.GetNames(typeof(CandyType))
				.Select(candyType =>
					candyType.Humanize(LetterCasing.Title))
				.ToList();
		}

        internal List<string> GetUserTypes()
        {
            return Enum
                .GetNames(typeof(Users))
                .Select(users =>
                    users.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal Dictionary<string, int> CandyGroup()
        {
            var contents = new Dictionary<string, int>();
            contents.Add("Taffy", _countOfTaffy);
            contents.Add("Candy Coated", _countOfCandyCoated);
            contents.Add("Chocolate Bar", _countOfChocolateBar);
            contents.Add("Zagnut", _countOfZagnut);

            return contents;
        }

        internal void SaveNewCandy(char selectedCandyMenuOption)
		{
			var candyOption = int.Parse(selectedCandyMenuOption.ToString());
			var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
			var forRealTheCandyThisTime = (CandyType)candyOption;

			switch (forRealTheCandyThisTime)
			{
				case CandyType.TaffyNotLaffy:
					++_countOfTaffy;
					break;
				case CandyType.CandyCoated:
					++_countOfCandyCoated;
					break;
				case CandyType.CompressedSugar:
					++_countOfChocolateBar;
					break;
				case CandyType.ZagnutStyle:
					++_countOfZagnut;
					break;
				default:
					break;
			}
		}

        internal void EatCandy(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());
            var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
            var forRealTheCandyThisTime = (CandyType)candyOption;

            switch (forRealTheCandyThisTime)
            {
                case CandyType.TaffyNotLaffy:
                    --_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    --_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    --_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    --_countOfZagnut;
                    break;
                default:
                    break;
            }
        }

        internal void GoodbyeCandy(char selectedCandyMenuOption, int numberOfCandies)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());
            var forRealTheCandyThisTime = (CandyType)candyOption;

            switch (forRealTheCandyThisTime)
            {
                case CandyType.TaffyNotLaffy:
                    if(_countOfTaffy < 1)
                    {
                    break;
                    }
                    _countOfTaffy -= numberOfCandies;
                    break;
                case CandyType.CandyCoated:
                    if (_countOfCandyCoated < 1)
                    {
                        break;
                    }
                    _countOfCandyCoated -= numberOfCandies;
                    break;
                case CandyType.CompressedSugar:
                    if (_countOfChocolateBar < 1)
                    {
                        break;
                    }
                    _countOfChocolateBar -= numberOfCandies;
                    break;
                case CandyType.ZagnutStyle:
                    if (_countOfZagnut < 1)
                    {
                        break;
                    }
                    _countOfZagnut -= numberOfCandies;
                    break;
                default:
                    break;
            }
        }
    }
}