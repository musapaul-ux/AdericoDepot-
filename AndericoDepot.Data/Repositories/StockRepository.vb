Imports Microsoft.Data.SqlClient
Imports AndericoDepot.Data.Helpers

Namespace Repositories
    Public Class StockRepository

        ''' <summary>
        ''' Adds a stock movement and updates CurrentStock.
        ''' Can work standalone or inside an existing transaction.
        ''' </summary>
        Public Sub AddStockMovement(productId As Integer,
                                    quantity As Decimal,
                                    movementType As Integer,
                                    unitCost As Decimal?,
                                    referenceType As String,
                                    referenceId As Integer?,
                                    referenceNumber As String,
                                    notes As String,
                                    createdBy As Integer,
                                    Optional conn As SqlConnection = Nothing,
                                    Optional transaction As SqlTransaction = Nothing)

            Dim ownConnection As Boolean = False

            If conn Is Nothing Then
                conn = ConnectionHelper.GetConnection()
                conn.Open()
                ownConnection = True
            End If

            Try
                ' 1. Insert movement
                Using cmd As New SqlCommand("
                    INSERT INTO StockMovements 
                    (MovementType, ProductId, Quantity, UnitCost, ReferenceType, 
                     ReferenceId, ReferenceNumber, Notes, CreatedBy)
                    VALUES 
                    (@MovementType, @ProductId, @Quantity, @UnitCost, @ReferenceType,
                     @ReferenceId, @ReferenceNumber, @Notes, @CreatedBy)", conn, transaction)

                    cmd.Parameters.AddWithValue("@MovementType", movementType)
                    cmd.Parameters.AddWithValue("@ProductId", productId)
                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@UnitCost", If(unitCost.HasValue, unitCost.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@ReferenceType", If(String.IsNullOrEmpty(referenceType), DBNull.Value, referenceType))
                    cmd.Parameters.AddWithValue("@ReferenceId", If(referenceId.HasValue, referenceId.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@ReferenceNumber", If(String.IsNullOrEmpty(referenceNumber), DBNull.Value, referenceNumber))
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy)

                    cmd.ExecuteNonQuery()
                End Using

                ' 2. Update CurrentStock
                Using cmd As New SqlCommand("
                    UPDATE Products 
                    SET CurrentStock = CurrentStock + @Quantity,
                        UpdatedAt = GETDATE()
                    WHERE ProductId = @ProductId", conn, transaction)

                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@ProductId", productId)
                    cmd.ExecuteNonQuery()
                End Using

            Finally
                If ownConnection Then
                    conn.Close()
                    conn.Dispose()
                End If
            End Try
        End Sub

    End Class
End Namespace