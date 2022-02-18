INSERT INTO Products(productName, supplierId, subCategoryId, [description], unitPrice, unitInStock, size, color)
VALUES('Adidas Originals ZX 750', 3, 6, 'Flexa en ikonisk retrolook med ett par ZX 750 sneakers från adidas Originals.', 1000, 14, '46', 'Mörkröd' ),
('Slim Fit Tech Prep™ pikéskjorta', 5, 5, 'Vår Tech Prep™-kollektion är tillverkad av innovativa, smarta material som gör att du kan röra dig och vara bekväm hela dagen. ', 1299, 4, 'L', 'Vit' )

--Hämta senast tillagd produkt
SELECT * FROM Products WHERE Id = (SELECT MAX(id) FROM Products)