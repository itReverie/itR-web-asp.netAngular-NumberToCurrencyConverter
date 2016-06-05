using MoneyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyController
{
    public class Currency
    {

        #region Variables
        MoneyModel model = null;
        #endregion

        #region Properties
        public long CurrencyId { get; set; }
        public decimal CurrencyValue { get; set; }
        public string CurrencyType { get; set; }
        #endregion

        #region Constructor
        public Currency()
        {

        }
        #endregion

        public List<Currency> GetAllCurrencies()
        {
            List<Currency> listCurrencies = new List<Currency>();

            model = new MoneyModel();
            foreach (MoneyEntities.Money dbCurrency in model.Money.ToList())
            {
                Currency currency = new Currency();
                currency.CurrencyId = dbCurrency.CurrencyId;
                currency.CurrencyValue = Convert.ToDecimal(dbCurrency.CurrencyValue);
                currency.CurrencyType = dbCurrency.CurrencyType;
                listCurrencies.Add(currency);
            }

            return listCurrencies;
        }
    }
}
