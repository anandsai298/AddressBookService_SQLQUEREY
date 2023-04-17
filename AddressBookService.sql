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
update AddressBook set Firstname='Askar' where Firstname='Anand';
update AddressBook set Firstname='Anandsai' where Firstname='Sai';
update AddressBook set Firstname='Anandsaikumar' where Firstname='Vijaya';
update AddressBook set Lastname='Vijayarowthu' where Lastname='Rowthu';

--UC5-Delete
delete from AddressBook where PersonId=2;

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
insert into PersonType(PersonName,RelationType) values('Yash','Friend');
insert into PersonType(PersonName,RelationType) values('Satish','Friend');
insert into PersonType(PersonName,RelationType) values('Sainag','Family');
insert into PersonType(PersonName,RelationType) values('Phani','Profession');

select * from PersonType;

--UC10-Count
select count(RelationType)from PersonType where RelationType='Friend' group by RelationType;
select count(RelationType)from PersonType where RelationType='Family' group by RelationType;
select count(RelationType)from PersonType where RelationType='Profession' group by RelationType;

--UC11-Ability to add person to both Friend and Family
insert into PersonType(PersonName,RelationType) values('Kiran','Family');
insert into PersonType(PersonName,RelationType) values('Harsha','Profession');




