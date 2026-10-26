Imports Microsoft.Data.SqlClient
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Helpers
Imports AndericoDepot.Common.Enums

Namespace Repositories
    Public Class SaleRepository

        Private ReadOnly _stockRepo As New StockRepository()

        Public Function CreateSale(customerId As Integer?,
                                   customerName As String,
                                   invoiceNumber As String,
                                   totalAmount As Decimal,
                                   discountAmount As Decimal,
                                   netAmount As Decimal,
                                   paymentMethod As Integer,
                                   amountPaid As Decimal,
                                   notes As String,
                                   details As List(Of SaleDetail),
                                   createdBy As Integer) As Integer

            Using conn = ConnectionHelper.GetConnection()
                conn.Open()
                Using transaction = conn.BeginTransaction()
                    Try
                        ' 1. Insert Sale Header
                        Dim saleId As Integer
                        Using cmd As New SqlCommand("
                            INSERT INTO Sales 
                            (CustomerId, CustomerName, InvoiceNumber, TotalAmount, DiscountAmount, 
                             NetAmount, PaymentMethod, AmountPaid, Notes, CreatedBy)
                            VALUES 
                            (@CustomerId, @CustomerName, @InvoiceNumber, @TotalAmount, @DiscountAmount,
                             @NetAmount, @PaymentMethod, @AmountPaid, @Notes, @CreatedBy);
                            SELECT SCOPE_IDENTITY();", conn, transaction)

                            cmd.Parameters.AddWithValue("@CustomerId", If(customerId, DBNull.Value))
                            cmd.Parameters.AddWithValue("@CustomerName", If(String.IsNullOrEmpty(customerName), DBNull.Value, customerName))
                            cmd.Parameters.AddWithValue("@InvoiceNumber", If(String.IsNullOrEmpty(invoiceNumber), DBNull.Value, invoiceNumber))
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
                            cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount)
                            cmd.Parameters.AddWithValue("@NetAmount", netAmount)
                            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                            cmd.Parameters.AddWithValue("@AmountPaid", amountPaid)
                            cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))
                            cmd.Parameters.AddWithValue("@CreatedBy", createdBy)

                            saleId = Convert.ToInt32(cmd.ExecuteScalar())
                        End Using

                        ' 2. Insert Details + Reduce Stock
                        For Each detail In details
                            ' Insert detail
                            Using cmd As New SqlCommand("
                                INSERT INTO SaleDetails (SaleId, ProductId, Quantity, UnitPrice)
                                VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice)", conn, transaction)

                                cmd.Parameters.AddWithValue("@SaleId", saleId)
                                cmd.Parameters.AddWithValue("@ProductId", detail.ProductId)
                                cmd.Parameters.AddWithValue("@Quantity", detail.Quantity)
                                cmd.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice)
                                cmd.ExecuteNonQuery()
                            End Using

                            ' Reduce stock (negative quantity)
                            _stockRepo.AddStockMovement(
                                productId:=detail.ProductId,
                                quantity:=-detail.Quantity,          ' Negative for stock out
                                movementType:=StockMovementType.Sale,
                                unitCost:=Nothing,
                                referenceType:="Sale",
                                referenceId:=saleId,
                                referenceNumber:=invoiceNumber,
                                notes:="Sale",
                                createdBy:=createdBy,
                                conn:=conn,
                                transaction:=transaction
                            )
                        Next

                        transaction.Commit()
                        Return saleId

                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

    End Class
End Namespace