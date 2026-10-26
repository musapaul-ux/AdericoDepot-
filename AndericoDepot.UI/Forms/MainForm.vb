Imports AndericoDepot.Common.Models

Public Class MainForm

    Private ReadOnly _currentUser As User

    Public Sub New(user As User)
        InitializeComponent()
        _currentUser = user
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = $"Anderico Investments Depot - {_currentUser.FullName} ({_currentUser.RoleName})"
        Me.WindowState = FormWindowState.Maximized

        ' Simple welcome label (you can design this later)
        Dim lblWelcome As New Label()
        lblWelcome.Text = $"Welcome, {_currentUser.FullName}" & Environment.NewLine &
                          $"Role: {_currentUser.RoleName}"
        lblWelcome.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblWelcome.AutoSize = True
        lblWelcome.Location = New Point(30, 30)
        Me.Controls.Add(lblWelcome)
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        Dim form As New ProductListForm()
        form.ShowDialog()
    End Sub

    Private Sub btnStockAdjustment_Click(sender As Object, e As EventArgs) Handles btnStockAdjustment.Click
        Dim form As New StockAdjustmentForm(_currentUser)
        form.ShowDialog()
    End Sub
    Private Sub btnNewPurchase_Click(sender As Object, e As EventArgs) Handles btnNewPurchase.Click
        Dim form As New PurchaseEntryForm(_currentUser)
        form.ShowDialog()
    End Sub
End Class