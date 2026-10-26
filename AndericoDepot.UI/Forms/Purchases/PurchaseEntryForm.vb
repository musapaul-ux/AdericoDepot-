Imports AndericoDepot.Business.Services
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Helpers
Imports Microsoft.Data.SqlClient

Public Class PurchaseEntryForm

    Private ReadOnly _purchaseService As New PurchaseService()
    Private ReadOnly _currentUser As User
    Private _details As New List(Of PurchaseDetail)

    Public Sub New(currentUser As User)
        InitializeComponent()
        _currentUser = currentUser
    End Sub

    Private Sub PurchaseEntryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "New Purchase (Stock In)"
        Me.StartPosition = FormStartPosition.CenterParent
        dtpPurchaseDate.Value = DateTime.Today
        LoadSuppliers()
        LoadProducts()
        RefreshGrid()
    End Sub

    Private Sub LoadSuppliers()
        cboSupplier.Items.Clear()
        cboSupplier.DisplayMember = "Text"
        cboSupplier.ValueMember = "Value"

        Using conn = ConnectionHelper.GetConnection()
            Using cmd As New SqlCommand("SELECT SupplierId, SupplierName FROM Suppliers WHERE IsActive = 1 ORDER BY SupplierName", conn)
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        cboSupplier.Items.Add(New With {
                            .Text = reader("SupplierName").ToString(),
                            .Value = Convert.ToInt32(reader("SupplierId"))
                        })
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadProducts()
        cboProduct.Items.Clear()
        cboProduct.DisplayMember = "Text"
        cboProduct.ValueMember = "Value"

        Using conn = ConnectionHelper.GetConnection()
            Using cmd As New SqlCommand("
                SELECT ProductId, ProductCode + ' - ' + ProductName AS DisplayName, SellingPrice
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

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If cboProduct.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a product", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If numQuantity.Value <= 0 Then
            MessageBox.Show("Quantity must be greater than zero", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productId As Integer = cboProduct.SelectedItem.Value
        Dim productName As String = cboProduct.SelectedItem.Text

        ' Check if product already exists in the list
        Dim existing = _details.FirstOrDefault(Function(d) d.ProductId = productId)
        If existing IsNot Nothing Then
            existing.Quantity += numQuantity.Value
            existing.UnitCost = numUnitCost.Value
            existing.LineTotal = existing.Quantity * existing.UnitCost
        Else
            _details.Add(New PurchaseDetail With {
                .ProductId = productId,
                .ProductName = productName,
                .Quantity = numQuantity.Value,
                .UnitCost = numUnitCost.Value,
                .LineTotal = numQuantity.Value * numUnitCost.Value
            })
        End If

        RefreshGrid()
        ClearItemInputs()
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvItems.CurrentRow Is Nothing Then
            MessageBox.Show("Please select an item to remove", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selected = CType(dgvItems.CurrentRow.DataBoundItem, PurchaseDetail)
        _details.Remove(selected)
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        dgvItems.DataSource = Nothing
        dgvItems.DataSource = _details.ToList()

        If dgvItems.Columns.Contains("ProductId") Then
            dgvItems.Columns("ProductId").Visible = False
        End If

        UpdateTotal()
    End Sub

    Private Sub UpdateTotal()
        Dim total = _details.Sum(Function(d) d.LineTotal)
        lblTotal.Text = "Total: " & total.ToString("N2")
    End Sub

    Private Sub ClearItemInputs()
        cboProduct.SelectedIndex = -1
        numQuantity.Value = 1
        numUnitCost.Value = 0
        cboProduct.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cboSupplier.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a supplier", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _details.Count = 0 Then
                MessageBox.Show("Please add at least one product", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim supplierId As Integer = cboSupplier.SelectedItem.Value
            Dim invoiceNumber As String = txtInvoiceNumber.Text.Trim()
            Dim notes As String = txtNotes.Text.Trim()

            Dim purchaseId = _purchaseService.CreatePurchase(
                supplierId:=supplierId,
                invoiceNumber:=invoiceNumber,
                notes:=notes,
                details:=_details,
                createdBy:=_currentUser.UserId
            )

            MessageBox.Show($"Purchase saved successfully!{Environment.NewLine}Purchase ID: {purchaseId}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving purchase: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class