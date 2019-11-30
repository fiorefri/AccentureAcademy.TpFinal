CREATE DATABASE [AccentureAcademy.DB]
GO

USE [AccentureAcademy.DB]
GO

CREATE TABLE Generos 
(
	Id int primary key identity(1,1),
	Genero varchar(50) unique not null 
);

CREATE TABLE Editoriales
(
	Id int primary key identity(1,1),
	Editorial varchar(30) unique not null 
);

CREATE TABLE Autores
(
	Id int primary key identity(1,1),
	NombreAutor varchar(100) unique not null
);

CREATE TABLE Libros
(
	Id int primary key identity(1,1),
	ISBN varchar(25) not null,
	Titulo varchar(20) not null,
	Descripcion varchar(100) not null,
	Imagen varchar(50) not null,
	Id_Genero int not null,
	Id_Editorial int not null,
	CONSTRAINT FK_LIBROS_GENEROS FOREIGN KEY (Id_Genero) REFERENCES Generos(Id) ON DELETE CASCADE,
	CONSTRAINT FK_LIBROS_EDITORIALES FOREIGN KEY (Id_Editorial) REFERENCES Editoriales(Id) ON DELETE CASCADE
);

CREATE TABLE EscritoPor (
	Id_Libro int not null,
	Id_Autor int not null,
	CONSTRAINT UQ_LIBROS_AUTORES UNIQUE (Id_Libro, Id_Autor),
	CONSTRAINT FK_ESCRITOPOR_LIBROS FOREIGN KEY (Id_Libro) REFERENCES Libros(Id) ON DELETE CASCADE,
	CONSTRAINT FK_ESCRITOPOR_AUTORES FOREIGN KEY (Id_Autor) REFERENCES Autores(Id) ON DELETE CASCADE,
	CONSTRAINT PK_ESCRITOPOR PRIMARY KEY (Id_Libro, Id_Autor)
);

INSERT INTO Generos (Genero)
VALUES 
('Narrativa'),
('Juvenil'),
('Policiales'),
('Cocina'),
('Terapias Alternativas'),
('Salud')

INSERT INTO Editoriales (Editorial)
VALUES 
('Punto de Lectura'),
('Barenhaus'),
('Debolsillo'),
('De la Flor'),
('Kier')

INSERT INTO Autores (NombreAutor)
VALUES 
('Julio Cortázar'),
('Roberto Alrt'),
('Jorge Luis Borges'),
('Adolfo Bioy Casares'),
('Jean Pierre Mourey'),
('José Hernandez'),
('Sergio Aguirre'),
('Claudia Piñeiro'),
('Esther Cross'),
('Sara Gallardo'),
('Griselda Gambaro'),
('Guillermo Saavedra'),
('James E. Robbers'),
('Varro E. Tyler'),
('Enric Corbera'),
('Monserrat Batlló'),
('Teresa Torralva'),
('Catalina Raimondi'),
('María Roca')
