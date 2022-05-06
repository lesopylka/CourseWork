 CREATE TABLE Exhibits(

  [id exhibits] int IDENTITY(1,1) NOT NULL,
  naimenovanie varchar(50) NOT NULL,
  [kod zala] int NOT NULL,
  [data postuplenia] date NOT NULL,
  avtor varchar(50) NOT NULL,
  material varchar(50) NOT NULL,
  tehnika varchar(50) NOT NULL,
  PRIMARY KEY([id exhibits])
);