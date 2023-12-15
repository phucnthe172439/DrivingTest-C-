drop database DriveTestDB;

create database DriveTestDB;

use DriveTestDB;

create table categories (
   id int identity(1,1) primary key,
   name varchar(2) not null,
);

create table quizzes (
    id int identity(1,1) primary key,
	title nvarchar(Max) not null,
	image nvarchar(MAX),
	a nvarchar(MAX) not null,
	b nvarchar(MAX) not null,
	c nvarchar(MAX) not null,
	d nvarchar(MAX),
	answer nvarchar(MAX) not null,
	isZeroPoint bit not null,
	categoryid int not null,
	foreign key(categoryid) references categories(id),

);

create table users (
    id int identity(1,1) primary key,
	username varchar(50) not null,
	password varchar(50) not null,
	roleid int not null,
);
create table results (
    id int identity(1,1) primary key,
	userid int ,
	foreign key(userid) references users(id),
	result int not null,
	categoryid int not null,
	foreign key(categoryid) references categories(id)
);
select * from users;
insert into users(username,password,roleid)
values('phucnthe172439','123',1);
insert into users(username,password,roleid)
values('user','123',0);

