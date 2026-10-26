Imports AndericoDepot.Common.Enums
Imports AndericoDepot.Data.Repositories

Namespace Services
    Public Class StockService

        Private ReadOnly _stockRepo As New StockRepository()

        Public Sub AddOpeningBalance(productId As Integer, quantity As Decimal, unitCost As Decimal?, notes As String, userId As Integer)
            If quantity <= 0 Then
                Throw New Exception("Quantity must be greater than zero")
            End If

            _stockRepo.AddStockMovement(
                productId:=productId,
                quantity:=quantity,
                movementType:=StockMovementType.OpeningBalance,
                unitCost:=unitCost,
                referenceType:="OpeningBalance",
                referenceId:=Nothing,
                referenceNumber:=Nothing,
                notes:=notes,
                createdBy:=userId
            )
        End Sub

        Public Sub AddAdjustment(productId As Integer, quantity As Decimal, notes As String, userId As Integer)
            ' quantity can be positive (increase) or negative (decrease)
            If quantity = 0 Then
                Throw New Exception("Quantity cannot be zero")
            End If

            _stockRepo.AddStockMovement(
                productId:=productId,
                quantity:=quantity,
                movementType:=StockMovementType.Adjustment,
                unitCost:=Nothing,
                referenceType:="Adjustment",
                referenceId:=Nothing,
                referenceNumber:=Nothing,
                notes:=notes,
                createdBy:=userId
            )
        End Sub

    End Class
End Namespace