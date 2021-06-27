select * from competence

select * from employee

select * from knowledge

select * from position

select * from requirement

insert into competence(id, name) values(1,'test')

insert into employee(id, pos_id, fullname) values(1,1,'test')

insert into knowledge(id, com_id, emp_id, level) values(1,1,1,1)

insert into position(id, name) values(1,'test')

insert into requirement(id, pos_id, com_id, level) values(1,1,1,1)

delete from competence where id = 1 and name = 'test'

delete from employee where id = 1 and pos_id = 1 and fullname = 'test'

delete from knowledge where id = 1 and com_id = 1 and emp_id = 1 and level = 1

delete from position where id = 1 and name = 'test'

delete from requirement where id =1 and pos_id = 1 and com_id  =1 and level =1

--select * from employee where id = 1

--Employee
select k.id, k.com_id, k.emp_id, k.level from knowledge k left join competence c where c.id = 1

