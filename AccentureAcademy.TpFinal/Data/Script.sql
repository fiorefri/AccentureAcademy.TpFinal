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
	Titulo varchar(100) not null,
	Descripcion varchar(1000) not null,
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

INSERT INTO Libros (ISBN, Titulo, Descripcion, Id_Genero, Id_Editorial)
VALUES
(9789875782211, 'Rayuela', 'El amor turbulento de Oliveira y La Maga, los amigos del Club de la Serpiente, las caminatas por París en busca del cielo y el infierno tienen su reverso en la aventura simétrica de Oliveira, Talita y Traveler en un Buenos Aires teñido por el recuerdo.
La aparición de Rayuela en 1963 fue una verdadera revolución dentro de la novelística en lengua española: por primera vez, un escritor llevaba hasta las últimas consecuencias la voluntad de transgredir el orden tradicional de una historia y el lenguaje para contarla. El resultado es este libro único, abierto a múltiples lecturas, lleno de humor, de riesgo y de una originalidad sin precedentes.',
1, 1),
(9789875666474, 'Ficciones', 'Ficciones es quizás el libro más reconocido dejorge Luis Borges. Entre los cuentos que se reúnen aquí hay algunos de corte policial, como La muerte y la brújula y muchos pertenecientes al género fantástico, como Las ruinas circulares o El Sur, acaso su mejor relato, en palabras del mismo autor. Está compuesto por los libros El jardín de senderos que se bifurcan (1941) y Artificios (1944), considerados piezas fundamentales del universo borgeano.',
1, 3),
(9789505159000, 'La Invención de Morel', 'Un fugitivo llega a una isla desierta. No se dice quién lo persigue ni cómo llega. El lugar es extraño: hay una mansión suntuosa, que parece abandonada, en cuyo sótano se conserva reluciente una compleja maquinaria de funciones incomprensibles para él. Cuando la activa, advierte que no está solo, como cree: un grupo de veraneantes, reunidos por un tal Morel, empieza a circular por el lugar como si participaran de una fiesta cuyo ritual parece repetirse indefinidamente.',
1, 3),
(9789875455306, 'Los Vecinos Mueren en las Novelas', 'Porque todo comenzará así: un hombre llega a la casa de una anciana absolutamente desconocida. Él mismo no sabe, hasta que llama a la puerta, que ha decidido matarla.',
2, 1),
(9789870409878, 'Tuya', 'Un corazón dibujado con rouge, cruzado por un te quiero y firmado Tuya le revela a Inés que su marido la engaña. Lo que sigue a continuación no sólo es un policial vertiginoso y atrapante, sino un retrato implacable de la vida familiar de la clase media.
Claudia Piñeiro capta con genialidad los tonos de las voces de la sociedad argentina. Y entre ellas la de un ama de casa dispuesta a todo con tal de conservar su matrimonio y las buenas apariencias.',
3, 4),
(9789500763691, 'Los Mejores Cuentos Policiales', 'Jorge Luis Borges y Adolfo Bioy Casares, amigos por más de cincuenta años, compartieron a lo largo de sus vidas una pasión: el género policial. Originalmente publicada en dos volúmenes, la selección de treinta y un textos que reunieron en Los mejores cuentos policiales celebra su amistad y su gusto por el género.',
3, 2),
(9789875781573, 'Cuentos De Escritoras Argentinas', 'Los cuentos que integran este libro indagan diversas posibilidades del vínculo fraterno; reponen insólitas escenas de la historia argentina; capturan la frágil belleza o la fulmínea irrupción del instante; asedian el amor, la melancolía del desencuentro y la inevitable puntualidad de la muerte; exponen la miseria y la soledad, despliegan la incandescencia del erotismo y la a veces insospechada eficacia del deseo. En todos los casos, estos relatos ponen en acción la condición resbalosa de las palabras y hacen andar la máquina de la ficción, el inagotable arte de contar historias.',
1, 2),
(9789500209984, 'REHABILITACION COGNITIVA', 'Esta obra brinda un excelente texto de consulta para todos los profesionales de la salud que trabajen en el ámbito de la rehabilitación de pacientes con enfermedades neurológicas o psiquiátricas que cursen con algún tipo de afectación cognitiva',
6, 5)

INSERT INTO EscritoPor (Id_Libro, Id_Autor)
VALUES
(1, 1),
(2, 3),
(3, 4),
(3, 5),
(4, 7),
(5, 8),
(6, 3),
(6, 4),
(7, 9),
(7, 10),
(7, 11),
(7, 12),
(8, 17),
(8, 18),
(8, 19)