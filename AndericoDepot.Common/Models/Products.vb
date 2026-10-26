Namespace Models
    Public Class Product
        Public Property ProductId As Integer
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property Brand As String
        Public Property CategoryId As Integer?
        Public Property CategoryName As String
        Public Property Size As String
        Public Property PackagingType As String
        Public Property UnitId As Integer
        Public Property UnitName As String
        Public Property PurchasePrice As Decimal
        Public Property SellingPrice As Decimal
        Public Property ReorderLevel As Integer
        Public Property CurrentStock As Decimal
        Public Property Status As Integer
        Public Property CreatedAt As DateTime
        Public Property UpdatedAt As DateTime?
    End Class
End Namespace