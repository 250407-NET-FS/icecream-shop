# Cart's Icecream Shop
## Executive Summary
This proposal gives a brief overview of "Cart's Icecream Shop", created on April 10, 2025, with the goal of creating a digital icecream shop with user accessibility. The project meets to satisfy user taste while upholding a business structure. 

Key functionalities include setting a price for custom-made icecream and adding transactions based on the orders made. Customers can order and customize a select number of icecream; cashiers create transactions to save orders and start purchases with the customers.

The proposed development approach utilizes a waterfall methodology, ensuring productivity and iterative progress with feedback integration anticipates completing the service by April 18, 2025. A brief demo is scheduled for the due date, with the full system go-live to be discussed.

Potential risks identified include the storage of personal information for both our staff and customers. Mitigation strategies, including necessary security implementations in a dedicated database, will be in place to address these risks.

The project aims to deliver a high-quality, impactful solution that meets the strategic objectives of the organization. We look forward to the opportunity to partner with you on this transformative initiative.
## Models
* Icecream
  - Number of scoops
  - Flavors added to icecream (list based on number of scoops)
  - Toppings
  - Size (xs, s, m, l, xl)
  - On cone or on bowl?
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
  - Total Cost of Icecream List
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
* Connect to a SQL Server database containing the store data
