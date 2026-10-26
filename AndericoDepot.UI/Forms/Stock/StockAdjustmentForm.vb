Imports AndericoDepot.Business.Services
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Helpers
Imports Microsoft.Data.SqlClient

Public Class StockAdjustmentForm

    Private ReadOnly _stockService As New StockService()
    Private ReadOnly _currentUser As User

    Public Sub New(currentUser As User)
        InitializeComponent()
        _currentUser = currentUser
    End Sub

    Private Sub StockAdjustmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Stock Adjustment / Opening Balance"
        Me.StartPosition = FormStartPosition.CenterParent
        rbOpeningBalance.Checked = True
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        cboProduct.Items.Clear()
        cboProduct.DisplayMember = "Text"
        cboProduct.ValueMember = "Value"

        Using conn = ConnectionHelper.GetConnection()
            Using cmd As New SqlCommand("
                SELECT ProductId, ProductCode + ' - ' + ProductName AS DisplayName
                FROM Products 
                WHERE Status = 1
                ORDER BY ProductName", conn)

                conn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        cboProduct.Items.Add(New With {
                            .Text = reader("DisplayName").ToString(),
                            .Value = Convert.ToInt32(reader("ProductId"))
                        })
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cboProduct.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a product", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If numQuantity.Value <= 0 Then
                MessageBox.Show("Quantity must be greater than zero", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim productId As Integer = cboProduct.SelectedItem.Value
            Dim quantity As Decimal = numQuantity.Value
            Dim unitCost As Decimal? = If(numUnitCost.Value > 0, numUnitCost.Value, Nothing)
            Dim notes As String = txtNotes.Text.Trim()

            If rbOpeningBalance.Checked Then
                _stockService.AddOpeningBalance(productId, quantity, unitCost, notes, _currentUser.UserId)
                MessageBox.Show("Opening balance added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                _stockService.AddAdjustment(productId, quantity, notes, _currentUser.UserId)
                MessageBox.Show("Stock adjustment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class