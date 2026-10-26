Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Repositories

Namespace Services
    Public Class PurchaseService

        Private ReadOnly _purchaseRepo As New PurchaseRepository()

        Public Function CreatePurchase(supplierId As Integer,
                                       invoiceNumber As String,
                                       notes As String,
                                       details As List(Of PurchaseDetail),
                                       createdBy As Integer) As Integer

            If supplierId <= 0 Then
                Throw New Exception("Please select a supplier")
            End If

            If details Is Nothing OrElse details.Count = 0 Then
                Throw New Exception("Please add at least one product")
            End If

            For Each d In details
                If d.Quantity <= 0 Then
                    Throw New Exception("Quantity must be greater than zero")
                End If
                If d.UnitCost < 0 Then
                    Throw New Exception("Unit cost cannot be negative")
                End If
            Next

            Return _purchaseRepo.CreatePurchase(supplierId, invoiceNumber, notes, details, createdBy)
        End Function

    End Class
End Namespace