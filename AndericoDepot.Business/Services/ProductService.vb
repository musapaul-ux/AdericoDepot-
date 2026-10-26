Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Repositories

Namespace Services
    Public Class ProductService

        Private ReadOnly _productRepo As New ProductRepository()

        Public Function GetAllProducts() As List(Of Product)
            Return _productRepo.GetAllProducts()
        End Function

        Public Function GetProductById(productId As Integer) As Product
            Return _productRepo.GetProductById(productId)
        End Function

        Public Function AddProduct(product As Product) As Integer
            ' Basic validation
            If String.IsNullOrWhiteSpace(product.ProductCode) Then
                Throw New Exception("Product Code is required")
            End If

            If String.IsNullOrWhiteSpace(product.ProductName) Then
                Throw New Exception("Product Name is required")
            End If

            If product.UnitId <= 0 Then
                Throw New Exception("Unit of Measure is required")
            End If

            If product.SellingPrice < 0 OrElse product.PurchasePrice < 0 Then
                Throw New Exception("Prices cannot be negative")
            End If

            Return _productRepo.AddProduct(product)
        End Function

        Public Sub UpdateProduct(product As Product)
            If product.ProductId <= 0 Then
                Throw New Exception("Invalid Product")
            End If

            If String.IsNullOrWhiteSpace(product.ProductCode) Then
                Throw New Exception("Product Code is required")
            End If

            If String.IsNullOrWhiteSpace(product.ProductName) Then
                Throw New Exception("Product Name is required")
            End If

            _productRepo.UpdateProduct(product)
        End Sub

    End Class
End Namespace