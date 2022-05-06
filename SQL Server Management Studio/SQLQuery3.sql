
 CREATE TABLE Excursion(
  [id excursion] int IDENTITY(1,1) NOT NULL,
  [vremya provedenia] time(7) NOT NULL,
  grafik date NOT NULL,
  [srok deistvia] date NOT NULL,
  [kod] int NOT NULL,
  price int NOT NULL,
  PRIMARY KEY([id excursion])
);