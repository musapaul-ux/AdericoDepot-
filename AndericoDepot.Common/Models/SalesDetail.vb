Namespace Models
    Public Class SaleDetail
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property Quantity As Decimal
        Public Property UnitPrice As Decimal
        Public Property LineTotal As Decimal
        Public Property AvailableStock As Decimal      ' For validation
    End Class
End Namespace