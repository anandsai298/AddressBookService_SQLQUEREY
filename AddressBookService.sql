--UC1
Create Database AddressBookService;
Use AddressBookService;

--UC2
create table AddressBook(
PersonId int Primary Key identity(1,1),
Firstname varchar(15),
Lastname varchar(15),
Address varchar(20),
City varchar(15),
State varchar(15),
ZipCode Bigint,
PHNO varchar(10),
EmailId varchar(25)
);

--UC3-AddData
Insert into AddressBook(Firstname,Lastname,Address,City,State,ZipCode,PHNO,EmailId)values('Anand','Kumar','Ghati','Kakinada','AP',533002,'9550631687','anand@gmail.com');
Insert into AddressBook(Firstname,Lastname,Address,City,State,ZipCode,PHNO,EmailId)values('Sai','Vijaya','Munsib','Kakinada','AP',533001,'9550631852','sai@gmail.com');
Insert into AddressBook(Firstname,Lastname,Address,City,State,ZipCode,PHNO,EmailId)values('Vijaya','Rowthu','Bhanugudi','Kakinada','AP',533003,'9550631951','kumar@gmail.com');
Insert into AddressBook(Firstname,Lastname,Address,City,State,ZipCode,PHNO,EmailId)values('Nani','Varupula','Nadaguduru','Hyderabad','Telengana',500060,'9550631951','kumar@gmail.com');


--UC4-Retrive,Edit
select * from AddressBook;
alter table AddressBook drop FK__AddressBo__Relat__5BE2A6F2;
alter table AddressBook drop column RelateType;
update AddressBook set Firstname='Askar' where Firstname='Anand';
update AddressBook set Firstname='Anandsai' where Firstname='Sai';
update AddressBook set Firstname='Anandsaikumar' where Firstname='Vijaya';
update AddressBook set Lastname='Vijayarowthu' where Lastname='Rowthu';

--UC5-Delete
delete from AddressBook where PersonId=2;
update AddressBook set Firstname='Sai',Lastname='Rowthu',Address='Sarpavaram',City='Kakinada',State='AP',ZipCode=58000,PHNO='9874561234',EmailId='sai@gmail.com' where PersonId=2;

--UC6-Retrive
select * from AddressBook where City='Kakinada' or State='Telengana';

--UC7-Size
select count(State)from AddressBook  group by  State;
select count(State)from AddressBook  group by  City;

--UC8-Sorted
select * from AddressBook ORDER by Firstname ASC;
select * from AddressBook ORDER by City ASC;

--UC9-Type
create table PersonType(
PersonId int Primary Key identity(1,1),
PersonName varchar(20),
RelationType varchar(20),
);
alter table PersonType drop FK__PersonTyp__Relat__5CD6CB2B;
alter table PersonType drop column RelateType;
alter table PersonType Add Id int foreign Key REFERENCES AddressBook(PersonId);
insert into PersonType(PersonName,RelationType,Id) values('Yash','Friend',1);
insert into PersonType(PersonName,RelationType,Id) values('Yash','Family',1);
insert into PersonType(PersonName,RelationType) values('Satish','Friend');
insert into PersonType(PersonName,RelationType) values('Sainag','Family');
insert into PersonType(PersonName,RelationType) values('Phani','Profession');

delete from PersonType where PersonId=8;
delete from PersonType where PersonId=9;
delete from PersonType where PersonId=1;

select * from PersonType;

--UC10-Count
select count(RelationType)from PersonType where RelationType='Friend' group by RelationType;
select count(RelationType)from PersonType where RelationType='Family' group by RelationType;
select count(RelationType)from PersonType where RelationType='Profession' group by RelationType;

--UC11-Ability to add person to both Friend and Family
insert into PersonType(PersonName,RelationType) values('Kiran','Family');
insert into PersonType(PersonName,RelationType) values('Kiran','Friend');
delete from PersonType where PersonName='Kiran';

--IDENTITY_INSERT
set IDENTITY_INSERT AddressBook ON
set IDENTITY_INSERT AddressBook OFF

--UC12-Storedprocedure
Create Procedure AddAddressDetails
(
@FirstName varchar(30),
@LastName varchar(30),
@Address varchar(30),
@City varchar(20),
@State varchar(15),
@ZipCode Bigint,
@PHNO varchar(10),
@EmailId varchar(30)
)
As
Begin
insert into AddressBook values(@FirstName,@LastName,@Address,@City,@State,@ZipCode,@PHNO,@EmailId);
End

--UC13-Delete procedure
Create Procedure DeleteAddressBook
(
@PersonId int
)
As 
Begin
Delete from AddressBook where PersonId=@PersonId;
End

--UC14-Update
Create Procedure UpdateAddressBook
(
@PersonId int,
@FirstName varchar(30)
)
As
Begin
Update AddressBook set FirstName=@FirstName where PersonId=@PersonId;
End







