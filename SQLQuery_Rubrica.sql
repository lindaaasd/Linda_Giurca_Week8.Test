--create database Rubrica;

create table Contatto(
ID int primary key identity(1,1),
Nome varchar(50) not null,
Cognome varchar(50) not null,
)

create table Indirizzo(
    ID int primary key identity(1,1),
    Tipologia varchar(30) not null,
    Via varchar(30) not null,
    Citta varchar(30) not null,
    CAP varchar(30) not null, 
    Provincia varchar(30) not null,
    Nazione varchar(30) not null, 
    IDContatto int not null constraint FK_Contatto foreign key references Contatto(ID)
)

insert into Contatto values('Linda', 'Giurca');
insert into Contatto values('Riccardo', 'Moschetti');
insert into Contatto values('Eva', 'Moschetti');