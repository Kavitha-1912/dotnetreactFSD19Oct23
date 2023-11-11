use pubs
select * from authors
select * from titles

--projection
select au_fname, phone from authors
select au_fname 'Author Name' ,phone 'Contact Number' from authors
select au_fname as 'Author Name' ,phone as 'Contact Number' from authors
select au_fname Author_Name ,phone Contact_Number from authors

--selection
select * from authors where contract = 0
select * from titles where royalty  >10
select * from titles where royalty  >10 or price>15
select * from titles where royalty  >10 and price>15
select title 'Book Name', price 'Cost', royalty 'Royalty Paid',
advance 'Advance received'
from titles 
where royalty  >10 and price>15

select title from titles where price >= 10 and price <=25
select title from titles where price between 10 and 25

select * from titles where title like 'The%'

--fetch those title that have 'data' any where in teh title
select Title from Titles where Title LIKE '%data%'

--fetch those titles whcih are published before '1991-06-18 00:00:00.000'
select Title from Titles where PubDate < '1991-06-18 00:00:00.000'


--fetch the book name and the price of those books that have been published by 0877
select Title 'BookName',price 'Price' from Titles where Pub_id = '0877'

-- fetch  book name, price nad notes of books from business    type that re priced in
-- the range of 15 to 100
select Title as BookName, Price, Notes from Titles where Type = 'business' AND Price BETWEEN 15 AND 100

--I want the books that have price of 10 or 20 or 30
select * from titles where price=10 or price=20 or price=30

select * from titles where price in (10,20,30)

--Aggrigated data
select AVG(price) 'Average price' from titles

select AVG(price) 'Averge price'from titles where  type='business'

select AVG(price) 'Averge price', Sum(price) 'Sum of price' from titles

--select MIN(price) 'Minimum price' from titles 
--select Max(price) 'Maximum price' from titles

--sub total and grouping
select type 'Type name', AVG(price) 'Average price' from titles group by type

select state, count(au_id) from authors group by state

select title_id, count(ord_num) 'number of times sold'
from sales group by title_id

select title_id, count(ord_num) 'number of times sold'
from sales 
group by title_id
having count(ord_num) > 1

--having filter the group by result

select type 'Type name', AVG(price) 'Average price' 
from titles 
where price>10
group by type
having AVG(price)>18
order by Type desc

--sorting
select * from authors order by state, city,au_fname

--subqueries

select * from titles
select * from sales
select title_id from titles where title = 'Straight Talk About Computers'
select * from sales where title_id = 'BU7832'

select * from sales where title_id =
(select title_id from titles where title = 'Straight Talk About Computers')


select * from authors

select * from titles where title_id in(
select title_id from titleauthor where au_id =
(select au_id from authors where au_lname = 'White'))

select * from authors where au_lname = 'Carson'

--print title name for books that have been sold
select title 'Book Name'from titles where title_id in
(select title_id from sales)

select AVG(price) as avg_price_of_Titles,pub_id from 

select title from Titles;

sp_help titles
sp_help publishers
select type from titles

--set 1
--1) Print all the titles names
select title from titles

--2) Print all the titles that have been published by 1389
select title,pub_id from titles where pub_id = 1389

--3) Print the books that have price in rangeof 10 to 15
select title from titles where price between 10 and 15

--4) Print those books that have no price
select title,price from titles where price is null

--5) Print the book names that strat with 'The'
select title from titles where title like 'The%'

--6) Print the book names that do not have 'v' in their name
select title from titles where title not like '%v%'

--7) print the books sorted by the royalty
select title,royalty from titles order by royalty asc

--8) print the books sorted by publisher in descending then by types in asending then by price in descending
select title,pub_id,type,price from titles order by pub_id desc,type asc,price desc

--9) Print the average price of books in every type
select AVG(price) 'Average price' from titles

--10) print all the types in uniques
select type from titles

--11) Print the first 2 costliest books
select top 2 title,price from titles order by price desc

--12) Print books that are of type business and have price less than 20 which also have advance greater than 7000
select title,type,price,advance from titles where type='business' and price<20 and advance>7000

--13) Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. Print only those which have count greater than 2. Also sort the result in ascending order of count
select Pub_id, count(*) as NumberOfBooksfrom titles
where price between 15 and 25 and title like '%It%'
group by pub_id
having count(*) > 2
order by NumberOfBooks ASC

sp_help authors
--14) Print the Authors who are from 'CA'
select state,au_fname,au_lname from authors where state = 'CA'

--15) Print the count of authors from every state
select state, COUNT(*) as AuthorCount from authors group by state

sp_help sales

