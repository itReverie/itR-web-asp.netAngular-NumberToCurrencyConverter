# itR-web-angularCurrencyConverter

Program that converts numbers into coins and bills.For example:

Available Bills: 
- £50, £20, £10, £5

Availabel coins: 
- £2, £1, 
- 50p, 20p, 10p, 5p, 2p, 1p

Input: 
**£155.55**

Output: 
- £50 - 3 bills
- £5  - 1 bills
- 50p - 1 bills
- 5p  - 1 bills

**NOTE** This example is done with English currency, to **CHANGE THE CURRENCY** just change the list of currency and the table currency with your values.

The program works by default in offline mode and it could also work taking and saving the searches in a db if you configure a valid db on the web.config.

If you are just interested in taking the algorithm, take it from the controllers and test it via the unit testing included.
MoneyChangeController.cs
public List<MoneyChange> GetMoneyChange(decimal number)
