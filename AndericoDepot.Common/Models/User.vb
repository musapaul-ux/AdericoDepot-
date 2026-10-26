Namespace Models
    Public Class User
        Public Property UserId As Integer
        Public Property Username As String
        Public Property PasswordHash As String
        Public Property FullName As String
        Public Property Email As String
        Public Property Phone As String
        Public Property RoleId As Integer
        Public Property RoleName As String
        Public Property IsActive As Boolean
        Public Property CreatedAt As DateTime
        Public Property LastLogin As DateTime?
    End Class
End Namespace