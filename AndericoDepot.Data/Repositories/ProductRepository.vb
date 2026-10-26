Imports System.Data
Imports Microsoft.Data.SqlClient
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Helpers

Namespace Repositories
    Public Class ProductRepository

        Public Function GetAllProducts() As List(Of Product)
            Dim list As New List(Of Product)

            Using conn = ConnectionHelper.GetConnection()
                Using cmd As New SqlCommand("
                    SELECT p.*, c.CategoryName, u.UnitName
                    FROM Products p
                    LEFT JOIN ProductCategories c ON p.CategoryId = c.CategoryId
                    INNER JOIN UnitsOfMeasure u ON p.UnitId = u.UnitId
                    ORDER BY p.ProductName", conn)

                    conn.Open()
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(MapProduct(reader))
                        End While
                    End Using
                End Using
            End Using

            Return list
        End Function

        Public Function GetProductById(productId As Integer) As Product
            Using conn = ConnectionHelper.GetConnection()
                Using cmd As New SqlCommand("
                    SELECT p.*, c.CategoryName, u.UnitName
                    FROM Products p
                    LEFT JOIN ProductCategories c ON p.CategoryId = c.CategoryId
                    INNER JOIN UnitsOfMeasure u ON p.UnitId = u.UnitId
                    WHERE p.ProductId = @ProductId", conn)

                    cmd.Parameters.AddWithValue("@ProductId", productId)
                    conn.Open()

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapProduct(reader)
                        End If
                    End Using
                End Using
            End Using
            Return Nothing
        End Function

        Public Function AddProduct(product As Product) As Integer
            Using conn = ConnectionHelper.GetConnection()
                Using cmd As New SqlCommand("
                    INSERT INTO Products 
                    (ProductCode, ProductName, Brand, CategoryId, Size, PackagingType, 
                     UnitId, PurchasePrice, SellingPrice, ReorderLevel, CurrentStock, Status)
                    VALUES 
                    (@ProductCode, @ProductName, @Brand, @CategoryId, @Size, @PackagingType,
                     @UnitId, @PurchasePrice, @SellingPrice, @ReorderLevel, 0, @Status);
                    SELECT SCOPE_IDENTITY();", conn)

                    AddProductParameters(cmd, product)
                    conn.Open()
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Public Sub UpdateProduct(product As Product)
            Using conn = ConnectionHelper.GetConnection()
                Using cmd As New SqlCommand("
                    UPDATE Products SET
                        ProductCode = @ProductCode,
                        ProductName = @ProductName,
                        Brand = @Brand,
                        CategoryId = @CategoryId,
                        Size = @Size,
                        PackagingType = @PackagingType,
                        UnitId = @UnitId,
                        PurchasePrice = @PurchasePrice,
                        SellingPrice = @SellingPrice,
                        ReorderLevel = @ReorderLevel,
                        Status = @Status,
                        UpdatedAt = GETDATE()
                    WHERE ProductId = @ProductId", conn)

                    cmd.Parameters.AddWithValue("@ProductId", product.ProductId)
                    AddProductParameters(cmd, product)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Private Sub AddProductParameters(cmd As SqlCommand, product As Product)
            cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode)
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName)
            cmd.Parameters.AddWithValue("@Brand", If(product.Brand, DBNull.Value))
            cmd.Parameters.AddWithValue("@CategoryId", If(product.CategoryId, DBNull.Value))
            cmd.Parameters.AddWithValue("@Size", If(product.Size, DBNull.Value))
            cmd.Parameters.AddWithValue("@PackagingType", If(product.PackagingType, DBNull.Value))
            cmd.Parameters.AddWithValue("@UnitId", product.UnitId)
            cmd.Parameters.AddWithValue("@PurchasePrice", product.PurchasePrice)
            cmd.Parameters.AddWithValue("@SellingPrice", product.SellingPrice)
            cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel)
            cmd.Parameters.AddWithValue("@Status", product.Status)
        End Sub

        Private Function MapProduct(reader As SqlDataReader) As Product
            Return New Product With {
                .ProductId = Convert.ToInt32(reader("ProductId")),
                .ProductCode = reader("ProductCode").ToString(),
                .ProductName = reader("ProductName").ToString(),
                .Brand = If(IsDBNull(reader("Brand")), Nothing, reader("Brand").ToString()),
                .CategoryId = If(IsDBNull(reader("CategoryId")), Nothing, Convert.ToInt32(reader("CategoryId"))),
                .CategoryName = If(IsDBNull(reader("CategoryName")), Nothing, reader("CategoryName").ToString()),
                .Size = If(IsDBNull(reader("Size")), Nothing, reader("Size").ToString()),
                .PackagingType = If(IsDBNull(reader("PackagingType")), Nothing, reader("PackagingType").ToString()),
                .UnitId = Convert.ToInt32(reader("UnitId")),
                .UnitName = reader("UnitName").ToString(),
                .PurchasePrice = Convert.ToDecimal(reader("PurchasePrice")),
                .SellingPrice = Convert.ToDecimal(reader("SellingPrice")),
                .ReorderLevel = Convert.ToInt32(reader("ReorderLevel")),
                .CurrentStock = Convert.ToDecimal(reader("CurrentStock")),
                .Status = Convert.ToInt32(reader("Status")),
                .CreatedAt = Convert.ToDateTime(reader("CreatedAt")),
                .UpdatedAt = If(IsDBNull(reader("UpdatedAt")), Nothing, Convert.ToDateTime(reader("UpdatedAt")))
            }
        End Function

    End Class
End Namespace