CREATE VIEW createParcialClosure AS
SELECT 
	Sale.Date,
	Inventory.ProductId,
	Sale.QuantitySold,
	ROUND(Sale.QuantitySold * COALESCE(SUM(Products.UnitCost), 1), 2) AS TotalSale
FROM Sale 
LEFT JOIN Inventory ON Inventory.Id = Sale.InventoryId
LEFT JOIN Products ON Inventory.ProductId = Products.Id
WHERE Sale.Registered = 0
GROUP BY 
	Sale.Date, 
	Inventory.ProductId,
	Sale.QuantitySold