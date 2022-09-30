USE CHALLENGE_BACKEND_ALURAFLIX;

CREATE TABLE IF NOT EXISTS ApplicationUser(
	IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    UserName NVARCHAR(256) NOT NULL,
    NormalizedUserName NVARCHAR(256) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    NormalizedEmail NVARCHAR(256) NOT NULL,
    EmailConfirmed BIT NOT NULL,
    PasswordHash NVARCHAR(1111) NULL,
    PhoneNumber NVARCHAR(50) NULL,
    PhoneNumberConfirmed BIT NOT NULL,
    TwoFactorEnabled BIT NOT NULL
);

CREATE INDEX Usuario ON ApplicationUser (NormalizedUserName);

CREATE INDEX EmailNormalized On ApplicationUser (NormalizedEmail);

CREATE TABLE IF NOT EXISTS ApplicationRole(
	IdRole INT AUTO_INCREMENT PRIMARY KEY,
    Nome NVARCHAR(256) NOT NULL,
    NormalizedNome NVARCHAR(256) NOT NULL
);

CREATE INDEX ApplicationRoleNormalizedNome ON ApplicationRole (NormalizedNome);

CREATE TABLE IF NOT EXISTS ApplicationUserRole(
    IdUsuario INT NOT NULL,
    IdRole INT NOT NULL,
    PRIMARY KEY (IdUsuario, IdRole),
    CONSTRAINT FK_ApplicationUserRole_USER FOREIGN KEY (IdUsuario) REFERENCES ApplicationUser (IdUsuario),
    CONSTRAINT FK_ApplicationUserRole_ROLE FOREIGN KEY (IdRole) REFERENCES ApplicationRole (IdRole)
);
