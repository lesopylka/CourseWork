/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [id_excursion]
      ,[vremya_provedenia]
      ,[grafik]
      ,[srok_deistvia]
      ,[kod]
      ,[price]
  FROM [museum].[dbo].[Excursion]