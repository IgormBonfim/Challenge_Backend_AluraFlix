CREATE SCHEMA IF NOT EXISTS Challenge_Backend_AluraFlix;

USE Challenge_Backend_AluraFlix;

CREATE TABLE IF NOT EXISTS Video(
	idVideo INT AUTO_INCREMENT,
    tituloVideo VARCHAR(100) NOT NULL,
    descVideo VARCHAR(100) NOT NULL,
    urlVideo VARCHAR(255) NOT NULL,
    PRIMARY KEY (idVideo)
);