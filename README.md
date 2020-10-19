# Assesment_API

##scripts


DB Scripts:
-------------------------------------------------------------------------------------------------------------------
Department Table:
CREATE TABLE Department
(
Id int IDENTITY(1,1) PRIMARY KEY,
DepartmentName varchar(50) Not Null UNIQUE,
MarkAlias varchar(20),
AddedBy varchar(50) Not Null,
AddedTime datetime Not Null,
ModifiedBy varchar(50)  Not Null,
ModifiedTime datetime Not Null,
DepartmentLead int,
ParentDepartment int,
FOREIGN KEY (ID) REFERENCES DepartmentLead(ID)
);

Insert data:
insert into Department VALUES(1,"Marketing", "","Admin1",GETDATE(),"Admin1",GETDATE(),1,"");
--------------------------------------------------------------------------------------------------------------------------
DepartmentLead:

Table :
create table DepartmentLead(
Id int IDENTITY(1,1) PRIMARY KEY,
DepartmentID int,
Name varchar(50) Not Null UNIQUE
);


INSERT INTO DepartmentLead(Name)  
VALUES  ('Lead1');

INSERT INTO DepartmentLead(Name)  
VALUES  ('Lead2');

INSERT INTO DepartmentLead(Name)  
VALUES  ('Lead3');

INSERT INTO DepartmentLead(Name)  
VALUES  ('Lead4');

INSERT INTO DepartmentLead(Name)  
VALUES  ('Lead5');

----------------------------------------------------------------------------
