create table register (
id_user int identity(1,1) not null,
login_user varchar(50) not null primary key,
password_user varchar(50) not null
)
insert into register (login_user,password_user) values ('admin','admin')