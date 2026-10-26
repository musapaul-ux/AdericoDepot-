<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleEntryForm
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
        cboPaymentMethod = New ComboBox()
        txtNotes = New TextBox()
        txtInvoiceNumber = New TextBox()
        txtCustomerName = New TextBox()
        numDiscount = New NumericUpDown()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        cboProduct = New ComboBox()
        lblAvailableStock = New Label()
        numUnitPrice = New NumericUpDown()
        numQuantity = New NumericUpDown()
        btnRemoveItem = New Button()
        btnAddItem = New Button()
        dgvItems = New DataGridView()
        btnSave = New Button()
        btnCancel = New Button()
        numAmountPaid = New NumericUpDown()
        lblNetAmount = New Label()
        lblTotal = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        CType(numDiscount, ComponentModel.ISupportInitialize).BeginInit()
        CType(numUnitPrice, ComponentModel.ISupportInitialize).BeginInit()
        CType(numQuantity, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvItems, ComponentModel.ISupportInitialize).BeginInit()
        CType(numAmountPaid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cboPaymentMethod
        ' 
        cboPaymentMethod.FormattingEnabled = True
        cboPaymentMethod.Location = New Point(441, 56)
        cboPaymentMethod.Name = "cboPaymentMethod"
        cboPaymentMethod.Size = New Size(182, 33)
        cboPaymentMethod.TabIndex = 0
        ' 
        ' txtNotes
        ' 
        txtNotes.Location = New Point(941, 45)
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(150, 46)
        txtNotes.TabIndex = 1
        ' 
        ' txtInvoiceNumber
        ' 
        txtInvoiceNumber.Location = New Point(239, 45)
        txtInvoiceNumber.Multiline = True
        txtInvoiceNumber.Name = "txtInvoiceNumber"
        txtInvoiceNumber.Size = New Size(150, 46)
        txtInvoiceNumber.TabIndex = 2
        ' 
        ' txtCustomerName
        ' 
        txtCustomerName.Location = New Point(40, 43)
        txtCustomerName.Multiline = True
        txtCustomerName.Name = "txtCustomerName"
        txtCustomerName.Size = New Size(155, 46)
        txtCustomerName.TabIndex = 3
        ' 
        ' numDiscount
        ' 
        numDiscount.DecimalPlaces = 2
        numDiscount.Location = New Point(691, 57)
        numDiscount.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numDiscount.Name = "numDiscount"
        numDiscount.Size = New Size(180, 31)
        numDiscount.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(59, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 25)
        Label1.TabIndex = 5
        Label1.Text = "Customer"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(265, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(97, 25)
        Label2.TabIndex = 6
        Label2.Text = "Invoice No"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(458, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(148, 25)
        Label3.TabIndex = 7
        Label3.Text = "Payment Method"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(711, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(82, 25)
        Label4.TabIndex = 8
        Label4.Text = "Discount"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(975, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(59, 25)
        Label5.TabIndex = 9
        Label5.Text = "Notes"
        ' 
        ' cboProduct
        ' 
        cboProduct.FormattingEnabled = True
        cboProduct.Location = New Point(40, 148)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(155, 33)
        cboProduct.TabIndex = 10
        ' 
        ' lblAvailableStock
        ' 
        lblAvailableStock.AutoSize = True
        lblAvailableStock.Location = New Point(265, 150)
        lblAvailableStock.Name = "lblAvailableStock"
        lblAvailableStock.Size = New Size(0, 25)
        lblAvailableStock.TabIndex = 11
        ' 
        ' numUnitPrice
        ' 
        numUnitPrice.DecimalPlaces = 2
        numUnitPrice.Location = New Point(691, 148)
        numUnitPrice.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numUnitPrice.Name = "numUnitPrice"
        numUnitPrice.Size = New Size(180, 31)
        numUnitPrice.TabIndex = 12
        ' 
        ' numQuantity
        ' 
        numQuantity.DecimalPlaces = 2
        numQuantity.Location = New Point(441, 148)
        numQuantity.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numQuantity.Name = "numQuantity"
        numQuantity.Size = New Size(180, 31)
        numQuantity.TabIndex = 13
        ' 
        ' btnRemoveItem
        ' 
        btnRemoveItem.Location = New Point(996, 130)
        btnRemoveItem.Name = "btnRemoveItem"
        btnRemoveItem.Size = New Size(95, 52)
        btnRemoveItem.TabIndex = 14
        btnRemoveItem.Text = "Remove"
        btnRemoveItem.UseVisualStyleBackColor = True
        ' 
        ' btnAddItem
        ' 
        btnAddItem.Location = New Point(894, 130)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(87, 51)
        btnAddItem.TabIndex = 15
        btnAddItem.Text = "Add"
        btnAddItem.UseVisualStyleBackColor = True
        ' 
        ' dgvItems
        ' 
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvItems.Location = New Point(40, 200)
        dgvItems.Name = "dgvItems"
        dgvItems.RowHeadersWidth = 62
        dgvItems.Size = New Size(1051, 495)
        dgvItems.TabIndex = 16
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(844, 712)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(112, 42)
        btnSave.TabIndex = 17
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(979, 709)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 46)
        btnCancel.TabIndex = 18
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' numAmountPaid
        ' 
        numAmountPaid.DecimalPlaces = 2
        numAmountPaid.Location = New Point(582, 718)
        numAmountPaid.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numAmountPaid.Name = "numAmountPaid"
        numAmountPaid.Size = New Size(144, 31)
        numAmountPaid.TabIndex = 19
        ' 
        ' lblNetAmount
        ' 
        lblNetAmount.AutoSize = True
        lblNetAmount.Location = New Point(210, 724)
        lblNetAmount.Name = "lblNetAmount"
        lblNetAmount.Size = New Size(0, 25)
        lblNetAmount.TabIndex = 20
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(40, 722)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(0, 25)
        lblTotal.TabIndex = 21
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(40, 108)
        Label6.Name = "Label6"
        Label6.Size = New Size(74, 25)
        Label6.TabIndex = 22
        Label6.Text = "Product"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(256, 108)
        Label7.Name = "Label7"
        Label7.Size = New Size(130, 25)
        Label7.TabIndex = 23
        Label7.Text = "Available stock"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(441, 108)
        Label8.Name = "Label8"
        Label8.Size = New Size(80, 25)
        Label8.TabIndex = 24
        Label8.Text = "Quantity"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(691, 108)
        Label9.Name = "Label9"
        Label9.Size = New Size(106, 25)
        Label9.TabIndex = 25
        Label9.Text = "Selling Price"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(441, 720)
        Label10.Name = "Label10"
        Label10.Size = New Size(115, 25)
        Label10.TabIndex = 26
        Label10.Text = "Amount Paid"
        ' 
        ' SaleEntryForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1132, 767)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(lblTotal)
        Controls.Add(lblNetAmount)
        Controls.Add(numAmountPaid)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(dgvItems)
        Controls.Add(btnAddItem)
        Controls.Add(btnRemoveItem)
        Controls.Add(numQuantity)
        Controls.Add(numUnitPrice)
        Controls.Add(lblAvailableStock)
        Controls.Add(cboProduct)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(numDiscount)
        Controls.Add(txtCustomerName)
        Controls.Add(txtInvoiceNumber)
        Controls.Add(txtNotes)
        Controls.Add(cboPaymentMethod)
        Name = "SaleEntryForm"
        Text = "SaleEntryForm"
        CType(numDiscount, ComponentModel.ISupportInitialize).EndInit()
        CType(numUnitPrice, ComponentModel.ISupportInitialize).EndInit()
        CType(numQuantity, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvItems, ComponentModel.ISupportInitialize).EndInit()
        CType(numAmountPaid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboPaymentMethod As ComboBox
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents txtInvoiceNumber As TextBox
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents numDiscount As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents lblAvailableStock As Label
    Friend WithEvents numUnitPrice As NumericUpDown
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents btnAddItem As Button
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents numAmountPaid As NumericUpDown
    Friend WithEvents lblNetAmount As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
End Class
