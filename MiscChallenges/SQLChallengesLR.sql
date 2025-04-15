USE Chinook;
-- First Test Run
SELECT * FROM Album;
SELECT * FROM Genre;
-- Basic Challenges

-- List all customers (full name, customer id, and country) who are not in the USA
SELECT FirstName + ' ' + LastName AS 'Full Name', customerid, country
FROM Customer
WHERE country != 'USA';

-- List all customers from Brazil
SELECT FirstName + ' ' + LastName AS 'Full Name', customerid, country
FROM Customer
WHERE country = 'Brazil';

-- List all sales agents
SELECT FirstName + ' ' + LastName AS 'Full Name', Title
FROM Employee
WHERE Title LIKE 'Sales%Agent';

-- Retrieve a list of all countries in billing addresses on invoices
SELECT BillingAddress, BillingCountry FROM Invoice;

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
SELECT COUNT(InvoiceId) AS '2025 Count', SUM(Total) as SalesTotal
FROM Invoice
WHERE InvoiceDate >= '2025-01-01';

-- (challenge: find the invoice count sales total for every year using one query)
SELECT YEAR(InvoiceDate), COUNT(InvoiceId) AS 'Count', SUM(Total) as SalesTotal 
FROM Invoice 
GROUP BY YEAR(InvoiceDate);

-- how many line items were there for invoice #37
SELECT Sum(Quantity) AS 'Total Items'
FROM InvoiceLine
WHERE InvoiceId = 37;

-- how many invoices per country? BillingCountry # of invoices -
SELECT BillingCountry, COUNT(InvoiceId) AS "Total Invoices"
FROM Invoice
GROUP BY BillingCountry;

-- Retrieve the total sales per country, ordered by the highest total sales first.
SELECT BillingCountry, SUM(Total) AS "Total Sales"
FROM Invoice
GROUP BY BillingCountry
ORDER BY "Total Sales" DESC;

-- JOINS CHALLENGES
-- Every Album by Artist
SELECT Artist.ArtistId, Name, AlbumId, Title
FROM Album
INNER JOIN Artist
ON Album.ArtistId = Artist.ArtistId;

-- All Songs of the rock genre
SELECT t.TrackId, t.Name, g.GenreId, g.Name
FROM Track t
INNER JOIN Genre g 
ON t.GenreId = g.GenreId
WHERE g.Name = 'Rock';

-- Show all invoices of customers from brazil (mailing address not billing)
SELECT c.CustomerId, c.FirstName + ' ' + c.LastName AS 'Full Name', i.InvoiceId, i.InvoiceDate, i.Total
FROM Customer c
INNER JOIN Invoice i 
On i.CustomerId = c.CustomerId
WHERE c.Country = 'Brazil';

-- Show all invoices together with the name of the sales agent for each one
Select i.InvoiceId, i.InvoiceDate, c.CustomerId, c.FirstName + ' ' + c.LastName 'Customer', e.FirstName + ' ' + e.LastName 'Sales Agent' 
From Invoice i 
JOIN Customer c ON i.CustomerId = c.CustomerId 
JOIN Employee e ON c.SupportRepId = e.EmployeeId;

-- Which sales agent made the most sales in 2009?
SELECT TOP 1 e.EmployeeId, SUM(i.Total) AS 'Sales Total'
FROM Invoice i 
JOIN Customer c ON i.CustomerId = c.CustomerId
JOIN Employee e ON c.SupportRepId = e.EmployeeId
WHERE e.Title LIKE 'Sales%Agent' AND i.InvoiceDate >= '2025-01-01'
GROUP BY e.EmployeeId
ORDER By 'Sales Total' DESC;

-- How many customers are assigned to each sales agent?
SELECT e.EmployeeId, COUNT(CustomerId) AS 'Customer Count'
FROM Customer c 
JOIN Employee e 
ON c.SupportRepId = e.EmployeeId
WHERE e.Title LIKE 'Sales%Agent'
GROUP BY e.EmployeeId;

-- Which track was purchased the most in 2010?
SELECT TOP 1 iL.TrackId, COUNT(t.TrackId) AS 'Invoice Count'
FROM Invoice i 
JOIN InvoiceLine iL ON iL.InvoiceId = i.InvoiceId
JOIN Track t ON t.TrackId = iL.TrackId
WHERE InvoiceDate >= '2022-01-01' AND InvoiceDate < '2023-12-31'
GROUP BY iL.TrackId
ORDER BY 'Invoice Count' DESC;

-- Show the top three best selling artists.
SELECT TOP 3 a.ArtistId, SUM(Total)
FROM Artist a 
JOIN Album al ON al.ArtistId = a.ArtistId
JOIN Track t ON t.AlbumId = al.AlbumId 
JOIN InvoiceLine iL ON t.TrackId = iL.TrackId
JOIN Invoice i ON iL.InvoiceId = i.InvoiceId
GROUP BY a.ArtistId
ORDER BY SUM(Total) DESC;

-- Which customers have the same initials as at least one other customer?
SELECT c.CustomerId, SUBSTRING(c.FirstName, 1, 1)+SUBSTRING(c1.LastName, 1, 1) AS 'Initials 1',
    c1.CustomerId, SUBSTRING(c1.FirstName, 1, 1) + SUBSTRING(c1.LastName, 1, 1) AS 'Initials 2'
FROM Customer c
INNER JOIN Customer c1 ON c.CustomerId = c1.CustomerId 
WHERE SUBSTRING(c.FirstName, 1, 1) + SUBSTRING(c1.LastName, 1, 1) = SUBSTRING(c1.FirstName, 1, 1) + SUBSTRING(c1.LastName, 1, 1);

-- ADVACED CHALLENGES: Solve these with a mixture of joins, subqueries, CTE, and set operators. 
-- Solve at least one of them in two different ways, and see if the execution, and plan for them is the same, or different.
-- 1. which artists did not make any albums at all?
SELECT a.ArtistId
FROM Artist a 
LEFT JOIN Album al ON a.ArtistId = al.ArtistId
GROUP BY a.ArtistId
HAVING COUNT(al.AlbumId) = 0;

-- 2. which artists did not record any tracks of the Latin genre?
SELECT a.ArtistId, COUNT(g.GenreId) AS 'Latin Song Count'
FROM Artist a 
JOIN Album al ON a.ArtistId = al.AlbumId
LEFT JOIN Track t ON al.AlbumId = t.AlbumId
LEFT JOIN Genre g ON t.GenreId = g.GenreId
WHERE g.Name = 'Latin'
GROUP BY a.ArtistId;
-- HAVING COUNT(g.GenreId) = 0