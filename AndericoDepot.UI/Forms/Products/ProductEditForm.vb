Imports AndericoDepot.Business.Services
Imports AndericoDepot.Common.Models
Imports AndericoDepot.Data.Helpers
Imports Microsoft.Data.SqlClient

Public Class ProductEditForm

    Private ReadOnly _productService As New ProductService()
    Private _product As Product
    Private _isEditMode As Boolean = False

    ' Constructor for Add New
    Public Sub New()
        InitializeComponent()
        _product = New Product()
        _isEditMode = False
    End Sub

    ' Constructor for Edit
    Public Sub New(product As Product)
        InitializeComponent()
        _product = product
        _isEditMode = True
    End Sub

    Private Sub ProductEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = If(_isEditMode, "Edit Product", "Add New Product")
        LoadCategories()
        LoadUnits()
        LoadStatuses()

        If _isEditMode Then
            LoadProductData()
        End If
    End Sub

    Private Sub LoadCategories()
        cboCategory.Items.Clear()
        cboCategory.DisplayMember = "Text"
        cboCategory.ValueMember = "Value"

        Using conn = ConnectionHelper.GetConnection()
            Using cmd As New SqlCommand("SELECT CategoryId, CategoryName FROM ProductCategories WHERE IsActive = 1 ORDER BY CategoryName", conn)
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        cboCategory.Items.Add(New With {
                            .Text = reader("CategoryName").ToString(),
                            .Value = Convert.ToInt32(reader("CategoryId"))
                        })
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadUnits()
        cboUnit.Items.Clear()
        cboUnit.DisplayMember = "Text"
        cboUnit.ValueMember = "Value"

        Using conn = ConnectionHelper.GetConnection()
            Using cmd As New SqlCommand("SELECT UnitId, UnitName FROM UnitsOfMeasure WHERE IsActive = 1 ORDER BY UnitName", conn)
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        cboUnit.Items.Add(New With {
                            .Text = reader("UnitName").ToString(),
                            .Value = Convert.ToInt32(reader("UnitId"))
                        })
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadStatuses()
        cboStatus.Items.Clear()
        cboStatus.Items.Add(New With {.Text = "Active", .Value = 1})
        cboStatus.Items.Add(New With {.Text = "Inactive", .Value = 2})
        cboStatus.Items.Add(New With {.Text = "Discontinued", .Value = 3})
        cboStatus.DisplayMember = "Text"
        cboStatus.ValueMember = "Value"
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadProductData()
        txtProductCode.Text = _product.ProductCode
        txtProductName.Text = _product.ProductName
        txtBrand.Text = _product.Brand
        txtSize.Text = _product.Size
        txtPackagingType.Text = _product.PackagingType
        numPurchasePrice.Value = _product.PurchasePrice
        numSellingPrice.Value = _product.SellingPrice
        numReorderLevel.Value = _product.ReorderLevel

        ' Select Category
        For Each item In cboCategory.Items
            If item.Value = _product.CategoryId Then
                cboCategory.SelectedItem = item
                Exit For
            End If
        Next

        ' Select Unit
        For Each item In cboUnit.Items
            If item.Value = _product.UnitId Then
                cboUnit.SelectedItem = item
                Exit For
            End If
        Next

        ' Select Status
        For Each item In cboStatus.Items
            If item.Value = _product.Status Then
                cboStatus.SelectedItem = item
                Exit For
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrWhiteSpace(txtProductCode.Text) Then
                MessageBox.Show("Product Code is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtProductName.Text) Then
                MessageBox.Show("Product Name is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductName.Focus()
                Return
            End If

            If cboUnit.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a Unit of Measure", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Fill the product object
            _product.ProductCode = txtProductCode.Text.Trim()
            _product.ProductName = txtProductName.Text.Trim()
            _product.Brand = txtBrand.Text.Trim()
            _product.Size = txtSize.Text.Trim()
            _product.PackagingType = txtPackagingType.Text.Trim()
            _product.PurchasePrice = numPurchasePrice.Value
            _product.SellingPrice = numSellingPrice.Value
            _product.ReorderLevel = CInt(numReorderLevel.Value)
            _product.UnitId = cboUnit.SelectedItem.Value
            _product.Status = cboStatus.SelectedItem.Value

            If cboCategory.SelectedItem IsNot Nothing Then
                _product.CategoryId = cboCategory.SelectedItem.Value
            Else
                _product.CategoryId = Nothing
            End If

            If _isEditMode Then
                _productService.UpdateProduct(_product)
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                _productService.AddProduct(_product)
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class