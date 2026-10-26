Imports AndericoDepot.Business.Services
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Common.Enums
Imports AndericoDepot.Data.Helpers
Imports Microsoft.Data.SqlClient

Public Class SaleEntryForm

    Private ReadOnly _saleService As New SaleService()
    Private ReadOnly _currentUser As User
    Private _details As New List(Of SaleDetail)

    Public Sub New(currentUser As User)
        InitializeComponent()
        _currentUser = currentUser
    End Sub

    Private Sub SaleEntryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "New Sale"
        Me.StartPosition = FormStartPosition.CenterParent

        ' Payment methods
        cboPaymentMethod.Items.Clear()
        cboPaymentMethod.Items.Add(New With {.Text = "Cash", .Value = CInt(PaymentMethod.Cash)})
        cboPaymentMethod.Items.Add(New With {.Text = "Mobile Money", .Value = CInt(PaymentMethod.MobileMoney)})
        cboPaymentMethod.Items.Add(New With {.Text = "Bank Transfer", .Value = CInt(PaymentMethod.BankTransfer)})
        cboPaymentMethod.Items.Add(New With {.Text = "Credit", .Value = CInt(PaymentMethod.Credit)})
        cboPaymentMethod.DisplayMember = "Text"
        cboPaymentMethod.ValueMember = "Value"
        cboPaymentMethod.SelectedIndex = 0

        LoadProducts()
        RefreshGrid()
    End Sub

    Private Sub LoadProducts()
        cboProduct.Items.Clear()
        cboProduct.DisplayMember = "Text"
        cboProduct.ValueMember = "Value"

        Using conn = ConnectionHelper.GetConnection()
            Using cmd As New SqlCommand("
                SELECT ProductId, ProductCode + ' - ' + ProductName AS DisplayName, 
                       SellingPrice, CurrentStock
                FROM Products 
                WHERE Status = 1 AND CurrentStock > 0
                ORDER BY ProductName", conn)
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        cboProduct.Items.Add(New With {
                            .Text = reader("DisplayName").ToString(),
                            .Value = Convert.ToInt32(reader("ProductId")),
                            .SellingPrice = Convert.ToDecimal(reader("SellingPrice")),
                            .CurrentStock = Convert.ToDecimal(reader("CurrentStock"))
                        })
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub cboProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProduct.SelectedIndexChanged
        If cboProduct.SelectedItem IsNot Nothing Then
            Dim item = cboProduct.SelectedItem

            ' Make sure the NumericUpDown can accept the price
            If item.SellingPrice > numUnitPrice.Maximum Then
                numUnitPrice.Maximum = item.SellingPrice + 1000
            End If

            numUnitPrice.Value = item.SellingPrice
            lblAvailableStock.Text = "Available: " & Format(item.CurrentStock, "N2")
        Else
            lblAvailableStock.Text = "Available: 0"
        End If
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

        Dim selected = cboProduct.SelectedItem
        Dim productId As Integer = selected.Value
        Dim availableStock As Decimal = selected.CurrentStock

        If numQuantity.Value > availableStock Then
            MessageBox.Show($"Insufficient stock. Available: {availableStock}", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim existing = _details.FirstOrDefault(Function(d) d.ProductId = productId)
        If existing IsNot Nothing Then
            Dim newQty = existing.Quantity + numQuantity.Value
            If newQty > availableStock Then
                MessageBox.Show($"Insufficient stock. Available: {availableStock}", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            existing.Quantity = newQty
            existing.UnitPrice = numUnitPrice.Value
            existing.LineTotal = existing.Quantity * existing.UnitPrice
        Else
            _details.Add(New SaleDetail With {
                .ProductId = productId,
                .ProductName = selected.Text,
                .Quantity = numQuantity.Value,
                .UnitPrice = numUnitPrice.Value,
                .LineTotal = numQuantity.Value * numUnitPrice.Value,
                .AvailableStock = availableStock
            })
        End If

        RefreshGrid()
        ClearItemInputs()
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvItems.CurrentRow Is Nothing Then Return

        Dim selected = CType(dgvItems.CurrentRow.DataBoundItem, SaleDetail)
        _details.Remove(selected)
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        dgvItems.DataSource = Nothing
        dgvItems.DataSource = _details.ToList()

        If dgvItems.Columns.Contains("ProductId") Then dgvItems.Columns("ProductId").Visible = False
        If dgvItems.Columns.Contains("AvailableStock") Then dgvItems.Columns("AvailableStock").Visible = False

        UpdateTotals()
    End Sub

    Private Sub UpdateTotals()
        Dim total = _details.Sum(Function(d) d.LineTotal)
        Dim discount = numDiscount.Value
        Dim net = total - discount

        lblTotal.Text = "Total: " & total.ToString("N2")
        lblNetAmount.Text = "Net Amount: " & net.ToString("N2")
        numAmountPaid.Value = Math.Max(net, 0)
    End Sub

    Private Sub numDiscount_ValueChanged(sender As Object, e As EventArgs) Handles numDiscount.ValueChanged
        UpdateTotals()
    End Sub

    Private Sub ClearItemInputs()
        cboProduct.SelectedIndex = -1
        numQuantity.Value = 1
        numUnitPrice.Value = 0
        lblAvailableStock.Text = "Available: 0"
        cboProduct.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If _details.Count = 0 Then
                MessageBox.Show("Please add at least one product", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim paymentMethod As Integer = cboPaymentMethod.SelectedItem.Value

            Dim saleId = _saleService.CreateSale(
                customerId:=Nothing,
                customerName:=txtCustomerName.Text.Trim(),
                invoiceNumber:=txtInvoiceNumber.Text.Trim(),
                discountAmount:=numDiscount.Value,
                paymentMethod:=paymentMethod,
                amountPaid:=numAmountPaid.Value,
                notes:=txtNotes.Text.Trim(),
                details:=_details,
                createdBy:=_currentUser.UserId
            )

            MessageBox.Show($"Sale completed successfully!{Environment.NewLine}Sale ID: {saleId}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class