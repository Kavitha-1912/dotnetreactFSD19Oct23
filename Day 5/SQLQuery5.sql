insert into Areas(area,zipcode) values ('ABC' , '12345')
insert into Areas(area,zipcode) values ('BBB' , '12345')
insert into Areas values('CCC' , '54321')
select * from Areas

insert into Skills values('C', 'PLT')
insert into Skills values('C++', 'OOPS'), ('Java', 'Web'), ('SQL','RDMS')
select * from Skills


insert into Employees(name,age,area) values('Ramu',23,'ABC')
insert into Employees(name,age,area) values('Somu',34,'BBB'),('Bimu',27,'ABC')
select * from Employees

insert into EmployeesSkills values(101,'C',7)
insert into EmployeesSkills values(101,'C++',7)
insert into EmployeesSkills values(101,'Java',6)
insert into EmployeesSkills values(102,'Java',7)
insert into EmployeesSkills values(102,'SQL',8)
select * from EmployeesSkills

update EmployeesSkills set skill_level = 8 where employee_id = 101 and skill_name = 'c'  

update Employees set age = 29 where name = 'Bimu'  

update Employees set name = ' Kolu' , age = 22 where employee_id = 102

--delete child first then parent otherwise it will shows error
 
 --child table

 delete from EmployeesSkills where skill_name = 'c'

 --parent

 delete from Skills where skill = 'c'

