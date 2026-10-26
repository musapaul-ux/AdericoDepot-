Imports System.Data
Imports Microsoft.Data.SqlClient
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Helpers

Namespace Repositories
    Public Class UserRepository

        Public Function GetUserByUsername(username As String) As User
            Dim user As User = Nothing

            Using conn As SqlConnection = ConnectionHelper.GetConnection()
                Using cmd As New SqlCommand("
                    SELECT u.UserId, u.Username, u.PasswordHash, u.FullName, 
                           u.Email, u.Phone, u.RoleId, r.RoleName, 
                           u.IsActive, u.CreatedAt, u.LastLogin
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleId = r.RoleId
                    WHERE u.Username = @Username AND u.IsActive = 1", conn)

                    cmd.Parameters.AddWithValue("@Username", username)

                    conn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            user = New User With {
                                .UserId = Convert.ToInt32(reader("UserId")),
                                .Username = reader("Username").ToString(),
                                .PasswordHash = reader("PasswordHash").ToString(),
                                .FullName = reader("FullName").ToString(),
                                .Email = If(IsDBNull(reader("Email")), Nothing, reader("Email").ToString()),
                                .Phone = If(IsDBNull(reader("Phone")), Nothing, reader("Phone").ToString()),
                                .RoleId = Convert.ToInt32(reader("RoleId")),
                                .RoleName = reader("RoleName").ToString(),
                                .IsActive = Convert.ToBoolean(reader("IsActive")),
                                .CreatedAt = Convert.ToDateTime(reader("CreatedAt")),
                                .LastLogin = If(IsDBNull(reader("LastLogin")), Nothing, Convert.ToDateTime(reader("LastLogin")))
                            }
                        End If
                    End Using
                End Using
            End Using

            Return user
        End Function

        Public Sub UpdateLastLogin(userId As Integer)
            Using conn As SqlConnection = ConnectionHelper.GetConnection()
                Using cmd As New SqlCommand("UPDATE Users SET LastLogin = GETDATE() WHERE UserId = @UserId", conn)
                    cmd.Parameters.AddWithValue("@UserId", userId)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

    End Class
End Namespace