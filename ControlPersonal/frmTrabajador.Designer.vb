<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrabajador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvTrabajadores = New System.Windows.Forms.DataGridView()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apePaterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apeMaterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sueldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seguro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.asignacionFamiliar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSueldo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkAsignacionFamiliar = New System.Windows.Forms.CheckBox()
        Me.chkSeguro = New System.Windows.Forms.CheckBox()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtApeMaterno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtApePaterno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvTrabajadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Location = New System.Drawing.Point(721, 406)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(109, 30)
        Me.btnEliminar.TabIndex = 12
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnModificar.Location = New System.Drawing.Point(507, 406)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(109, 30)
        Me.btnModificar.TabIndex = 11
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.Location = New System.Drawing.Point(296, 406)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(109, 30)
        Me.btnNuevo.TabIndex = 10
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvTrabajadores)
        Me.GroupBox2.Location = New System.Drawing.Point(272, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(558, 388)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lista de Trabajadores"
        '
        'dgvTrabajadores
        '
        Me.dgvTrabajadores.AllowUserToAddRows = False
        Me.dgvTrabajadores.AllowUserToDeleteRows = False
        Me.dgvTrabajadores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTrabajadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTrabajadores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nombre, Me.apePaterno, Me.apeMaterno, Me.area, Me.sueldo, Me.Seguro, Me.asignacionFamiliar})
        Me.dgvTrabajadores.Location = New System.Drawing.Point(6, 19)
        Me.dgvTrabajadores.MultiSelect = False
        Me.dgvTrabajadores.Name = "dgvTrabajadores"
        Me.dgvTrabajadores.ReadOnly = True
        Me.dgvTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTrabajadores.Size = New System.Drawing.Size(546, 351)
        Me.dgvTrabajadores.TabIndex = 0
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        '
        'apePaterno
        '
        Me.apePaterno.DataPropertyName = "apePaterno"
        Me.apePaterno.HeaderText = "A. Paterno"
        Me.apePaterno.Name = "apePaterno"
        Me.apePaterno.ReadOnly = True
        '
        'apeMaterno
        '
        Me.apeMaterno.DataPropertyName = "apeMaterno"
        Me.apeMaterno.HeaderText = "A. Materno"
        Me.apeMaterno.Name = "apeMaterno"
        Me.apeMaterno.ReadOnly = True
        '
        'area
        '
        Me.area.DataPropertyName = "area"
        Me.area.HeaderText = "Área"
        Me.area.Name = "area"
        Me.area.ReadOnly = True
        '
        'sueldo
        '
        Me.sueldo.DataPropertyName = "sueldo"
        Me.sueldo.HeaderText = "Sueldo"
        Me.sueldo.Name = "sueldo"
        Me.sueldo.ReadOnly = True
        Me.sueldo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Seguro
        '
        Me.Seguro.DataPropertyName = "seguro"
        Me.Seguro.HeaderText = "seguro"
        Me.Seguro.Name = "Seguro"
        Me.Seguro.ReadOnly = True
        Me.Seguro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Seguro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'asignacionFamiliar
        '
        Me.asignacionFamiliar.DataPropertyName = "asignacionFamiliar"
        Me.asignacionFamiliar.HeaderText = "A. Familiar"
        Me.asignacionFamiliar.Name = "asignacionFamiliar"
        Me.asignacionFamiliar.ReadOnly = True
        Me.asignacionFamiliar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.asignacionFamiliar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtSueldo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkAsignacionFamiliar)
        Me.GroupBox1.Controls.Add(Me.chkSeguro)
        Me.GroupBox1.Controls.Add(Me.cmbArea)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtApeMaterno)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtApePaterno)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 437)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trabajador"
        '
        'txtSueldo
        '
        Me.txtSueldo.Enabled = False
        Me.txtSueldo.Location = New System.Drawing.Point(79, 207)
        Me.txtSueldo.Name = "txtSueldo"
        Me.txtSueldo.Size = New System.Drawing.Size(159, 20)
        Me.txtSueldo.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Sueldo"
        '
        'chkAsignacionFamiliar
        '
        Me.chkAsignacionFamiliar.AutoSize = True
        Me.chkAsignacionFamiliar.Enabled = False
        Me.chkAsignacionFamiliar.Location = New System.Drawing.Point(114, 245)
        Me.chkAsignacionFamiliar.Name = "chkAsignacionFamiliar"
        Me.chkAsignacionFamiliar.Size = New System.Drawing.Size(116, 17)
        Me.chkAsignacionFamiliar.TabIndex = 15
        Me.chkAsignacionFamiliar.Text = "Asignación Familiar"
        Me.chkAsignacionFamiliar.UseVisualStyleBackColor = True
        '
        'chkSeguro
        '
        Me.chkSeguro.AutoSize = True
        Me.chkSeguro.Enabled = False
        Me.chkSeguro.Location = New System.Drawing.Point(15, 245)
        Me.chkSeguro.Name = "chkSeguro"
        Me.chkSeguro.Size = New System.Drawing.Size(60, 17)
        Me.chkSeguro.TabIndex = 14
        Me.chkSeguro.Text = "Seguro"
        Me.chkSeguro.UseVisualStyleBackColor = True
        '
        'cmbArea
        '
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.Enabled = False
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Items.AddRange(New Object() {"Contabilidad", "Especialista", "RR.HH"})
        Me.cmbArea.Location = New System.Drawing.Point(79, 164)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(159, 21)
        Me.cmbArea.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Área"
        '
        'txtApeMaterno
        '
        Me.txtApeMaterno.Enabled = False
        Me.txtApeMaterno.Location = New System.Drawing.Point(79, 123)
        Me.txtApeMaterno.Name = "txtApeMaterno"
        Me.txtApeMaterno.Size = New System.Drawing.Size(159, 20)
        Me.txtApeMaterno.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Ape Materno"
        '
        'txtApePaterno
        '
        Me.txtApePaterno.Enabled = False
        Me.txtApePaterno.Location = New System.Drawing.Point(79, 83)
        Me.txtApePaterno.Name = "txtApePaterno"
        Me.txtApePaterno.Size = New System.Drawing.Size(159, 20)
        Me.txtApePaterno.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ape Paterno"
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(79, 43)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(159, 20)
        Me.txtNombre.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nombre"
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(130, 353)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(99, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(12, 353)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(99, 23)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmTrabajador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 461)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTrabajador"
        Me.Text = "Trabajador"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvTrabajadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTrabajadores As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtApeMaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtApePaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSueldo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAsignacionFamiliar As System.Windows.Forms.CheckBox
    Friend WithEvents chkSeguro As System.Windows.Forms.CheckBox
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents apePaterno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents apeMaterno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sueldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seguro As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents asignacionFamiliar As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
