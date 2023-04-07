CREATE VIEW viewInventory AS
SELECT 
Inventory.Id, 
Inventory.ProductId, 
Inventory.Quantity, 
Inventory.Quantity - COALESCE(SUM(Sale.QuantitySold), 0) AS RealQuantity
FROM Inventory
LEFT JOIN Sale ON Inventory.Id = InventoryId
GROUP BY Inventory.Id, Inventory.ProductId, Inventory.Quantity;