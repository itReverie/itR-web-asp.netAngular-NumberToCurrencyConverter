
using MoneyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyController
{
    public class MoneyChange
    {
        #region Variables
        MoneyEntities.MoneyChange dbMoneyChange = null;
        MoneyModel model = null;
        List<Currency> currencyList;
        List<MoneyChange> moneyChangeList;
        #endregion

        #region Properties
        public decimal Number { get; set; }
        public long Id { get; set; }
        public Guid MoneyChangeId { get; set; }
        public long CurrencyId { get; set; }
        public decimal CurrencyValue { get; set; }
        public int Quantity { get; set; }
        public DateTime RequestedTime { get; set; }
        public String Error { get; set; }
        #endregion

        #region Constructor
        public MoneyChange()
        {

        }
        #endregion

        #region privateMethdos

        private void GetIntegers(decimal numberBeforePoint, int positionListMoney, Guid moneyChangeId)
        {
            decimal quotient = Math.Floor(numberBeforePoint / currencyList[positionListMoney].CurrencyValue);
            CalculateMoneyChange(numberBeforePoint, quotient, positionListMoney, moneyChangeId);
        }

        private void GetDecimals(decimal numberAfterPoint, int positionListMoney, Guid moneyChangeId)
        {
            decimal quotient = numberAfterPoint / currencyList[positionListMoney].CurrencyValue;
            CalculateMoneyChange(numberAfterPoint, quotient, positionListMoney, moneyChangeId);
        }

        private void CalculateMoneyChange(decimal number, decimal quotient, int position, Guid moneyChangeId)
        {
            if (quotient >= 1)
            {

                MoneyChange moneySearch = new MoneyChange();
                moneySearch.MoneyChangeId = moneyChangeId;
                moneySearch.CurrencyId = currencyList[position].CurrencyId;
                moneySearch.CurrencyValue = currencyList[position].CurrencyValue;
                moneySearch.Quantity = Convert.ToInt16(quotient);
                moneySearch.Number = this.Number;

                moneySearch.AddMoneyChange();


                moneyChangeList.Add(moneySearch);

                number -= (quotient * currencyList[position].CurrencyValue);
            }
            decimal remainder = number % currencyList[position].CurrencyValue;
            if (remainder > 0)
            {
                GetIntegers(number, position + 1, moneyChangeId);
            }
        }



        #endregion

        public List<MoneyChange> GetAllMoneyChanges()
        {
            List<MoneyChange> listAllMoneyChanges = new List<MoneyChange>();

            model = new MoneyModel();
            foreach (MoneyEntities.MoneyChange dbMoneyChange in model.MoneyChange.ToList())
            {
                MoneyChange moneyChange = new MoneyChange();
                moneyChange.Id = dbMoneyChange.Id;
                moneyChange.MoneyChangeId = new Guid(dbMoneyChange.MoneyChangeId.ToString());
                moneyChange.CurrencyId = Convert.ToInt16(dbMoneyChange.CurrencyId);
                moneyChange.CurrencyValue = Convert.ToDecimal(dbMoneyChange.CurrencyValue);
                moneyChange.Quantity = Convert.ToInt16(dbMoneyChange.Quantity);
                moneyChange.RequestedTime = Convert.ToDateTime(dbMoneyChange.RequestedTime);
                moneyChange.Number = Convert.ToDecimal(dbMoneyChange.Number);
                listAllMoneyChanges.Add(moneyChange);
            }

            return listAllMoneyChanges;
        }

        public void AddMoneyChange()
        {
            try
            {
                model = new MoneyModel();
                dbMoneyChange = new MoneyEntities.MoneyChange();
                dbMoneyChange.MoneyChangeId = this.MoneyChangeId;
                dbMoneyChange.CurrencyId = this.CurrencyId;
                dbMoneyChange.CurrencyValue = this.CurrencyValue;
                dbMoneyChange.Quantity = this.Quantity;
                dbMoneyChange.RequestedTime = DateTime.Now;
                dbMoneyChange.Number = this.Number;
                model.MoneyChange.Add(this.dbMoneyChange);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        /// <summary>
        /// Returns the list of currency change according to a decimal number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<MoneyChange> GetMoneyChange(decimal number, List<Currency> currencyList)
        {
            moneyChangeList = new List<MoneyChange>();
            Guid moneyChangeId = Guid.NewGuid();
            this.Number = number;

            this.currencyList = currencyList;

            GetIntegers(Math.Truncate(number), 0, moneyChangeId);
            GetDecimals(number % 1,5, moneyChangeId);//based on the list of currencies in the position 5 we start with the decimals

            return moneyChangeList;
        }
    }
}
