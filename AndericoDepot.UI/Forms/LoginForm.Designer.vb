<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblUsername = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        lblPassword = New Label()
        lblMessage = New Label()
        btnLogin = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = SystemColors.HotTrack
        lblTitle.ForeColor = SystemColors.ControlLightLight
        lblTitle.Location = New Point(168, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Padding = New Padding(2)
        lblTitle.Size = New Size(306, 29)
        lblTitle.TabIndex = 0
        lblTitle.Text = "ANDERICO INVESTMENT DEPOT LTD"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(250, 57)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(99, 25)
        lblUsername.TabIndex = 1
        lblUsername.Text = "User Name"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(196, 96)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(212, 31)
        txtUsername.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(196, 198)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(212, 31)
        txtPassword.TabIndex = 3
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(250, 153)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(87, 25)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Password"
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Location = New Point(250, 376)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(0, 25)
        lblMessage.TabIndex = 5
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(237, 289)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(112, 46)
        btnLogin.TabIndex = 6
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(586, 450)
        Controls.Add(btnLogin)
        Controls.Add(lblMessage)
        Controls.Add(lblPassword)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(lblUsername)
        Controls.Add(lblTitle)
        Name = "LoginForm"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnLogin As Button

End Class
