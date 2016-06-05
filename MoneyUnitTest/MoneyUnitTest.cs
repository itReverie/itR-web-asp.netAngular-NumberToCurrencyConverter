using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using MoneyController;

namespace MoneySearchUnitTest
{
    [TestClass]
    public class MoneyUnitTest
    {
        [TestMethod]
        public void GetAllCurrenciesSql()
        {
            CurrencyController currencyController = new CurrencyController();
            List<Currency> currencyList= currencyController.GetAllCurrenciesFromDateBase();
            foreach(Currency currency in currencyList)
            {
                Debug.WriteLine(currency.CurrencyValue);
            }
            Assert.IsTrue(currencyList.Count==12);
        }

        [TestMethod]
        public void GetMoneyChangeSql()
        {
            decimal number = Convert.ToDecimal(834.35);
            Debug.WriteLine("Number: " + number);
            decimal total=0;
            
            MoneyChangeController moneyChangeController = new MoneyChangeController();
            List<MoneyChange> moneyChangeList = moneyChangeController.GetMoneyChangeFromDataBase(number);
            for (int i=0; i < moneyChangeList.Count;i++ )
            {
                //if is the last one just add it 
                if (i == moneyChangeList.Count - 1)
                {
                    total += moneyChangeList[i].CurrencyValue * moneyChangeList[i].Quantity;
                }
                else
                {
                    //make sure the next coin or bill is lower than the current one
                    if ((moneyChangeList[i + 1].Quantity <= moneyChangeList[i].Quantity) ||
                        (moneyChangeList[i + 1].Quantity * moneyChangeList[i + 1].CurrencyValue < moneyChangeList[i].CurrencyValue))
                    {
                        // if it is lower sum up to toal
                        total += moneyChangeList[i].CurrencyValue * moneyChangeList[i].Quantity;
                    }
                    //if it is not lower it wont add it to the total and it means we are not making sure that the highest values of coins and bills are used first
                    else
                    {
                        Assert.Fail("The algorithm is not making sure to use always the higher value coins and bills. ");
                    }
                }

                Debug.WriteLine("Currency Value: " + moneyChangeList[i].CurrencyValue + " Quantity: " + moneyChangeList[i].Quantity + " Total: " + total);
            }
            //if the total isn't the same as the original number it means there was one quantity of currency bigger hence the test fails
            Assert.IsTrue(total == number);
            
        }


        [TestMethod]
        public void GetMoneyChange()
        {
            decimal number = Convert.ToDecimal(36.7);//834.35
            Debug.WriteLine("Number: " + number);
            decimal total = 0;

            MoneyChangeController moneyChangeController = new MoneyChangeController();
            List<MoneyChange> moneyChangeList = moneyChangeController.GetMoneyChange(number);
            for (int i = 0; i < moneyChangeList.Count; i++)
            {
                //if is the last one just add it 
                if (i == moneyChangeList.Count - 1)
                {
                    total += moneyChangeList[i].CurrencyValue * moneyChangeList[i].Quantity;
                }
                else
                {
                    //make sure the next coin or bill is lower than the current one
                    if ((moneyChangeList[i + 1].Quantity <= moneyChangeList[i].Quantity) ||
                        (moneyChangeList[i + 1].Quantity * moneyChangeList[i + 1].CurrencyValue < moneyChangeList[i].CurrencyValue))
                    {
                        // if it is lower sum up to toal
                        total += moneyChangeList[i].CurrencyValue * moneyChangeList[i].Quantity;
                    }
                    //if it is not lower it wont add it to the total and it means we are not making sure that the highest values of coins and bills are used first
                    else
                    {
                        Assert.Fail("The algorithm is not making sure to use always the higher value coins and bills. ");
                    }
                }

                Debug.WriteLine("Currency Value: " + moneyChangeList[i].CurrencyValue + " Quantity: " + moneyChangeList[i].Quantity + " Total: " + total);
            }
            //if the total isn't the same as the original number it means there was one quantity of currency bigger hence the test fails
            Assert.IsTrue(total == number);

        }

    }
}
