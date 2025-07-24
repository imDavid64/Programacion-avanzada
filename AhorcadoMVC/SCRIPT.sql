-- CREAR BASE DE DATOS (opcional si ya existe)
CREATE DATABASE AhorcadoDB;
GO

USE AhorcadoDB;
GO

-- ELIMINAR TABLA SI EXISTE (precaución: borra datos)
IF OBJECT_ID('Palabra', 'U') IS NOT NULL
    DROP TABLE Palabra;
GO

-- CREAR TABLA Palabra
CREATE TABLE Palabra (
    Id INT PRIMARY KEY,
    Texto NVARCHAR(100) NOT NULL,
    Dificultad INT NOT NULL CHECK (Dificultad BETWEEN 1 AND 3)
);
GO

CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL UNIQUE,
    Contrasena NVARCHAR(510) NOT NULL,
    Rol NVARCHAR(40) NOT NULL CHECK (Rol = 'Jugador' OR Rol = 'Admin'),
    HighestScore INT NULL DEFAULT(0)
);

CREATE TABLE Partida (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    PalabraId INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT(GETDATE()),
    Resultado NVARCHAR(40) NOT NULL CHECK (Resultado = 'Ganó' OR Resultado = 'Perdió'),
    Puntaje INT NOT NULL,

    CONSTRAINT FK_Partida_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id),
    CONSTRAINT FK_Partida_Palabra FOREIGN KEY (PalabraId) REFERENCES Palabra(Id)
);



-- INSERTS (100 palabras)
INSERT INTO Palabra (Id, Texto, Dificultad) VALUES
(1, N'perro', 1),
(2, N'gato', 1),
(3, N'libro', 1),
(4, N'flor', 1),
(5, N'mesa', 1),
(6, N'silla', 1),
(7, N'pluma', 1),
(8, N'camino', 1),
(9, N'puerta', 1),
(10, N'ratón', 1),
(11, N'pared', 1),
(12, N'cielo', 1),
(13, N'nube', 1),
(14, N'arena', 1),
(15, N'bosque', 1),
(16, N'fruta', 1),
(17, N'ropa', 1),
(18, N'carro', 1),
(19, N'manzana', 1),
(20, N'papel', 1),
(21, N'lápiz', 1),
(22, N'agua', 1),
(23, N'casa', 1),
(24, N'piedra', 1),
(25, N'pasto', 1),
(26, N'juego', 1),
(27, N'reloj', 1),
(28, N'barco', 1),
(29, N'taza', 1),
(30, N'pan', 1),
(31, N'luz', 1),
(32, N'sol', 1),
(33, N'dado', 1),
(34, N'árbol', 2),
(35, N'música', 2),
(36, N'revisión', 2),
(37, N'cántaro', 2),
(38, N'teléfono', 2),
(39, N'historia', 2),
(40, N'limón', 2),
(41, N'fútbol', 2),
(42, N'ventana', 2),
(43, N'césped', 2),
(44, N'cámara', 2),
(45, N'pájaro', 2),
(46, N'pantalla', 2),
(47, N'bebida', 2),
(48, N'herida', 2),
(49, N'zapato', 2),
(50, N'cálido', 2),
(51, N'dólar', 2),
(52, N'película', 2),
(53, N'domingo', 2),
(54, N'balcón', 2),
(55, N'témpano', 2),
(56, N'difícil', 2),
(57, N'rúbrica', 2),
(58, N'recámara', 2),
(59, N'plátano', 2),
(60, N'sábado', 2),
(61, N'céfiro', 2),
(62, N'cómodo', 2),
(63, N'cuadro', 2),
(64, N'rápido', 2),
(65, N'método', 2),
(66, N'héroe', 2),
(67, N'amígdalas', 2),
(68, N'murciélago', 3),
(69, N'jalapeño', 3),
(70, N'esdrújula', 3),
(71, N'hipopótamo', 3),
(72, N'ornitorrinco', 3),
(73, N'pingüino', 3),
(74, N'paralelepípedo', 3),
(75, N'transcripción', 3),
(76, N'aeropuerto', 3),
(77, N'psicología', 3),
(78, N'extrañar', 3),
(79, N'zángano', 3),
(80, N'inmóvil', 3),
(81, N'antártida', 3),
(82, N'almohadilla', 3),
(83, N'subtítulo', 3),
(84, N'reverberar', 3),
(85, N'cráteres', 3),
(86, N'geometría', 3),
(87, N'fósforo', 3),
(88, N'tóxico', 3),
(89, N'cuádriceps', 3),
(90, N'fantástico', 3),
(91, N'catástrofe', 3),
(92, N'parásito', 3),
(93, N'mármoles', 3),
(94, N'oxímoron', 3),
(95, N'anémona', 3),
(96, N'colibrí', 3),
(97, N'crucigrama', 3),
(98, N'hipérbole', 3),
(99, N'huracán', 3),
(100, N'guarida', 3);
GO
