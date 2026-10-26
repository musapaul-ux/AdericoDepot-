<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockAdjustmentForm
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
        components = New ComponentModel.Container()
        cboProduct = New ComboBox()
        numQuantity = New NumericUpDown()
        numUnitCost = New NumericUpDown()
        txtNotes = New TextBox()
        btnSave = New Button()
        btnCancel = New Button()
        rbOpeningBalance = New RadioButton()
        rbAdjustment = New RadioButton()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        ImageList1 = New ImageList(components)
        Label5 = New Label()
        Label6 = New Label()
        CType(numQuantity, ComponentModel.ISupportInitialize).BeginInit()
        CType(numUnitCost, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cboProduct
        ' 
        cboProduct.FormattingEnabled = True
        cboProduct.Location = New Point(307, 78)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(320, 33)
        cboProduct.TabIndex = 0
        ' 
        ' numQuantity
        ' 
        numQuantity.DecimalPlaces = 2
        numQuantity.Location = New Point(307, 137)
        numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        numQuantity.Name = "numQuantity"
        numQuantity.Size = New Size(180, 31)
        numQuantity.TabIndex = 1
        numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        ' 
        ' numUnitCost
        ' 
        numUnitCost.DecimalPlaces = 2
        numUnitCost.Location = New Point(307, 193)
        numUnitCost.Name = "numUnitCost"
        numUnitCost.Size = New Size(180, 31)
        numUnitCost.TabIndex = 2
        ' 
        ' txtNotes
        ' 
        txtNotes.Location = New Point(307, 251)
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(320, 65)
        txtNotes.TabIndex = 3
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(216, 436)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(135, 47)
        btnSave.TabIndex = 4
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(455, 436)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(138, 47)
        btnCancel.TabIndex = 5
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' rbOpeningBalance
        ' 
        rbOpeningBalance.AutoSize = True
        rbOpeningBalance.Location = New Point(307, 348)
        rbOpeningBalance.Name = "rbOpeningBalance"
        rbOpeningBalance.Size = New Size(170, 29)
        rbOpeningBalance.TabIndex = 6
        rbOpeningBalance.TabStop = True
        rbOpeningBalance.Text = "Opening Balance"
        rbOpeningBalance.UseVisualStyleBackColor = True
        ' 
        ' rbAdjustment
        ' 
        rbAdjustment.AutoSize = True
        rbAdjustment.Location = New Point(481, 348)
        rbAdjustment.Name = "rbAdjustment"
        rbAdjustment.Size = New Size(177, 29)
        rbAdjustment.TabIndex = 7
        rbAdjustment.TabStop = True
        rbAdjustment.Text = "Stock Adjustment"
        rbAdjustment.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(150, 86)
        Label1.Name = "Label1"
        Label1.Size = New Size(125, 25)
        Label1.TabIndex = 8
        Label1.Text = "Select Product"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(150, 143)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 25)
        Label2.TabIndex = 9
        Label2.Text = "Quantity"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(150, 199)
        Label3.Name = "Label3"
        Label3.Size = New Size(85, 25)
        Label3.TabIndex = 10
        Label3.Text = "Unit Cost"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(150, 267)
        Label4.Name = "Label4"
        Label4.Size = New Size(59, 25)
        Label4.TabIndex = 11
        Label4.Text = "Notes"
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(16, 16)
        ImageList1.TransparentColor = Color.Transparent
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(150, 352)
        Label5.Name = "Label5"
        Label5.Size = New Size(104, 25)
        Label5.TabIndex = 12
        Label5.Text = "Adjustment"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(319, 18)
        Label6.Name = "Label6"
        Label6.Size = New Size(179, 25)
        Label6.TabIndex = 13
        Label6.Text = "STOCK ADJUSTMENT"
        ' 
        ' StockAdjustmentForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(835, 553)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(rbAdjustment)
        Controls.Add(rbOpeningBalance)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtNotes)
        Controls.Add(numUnitCost)
        Controls.Add(numQuantity)
        Controls.Add(cboProduct)
        Name = "StockAdjustmentForm"
        Text = "StockAdjustmentForm"
        CType(numQuantity, ComponentModel.ISupportInitialize).EndInit()
        CType(numUnitCost, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents numUnitCost As NumericUpDown
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents rbOpeningBalance As RadioButton
    Friend WithEvents rbAdjustment As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
