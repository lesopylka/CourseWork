/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [id_exhibits]
      ,[naimenovanie]
      ,[id_zala]
      ,[data_postuplenia]
      ,[avtor]
      ,[material]
      ,[tehnika]
  FROM [museum].[dbo].[Exhibits]