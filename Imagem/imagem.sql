CREATE DATABASE IMAGEM
Go

USE IMAGEM
GO

CREATE TABLE exemplo(idexemplo int identity(1,1) primary key,
					Titulo nvarchar(250), descricao nvarchar(max),
					caminhoImagem nvarchar(max), status char)
go