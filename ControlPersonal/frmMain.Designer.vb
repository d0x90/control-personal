<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrabajadoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlDeAccesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AmonestacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CongratulationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SancionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PermisosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VacacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsistenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TrabajadoresToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenimientoToolStripMenuItem, Me.ReportesToolStripMenuItem, Me.ReportesToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(891, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrabajadoresToolStripMenuItem, Me.ControlDeAccesoToolStripMenuItem})
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(123, 20)
        Me.MantenimientoToolStripMenuItem.Text = "Control de Personal"
        '
        'TrabajadoresToolStripMenuItem
        '
        Me.TrabajadoresToolStripMenuItem.Name = "TrabajadoresToolStripMenuItem"
        Me.TrabajadoresToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.TrabajadoresToolStripMenuItem.Text = "Trabajadores"
        '
        'ControlDeAccesoToolStripMenuItem
        '
        Me.ControlDeAccesoToolStripMenuItem.Name = "ControlDeAccesoToolStripMenuItem"
        Me.ControlDeAccesoToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ControlDeAccesoToolStripMenuItem.Text = "Asistencias"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AmonestacionesToolStripMenuItem, Me.CongratulationToolStripMenuItem, Me.SancionesToolStripMenuItem, Me.LicenciasToolStripMenuItem, Me.PermisosToolStripMenuItem, Me.VacacionesToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ReportesToolStripMenuItem.Text = "Consultas"
        '
        'AmonestacionesToolStripMenuItem
        '
        Me.AmonestacionesToolStripMenuItem.Name = "AmonestacionesToolStripMenuItem"
        Me.AmonestacionesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AmonestacionesToolStripMenuItem.Text = "Amonestaciones"
        '
        'CongratulationToolStripMenuItem
        '
        Me.CongratulationToolStripMenuItem.Name = "CongratulationToolStripMenuItem"
        Me.CongratulationToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CongratulationToolStripMenuItem.Text = "Congratulation"
        '
        'SancionesToolStripMenuItem
        '
        Me.SancionesToolStripMenuItem.Name = "SancionesToolStripMenuItem"
        Me.SancionesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SancionesToolStripMenuItem.Text = "Sanciones"
        '
        'LicenciasToolStripMenuItem
        '
        Me.LicenciasToolStripMenuItem.Name = "LicenciasToolStripMenuItem"
        Me.LicenciasToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.LicenciasToolStripMenuItem.Text = "Licencias"
        '
        'PermisosToolStripMenuItem
        '
        Me.PermisosToolStripMenuItem.Name = "PermisosToolStripMenuItem"
        Me.PermisosToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PermisosToolStripMenuItem.Text = "Permisos"
        '
        'VacacionesToolStripMenuItem
        '
        Me.VacacionesToolStripMenuItem.Name = "VacacionesToolStripMenuItem"
        Me.VacacionesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.VacacionesToolStripMenuItem.Text = "Vacaciones"
        '
        'ReportesToolStripMenuItem1
        '
        Me.ReportesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsistenciasToolStripMenuItem, Me.HistoriasToolStripMenuItem, Me.TrabajadoresToolStripMenuItem1})
        Me.ReportesToolStripMenuItem1.Name = "ReportesToolStripMenuItem1"
        Me.ReportesToolStripMenuItem1.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem1.Text = "Reportes"
        '
        'AsistenciasToolStripMenuItem
        '
        Me.AsistenciasToolStripMenuItem.Name = "AsistenciasToolStripMenuItem"
        Me.AsistenciasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AsistenciasToolStripMenuItem.Text = "Asistencias"
        '
        'HistoriasToolStripMenuItem
        '
        Me.HistoriasToolStripMenuItem.Name = "HistoriasToolStripMenuItem"
        Me.HistoriasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HistoriasToolStripMenuItem.Text = "Historias"
        '
        'TrabajadoresToolStripMenuItem1
        '
        Me.TrabajadoresToolStripMenuItem1.Name = "TrabajadoresToolStripMenuItem1"
        Me.TrabajadoresToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.TrabajadoresToolStripMenuItem1.Text = "Trabajadores"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 446)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Personal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MantenimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrabajadoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlDeAccesoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AmonestacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SancionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LicenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PermisosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VacacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsistenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoriasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CongratulationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrabajadoresToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
