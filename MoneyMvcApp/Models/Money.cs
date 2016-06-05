using MoneySearchEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneySearchMvcApp.Models
{
    public class Money
    {
        public List<Money> getMoney()
          {
              MoneySearchModel moneySearchModel = new MoneySearchModel();
              List<Money> money = moneySearchModel.Moneys.ToList();
              return money;
        }
    }
}