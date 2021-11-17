create database pelicula;
use pelicula;
create table peliculas ( 
ID INT PRIMARY KEY IDENTITY (1, 1),
 titulo VARCHAR(60),
 fechaLanzamiento DATETIME, 
 genero VARCHAR(60),
 precio DECIMAL, director_ID int FOREIGN KEY (director_ID) REFERENCES directores(ID)
 ); create table directores( ID INT PRIMARY KEY IDENTITY (1, 1), Nombre VARCHAR(60),
 fechaNacimiento DATETIME, 
 Pais VARCHAR(80), )