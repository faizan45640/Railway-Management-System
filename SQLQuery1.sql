﻿CREATE TABLE ADMIN(

email VARCHAR(50) PRIMARY KEY ,
name VARCHAR(50),
password VARCHAR(50)

)
INSERT INTO ADMIN VALUES('admin@admin.com' , 'admin' , 'admin');
SELECT * FROM Passenger WHERE email='faizan45640@gmail.com' AND password='1234';


Create TABLE Passenger(
id INT PRIMARY KEY IDENTITY (1,1),
username VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL,
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
reservationID INT ,
date DATETIME

) 







 
