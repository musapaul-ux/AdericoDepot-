Imports AndericoDepot.Business.Services
Imports AndericoDepot.Common.Models

Public Class LoginForm

    Private ReadOnly _authService As New AuthService()

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Anderico Investments Depot - Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        lblMessage.Text = ""
        lblMessage.ForeColor = Color.Red
        txtPassword.PasswordChar = "*"c
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            lblMessage.Text = ""

            Dim username As String = txtUsername.Text.Trim()
            Dim password As String = txtPassword.Text

            If String.IsNullOrWhiteSpace(username) Then
                lblMessage.Text = "Please enter username"
                txtUsername.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(password) Then
                lblMessage.Text = "Please enter password"
                txtPassword.Focus()
                Return
            End If

            ' Disable button while processing
            btnLogin.Enabled = False
            btnLogin.Text = "Logging in..."

            Dim user As User = _authService.Login(username, password)

            If user IsNot Nothing Then
                ' Login successful
                MessageBox.Show($"Welcome {user.FullName}!", "Login Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Open Main Form and hide login
                Dim mainForm As New MainForm(user)
                mainForm.Show()
                Me.Hide()
            Else
                lblMessage.Text = "Invalid username or password"
                txtPassword.Clear()
                txtPassword.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnLogin.Enabled = True
            btnLogin.Text = "Login"
        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

End Class