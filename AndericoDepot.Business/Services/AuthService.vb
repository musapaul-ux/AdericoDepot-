Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Repositories

Namespace Services
    Public Class AuthService

        Private ReadOnly _userRepo As New UserRepository()

        Public Function Login(username As String, password As String) As User
            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                Return Nothing
            End If

            Dim user = _userRepo.GetUserByUsername(username.Trim())

            If user Is Nothing Then
                Return Nothing
            End If

            ' Temporary simple password check (we will improve this later with proper hashing)
            If user.PasswordHash = password Then
                _userRepo.UpdateLastLogin(user.UserId)
                Return user
            End If

            Return Nothing
        End Function

    End Class
End Namespace