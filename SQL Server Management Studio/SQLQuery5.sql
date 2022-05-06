 CREATE TABLE Sotrudniki(

  kod int IDENTITY(1,1) NOT NULL,
  FIO varchar(50) NOT NULL,
  oklad money NOT NULL,
  dolznost varchar(50) NOT NULL,
  PRIMARY KEY([kod])
);