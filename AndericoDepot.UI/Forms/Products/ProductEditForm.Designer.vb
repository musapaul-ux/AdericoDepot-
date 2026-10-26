<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductEditForm
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
        txtProductCode = New TextBox()
        txtProductName = New TextBox()
        txtBrand = New TextBox()
        cboCategory = New ComboBox()
        txtSize = New TextBox()
        txtPackagingType = New TextBox()
        cboUnit = New ComboBox()
        numPurchasePrice = New NumericUpDown()
        numSellingPrice = New NumericUpDown()
        numReorderLevel = New NumericUpDown()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        cboStatus = New ComboBox()
        btnSave = New Button()
        btnCancel = New Button()
        Label11 = New Label()
        CType(numPurchasePrice, ComponentModel.ISupportInitialize).BeginInit()
        CType(numSellingPrice, ComponentModel.ISupportInitialize).BeginInit()
        CType(numReorderLevel, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtProductCode
        ' 
        txtProductCode.Location = New Point(259, 27)
        txtProductCode.Name = "txtProductCode"
        txtProductCode.Size = New Size(309, 31)
        txtProductCode.TabIndex = 0
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(259, 74)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(309, 31)
        txtProductName.TabIndex = 1
        ' 
        ' txtBrand
        ' 
        txtBrand.Location = New Point(259, 123)
        txtBrand.Name = "txtBrand"
        txtBrand.Size = New Size(309, 31)
        txtBrand.TabIndex = 2
        ' 
        ' cboCategory
        ' 
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(259, 180)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(309, 33)
        cboCategory.TabIndex = 3
        ' 
        ' txtSize
        ' 
        txtSize.Location = New Point(259, 234)
        txtSize.Name = "txtSize"
        txtSize.Size = New Size(309, 31)
        txtSize.TabIndex = 4
        ' 
        ' txtPackagingType
        ' 
        txtPackagingType.Location = New Point(259, 281)
        txtPackagingType.Name = "txtPackagingType"
        txtPackagingType.Size = New Size(309, 31)
        txtPackagingType.TabIndex = 5
        ' 
        ' cboUnit
        ' 
        cboUnit.FormattingEnabled = True
        cboUnit.Location = New Point(259, 334)
        cboUnit.Name = "cboUnit"
        cboUnit.Size = New Size(309, 33)
        cboUnit.TabIndex = 6
        ' 
        ' numPurchasePrice
        ' 
        numPurchasePrice.DecimalPlaces = 2
        numPurchasePrice.Location = New Point(259, 386)
        numPurchasePrice.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numPurchasePrice.Name = "numPurchasePrice"
        numPurchasePrice.Size = New Size(180, 31)
        numPurchasePrice.TabIndex = 7
        ' 
        ' numSellingPrice
        ' 
        numSellingPrice.DecimalPlaces = 2
        numSellingPrice.Location = New Point(259, 440)
        numSellingPrice.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numSellingPrice.Name = "numSellingPrice"
        numSellingPrice.Size = New Size(180, 31)
        numSellingPrice.TabIndex = 8
        ' 
        ' numReorderLevel
        ' 
        numReorderLevel.Location = New Point(259, 487)
        numReorderLevel.Name = "numReorderLevel"
        numReorderLevel.Size = New Size(180, 31)
        numReorderLevel.TabIndex = 9
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(111, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(121, 25)
        Label1.TabIndex = 10
        Label1.Text = "Product Code"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(111, 80)
        Label2.Name = "Label2"
        Label2.Size = New Size(126, 25)
        Label2.TabIndex = 11
        Label2.Text = "Product Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(111, 129)
        Label3.Name = "Label3"
        Label3.Size = New Size(58, 25)
        Label3.TabIndex = 12
        Label3.Text = "Brand"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(111, 188)
        Label4.Name = "Label4"
        Label4.Size = New Size(84, 25)
        Label4.TabIndex = 13
        Label4.Text = "Category"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(111, 234)
        Label5.Name = "Label5"
        Label5.Size = New Size(43, 25)
        Label5.TabIndex = 14
        Label5.Text = "Size"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(111, 287)
        Label6.Name = "Label6"
        Label6.Size = New Size(134, 25)
        Label6.TabIndex = 15
        Label6.Text = "Packaging Type"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(111, 342)
        Label7.Name = "Label7"
        Label7.Size = New Size(138, 25)
        Label7.TabIndex = 16
        Label7.Text = "Unit of Measure"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(111, 392)
        Label8.Name = "Label8"
        Label8.Size = New Size(124, 25)
        Label8.TabIndex = 17
        Label8.Text = "Purchase Price"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(111, 446)
        Label9.Name = "Label9"
        Label9.Size = New Size(106, 25)
        Label9.TabIndex = 18
        Label9.Text = "Selling Price"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(111, 489)
        Label10.Name = "Label10"
        Label10.Size = New Size(118, 25)
        Label10.TabIndex = 19
        Label10.Text = "Reorder Level"
        ' 
        ' cboStatus
        ' 
        cboStatus.FormattingEnabled = True
        cboStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        cboStatus.Location = New Point(259, 542)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(182, 33)
        cboStatus.TabIndex = 20
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(259, 615)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(112, 46)
        btnSave.TabIndex = 21
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(456, 615)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 46)
        btnCancel.TabIndex = 22
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(111, 542)
        Label11.Name = "Label11"
        Label11.Size = New Size(60, 25)
        Label11.TabIndex = 23
        Label11.Text = "Status"
        ' 
        ' ProductEditForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(827, 683)
        Controls.Add(Label11)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(cboStatus)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(numReorderLevel)
        Controls.Add(numSellingPrice)
        Controls.Add(numPurchasePrice)
        Controls.Add(cboUnit)
        Controls.Add(txtPackagingType)
        Controls.Add(txtSize)
        Controls.Add(cboCategory)
        Controls.Add(txtBrand)
        Controls.Add(txtProductName)
        Controls.Add(txtProductCode)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "ProductEditForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "ProductEditForm"
        CType(numPurchasePrice, ComponentModel.ISupportInitialize).EndInit()
        CType(numSellingPrice, ComponentModel.ISupportInitialize).EndInit()
        CType(numReorderLevel, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtProductCode As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents txtSize As TextBox
    Friend WithEvents txtPackagingType As TextBox
    Friend WithEvents cboUnit As ComboBox
    Friend WithEvents numPurchasePrice As NumericUpDown
    Friend WithEvents numSellingPrice As NumericUpDown
    Friend WithEvents numReorderLevel As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label11 As Label
End Class
