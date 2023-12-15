insert into categories(name)
values('B1');
insert into categories(name)
values('A1');
insert into categories(name)
values('A2');
insert into categories(name)
values('B2');
insert into quizzes(title,image,a,b,c,d,answer,isZeroPoint,categoryid)
values('First Question','Checkvar.jpg','First Answer','Second Answer','Third Answer','Fourth Answer','First Answer',1,2);
select * from quizzes;
ALTER TABLE quizzes ALTER COLUMN c NVARCHAR(MAX) NULL;
alter table results add column 