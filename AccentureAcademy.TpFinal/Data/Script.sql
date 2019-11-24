CREATE DATABASE [AccentureAcademy.DB]
GO

USE [AccentureAcademy.DB]
GO

CREATE TABLE Generos 
(
	Id int primary key identity(1,1),
	Genero varchar(20) not null unique
);

CREATE TABLE Editoriales
(
	Id int primary key identity(1,1),
	Editorial varchar(30) not null unique
);

CREATE TABLE Niveles
(
	Id int primary key identity(1,1),
	Nivel varchar(20) not null unique
);

CREATE TABLE Autores
(
	Id int primary key identity(1,1),
	Nombre varchar(20) not null,
	Apellido varchar(20) not null,
	FechaNacimiento datetime not null,
	FechaFallecimiento datetime not null,
	Biografia varchar(100) not null,
	Imagen varchar(50) not null
	CONSTRAINT UQ_NOMBRE_APELLIDO_AUTORES UNIQUE (Nombre, Apellido)
);

CREATE TABLE Libros
(
	Id int primary key identity(1,1),
	ISBN varchar(25) not null,
	Titulo varchar(20) not null,
	Descripcion varchar(100) not null,
	Imagen varchar(50) not null,
	FechaPublicacion datetime not null,
	Id_Genero int not null,
	Id_Editorial int not null,
	Id_Nivel int not null,
	CONSTRAINT FK_LIBROS_GENEROS FOREIGN KEY (Id_Genero) REFERENCES Generos(Id) ON DELETE CASCADE,
	CONSTRAINT FK_LIBROS_EDITORIALES FOREIGN KEY (Id_Editorial) REFERENCES Editoriales(Id) ON DELETE CASCADE,
	CONSTRAINT FK_LIBROS_NIVELES FOREIGN KEY (Id_Nivel) REFERENCES Niveles(Id) ON DELETE CASCADE
);

CREATE TABLE EscritoPor (
	Id int primary key identity(1,1),
	Id_Libro int not null,
	Id_Autor int not null
	CONSTRAINT UQ_LIBROS_AUTORES UNIQUE (Id_Libro, Id_Autor),
	CONSTRAINT FK_ESCRITOPOR_LIBROS FOREIGN KEY (Id_Libro) REFERENCES Libros(Id) ON DELETE CASCADE,
	CONSTRAINT FK_ESCRITOPOR_AUTORES FOREIGN KEY (Id_Autor) REFERENCES Autores(Id) ON DELETE CASCADE
);