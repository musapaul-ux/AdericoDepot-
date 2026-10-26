Imports AndericoDepot.Business.Services
Imports AndericoDepot.Common.Models

Public Class ProductListForm

    Private ReadOnly _productService As New ProductService()
    Private _products As List(Of Product)

    Private Sub ProductListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Product Management"
        Me.StartPosition = FormStartPosition.CenterScreen
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        Try
            _products = _productService.GetAllProducts()
            dgvProducts.DataSource = Nothing
            dgvProducts.DataSource = _products

            ' Hide some columns we don't need to show
            If dgvProducts.Columns.Contains("ProductId") Then
                dgvProducts.Columns("ProductId").Visible = False
            End If
            If dgvProducts.Columns.Contains("CategoryId") Then
                dgvProducts.Columns("CategoryId").Visible = False
            End If
            If dgvProducts.Columns.Contains("UnitId") Then
                dgvProducts.Columns("UnitId").Visible = False
            End If
            If dgvProducts.Columns.Contains("CreatedAt") Then
                dgvProducts.Columns("CreatedAt").Visible = False
            End If
            If dgvProducts.Columns.Contains("UpdatedAt") Then
                dgvProducts.Columns("UpdatedAt").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadProducts()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim form As New ProductEditForm()      ' We will create this next
        If form.ShowDialog() = DialogResult.OK Then
            LoadProducts()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvProducts.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a product to edit.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedProduct As Product = CType(dgvProducts.CurrentRow.DataBoundItem, Product)
        Dim form As New ProductEditForm(selectedProduct)
        If form.ShowDialog() = DialogResult.OK Then
            LoadProducts()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvProducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        If e.RowIndex >= 0 Then
            btnEdit.PerformClick()
        End If
    End Sub

End Class