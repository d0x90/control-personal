Imports Reglas
Imports Entidades
Public Class frmPermiso
    Public Property tipoPermiso As String
    Dim actual As Permiso

    Private Sub frmPermiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = tipoPermiso
        Me.GroupBox1.Text = tipoPermiso
        Me.GroupBox2.Text = "Lista de " & tipoPermiso
        listarTabla()
        listarTrabajadores()
    End Sub
    Private Sub limpiarControles()
        Me.cmbTrabajador.SelectedIndex = -1
        Me.DateTimePicker1.Value = Now
        Me.DateTimePicker2.Value = Now
        Me.txtDescripcion.Text = ""
        Me.actual = Nothing
    End Sub
    Private Sub listarTrabajadores()
        Dim rn As New RNTrabajador
        Dim trabajadores As New List(Of Trabajador)
        Try
            trabajadores = rn.listarTrabajadores

            If trabajadores.Count > 0 Then
                Me.cmbTrabajador.DataSource = trabajadores
                Me.cmbTrabajador.ValueMember = "id"
                Me.cmbTrabajador.DisplayMember = "LeerNombreTrabajador"
                Me.cmbTrabajador.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("No se encontraron Trabajadores", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub listarTabla()
        Dim rnPermiso As New RNPermiso
        'licencias, permisos, vacaciones
        Me.dgvPermisos.AutoGenerateColumns = False
        Me.dgvPermisos.DataSource = rnPermiso.listarPermisos(tipoPermiso)
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvPermisos.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvPermisos.CurrentRow.DataBoundItem, Permiso)
            Me.ActivarControles(True)
            Me.PresentarDatos()

        Else
            MessageBox.Show("Debe seleccionar un permiso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PresentarDatos()
        Dim rn As New RNPermiso
        Try
            Me.actual = rn.leer(Me.actual.id)
            Me.cmbTrabajador.SelectedValue = Me.actual.trabajador.id
            Me.DateTimePicker1.Value = Me.actual.fechaInicio
            Me.DateTimePicker2.Value = Me.actual.fechaFin
            Me.txtDescripcion.Text = Me.actual.descripcion

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Me.limpiarControles()
        Me.ActivarControles(True)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.limpiarControles()
        Me.ActivarControles(False)
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.cmbTrabajador.SelectedIndex <> -1 And Me.txtDescripcion.Text.Trim <> "" Then
            Dim rnPermiso As New RNPermiso
            Dim permiso As New Permiso
            permiso.fechaInicio = DateTimePicker1.Value
            permiso.fechaFin = DateTimePicker2.Value

            Dim tspan As TimeSpan = DateTimePicker2.Value - DateTimePicker1.Value 'Dia Inicial + Dia final
            If tspan.Days = 0 Then
                If DateTimePicker2.Value.Day = DateTimePicker1.Value.Day Then
                    permiso.cantidadDias = tspan.Days + 1
                Else
                    permiso.cantidadDias = tspan.Days + 2
                End If
            Else
                permiso.cantidadDias = tspan.Days + 2
            End If
            permiso.trabajador = DirectCast(Me.cmbTrabajador.SelectedItem, Trabajador)
            permiso.descripcion = Me.txtDescripcion.Text
            permiso.tipo = Me.tipoPermiso

            If actual Is Nothing Then

                rnPermiso.registrar(permiso)
            Else

                permiso.id = Me.actual.id
                rnPermiso.actualizar(permiso)
            End If
            listarTabla()
            Me.limpiarControles()
            ActivarControles(False)
            actual = Nothing
        Else
            MsgBox("Rellene los campos para poder registrar/actualizar el Permiso")
        End If
        
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim rn As New RNPermiso
        If Me.dgvPermisos.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvPermisos.CurrentRow.DataBoundItem, Permiso)
            rn.eliminar(Me.actual)
            Me.actual = Nothing
            listarTabla()
        Else
            MessageBox.Show("Debe seleccionar un permiso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class