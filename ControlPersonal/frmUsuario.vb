Imports Entidades
Imports Reglas

Public Class frmUsuario
    Dim actual As Usuario
    Private Sub frmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarTabla()
        listarTrabajadores()

    End Sub

    Private Sub limpiarControles()
        Me.cmbTrabajador.SelectedIndex = -1
        Me.txtUsuario.Text = ""
        Me.txtContrasenia.Text = ""
        Me.cmbTipo.SelectedIndex = -1
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
        Dim rn As New RNUsuario
        'licencias, permisos, vacaciones
        Me.dgvUsuarios.AutoGenerateColumns = False
        Me.dgvUsuarios.DataSource = rn.listar()

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvUsuarios.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvUsuarios.CurrentRow.DataBoundItem, Usuario)
            Me.ActivarControles(True)
            Me.PresentarDatos()

        Else
            MessageBox.Show("Debe seleccionar un usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ActivarControles(e As Boolean)
        Me.cmbTrabajador.Enabled = e
        Me.txtUsuario.Enabled = e
        Me.txtContrasenia.Enabled = e
        Me.cmbTipo.Enabled = e
        Me.btnCancelar.Enabled = e
        Me.btnGuardar.Enabled = e
        Me.GroupBox1.Enabled = e

        Me.dgvUsuarios.Enabled = Not e
        Me.btnNuevo.Enabled = Not e
        Me.btnModificar.Enabled = Not e
        Me.btnEliminar.Enabled = Not e
        Me.GroupBox2.Enabled = Not e
    End Sub

    Private Sub PresentarDatos()
        Dim rn As New RNUsuario
        Try
            Me.actual = rn.leer(Me.actual.id)
            With Me.actual
                Me.txtUsuario.Text = .username
                Me.txtContrasenia.Text = .pswd
                Me.cmbTrabajador.SelectedValue = .trabajador.id
                Select Case .tipo
                    Case "A"c
                        Me.cmbTipo.SelectedItem = "Administrador"
                    Case "C"c
                        Me.cmbTipo.SelectedItem = "Contador"
                    Case "R"c
                        Me.cmbTipo.SelectedItem = "RR.HH"
                    Case "E"c
                        Me.cmbTipo.SelectedItem = "Especialista"

                End Select

            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.txtUsuario.Text.Trim <> "" And Me.txtContrasenia.Text.Trim <> "" And Me.cmbTipo.SelectedIndex <> -1 And Me.cmbTrabajador.SelectedIndex <> -1 Then
            Dim rnUsuario As New RNUsuario
            Dim usuario As New Usuario
            usuario.username = Me.txtUsuario.Text
            usuario.pswd = Me.txtContrasenia.Text
            Select Case Me.cmbTipo.SelectedItem
                Case "Administrador"
                    usuario.tipo = "A"c
                Case "Contador"
                    usuario.tipo = "C"c
                Case "RR.HH"
                    usuario.tipo = "R"c
                Case "Especialista"
                    usuario.tipo = "E"c

            End Select

            usuario.trabajador = DirectCast(Me.cmbTrabajador.SelectedItem, Trabajador)

            If actual Is Nothing Then

                rnUsuario.registrar(usuario)
            Else

                usuario.id = Me.actual.id
                rnUsuario.actualizar(usuario)
            End If
            listarTabla()
            Me.limpiarControles()
            ActivarControles(False)
            actual = Nothing
        Else
            MsgBox("Rellene los campos para poder registrar/actualizar el Usuario")
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.limpiarControles()
        Me.ActivarControles(False)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.limpiarControles()
        Me.ActivarControles(True)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim rn As New RNUsuario
        If Me.dgvUsuarios.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvUsuarios.CurrentRow.DataBoundItem, Usuario)
            rn.eliminar(Me.actual)
            Me.actual = Nothing
            listarTabla()
        Else
            MessageBox.Show("Debe seleccionar un usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class