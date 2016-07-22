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

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class