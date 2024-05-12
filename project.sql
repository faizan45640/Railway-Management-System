CREATE DATABASE railway;
use railway;
CREATE TABLE ADMIN(

email VARCHAR(50) unique PRIMARY KEY ,
name VARCHAR(50),
password VARCHAR(50)

)
INSERT INTO ADMIN VALUES('admin@admin.com' , 'admin' , 'admin');
SELECT * FROM Passenger WHERE email='faizan45640@gmail.com' AND password='1234';


Create TABLE Passenger(
id INT PRIMARY KEY IDENTITY (1,1),
username VARCHAR(50) NOT NULL,
email VARCHAR(50) Unique NOT NULL,
password VARCHAR(50) NOT NULL,
address VARCHAR(50) NOT NULL,
phone VARCHAR(11) NOT NULL,
gender VARCHAR(6) NOT NULL

 );



Create TABLE Train(
    id INT PRIMARY KEY IDENTITY (1,1),
	name VARCHAR(50) NOT NULL,
	capacity INT NOT NULL,
	Status VARCHAR(50)
);

Create TABLE Route(
id INT PRIMARY KEY IDENTITY(1,1),
trainid INT FOREIGN KEY REFERENCES Train(id) ON DELETE CASCADE ON UPDATE CASCADE,
source VARCHAR(50) NOT NULL,
destination VARCHAR(50) NOT NULL,
date DATETIME NOT NULL,
cost INT NOT NULL
)

CREATE TABLE Reservation(
 id INT PRIMARY KEY IDENTITY (1,1),
 passengerID int FOREIGN KEY REFERENCES Passenger(id) ON DELETE CASCADE ON UPDATE CASCADE,
 routeID int FOREIGN KEY REFERENCES Route(id) ON DELETE CASCADE,
 status VARCHAR(50)

)
CREATE TABLE Cancellation(
id INT PRIMARY KEY IDENTITY (1,1),
reservationID INT Foreign KEY REFERENCES Reservation(id) ON DELETE NO ACTION ON UPDATE NO ACTION ,
date DATETIME
) 

CREATE TABLE Passenger_audit
(
change_id int primary key identity(1,1),
id int not null,
 username varchar(50) not null,
 email varchar(50) not null,
 password varchar(50) not null,
 address varchar(50) not null,
 phone varchar(50) not null,
 gender varchar(6) not null,
 updated_at datetime not null,
 operation varchar(3) not null
 check (operation='INS'OR operation='DEL' or operation='UPD'));
 
 go
 create trigger trg_Passenger_audit
 on Passenger
 AFTER INSERT,DELETE
 as
 begin 
 set NOCOUNT on
 insert into Passenger_audit
 (id,
 username,
 email,
 password,
 address,
 phone,
 gender,
 updated_at,
 operation)
--for inserting data for insert
select 
i.id,
i.username,
i.email,
i.password,
i.address,
i.phone,
i.gender,
GETDATE(),
'INS'
from inserted i
union all
-- for inset the deleted data
select 
d.id,
d.username,
d.email,
d.password,
d.address,
d.phone,
d.gender,
GETDATE(),
'DEL'
from deleted d
end;

go
create trigger trg_Passenger_audit_update
on Passenger
after update
as begin
set nocount on
insert into Passenger_audit
( id,
username,
email,
password,
address,
phone,
gender,
updated_at,
operation)
-- for inserting data when updated

select 
u.id,
u.username,
u.email,
u.password,
u.address,
u.phone,
u.gender,
GETDATE(),
'UPD'
from inserted u
end;

CREATE TABLE Reservation_audit
(change_id int primary key identity(1,1),
id int not null,
passengerID int,
routeID int,
status varchar(50),
updated_at datetime not null,
operation varchar(3) not null
check (operation='INS' or operation='DEL'or operation='UPD'));


go
create trigger trg_Reservation_audit
on Reservation
after insert,delete
as 
begin
set nocount on
insert into Reservation_audit
(id,
passengerID,
routeID,
status,
updated_at,
operation)
--for inserting data when data is input
select 
i.id,
i.passengerID,
i.routeID,
i.status,
GETDATE(),
'INS'
from inserted i
union all
--for inserting data when data is deleted
select
d.id,
d.passengerID,
d.routeID,
d.status,
GETDATE(),
'DEL'
from deleted d
end;

