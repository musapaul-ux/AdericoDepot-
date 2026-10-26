Imports Microsoft.Data.SqlClient
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Helpers
Imports AndericoDepot.Common.Enums

Namespace Repositories
    Public Class PurchaseRepository

        Private ReadOnly _stockRepo As New StockRepository()

        Public Function CreatePurchase(supplierId As Integer,
                                       invoiceNumber As String,
                                       notes As String,
                                       details As List(Of PurchaseDetail),
                                       createdBy As Integer) As Integer

            Dim totalAmount As Decimal = details.Sum(Function(d) d.Quantity * d.UnitCost)

            Using conn = ConnectionHelper.GetConnection()
                conn.Open()
                Using transaction = conn.BeginTransaction()
                    Try
                        ' 1. Insert Purchase Header
                        Dim purchaseId As Integer
                        Using cmd As New SqlCommand("
                            INSERT INTO Purchases (SupplierId, InvoiceNumber, TotalAmount, Notes, CreatedBy)
                            VALUES (@SupplierId, @InvoiceNumber, @TotalAmount, @Notes, @CreatedBy);
                            SELECT SCOPE_IDENTITY();", conn, transaction)

                            cmd.Parameters.AddWithValue("@SupplierId", supplierId)
                            cmd.Parameters.AddWithValue("@InvoiceNumber", If(String.IsNullOrEmpty(invoiceNumber), DBNull.Value, invoiceNumber))
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
                            cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))
                            cmd.Parameters.AddWithValue("@CreatedBy", createdBy)

                            purchaseId = Convert.ToInt32(cmd.ExecuteScalar())
                        End Using

                        ' 2. Insert Details + Stock Movements
                        For Each detail In details
                            ' Insert detail
                            Using cmd As New SqlCommand("
                                INSERT INTO PurchaseDetails (PurchaseId, ProductId, Quantity, UnitCost)
                                VALUES (@PurchaseId, @ProductId, @Quantity, @UnitCost)", conn, transaction)

                                cmd.Parameters.AddWithValue("@PurchaseId", purchaseId)
                                cmd.Parameters.AddWithValue("@ProductId", detail.ProductId)
                                cmd.Parameters.AddWithValue("@Quantity", detail.Quantity)
                                cmd.Parameters.AddWithValue("@UnitCost", detail.UnitCost)
                                cmd.ExecuteNonQuery()
                            End Using

                            ' Add stock movement (increase stock)
                            _stockRepo.AddStockMovement(
                            productId:=detail.ProductId,
                            quantity:=detail.Quantity,
                            movementType:=StockMovementType.Purchase,
                            unitCost:=detail.UnitCost,
                            referenceType:="Purchase",
                            referenceId:=purchaseId,
                            referenceNumber:=invoiceNumber,
                            notes:="Purchase from supplier",
                            createdBy:=createdBy,
                            conn:=conn,
                            transaction:=transaction
                        )
                        Next

                        transaction.Commit()
                        Return purchaseId

                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

    End Class
End Namespace