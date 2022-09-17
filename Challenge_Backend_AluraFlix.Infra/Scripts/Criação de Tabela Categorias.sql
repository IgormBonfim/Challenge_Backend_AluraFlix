USE CHALLENGE_BACKEND_ALURAFLIX;

CREATE TABLE IF NOT EXISTS categorias(
	IdCategoria INT AUTO_INCREMENT,
    TituloCategoria VARCHAR(100) NOT NULL,
    CorCategoria VARCHAR(7) NOT NULL,
    PRIMARY KEY(IdCategoria)
);

ALTER TABLE video
ADD idCategoria int not null,
ADD FOREIGN KEY (idCategoria) REFERENCES categorias(IdCategoria);