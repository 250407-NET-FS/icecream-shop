# icecream-shop
Simple Icecream Shop API that controls staffing and icecream transactions

## Models
* Icecream
  - Number of scoops
  - Flavors added to icecream (list based on number of scoops)
  - toppings
  - size (xs, s, m, l, xl)
  - on cone or on bowl?
  - Many to many with customer
  - GUID? (refer to stretch goal for predefined menu)
 
* Cashier
  - Name
  - Staff GUID
  - Phone Number
  - Many to many with customer

* Customer
  - Name
  - Email Address
  - Customer GUID
  - Custom Icecream History
  - Many to many with cashier, icecream

* Transaction
  - Cashier (who sets up the transaction) 
  - Customer (who helps go through the transaction)
  - Price of icecream
  - many to one with customer
 
## Functionalities
* Calculate price of Icecream (Business Service)
  - formula: ((# of scoops) + (toppings * 0.25)) * size + (2 * isCone)
  - isCone = boolean where false = 0 or true = 1
 
* Add to Custom Icecream History (Request)

* Add to Customer List (Request)

* Add/Remove Cashier to Cashier List (Request)

* Add Transaction:
  - Utilizes icecream price calculation

### Stretch Goals
* Create a predefined menu of icecream to order (birthday cake icecream included?)
* Have a frontend that can better interact with the requests
