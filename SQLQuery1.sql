select * from AppTasks

insert into AppTasks (CreationTime,Description,State,Title) values ('2017-06-08','学习新东西',0,'new knowledge')
insert into AppTasks (CreationTime,Description,State,Title) values ('2017-06-08','今天晚上买面包',1,'buy bread')

insert into AppTasks (CreationTime,Description,State,Title) values ('2017-06-08 ','今天晚上买面包',1,'buy bread')

insert into AppTasks (CreationTime,Description,State,Title) 
select '2017-06-08 ',N'后台找宝贝儿',0,N'见宝贝儿'

delete from apptasks where id=6