CREATE DATABASE RecreationalClub;

USE RecreationalClub;

-- Tabla de rolesclientes
CREATE TABLE Roles (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaUltimaModificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Tabla de usuarios autorizados
CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    RolId INT NOT NULL,
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

-- Tabla de tipos de clientes
CREATE TABLE TiposClientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Tipo VARCHAR(50) NOT NULL
);

-- Tabla de clientes
CREATE TABLE Clientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    TipoClienteId INT NOT NULL,
    FOREIGN KEY (TipoClienteId) REFERENCES TiposClientes(Id)
);

-- Tabla de tipos de contacto
CREATE TABLE TiposContacto (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Tipo VARCHAR(50) NOT NULL,
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME
);

-- Tabla de información de contacto
CREATE TABLE InformacionContacto (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ClienteId INT NOT NULL,
    TipoContactoId INT NOT NULL,
    Informacion VARCHAR(255) NOT NULL,
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (TipoContactoId) REFERENCES TiposContacto(Id)
);

-- Tabla de registros de acceso
CREATE TABLE RegistrosAcceso (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ClienteId INT NOT NULL,
    FechaHoraEntrada DATETIME NOT NULL,
    FechaHoraSalida DATETIME,
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Tabla de marcas de vehículos
CREATE TABLE Marcas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME
);

-- Tabla de modelos de vehículos
CREATE TABLE Modelos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    MarcaId INT NOT NULL,
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME,
    FOREIGN KEY (MarcaId) REFERENCES Marcas(Id)
);

-- Tabla de vehículos
CREATE TABLE Vehiculos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    MarcaId INT NOT NULL,
    ModeloId INT NOT NULL,
    Placa VARCHAR(20) NOT NULL,
    ClienteId INT NOT NULL,
    ParqueoValetId INT NOT NULL,
    CodigoUbicacion VARCHAR(20) NOT NULL,
    FechaHoraEntrada DATETIME NOT NULL,
    FechaHoraSalida DATETIME,
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME,
    FOREIGN KEY (MarcaId) REFERENCES Marcas(Id),
    FOREIGN KEY (ModeloId) REFERENCES Modelos(Id),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Tabla de parqueo valet
CREATE TABLE ParqueoValet (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME
);

-- Tabla de códigos de ubicación de estacionamiento
CREATE TABLE CodigosUbicacion (
    Codigo VARCHAR(20) PRIMARY KEY,
    Descripcion VARCHAR(255),
    UsuarioId INT,
    FechaCreacion DATETIME,
    FechaUltimaModificacion DATETIME
);

CREATE TABLE Permisos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaUltimaModificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

	
CREATE TABLE Tokens (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UsuarioId INT NOT NULL,
    Token VARCHAR(255) NOT NULL,
    RefreshToken VARCHAR(255) NOT NULL,
    ExpiryDate TIMESTAMP NOT NULL,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaUltimaModificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

CREATE TABLE RolPermisos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    RolId INT NOT NULL,
    PermisoId INT NOT NULL,
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE CASCADE,
    FOREIGN KEY (PermisoId) REFERENCES Permisos(Id) ON DELETE CASCADE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaUltimaModificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);


-- Insertar roles
INSERT INTO Roles (Nombre) VALUES ('Admin'), ('PersonalAutorizado');

-- Insertar tipos de clientes
INSERT INTO TiposClientes (Tipo) VALUES ('Visitante'), ('Miembro');

--Insert de permisos
INSERT INTO Permisos (Nombre, Descripcion)
VALUES 
('GET', 'Permiso para obtener la lista de recursos'),
('POST', 'Permiso para agregar nuevos recursos'),
('DELETE', 'Permiso para eliminar recursos'),
('PUT', 'Permiso para Editar');

-- Permisos para el rol Administrador (RolId = 1)
INSERT INTO RolPermisos (RolId, PermisoId, FechaCreacion, FechaUltimaModificacion)
VALUES 
(1, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP), -- Asociar "Ver" al rol Administrador
(1, 2, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP), -- Asociar "Editar" al rol Administrador
(1, 3, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP); -- Asociar "Eliminar" al rol Administrador
