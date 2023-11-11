create table ITEM (
    itemname varchar(255) primary key,
    itemtype varchar(255),
    itemcolor varchar(255)
)

create table DEPARTMENT (
    deptname varchar(255) primary key,
    floor int,
    phone varchar(255),
    empno int not null
)

create table EMP (
    empno int primary key,
    empname varchar(255),
    salary int,
    deptname varchar(255) references DEPARTMENT(deptname),
    bossno int references EMP(empno)
)

create table SALES (
    salesno int primary key,
    saleqty int,
    itemname varchar(255) not null references ITEM(itemname),
    deptname varchar(255) not null references DEPARTMENT(deptname)
)

insert into ITEM (itemname, itemtype, itemcolor)
values
    ('Pocket Knife-Nile', 'E', 'Brown'),
    ('Pocket Knife-Avon', 'E', 'Brown'),
    ('Compass', 'N', '--'),
	('Geo positioning system','N','--'),
	('Elephant Polo stick','R','Bamboo'),
	('Camel Saddle','R','Brown'),
	('Sextant','N','--'),
	('Map Measure','N','--'),
	('Boots-snake proof','C','Green'),
	('Pith Helmet','C','Khaki'),
	('Hat-polar Explorer','C','White'),
	('Exploring in 10 Easy Lessons','B','--'),
	('Hammock','F','Khaki'),
	('How to win Foreign Friends','B','--'),
	('Map case','E','Brown'),
	('Safari Chair','F','khaki'),
	('Safari cooking kit','F','Khaki'),
	('Stetson','C','Black'),
	('Tent - 2 person','F','Khaki'),
	('Tent -8 person','F','Khaki')

insert into DEPARTMENT (deptname, floor, phone, empno)
values
    ('Management', 5, '34', 1),
    ('Books', 1, '81', 4),
    ('Clothes', 2, '24', 4),
	('Equipment',3,'5',3),
	('Furniture',4,'14',3),
	('Navigation',1,'41',3),
	('Recreation',2,'29',4),
	('Accounting',5,'35',5),
	('Purchasing',5,'36',7),
	('Personnel',5,'37',9),
	('Marketing',5,'38',2)

insert into EMP (empno, empname, salary, deptname, bossno)
values
    (1, 'Alice', 75000, 'Management', NULL),
    (2, 'Ned', 45000, 'Marketing', 1),
    (3, 'Andrew', 25000, 'Marketing', 2),
	(4,'Clare',22000,'Marketing',2),
	(5,'Todd',38000,'Accounting',1),
	(6,'Nancy',22000,'Accounting',5),
	(7,'Brier',43000,'Purchasing',1),
	(8,'Sarah',56000,'Purchasing',7),
	(9,'Sophile',35000,'Personnel',1),
	(10,'Sanjay',15000,'Navigation',3),
	(11,'Rita',15000,'Books',4),
	(12,'Gigi',16000,'Clothes',4),
	(13,'Maggie',11000,'Clothes',4),
	(14,'Paul',15000,'Equipment',3),
	(15,'James',15000,'Equipment',3),
	(16,'Pat',15000,'Furniture',3),
	(17,'Mark',15000,'Recreation',3)

insert into SALES (salesno, saleqty, itemname, deptname)
values
    (101, 2, 'Boots-snake proof', 'Clothes'),
    (102, 1, 'Pith Helmet', 'Clothes'),
    (103, 1, 'Sextant', 'Navigation'),
	(104, 3, 'Hat-polar Explorer','Clothes'),
	(105, 5,'Pith Helmet','Equipment'),
	(106, 2,'Pocket Knife-Nile','Clothes'),
	(107, 3,'Pocket Knife-Nile','Recreation'),
	(108, 1,'Compass','Navigation'),
	(109, 2,'Geo positioning system','Navigation'),
	(110, 5,'Map Measure','Navigation')

select * from ITEM
select * from DEPARTMENT
select * from EMP
select * from SALES