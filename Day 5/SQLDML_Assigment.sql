create table Items
(item_name varchar(40) constraint pk_item primary key,
item_type varchar(40),
item_color varchar(20))

sp_help items



create table Sales
(sales_no int constraint pk_sales primary key,
saleqty int,
item_name varchar(40) constraint fk_item foreign key references items(item_name) not null,
dept_name varchar(70) not null)

sp_help sales

create table EMP
(emp_no int constraint pk_emp primary key,
emp_name varchar(40),
salary int,
dept_name varchar(70),
boss_no int constraint fk_boss foreign key references EMP(emp_no))

sp_help emp

create table Departments
(dept_name varchar(70) constraint pk_dname primary key,
floor int,
phone varchar(10),
emp_no int not null)

sp_help departments


