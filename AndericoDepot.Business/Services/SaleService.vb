Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Repositories

Namespace Services
    Public Class SaleService

        Private ReadOnly _saleRepo As New SaleRepository()

        Public Function CreateSale(customerId As Integer?,
                                   customerName As String,
                                   invoiceNumber As String,
                                   discountAmount As Decimal,
                                   paymentMethod As Integer,
                                   amountPaid As Decimal,
                                   notes As String,
                                   details As List(Of SaleDetail),
                                   createdBy As Integer) As Integer

            If details Is Nothing OrElse details.Count = 0 Then
                Throw New Exception("Please add at least one product")
            End If

            For Each d In details
                If d.Quantity <= 0 Then
                    Throw New Exception($"Quantity for {d.ProductName} must be greater than zero")
                End If

                If d.Quantity > d.AvailableStock Then
                    Throw New Exception($"Insufficient stock for {d.ProductName}. Available: {d.AvailableStock}")
                End If
            Next

            Dim totalAmount As Decimal = details.Sum(Function(d) d.Quantity * d.UnitPrice)
            Dim netAmount As Decimal = totalAmount - discountAmount

            If netAmount < 0 Then
                Throw New Exception("Discount cannot be greater than total amount")
            End If

            Return _saleRepo.CreateSale(
                customerId:=customerId,
                customerName:=customerName,
                invoiceNumber:=invoiceNumber,
                totalAmount:=totalAmount,
                discountAmount:=discountAmount,
                netAmount:=netAmount,
                paymentMethod:=paymentMethod,
                amountPaid:=amountPaid,
                notes:=notes,
                details:=details,
                createdBy:=createdBy
            )
        End Function

    End Class
End Namespace