Imports Reglas

Public Class frmTrabajador

    Private Sub frmTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbArea.SelectedIndex = 0

        Dim rnTrabajador As New RNTrabajador
        Me.dgvTrabajadores.DataSource = rnTrabajador.listarTrabajadores()


    End Sub
End Class