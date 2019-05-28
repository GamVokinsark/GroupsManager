Drop table if exists Stud_Group;
Drop table if exists Group_Disc;
Drop table if exists Groupz;
Drop table if exists Faculty;
Drop table if exists Student;
Drop table if exists Disciple;
Drop table if exists Users;

Create table Student (
	SID Int NOT NULL AUTO_INCREMENT,
	SName Varchar(20) NOT NULL,
	Surname Varchar(20) NOT NULL,
	Course Int NOT NULL,
 Primary Key (SID)) ENGINE = InnoDB;

Create table Groupz (
	GID Int NOT NULL AUTO_INCREMENT,
	Starosta Int,
	FID Int NOT NULL,
	GName Varchar(20) NOT NULL,
	IsTemp Bool NOT NULL DEFAULT FALSE,
 Primary Key (GID)) ENGINE = InnoDB;

Create table Disciple (
	DID Int NOT NULL AUTO_INCREMENT,
	Title Varchar(20) NOT NULL,
	ZvitForm Varchar(20) NOT NULL,
	HoursCount Int,
 Primary Key (DID)) ENGINE = InnoDB;

Create table Stud_Group (
	SID Int NOT NULL,
	GID Int NOT NULL,
 Primary Key (SID,GID)) ENGINE = InnoDB;

Create table Group_Disc (
	DID Int NOT NULL,
	GID Int NOT NULL,
 Primary Key (DID,GID)) ENGINE = InnoDB;

Create table Faculty (
	FID Int NOT NULL AUTO_INCREMENT,
	FName Varchar(20) NOT NULL,
 Primary Key (FID)) ENGINE = InnoDB;

-- Таблица для программы, а не для ИС
Create table Users (
	UID Int NOT NULL AUTO_INCREMENT,
	Login Varchar(20) NOT NULL,
	Pswd Char(128) NOT NULL,
	IsAdmin Bool NOT NULL DEFAULT FALSE,
	UNIQUE (Login),
 Primary Key (UID)) ENGINE = InnoDB;


Alter table Stud_Group add Foreign Key (SID) 
references Student (SID) on delete  cascade on update  cascade;
Alter table Groupz add Foreign Key (Starosta) 
references Student (SID) on delete  restrict on update  restrict;
Alter table Stud_Group add Foreign Key (GID) 
references Groupz (GID) on delete  cascade on update  cascade;
Alter table Group_Disc add Foreign Key (GID) 
references Groupz (GID) on delete  cascade on update  cascade;
Alter table Group_Disc add Foreign Key (DID) 
references Disciple (DID) on delete  cascade on update  cascade;
Alter table Groupz add Foreign Key (FID) 
references Faculty (FID) on delete  cascade on update  cascade;

commit;

INSERT INTO Faculty(FName) VALUES
('ElIT'),('FEM');

INSERT INTO Student (SName,Surname,Course) VALUES 
('Odysseus','Willis',4),('Ferdinand','Dalton',4),
('Silas','Clements',4),('Wilma','Nash',4),
('Yuri','Joyner',4),('Benedict','Walls',4),
('Ori','Massey',4),('Ivor','Irwin',4),
('Vanna','Peters',4),('Herman','Finley',4),

('Maggy','Mcbride',3),('Alfreda','Wheeler',3),
('Gemma','Bridges',3),('Davis','Young',3),
('Sara','Barrett',3),('Xenos','Solis',3),
('Britanni','Mack',3),('Jackson','Sargent',3),
('Linda','Hewitt',3),('Brent','Pennington',3),

('Allen','Kirby',2),('Noelle','Acevedo',2),
('Leilani','Schroeder',2),('Jasmine','Brown',2),
('Connor','Armstrong',2),('Maite','Alvarez',2),
('Mason','Whitaker',2),('Aristotle','Kent',2),
('Larissa','Banks',2),('Emerson','Dyer',2),

('Lavinia','Bennett',1),('Geoffrey','Cunningham',1),
('Nadine','Clark',1),('Vaughan','Sanchez',1),
('Kitra','Roth',1),('Andrew','Solis',1),
('Giacomo','Franks',1),('Owen','Aguirre',1),
('Skyler','Lott',1),('Rebekah','Oneal',1),

('Hiram','Clark',4),('Rebecca','Kramer',4),
('Samantha','Stephens',4),('Irene','Heath',4),
('Desiree','Downs',4),('Mechelle','Kerr',4),
('Sean','Lewis',4),('Indigo','Avery',4),
('Sage','Parker',4),('Sawyer','Stout',4),

('Fuller','Valencia',3),('Orla','Woodard',3),
('Imani','Leach',3),('Ifeoma','Horne',3),
('Darryl','Mcclain',3),('Melvin','Santos',3),
('Madison','Wade',3),('Vincent','Faulkner',3),
('Nigel','Kelley',3),('Caleb','Padilla',3),

('Taylor','Mason',4),('Jaquelyn','Cooke',4),
('Eric','Savage',4),('Macon','Mosley',4),
('Amos','Mccray',4),('Abra','Gates',4),
('Amanda','Head',4),('Xena','Lott',4),
('Shoshana','Humphrey',4),('Rajah','Munoz',4),

