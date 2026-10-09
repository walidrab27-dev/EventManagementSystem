-- create database EventManagementSystemDB;

create table Organizer
(
	id int primary key identity(1,1),
	name varchar(250) not null check (len(trim(name)) > 0),
	email varchar(250) not null unique check (email like '%@%.%'),
	createdAt datetime not null default getdate(),
	updatedAt datetime not null default getdate()
);

create table Venue
(
	id int primary key identity(1,1),
	name varchar(250) not null unique check(len(trim(name)) > 0),
	location varchar(max) not null,
	capacity int not null check(capacity > 0),
	createdAt datetime not null default getdate(),
	updatedAt datetime not null default getdate()
);

create table Event
(
	id int primary key identity(1,1),
	title varchar(250) not null unique check(len(trim(title)) > 0),
	organizerId int not null,
	venueId int not null,
	foreign key (organizerId) references Organizer(id),
	foreign key (venueId) references Venue(id),
	eventDate datetime not null,
	createdAt datetime not null default getdate(),
	updatedAt datetime not null default getdate()
);

create table Attendee 
(
	id int primary key identity(1,1),
	name varchar(250) not null check (len(trim(name)) > 0),
	email varchar(250) not null unique check (email like '%@%.%'),
	createdAt datetime not null default getdate(),
	updatedAt datetime not null default getdate()
);

create table Ticket
(
	id int primary key identity(1,1),
	eventId int not null,
	attendeeId int not null,
	foreign key (eventId) references Event(id),
	foreign key (attendeeId) references Attendee(id),
	price decimal(18,2) not null check(price > 0),	
	checkIn datetime,
	createdAt datetime not null default getdate(),
	updatedAt datetime not null default getdate()
);