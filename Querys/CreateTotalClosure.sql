--Declarar una tabla temporal para mostrar solo las ventas que se acaban de cerrar
DECLARE @insertedRows TABLE (Id INT, Date DATETIME, ProductId INT, QualitySold INT, TotalSale FLOAT)
--Insertar los registros no cerrados en la tabla de Cierre Total
INSERT INTO TotalClosure (Date, ProductId, QuantitySold, TotalSale)
OUTPUT inserted.Id, inserted.Date, inserted.ProductId, inserted.QuantitySold, inserted.TotalSale
SELECT 
	GETDATE(),
	PartialClosure.ProductId,
	PartialClosure.QuantitySold,
	PartialClosure.TotalSale
FROM PartialClosure
WHERE PartialClosure.Closed = 0 AND CONVERT(date, PartialClosure.Date) = CONVERT(date, GETDATE())
GROUP BY 
	PartialClosure.ProductId, 
	PartialClosure.QuantitySold,
	PartialClosure.TotalSale

--Actualizar los registros a True
UPDATE PartialClosure SET Closed = 1
WHERE Closed = 0


