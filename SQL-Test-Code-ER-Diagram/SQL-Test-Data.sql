INSERT INTO Products(productName, supplierId, subCategoryId, [description], unitPrice, unitInStock, size, color)
VALUES('Adidas Originals ZX 750', 3, 6, 'Flexa en ikonisk retrolook med ett par ZX 750 sneakers fr�n adidas Originals.', 1000, 14, '46', 'M�rkr�d' ),
('Slim Fit Tech Prep� pik�skjorta', 5, 5, 'V�r Tech Prep�-kollektion �r tillverkad av innovativa, smarta material som g�r att du kan r�ra dig och vara bekv�m hela dagen. ', 1299, 4, 'L', 'Vit' )

--H�mta senast tillagd produkt
SELECT * FROM Products WHERE Id = (SELECT MAX(id) FROM Products)