('Nayda','Cooke',3),('Elvis','Estrada',3),
('Gage','Charles',3),('Deirdre','Saunders',3),
('Brennan','Shelton',3),('Joshua','Townsend',3),
('Steel','Newman',3),('Mufutau','Craig',3),
('Tiger','Dodson',3),('Prescott','Moody',3),

('Maxwell','Davis',2),('Ulysses','Perez',2),
('Calvin','Singleton',2),('Timothy','Rosario',2),
('Margaret','Hardy',2),('Martina','Webb',2),
('Hilel','Talley',2),('Pascale','Fleming',2),
('Isabelle','Richardson',2),('Benedict','Chaney',2),

('Renee','Rivera',1),('Catherine','Diaz',1),
('Rooney','Sanders',1),('Dolan','Burt',1),
('Flavia','Bradford',1),('Chantale','Orr',1),
('Rowan','Bell',1),('Kaseem','Kane',1),
('Ocean','Clark',1),('Rene','Decart',1);

INSERT INTO Groupz(FID,Starosta,GName,IsTemp) VALUES
(1,1,'AN-51',false),(1,11,'AN-61',false),(1,21,'AN-71',false),
(1,31,'AN-81',false),(1,41,'GB-51',false),(1,51,'GB-61',false),
(2,61,'TS-51',false),(2,71,'TS-61',false),(2,81,'TS-71',false),(2,91,'TS-81',false);

INSERT INTO Disciple(Title,ZvitForm,HoursCount) VALUES
('Math','Examen',16),
('Programming','Examen',16),
('TSO','Zalik',14),
('MMDO','Zalik',12),
('Phisics','Zalik',18);

INSERT INTO Stud_Group(SID,GID) VALUES
(1,1),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,1),(10,1),
(11,2),(12,2),(13,2),(14,2),(15,2),(16,2),(17,2),(18,2),(19,2),(20,2),
(21,3),(22,3),(23,3),(24,3),(25,3),(26,3),(27,3),(28,3),(29,3),(30,3),
(31,4),(32,4),(33,4),(34,4),(35,4),(36,4),(37,4),(38,4),(39,4),(40,4),
(41,5),(42,5),(43,5),(44,5),(45,5),(46,5),(47,5),(48,5),(49,5),(50,5),
(51,6),(52,6),(53,6),(54,6),(55,6),(56,6),(57,6),(58,6),(59,6),(60,6),
(61,7),(62,7),(63,7),(64,7),(65,7),(66,7),(67,7),(68,7),(69,7),(70,7),
(71,8),(72,8),(73,8),(74,8),(75,8),(76,8),(77,8),(78,8),(79,8),(80,8),
(81,9),(82,9),(83,9),(84,9),(85,9),(86,9),(87,9),(88,9),(89,9),(90,9),
(91,10),(92,10),(93,10),(94,10),(95,10),(96,10),(97,10),(98,10),(99,10),(100,10);


INSERT INTO Group_Disc(GID,DID) VALUES
(1,2),(1,4),
(2,1),
(3,2),
(4,3),(4,5),
(5,4),(5,5),
(6,2),(6,5),
(7,5),
(8,3),
(9,2),
(10,1);

INSERT INTO Users(Login,Pswd,IsAdmin) VALUES
('root','f21688ca45039bf6593c20660826d56d0f56b977dbac0d15c8267bd5c25f01e058702328d3111a1446f220d69aef39571f46c66db10664c82c35a8e88cc41f2e',True);

commit;


-- Список студентов группы Х.
select SName, Surname, GName, Course
from Student s
join Stud_Group sg on(s.SID=sg.SID)
join Groupz g on(sg.GID=g.GID)
where GName = 'AN-51';

-- Список старост на факультете Х.
select SName, Surname, GName, FName, Course
from Student s
join Groupz g on(g.Starosta=s.SID)
join Faculty f on(f.FID=g.FID)
where FName = 'ElIT';

-- Статистика количества студентов по группам и курсам и факультетам.
select FName, Course, GName, COUNT(s.SID) Num
from Student s
join Stud_Group sg on(s.SID=sg.SID)
join Groupz g on(sg.GID=g.GID)
join Faculty f on(f.FID=g.FID)
where IsTemp = false
group by FName, Course, Gname;

-- У кого из старост больше всего студентов в группе?
select SName, Surname, GName, Course
from Student s
join Groupz g on(s.SID=g.Starosta)
where GName = (select GName
   			   from (select GName, COUNT(sg.SID) Num
                     from Stud_Group sg
                     join Groupz g on(sg.GID=g.GID)
                     group by GName
                     order by 2 DESC
                     Limit 1
                    ) tempTable
              );

-- Дисциплины (в т.ч. по выбору) могут иметь разную продолжительность. Какая средняя учебная нагрузка у студента группы Х.
select GName, AVG(HoursCount) AvgHours
from Groupz g
join Group_Disc gd on(gd.GID=g.GID)
join Disciple d on(d.DID=gd.DID)
where GName = 'GB-61'
group by GName;

-- Топ 3 дисциплин по количеству студентов, которым они читаются.
select Title, COUNT(sg.SID) Num
from Groupz g
join Stud_Group sg on(sg.GID=g.GID)
join Group_Disc gd on(gd.GID=g.GID)
join Disciple d on(d.DID=gd.DID)
group by Title
order by 2 DESC
Limit 3;