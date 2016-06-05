
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyController
{
    /// <summary>
    /// Manages all operations related to money
    /// </summary>
    public class CurrencyController
    {

        /// <summary>
        /// Gets the list of all currencies available in ascending order.
        /// </summary>
        /// <returns>List of currencies in ascending order.</returns>
        public List<Currency> GetAllCurrenciesFromDateBase()
        {
            Currency money = new Currency();
            return money.GetAllCurrencies();
        }

        /// <summary>
        /// Gets the list of all currencies available in ascending order.
        /// </summary>
        /// <returns>List of currencies in ascending order.</returns>
        public List<Currency> GetAllCurrenciesFromList()
        {
            //todo: pass the currency list in a text file, no in code
            List<Currency> currencyList = new List<Currency>();
            
            Currency currency1 = new Currency();
            currency1.CurrencyId = 1;
            currency1.CurrencyValue = Convert.ToDecimal(50.0);
            currency1.CurrencyType = "bill";
            currencyList.Add(currency1);
            Currency currency2 = new Currency();
            currency2.CurrencyId = 2;
            currency2.CurrencyValue = Convert.ToDecimal(20.0);
            currency2.CurrencyType = "bill";
            currencyList.Add(currency2);
            Currency currency3 = new Currency();
            currency3.CurrencyId = 3;
            currency3.CurrencyValue = Convert.ToDecimal(10.0);
            currency3.CurrencyType = "bill";
            currencyList.Add(currency3);
            Currency currency4 = new Currency();
            currency4.CurrencyId = 4;
            currency4.CurrencyValue = Convert.ToDecimal(5.0);
            currency4.CurrencyType = "bill";
            currencyList.Add(currency4);
            Currency currency5 = new Currency();
            currency5.CurrencyId = 5;
            currency5.CurrencyValue = Convert.ToDecimal(2.0);
            currency5.CurrencyType = "coin";
            currencyList.Add(currency5);
            Currency currency6 = new Currency();
            currency6.CurrencyId = 6;
            currency6.CurrencyValue = Convert.ToDecimal(1.0);
            currency6.CurrencyType = "coin";
            currencyList.Add(currency6);
            Currency currency7 = new Currency();
            currency7.CurrencyId = 7;
            currency7.CurrencyValue = Convert.ToDecimal(0.5);
            currency7.CurrencyType = "coin";
            currencyList.Add(currency7);
            Currency currency8 = new Currency();
            currency8.CurrencyId = 8;
            currency8.CurrencyValue = Convert.ToDecimal(0.2);
            currency8.CurrencyType = "coin";
            currencyList.Add(currency8);
            Currency currency9 = new Currency();
            currency9.CurrencyId = 9;
            currency9.CurrencyValue = Convert.ToDecimal(0.1);
            currency9.CurrencyType = "coin";
            currencyList.Add(currency9);
            Currency currency10 = new Currency();
            currency10.CurrencyId = 10;
            currency10.CurrencyValue = Convert.ToDecimal(0.05);
            currency10.CurrencyType = "coin";
            currencyList.Add(currency10);
            Currency currency11 = new Currency();
            currency11.CurrencyId = 11;
            currency11.CurrencyValue = Convert.ToDecimal(0.02);
            currency11.CurrencyType = "coin";
            currencyList.Add(currency11);
            Currency currency12 = new Currency();
            currency12.CurrencyId = 12;
            currency12.CurrencyValue = Convert.ToDecimal(0.01);
            currency12.CurrencyType = "coin";
            currencyList.Add(currency12);

            return currencyList;
        }


    }
}
