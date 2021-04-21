SELECT p.name ProductName, c.name CategoryName
FROM products p
         LEFT JOIN products_categories pc ON p.id = pc.product_id
         LEFT JOIN categories c ON pc.category_id = c.id
ORDER BY ProductName, CategoryName;