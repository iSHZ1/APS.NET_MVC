using System;
namespace Lesson4
{
	public class JSONGenerator
	{
        private static JSONGenerator _jsongenerator;

		private int[] IdArr = {1,2,3,4,5,6,7,8,9,20,55,100,1221,5603 };

		private string[] NameArr = { "", "", "", "", "", "" };
		private decimal[] PriceArr = { 500, 200, 300,450,890,490,250};

		public JSONGenerator()
		{
            //if (_jsongenerator is null)
            //    _jsongenerator = new JSONGenerator();
            //return _jsongenerator;
		}

		public JSONOzon OzonMarketGenerator()
		{
            //Id
            //name
            //price
            //httpProduct
            JSONOzon result = new JSONOzon
            {
                Id = IdArr.
            };
            result


			return " ";
		}

        public string WBMarketGenerator()
        {
            //Id
            //name
            //price
            //Наличие

            return " ";
        }

        public string YandexMarketGenerator()
        {
            //Id
            //name
            //price
            //Owner

            return " ";

        }
    }
}

