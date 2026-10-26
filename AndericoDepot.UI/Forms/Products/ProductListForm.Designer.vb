<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductListForm
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
        lblTitle = New Label()
        txtSearch = New TextBox()
        btnRefresh = New Button()
        dgvProducts = New DataGridView()
        btnAdd = New Button()
        btnEdit = New Button()
        btnClose = New Button()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(344, 21)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(139, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "PRODUCTS LIST"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(575, 15)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(372, 31)
        txtSearch.TabIndex = 1
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(953, 15)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(112, 34)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' dgvProducts
        ' 
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.AllowUserToDeleteRows = False
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Location = New Point(70, 64)
        dgvProducts.MultiSelect = False
        dgvProducts.Name = "dgvProducts"
        dgvProducts.ReadOnly = True
        dgvProducts.RowHeadersWidth = 62
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.Size = New Size(1401, 588)
        dgvProducts.TabIndex = 3
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(981, 671)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(112, 46)
        btnAdd.TabIndex = 4
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(1145, 671)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(112, 46)
        btnEdit.TabIndex = 5
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(1314, 671)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 46)
        btnClose.TabIndex = 6
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' ProductListForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1499, 729)
        Controls.Add(btnClose)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(dgvProducts)
        Controls.Add(btnRefresh)
        Controls.Add(txtSearch)
        Controls.Add(lblTitle)
        Name = "ProductListForm"
        Text = "ProductListForm"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnClose As Button
End Class
