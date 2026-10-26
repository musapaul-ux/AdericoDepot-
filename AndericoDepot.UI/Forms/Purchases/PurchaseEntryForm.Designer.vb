<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseEntryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        cboSupplier = New ComboBox()
        txtInvoiceNumber = New TextBox()
        txtNotes = New TextBox()
        dtpPurchaseDate = New DateTimePicker()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        cboProduct = New ComboBox()
        numUnitCost = New NumericUpDown()
        numQuantity = New NumericUpDown()
        btnAddItem = New Button()
        dgvItems = New DataGridView()
        btnRemoveItem = New Button()
        btnCancel = New Button()
        lblTotal = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        btnSave = New Button()
        CType(numUnitCost, ComponentModel.ISupportInitialize).BeginInit()
        CType(numQuantity, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvItems, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cboSupplier
        ' 
        cboSupplier.FormattingEnabled = True
        cboSupplier.Location = New Point(105, 17)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(182, 33)
        cboSupplier.TabIndex = 0
        ' 
        ' txtInvoiceNumber
        ' 
        txtInvoiceNumber.Location = New Point(427, 20)
        txtInvoiceNumber.Name = "txtInvoiceNumber"
        txtInvoiceNumber.Size = New Size(150, 31)
        txtInvoiceNumber.TabIndex = 1
        ' 
        ' txtNotes
        ' 
        txtNotes.Location = New Point(698, 12)
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(150, 46)
        txtNotes.TabIndex = 2
        ' 
        ' dtpPurchaseDate
        ' 
        dtpPurchaseDate.Location = New Point(961, 20)
        dtpPurchaseDate.Name = "dtpPurchaseDate"
        dtpPurchaseDate.Size = New Size(300, 31)
        dtpPurchaseDate.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(22, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(77, 25)
        Label1.TabIndex = 4
        Label1.Text = "Supplier"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(324, 23)
        Label2.Name = "Label2"
        Label2.Size = New Size(97, 25)
        Label2.TabIndex = 5
        Label2.Text = "Invoice No"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(607, 25)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 25)
        Label3.TabIndex = 6
        Label3.Text = "Notes"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(875, 29)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 25)
        Label4.TabIndex = 7
        Label4.Text = "Date"
        ' 
        ' cboProduct
        ' 
        cboProduct.FormattingEnabled = True
        cboProduct.Location = New Point(105, 79)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(182, 33)
        cboProduct.TabIndex = 8
        ' 
        ' numUnitCost
        ' 
        numUnitCost.DecimalPlaces = 2
        numUnitCost.Location = New Point(698, 77)
        numUnitCost.Name = "numUnitCost"
        numUnitCost.Size = New Size(180, 31)
        numUnitCost.TabIndex = 9
        ' 
        ' numQuantity
        ' 
        numQuantity.DecimalPlaces = 2
        numQuantity.Location = New Point(427, 81)
        numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        numQuantity.Name = "numQuantity"
        numQuantity.Size = New Size(150, 31)
        numQuantity.TabIndex = 10
        numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        ' 
        ' btnAddItem
        ' 
        btnAddItem.Location = New Point(961, 70)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(112, 48)
        btnAddItem.TabIndex = 11
        btnAddItem.Text = "Add"
        btnAddItem.UseVisualStyleBackColor = True
        ' 
        ' dgvItems
        ' 
        dgvItems.AllowUserToAddRows = False
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvItems.Location = New Point(22, 132)
        dgvItems.Name = "dgvItems"
        dgvItems.ReadOnly = True
        dgvItems.RowHeadersWidth = 62
        dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvItems.Size = New Size(1239, 335)
        dgvItems.TabIndex = 12
        ' 
        ' btnRemoveItem
        ' 
        btnRemoveItem.Location = New Point(1114, 70)
        btnRemoveItem.Name = "btnRemoveItem"
        btnRemoveItem.Size = New Size(112, 48)
        btnRemoveItem.TabIndex = 14
        btnRemoveItem.Text = "Remove"
        btnRemoveItem.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(1149, 489)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 48)
        btnCancel.TabIndex = 15
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(146, 501)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(0, 25)
        lblTotal.TabIndex = 16
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(22, 79)
        Label6.Name = "Label6"
        Label6.Size = New Size(74, 25)
        Label6.TabIndex = 17
        Label6.Text = "Product"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(324, 86)
        Label7.Name = "Label7"
        Label7.Size = New Size(80, 25)
        Label7.TabIndex = 18
        Label7.Text = "Quantity"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(603, 83)
        Label8.Name = "Label8"
        Label8.Size = New Size(85, 25)
        Label8.TabIndex = 19
        Label8.Text = "Unit Cost"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(961, 489)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(116, 48)
        btnSave.TabIndex = 20
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' PurchaseEntryForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1317, 567)
        Controls.Add(btnSave)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(lblTotal)
        Controls.Add(btnCancel)
        Controls.Add(btnRemoveItem)
        Controls.Add(dgvItems)
        Controls.Add(btnAddItem)
        Controls.Add(numQuantity)
        Controls.Add(numUnitCost)
        Controls.Add(cboProduct)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dtpPurchaseDate)
        Controls.Add(txtNotes)
        Controls.Add(txtInvoiceNumber)
        Controls.Add(cboSupplier)
        Name = "PurchaseEntryForm"
        Text = "PurchaseEntryForm"
        CType(numUnitCost, ComponentModel.ISupportInitialize).EndInit()
        CType(numQuantity, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents txtInvoiceNumber As TextBox
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents dtpPurchaseDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents numUnitCost As NumericUpDown
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents btnAddItem As Button
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSave As Button
End Class
