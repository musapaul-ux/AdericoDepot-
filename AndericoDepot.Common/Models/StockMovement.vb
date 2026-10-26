Namespace Models
    Public Class StockMovement
        Public Property MovementId As Long
        Public Property MovementDate As DateTime
        Public Property MovementType As Integer
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property ProductCode As String
        Public Property Quantity As Decimal
        Public Property UnitCost As Decimal?
        Public Property ReferenceType As String
        Public Property ReferenceId As Integer?
        Public Property ReferenceNumber As String
        Public Property Notes As String
        Public Property CreatedBy As Integer
        Public Property CreatedByName As String
        Public Property CreatedAt As DateTime
    End Class
End Namespace