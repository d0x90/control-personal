Imports Reglas
Imports Entidades

Public Class frmEvento

    Public Property tipoEvento As String
    Dim actual As Evento
    Private Sub frmEvento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = tipoEvento
        Me.GroupBox1.Text = tipoEvento
        'congratulation,amonestacion,sancion
        listarTabla()
        listarTrabajadores()
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
        Dim rnEvento As New RNEvento
        'licencias, permisos, vacaciones
        Me.dgvEventos.AutoGenerateColumns = False
        Me.dgvEventos.DataSource = rnEvento.listarEventos(tipoEvento)
    End Sub

    Private Sub ActivarControles(e As Boolean)

        Me.cmbTrabajador.Enabled = e
        Me.txtDescripcion.Enabled = e

        Me.btnCancelar.Enabled = e
        Me.btnGuardar.Enabled = e
        Me.GroupBox1.Enabled = e

        Me.dgvEventos.Enabled = Not e
        Me.btnNuevo.Enabled = Not e
        Me.btnModificar.Enabled = Not e
        Me.btnEliminar.Enabled = Not e
        Me.GroupBox2.Enabled = Not e

    End Sub
    Private Sub PresentarDatos()
        Dim rn As New RNEvento
        Try
            Me.actual = rn.leer(Me.actual.id)
            Me.cmbTrabajador.SelectedValue = Me.actual.trabajador.id
            Me.txtDescripcion.Text = Me.actual.descripcion

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub limpiarControles()
        Me.cmbTrabajador.SelectedIndex = 0
        Me.txtDescripcion.Text = ""
        Me.actual = Nothing
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.limpiarControles()
        Me.ActivarControles(True)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvEventos.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvEventos.CurrentRow.DataBoundItem, Evento)
            Me.ActivarControles(True)
            Me.PresentarDatos()

        Else
            MessageBox.Show("Debe seleccionar un permiso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim rnEvento As New RNEvento
        Dim evento As New Evento
        evento.tipo = Me.tipoEvento
        evento.descripcion = Me.txtDescripcion.Text
        evento.trabajador = DirectCast(Me.cmbTrabajador.SelectedItem, Trabajador)
        If actual Is Nothing Then

            rnEvento.registrar(evento)
        Else

            evento.id = Me.actual.id
            rnEvento.actualizar(evento)
        End If
        listarTabla()
        Me.limpiarControles()
        ActivarControles(False)
        actual = Nothing
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.limpiarControles()
        Me.ActivarControles(False)
    End Sub
End Class