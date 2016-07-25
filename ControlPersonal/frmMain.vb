Public Class frmMain



    Private Sub TrabajadoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrabajadoresToolStripMenuItem.Click
        'MsgBox(DataSesion.idusuario)
        Dim frmTrabajador As New frmTrabajador
        frmTrabajador.MdiParent = Me
        frmTrabajador.WindowState = FormWindowState.Maximized
        frmTrabajador.Show()
    End Sub


    Private Sub ControlDeAccesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeAccesoToolStripMenuItem.Click
        Dim frmAcceso As New frmAcceso
        frmAcceso.MdiParent = Me
        frmAcceso.WindowState = FormWindowState.Maximized
        frmAcceso.Show()
    End Sub

    Private Sub AmonestacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AmonestacionesToolStripMenuItem.Click
        Dim frmEvento As New frmEvento
        frmEvento.tipoEvento = "Amonestacion"
        frmEvento.MdiParent = Me
        frmEvento.WindowState = FormWindowState.Maximized
        frmEvento.Show()
    End Sub

    Private Sub SancionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SancionesToolStripMenuItem.Click
        Dim frmEvento As New frmEvento
        frmEvento.tipoEvento = "Sancion"
        frmEvento.MdiParent = Me
        frmEvento.WindowState = FormWindowState.Maximized
        frmEvento.Show()
    End Sub

    Private Sub LicenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicenciasToolStripMenuItem.Click
        Dim frmPermiso As New frmPermiso
        frmPermiso.tipoPermiso = "Licencias"
        frmPermiso.MdiParent = Me
        frmPermiso.WindowState = FormWindowState.Maximized
        frmPermiso.Show()
    End Sub

    Private Sub PermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermisosToolStripMenuItem.Click
        Dim frmPermiso As New frmPermiso
        frmPermiso.tipoPermiso = "Permisos"
        frmPermiso.MdiParent = Me
        frmPermiso.WindowState = FormWindowState.Maximized
        frmPermiso.Show()
    End Sub


    Private Sub CongratulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CongratulationToolStripMenuItem.Click
        Dim frmEvento As New frmEvento
        frmEvento.tipoEvento = "Congratulation"
        frmEvento.MdiParent = Me
        frmEvento.WindowState = FormWindowState.Maximized
        frmEvento.Show()
    End Sub

    Private Sub VacacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VacacionesToolStripMenuItem.Click
        Dim frmPermiso As New frmPermiso
        frmPermiso.tipoPermiso = "Vacaciones"
        frmPermiso.MdiParent = Me
        frmPermiso.WindowState = FormWindowState.Maximized
        frmPermiso.Show()
    End Sub

    
    Private Sub AsistenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsistenciasToolStripMenuItem.Click

        Dim frm As New frmAccesosReport
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub TrabajadoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TrabajadoresToolStripMenuItem1.Click
        Dim frm As New frmTrabajadoresReport
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub AmonestacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AmonestacionesToolStripMenuItem1.Click
        Dim frm As New frmEventosReporte
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.tipoEvento = "Amonestacion"
        frm.Show()
    End Sub

    Private Sub CongratulacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CongratulacionesToolStripMenuItem.Click
        Dim frm As New frmEventosReporte
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.tipoEvento = "Congratulation"
        frm.Show()
    End Sub

    Private Sub SancionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SancionesToolStripMenuItem1.Click
        Dim frm As New frmEventosReporte
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.tipoEvento = "Sancion"
        frm.Show()
    End Sub

    Private Sub LicenciasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LicenciasToolStripMenuItem1.Click
        Dim frm As New frmPermisosReporte
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.tipoPermiso = "Licencias"
        frm.Show()
    End Sub

    Private Sub PermisosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PermisosToolStripMenuItem1.Click
        Dim frm As New frmPermisosReporte
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.tipoPermiso = "Permisos"
        frm.Show()
    End Sub

    Private Sub VacacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VacacionesToolStripMenuItem1.Click
        Dim frm As New frmPermisosReporte
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.tipoPermiso = "Vacaciones"
        frm.Show()
    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuarioToolStripMenuItem.Click
        Dim frm As New frmUsuario
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If MessageBox.Show("Desea salir de la aplicación?", "Control de Personal", MessageBoxButtons.YesNo) = DialogResult.No Then
            ' Cancel the Closing event from closing the form.
            e.Cancel = True
        Else
            Application.Exit()
        End If

    End Sub 'Form1_Closing
End Class