--Declarar una tabla temporal para mostrar solo las ventas que se acaban de registrar
DECLARE @insertedRows TABLE (Id INT, Date DATETIME, ProductId INT, QualitySold INT, TotalSale FLOAT, Closed INT)
--Insertar las ventas no registradas en la tabla de Cierre Parcial
INSERT INTO PartialClosure (Date, ProductId, QuantitySold, TotalSale, Closed)
OUTPUT inserted.Id, inserted.Date, inserted.ProductId, inserted.QuantitySold, inserted.TotalSale, inserted.Closed
SELECT 
	GETDATE(),
	Inventory.ProductId,
	Sale.QuantitySold,
	ROUND(Sale.QuantitySold * COALESCE(SUM(Products.UnitCost), 1), 2) AS TotalSale,
	0
FROM Sale 
LEFT JOIN Inventory ON Inventory.Id = Sale.InventoryId
LEFT JOIN Products ON Inventory.ProductId = Products.Id
WHERE Sale.Registered = 0
GROUP BY 
	Sale.Date, 
	Inventory.ProductId,
	Sale.QuantitySold

--Actualizar las ventas a "Registered = True"
UPDATE Sale SET Registered = 1
WHERE Registered = 0


