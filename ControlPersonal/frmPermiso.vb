Imports Reglas
Imports Entidades
Public Class frmPermiso
    Public Property tipoPermiso As String
    Dim actual As Permiso
    Private Sub frmPermiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = tipoPermiso
        Me.GroupBox1.Text = tipoPermiso
        Me.GroupBox2.Text = "Lista de " & tipoPermiso
        Dim rnPermiso As New RNPermiso
        'licencias, permisos, vacaciones
        Me.dgvPermisos.DataSource = rnPermiso.listarPermisos(tipoPermiso)

    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvPermisos.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvPermisos.CurrentRow.DataBoundItem, Permiso)
            Me.PresentarDatos()
        Else
            MessageBox.Show("Debe seleccionar un Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PresentarDatos()
        Dim rn As New RNPermiso
        Try
            Me.actual = rn.leer(Me.actual.id)
            Me.cmbTrabajador.SelectedItem = Me.actual.trabajador
            Me.DateTimePicker1.Value = Me.actual.fechaInicio
            Me.DateTimePicker2.Value = Me.actual.fechaFin

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ActivarControles(e As Boolean)

        Me.cmbTrabajador.Enabled = e
        Me.DateTimePicker1.Enabled = e
        Me.DateTimePicker2.Enabled = e
        Me.btnCancelar.Enabled = e
        Me.btnGuardar.Enabled = e
        Me.GroupBox1.Enabled = e

        Me.dgvPermisos.Enabled = Not e
        Me.btnNuevo.Enabled = Not e
        Me.btnModificar.Enabled = Not e
        Me.btnEliminar.Enabled = Not e
        Me.GroupBox2.Enabled = Not e

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.ActivarControles(True)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.ActivarControles(False)
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim rnPermiso As New RNPermiso
        Dim permiso As New Permiso
        Dim cantDias As Integer = 0
        permiso.fechaInicio = DateTimePicker1.Value
        permiso.fechaFin = DateTimePicker2.Value
        
            Dim tspan As TimeSpan = DateTimePicker2.Value - DateTimePicker1.Value 'Dia Inicial + Dia final
            If tspan.Days = 0 Then
                If DateTimePicker2.Value.Day = DateTimePicker1.Value.Day Then
                    cantDias = tspan.Days + 1
                Else
                    cantDias = tspan.Days + 2
                End If
            Else
                cantDias = tspan.Days + 2
        End If
        

    End Sub

End Class