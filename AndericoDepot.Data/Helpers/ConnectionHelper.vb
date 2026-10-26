Imports Microsoft.Data.SqlClient
Imports Microsoft.Extensions.Configuration
Imports System.IO

Namespace Helpers
    Public Class ConnectionHelper

        Private Shared _connectionString As String

        Public Shared ReadOnly Property ConnectionString As String
            Get
                If String.IsNullOrEmpty(_connectionString) Then
                    Dim builder As New ConfigurationBuilder()
                    builder.SetBasePath(Directory.GetCurrentDirectory())
                    builder.AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True)

                    Dim config = builder.Build()
                    _connectionString = config.GetConnectionString("AndericoDepotDB")
                End If
                Return _connectionString
            End Get
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(ConnectionString)
        End Function

    End Class
End Namespace