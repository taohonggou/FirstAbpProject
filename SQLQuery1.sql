select * from AppTasks

insert into AppTasks (CreationTime,Description,State,Title) values ('2017-06-08','学习新东西',0,'new knowledge')
insert into AppTasks (CreationTime,Description,State,Title) values ('2017-06-08','今天晚上买面包',1,'buy bread')

insert into AppTasks (CreationTime,Description,State,Title) values ('2017-06-08 ','今天晚上买面包',1,'buy bread')

insert into AppTasks (CreationTime,Description,State,Title) 
select '2017-06-08 ',N'后台找宝贝儿',0,N'见宝贝儿'

delete from apptasks where id=6

select * from AppPersons

insert into AppPersons (id,CreationTime,CreatorUserId,LastModificationTime,LastModifierUserId,Name) 
select  NEWID(),GETDATE(),null,null,null,'Alen' union
select  NEWID(),GETDATE(),null,null,null,'Luce' union
select  NEWID(),GETDATE(),null,null,null,'Tim' 

-- CE3AF8D5-2ADC-4581-B962-6A41FEBBEF7A  46CBF16C-CC74-448B-B782-B4D8621B9984  822DF801-AE89-4B2C-81F0-DEDF024AD557

update AppTasks set AssignedPersonId='CE3AF8D5-2ADC-4581-B962-6A41FEBBEF7A' where id=3
update AppTasks set AssignedPersonId='46CBF16C-CC74-448B-B782-B4D8621B9984' where id=4
update AppTasks set AssignedPersonId='822DF801-AE89-4B2C-81F0-DEDF024AD557' where id=5