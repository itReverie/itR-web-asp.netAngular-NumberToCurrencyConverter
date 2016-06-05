using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyController
{


    /// <summary>
    /// Manages all the operations related to searches with money
    /// </summary>
    public class MoneyChangeController
    {

        #region Properties
        public string Error { get; set; }
        #endregion


        /// <summary>
        /// Gets all the money changes done in the past
        /// </summary>
        /// <returns>List of all the money searches</returns>
        public List<MoneyChange> GetAllMoneyChanges()
        {
            this.Error = "";
            List<MoneyChange> result = new List<MoneyChange>();
            try
            {
                MoneyChange moneySearch = new MoneyChange();
                result = moneySearch.GetAllMoneyChanges();
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Gets the money change based on a number provided and the currencies available in the db
        /// </summary>
        /// <param name="number">Number to return change in English currency</param>
        /// <returns>List of currencies and quantities used to return change stored in MoneyChange objects</returns>
        public List<MoneyChange> GetMoneyChangeFromDataBase(decimal number)
        {
            this.Error = "";
            List<MoneyChange> result = new List<MoneyChange>();
            try
            {
                //get the list of currencies from the database
                CurrencyController currencyController = new CurrencyController();
                List<Currency> currencyList = currencyController.GetAllCurrenciesFromDateBase();

                MoneyChange moneySearch = new MoneyChange();
                result = moneySearch.GetMoneyChange(number, currencyList);
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }
            return result;
        }


        /// <summary>
        /// Gets the money change based on a number provided and the currencies available in the db
        /// </summary>
        /// <param name="number">Number to return change in English currency</param>
        /// <returns>List of currencies and quantities used to return change stored in MoneyChange objects</returns>
        public List<MoneyChange> GetMoneyChange(decimal number)
        {
            this.Error = "";
            List<MoneyChange> result = new List<MoneyChange>();
            try
            {
                //get the list of currencies from the database
                CurrencyController currencyController = new CurrencyController();
                List<Currency> currencyList = currencyController.GetAllCurrenciesFromList();
                MoneyChange moneySearch = new MoneyChange();
                result = moneySearch.GetMoneyChange(number, currencyList);
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }
            return result;
        }

    }
}
