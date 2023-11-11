use dbCompany26Oct2023

select * from EmployeesSkills

alter trigger trgInsertEmployeeSkill
on EmployeesSkills
instead of insert
as
begin
   declare 
	 @skillName varchar(20),
	 @empId int,
	 @level int
	 set @SkillName = (select skill_name from inserted)
	 set @empId =  (select employee_id from inserted)
	 set @level =  (select skill_level from inserted)
	 if((select count(skill) from Skills where skill= @skillName) =0)
	 begin
			print 'Skill not present in skill table'
	end
	else
	begin
	    insert into EmployeesSkills values(@empId,@skillName,@level)	
	end
end

insert into EmployeesSkills values(101,'SQ',8)
