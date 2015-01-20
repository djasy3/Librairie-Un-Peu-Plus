CREATE PROCEDURE ShoppingCartAjoutProduits
(@CartID char(36),
@ProduitID int,
@Attributs char(255))
As
IF EXISTS
(SELECT CartID
 FROM ShoppingCart
 WHERE ProduitID = @ProduitID AND CartID = @CartID)
UPDATE ShoppingCart
SET Quantite = Quantite + 1
WHERE ProduitID = @ProduitID AND CartID = @CartID
ELSE
IF EXISTS (SELECT titre FROM livres WHERE NumLivre = @NumLivre)
INSERT INTO ShoppingCart (CartID, ProduitID, Attributs, Quantite, DateAjoute)
VALUES (@CartID, @ProduitID, @Attributs, 1, GETDATE())

