Imports Entidades
Imports Reglas
Public Class frmLogin

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim rn As New RNUsuario
        Dim res = rn.Verificarusuario(txtUsuario.Text, txtContrasenia.Text)
        ' 0 : no se pudo logear
        If CInt(res.Item(0)) = 0 Then
            MsgBox("Error, usuario y/o contraseña incorrectos")
        Else
            DataSesion.idusuario = CInt(res.Item(1))
            frmMain.Show()
            'Mantenimiento
            frmMain.MantenimientoToolStripMenuItem.Enabled = False
            'Consultas
            frmMain.ReportesToolStripMenuItem.Enabled = False
            'Reportes
            frmMain.ReportesToolStripMenuItem1.Enabled = False

            If CChar(res.Item(2)) = "A" Then
                frmMain.MantenimientoToolStripMenuItem.Enabled = True
                frmMain.ReportesToolStripMenuItem.Enabled = True
                frmMain.ReportesToolStripMenuItem1.Enabled = True
            ElseIf CChar(res.Item(2)) = "C" Then
                frmMain.ReportesToolStripMenuItem.Enabled = True
            ElseIf CChar(res.Item(2)) = "R" Then
                frmMain.ReportesToolStripMenuItem1.Enabled = True
            End If





            Me.Hide()
        End If

    End Sub
End Class