--set 2
--1) Print the storeid and number of orders for the store
select Stor_id, count(*) as NumberOfOrders from sales group by stor_id

--2) print the numebr of orders for every title
select title_id, count(*) as NumberOfOrders from sales group by title_id

sp_help publishers
sp_help titles

--3) print the publisher name and book name
select P.pub_name as PublisherName, T.title as BookTitle
from Publishers P inner join Titles T on P.pub_id = T.pub_id

sp_help authors

--4) Print the author full name for al the authors
select concat(au_fname, ' ', au_lname) as AuthorFullName from authors

--5) Print the price or every book with tax (price+price*12.36/100)
select title,Price, (Price + (Price * 12.36/100)) as PriceWithTax from titles

--6) Print the author name, title name
select concat(A.au_fname, ' ', A.au_lname) as AuthorName, T.title as Title from Authors A, Titles T

--7) print the author name, title name and the publisher name
select authors.au_fname, titles.title,publishers.pub_name
from titleauthor
join authors on titleauthor.au_id = authors.au_id
join titles on titleauthor.title_id = titles.title_id
join publishers on publishers.pub_id=titles.pub_id

--8) Print the average price of books pulished by every publicher
select P.pub_name as PublisherName, avg(T.price) as AveragePrice
from Publishers P
inner join Titles T on P.pub_id = T.pub_id
group by P.pub_name;

--9) print the books published by 'Marjorie'
select a.au_fname+' '+au_lname as Author,t.title 'Book' 
from authors a,titles t,titleauthor ta 
where a.au_id=ta.au_id and t.title_id=ta.title_id and au_fname like '%Marjorie%'

--10) Print the order numbers of books published by 'New Moon Books'
select a.pub_name, t.title,ta.ord_num
from publishers as a
join titles as t on a.pub_id = t.pub_id
join sales as ta on t.title_id = ta.title_id
where pub_name='New Moon Books'

--11) Print the number of orders for every publisher
select P.pub_name as PublisherName, count(S.ord_num) as NumberOfOrders
from Publishers P
left join Titles T on P.pub_id = T.pub_id
left join Sales S on T.title_id = S.title_id
group by P.pub_name
order by PublisherName;

--12) print the order number , book name, quantity, price and the total price for all orders
select S.ord_num as OrderNumber, T.title as BookName, S.qty as Quantity, T.price as Price,
(S.qty * T.price) as TotalPrice
from Sales S
inner join Titles T on S.title_id = T.title_id;

--13) print the total order quantity for every book
select T.title as BookName, sum(S.qty) as TotalQuantity
from Titles T
left join Sales S on T.title_id = S.title_id
group by T.title
order by TotalQuantity desc

--14) print the total ordervalue for every book
select T.title as BookName, sum(S.qty * T.price) as TotalOrderValue
from Titles T
left join Sales S on T.title_id = S.title_id
group by T.title
order by TotalOrderValue desc

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
SELECT s.ord_num
FROM titles AS t
JOIN sales AS s ON t.title_id = s.title_id
JOIN publishers AS p ON t.pub_id = p.pub_id
JOIN employee AS e ON p.pub_id = e.pub_id
WHERE e.fname = 'Paolo';

USE pubs; -- Replace with the name of your database
SELECT table_name = t.name
FROM sys.tables t


--Assignment 7
--1) print the store name, title name,, quantity, sale amount, pulisher name, author name for all the sales. 
--Also print those books which have not been sold and authors who have not written.

select
    st.stor_name  'Store Name',
    t.title  'Title Name',
    s.qty  'Quantity',
    s.qty * t.price  'Sale Amount',
    p.pub_name  'Publisher Name',
    CONCAT(au.au_fname, ' ', au.au_lname)  'Author Name',
    'Sold'  'Status'
from sales s
join stores st on s.stor_id = st.stor_id
join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
left join titleauthor ta on t.title_id = ta.title_id
left join authors au on ta.au_id = au.au_id

union all

select
    t.title  'Title Name',
    p.pub_name  'Publisher Name',
    null  'Quantity',
    null  'Sale Amount',
    null  'Store Name',
    CONCAT(au.au_fname, ' ', au.au_lname)  'Author Name',
    'Not Sold'  'Status'
from titles t
join publishers p on t.pub_id = p.pub_id
left join titleauthor ta on t.title_id = ta.title_id
left join authors au on ta.au_id = au.au_id

union all

select
    null  'Store Name',
    null  'Title Name',
    null  'Quantity',
    null  'Sale Amount',
    null  'Publisher Name',
    CONCAT(au.au_fname, ' ', au.au_lname)  'Author Name',
    'Not Written'  'Status'