go 
create trigger  trg_Reservation_audit_update
on Reservation
after update
as begin
set nocount on
insert into Reservation_audit
(id,
passengerID,
routeID,
status,
updated_at,
operation)
--for inserting data when data is updated
 select
 u.id,
 u.passengerID,
 u.routeID,
 u.status,
 GETDATE(),
 'UPD'
 from inserted u
 end;

 create table Train_audit
 (change_id int primary key identity (1,1),
 id int not null,
 name varchar(50) not null,
 capacity int not null,
 status varchar(50),
 updated_at datetime,
 operation varchar(3) not null
 check(operation='INS' or operation='DEL' or operation='UPD'));


 go 
 create trigger trg_Train_audit
 on Train
 after insert,delete
 as begin
 set nocount on
 insert into Train_audit
 (id,
 name,
 capacity,
 status,
 updated_at,
 operation)
 ----for inserting data when data is input
 select 
 i.id,
 i.name,
 i.capacity,
 i.Status,
 GETDATE(),
 'INS'
 from inserted i
 union all
 --for inserting data when data is deleted
 select
 d.id,
 d.name,
 d.capacity,
 d.Status,
 getdate(),
 'DEL'
 from deleted d
 end;

 go
 create trigger  trg_Train_audit_update
 on Train
 after update 
 as begin
 set nocount on
 insert into Train_audit
 (id,
 name,
 capacity,
 status,
 updated_at,
 operation)
 --for inserting data when data is updated
 select
 u.id,
 u.name,
 u.capacity,
 u.Status,
 GETDATE(),
 'UPD'
 from inserted u
 
 end;

 create table Route_audit
 (change_id int primary key identity(1,1),
 id int not null,
 trianid int,
 source varchar(50) not null,
 destination varchar(50) not null,
 date datetime not null,
 cost int not null,
 updated_at datetime not null,
 operation varchar(3) not null
 check (operation='INS' or operation='DEL' or operation ='UPD'));

 
 go 
 create trigger trg_Route_audit
 on Route
 after insert,delete
 as begin
 set nocount on
 insert into Route_audit
 ( id,
 trianID,
 source,
 destination,
 date,
 cost,
 updated_at,
 operation)
 --for inserting data when data is input
 select 
 i.id,
 i.trainid,
 i.source,
 i.destination,
 i.date,
 i.cost,
 getdate(),
 'INS'
 from inserted i
 union all
 --for inserting data when data is deleted
 select 
 d.id,
 d.trainid,
 d.source,
 d.destination,
 d.date,
 d.cost,
 GETDATE(),
 'DEL'
 from deleted d
 end;

 go
 create trigger trg_Route_audit_update
 on Route
 after update
 as begin
 set nocount on
  insert into Route_audit
 ( id,
 trianID,
 source,
 destination,
 date,
 cost,
 updated_at,
 operation)
 --for inserting data when data is updated
 select
 u.id,
 u.trainid,
 u.source,
 u.destination,
 u.date,
 u.cost,
 getdate(),
 'UPD'
 from inserted u
 end;

 create table Cancellation_audit
 ( change_id int primary key identity(1,1),
 id int not null,
 reservationID int ,
 date datetime,
 updated_at datetime,
 operation varchar(3) not null
 check(operation='INS' or operation='DEL' or operation='UPD'));
 
 go 
 create trigger trg_Cancellation_audit
 on Cancellation
 after insert,delete
 as begin
 set nocount on
 insert into Cancellation_audit
 (id,
 reservationID,
 date,
 updated_at,
 operation)
 --for inserting data when data is input
 select 
 i.id,
 i.reservationID,
 i.date,
 getdate(),
 'INS'
 from inserted i
 union all
 --for inserting data when data is deleted
 select
 d.id,
 d.reservationID,
 d.date,
 GETDATE(),
 'DEL'
 from deleted d
 end;

 go 
 create trigger trg_Cancellation_audit_update
 on Cancellation
 after update
 as begin
 set nocount on
 insert into Cancellation_audit
 (id,
 reservationID,
 date,
 updated_at,
 operation)
 --for inserting data when data is updated
 select
 u.id,
 u.reservationID,
 u.date,
 getdate(),
 'UPD'
 from inserted u
 end;

 SELECT * FROM Train_audit;
 INSERT INTO Train VALUES ( 'Rana Express' , 400 , 'Available');