<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        btnProducts = New Button()
        btnStockAdjustment = New Button()
        btnNewPurchase = New Button()
        SuspendLayout()
        ' 
        ' btnProducts
        ' 
        btnProducts.Location = New Point(43, 12)
        btnProducts.Name = "btnProducts"
        btnProducts.Size = New Size(179, 43)
        btnProducts.TabIndex = 0
        btnProducts.Text = "Manage Products"
        btnProducts.UseVisualStyleBackColor = True
        ' 
        ' btnStockAdjustment
        ' 
        btnStockAdjustment.Location = New Point(271, 12)
        btnStockAdjustment.Name = "btnStockAdjustment"
        btnStockAdjustment.Size = New Size(200, 43)
        btnStockAdjustment.TabIndex = 1
        btnStockAdjustment.Text = "Stock Adjustment"
        btnStockAdjustment.UseVisualStyleBackColor = True
        ' 
        ' btnNewPurchase
        ' 
        btnNewPurchase.Location = New Point(536, 12)
        btnNewPurchase.Name = "btnNewPurchase"
        btnNewPurchase.Size = New Size(126, 43)
        btnNewPurchase.TabIndex = 2
        btnNewPurchase.Text = "Stock In"
        btnNewPurchase.UseVisualStyleBackColor = True
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnNewPurchase)
        Controls.Add(btnStockAdjustment)
        Controls.Add(btnProducts)
        Name = "MainForm"
        Text = "MainForm"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnProducts As Button
    Friend WithEvents btnStockAdjustment As Button
    Friend WithEvents btnNewPurchase As Button
End Class
