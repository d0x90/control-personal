Imports Reglas
Imports Entidades

Public Class frmAcceso

    Private Sub frmAcceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbTipo.SelectedIndex = 0
        listarTabla()
        listarTrabajadores()

    End Sub
    Private Sub listarTabla()
        Dim rnAcceso As New RNAcceso
        'licencias, permisos, vacaciones
        Me.dgvAccesos.AutoGenerateColumns = False
        Me.dgvAccesos.DataSource = rnAcceso.listar()
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
    Private Sub ActivarControles(e As Boolean)

        Me.cmbTrabajador.Enabled = e
        Me.cmbTipo.Enabled = e

        Me.btnCancelar.Enabled = e
        Me.btnGuardar.Enabled = e
        Me.GroupBox1.Enabled = e

        Me.dgvAccesos.Enabled = Not e
        Me.btnNuevo.Enabled = Not e
        Me.GroupBox2.Enabled = Not e

    End Sub

    Private Sub limpiarControles()
        Me.cmbTrabajador.SelectedIndex = 0
        Me.cmbTipo.SelectedIndex = 0

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim rnAcceso As New RNAcceso
        Dim acceso As New Acceso
        acceso.trabajador = DirectCast(Me.cmbTrabajador.SelectedItem, Trabajador)
        acceso.tipo = Me.cmbTipo.SelectedItem.ToString
        rnAcceso.registrar(acceso)
        listarTabla()
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.ActivarControles(False)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.limpiarControles()
        Me.ActivarControles(True)
    End Sub
End Class