from authors au
left join titleauthor ta on au.au_id = ta.au_id;

SELECT s.stor_name 'Store Name', t.title 'Book Name', sl.qty 'Quantity', Sum(sl.qty) *
Sum(t.price) 'Sale Amount',
p.pub_name 'Publisher Name', concat(a.au_fname,' ',a.au_lname) 'Author Name'
FROM Stores s join Sales sl ON s.stor_id = sl.stor_id
full outer join titles t ON t.title_id = sl.title_id
full outer join titleauthor ta ON ta.title_id = t.title_id
full outer join authors a ON a.au_id = ta.au_id
left outer join Publishers p ON p.pub_id = t.pub_id
group by s.stor_name,
t.title,sl.qty,
p.pub_name,
a.au_fname,a.au_lname


--2) Create a stored procedure that will take the author name and print the total sales amount for all the books authored by him/her
--  Note : - If there are no books sold then print "Sale yet to gear up"

create procedure get_total_sales_by_author (@author_name varchar(60))
as
begin
	declare @total_sales decimal(10,2);
	set @total_sales = (select sum(s.qty )* sum(t.price)  from sales s
	inner join titles t ON s.title_id = t.title_id
	inner join titleauthor ta ON t.title_id = ta.title_id
	inner join authors a ON ta.au_id = a.au_id
	where a.au_fname + ' ' + a.au_lname = @author_name)
	if @total_sales IS NULL OR @total_sales = 0
	begin
		print 'Sale yet to gear up';
	end
	else
	begin
		print 'The total sales amount for ' + @author_name + ' is ' + CAST(@total_sales AS VARCHAR);
	end
end

EXEC get_total_sales_by_author @author_name = 'Leary	Michael'




--3) print the details of the sale when the sale quantity is greater than the sale quantity of all the same titles sold in the same store

select *from sales s where qty in (select max(qty) from sales
group by stor_id)

select
    s.stor_id  'Store ID',
    s.title_id  'Title ID',
    t.title  'Title',
    s.qty  'Sale Quantity',
    s.ord_date  'Sale Date'
from sales s
left join (select
        s.stor_id,
        s.title_id,
        max(s.qty) AS max_qty
    from sales s
    group by s.stor_id, s.title_id
) max_sale_qty on s.stor_id = max_sale_qty.stor_id
    and s.title_id = max_sale_qty.title_id
    and s.qty > max_sale_qty.max_qty
join titles t on s.title_id = t.title_id;


--4) Print the average price of every author's books withthe author's full name
select
    concat(au.au_fname, ' ', au.au_lname)  'Author Name',
    AVG(t.price) 'Average Price'
from authors au
join titleauthor ta on au.au_id = ta.au_id
join titles t on ta.title_id = t.title_id
group by au.au_id, au.au_fname, au.au_lname;

--5) Print the schema of the titles table and locate all the constrants

-- Get the schema of the titles table
EXEC sp_columns 'titles';

-- Locate the constraints for the titles table
EXEC sp_helpconstraint 'titles';


--6) Create a procedure that will take the price and prints the count of book that are priced less than that

create procedure proc_CountBooksPricedLessThan 
	@Price decimal(10, 2)
as
begin
    declare @BookCount int
    select @BookCount = count(*)
    from titles
    where price < @Price

    -- Print the count
    PRINT 'Count of books priced less than ' + CAST(@Price AS VARCHAR) + ': ' + CAST(@BookCount AS VARCHAR)
END

EXEC proc_CountBooksPricedLessThan 20.00


--7) Find a way to ensure that the price of books are not updated if the price is below 7

create trigger check_price_before_update
on titles 
instead of insert
as
begin
    declare
	@title_id varchar(6),
	@title varchar(60),
	@type char(12),
	@pub_id char(4),
	@price money,
	@advance money,
	@royalty int,
	@ytd_sales int,
	@notes varchar(200),
	@pubdate datetime,
	@new_price decimal(10,2);
    set @new_price = (select  price from inserted);

    if @new_price < 7
    begin
        print 'The price cannot be updated to below 7';
    end
	else
	begin
		insert into titles values(@title_id,@title,@type,@pub_id,@price,@advance,@royalty ,@ytd_sales ,@notes,@pubdate)
	end
end


insert into titles values('AU1099','Learn From Failures',
		'psychology','0599',6.00,15000.00,25,333,
		'Here you can face fear of Failures','2023-10-30 00:00:00:000')

--8) print the books that have 'e' and 'a' in their name
select title
from titles
where title like '%e%' and title like '%a%';

