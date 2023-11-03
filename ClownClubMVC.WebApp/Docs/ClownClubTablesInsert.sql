CREATE TABLE usersLoggin(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	apellido VARCHAR(100)NOT NULL,
	email VARCHAR(100) NOT NULL,
	nick VARCHAR(20) NOT NULL
);

INSERT INTO usersLoggin(name, apellido, email, nick)
VALUES
	('Juan', 'Pérez', 'juan@example.com', 'juanperez'),
	('María', 'Gómez', 'maria@example.com', 'mariagomez'),
	('Carlos', 'López', 'carlos@example.com', 'carloslopez'),
	('Laura', 'Ramírez', 'laura@example.com', 'lauraramirez'),
	('Luis', 'Martínez', 'luis@example.com', 'luismartinez');

CREATE TABLE passwordLoggin(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	userLoggin_id INT NOT NULL,
	passwordLoggin VARCHAR (10) NOT NULL,
	FOREIGN KEY (userLoggin_id) REFERENCES usersLoggin (id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO passwordLoggin (userLoggin_id, passwordLoggin)
VALUES 
	(1, 'Juanpe1.'),
	(2, 'Margo2.'),
	(3, 'Carlop3.'),
	(4, 'Lauram4.'),
	(5, 'Lumar5.');

CREATE TABLE datosBancarios(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	userLoggin_id INT NOT NULL,
	entidad VARCHAR (50) NOT NULL,
	numTarjeta VARCHAR(10) NOT NULL,
	f_caducidad DATE NOT NULL,
	FOREIGN KEY (userLoggin_id) REFERENCES usersLoggin (id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO datosBancarios (userLoggin_id, entidad, numTarjeta, f_caducidad)
VALUES 
	(1, 'CaixaBank', '1234567890', '2024-12-31'),
	(2, 'BBVA', '9876543210', '2023-11-30'),
	(3, 'TriodosBank', '5678901234', '2024-08-15'),
	(4, 'Santander', '1122334455', '2025-05-20'),
	(5, 'Ibercaja', '9988776655', '2026-02-28');

CREATE TABLE person(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	userLoggin_id INT NOT NULL,
	age INT,
	rolePerson VARCHAR(20) NOT NULL
	FOREIGN KEY (userLoggin_id) REFERENCES usersLoggin (id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO person (userLoggin_id, age, rolePerson)
VALUES
	(1, 23, 'user'),
	(2, 44, 'administrator'),
	(3, 25, 'administrator'),
	(4, 31, 'user'),
	(5, 53, 'user');

CREATE TABLE administratorApp(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	person_id INT NOT NULL,
	permissionsAdmin VARCHAR(255),
	FOREIGN KEY (person_id) REFERENCES person (id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO administratorApp(person_id, permissionsAdmin)
VALUES
	(2, 'Read, Write'),
	(3, 'Update, Delete');

CREATE TABLE userApp(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	person_id INT NOT NULL,
	FOREIGN KEY (person_id) REFERENCES person (id) ON DELETE CASCADE ON UPDATE CASCADE
)
INSERT INTO userApp(person_id)
VALUES
	(1),
	(4),
	(5);

CREATE TABLE content(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	title VARCHAR (255) NOT NULL,
	duration INT NOT NULL,
	size DECIMAL(5, 2) NOT NULL,
	viewsContent INT,
	languageContent VARCHAR (20),
	formatContent VARCHAR (25),
	producer VARCHAR (50)
);
INSERT INTO content(title, duration, size, viewsContent, languageContent, formatContent, producer)
VALUES
	('Días de fútbol', 125, 1.6, 2, 'Español', '.mp4', 'DeseoCo'),
	('Cuarto Milenial', 53, 0.8, 1, 'Español', '.mp3', 'SpotifyCo'),
	('Mentiras pasajeras', 480, 6.7, 3, 'Español', '.mp4', 'DeseoCo'),
	('El club de la comedia', 63, 2.5, 5, 'Español', '.mp4', 'AragonCo'),
	('Airbag', 127, 2.6, 20, 'Español', '.mp4', 'MaquiCo');

CREATE TABLE userApp_content(
	id_userApp int,
	id_content int,
	FOREIGN KEY (id_userApp) REFERENCES userApp (id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (id_content) REFERENCES content (id) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY (id_userApp, id_content)
);
INSERT INTO userApp_content (id_userApp, id_content)
VALUES
	(1,2),
	(1, 5),
	(2, 1),
	(2, 2),
	(3, 3);

CREATE TABLE film(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	content_id INT NOT NULL,
	actor VARCHAR (255),
	actress VARCHAR (255),
	FOREIGN KEY (content_id) REFERENCES content (id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO film(content_id, actor, actress)
VALUES
	(1, 'Fernando Tejero, Ernesto Alterio, Alberto San Juan', 'Nathalie Poza, Pilar Castro, Natalia Verbeke'),
	(5, 'Karra Elejalde, Manuel Manquiña, Luis Cuenca', 'Vicenta Ndongo, Rosa Maria Sarda, Raquel Meroño');

CREATE TABLE serie(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	content_id INT NOT NULL,
	actor VARCHAR (255),
	actress VARCHAR (255),
	FOREIGN KEY (content_id) REFERENCES content (id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO serie (content_id, actor, actress)
VALUES
	(3, 'Hugo Silva, Quim Gutierrez, Pedro Casablanc', 'Susi Sanchez, Maria Botto, Pilar Castro');

CREATE TABLE tvProgram(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	content_id INT NOT NULL,
	presenter VARCHAR (255),
	collaborator VARCHAR (255),
	FOREIGN KEY (content_id) REFERENCES content (id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO tvProgram(content_id, presenter, collaborator)
VALUES
	(4, 'Eva Hache', 'Berto Romero, Joaquín Reyes, Yolanda Ramos');


CREATE TABLE podcast(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	content_id INT NOT NULL,
	presenter VARCHAR (255),
	collaborator VARCHAR (255),
	FOREIGN KEY (content_id) REFERENCES content (id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO podcast(content_id, presenter, collaborator)
VALUES
	(2, 'Lalachus, Andrea Compton', 'Ger, Melo Moreno, Carolina Iglesias')