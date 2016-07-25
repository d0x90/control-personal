Imports Reglas
Imports Entidades

Public Class frmTrabajador
    Dim actual As Trabajador
    Private Sub frmTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbArea.SelectedIndex = 0
        listarTabla()


    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.txtNombre.Text.Trim <> "" And Me.txtApePaterno.Text.Trim <> "" And Me.txtSueldo.Text.Trim <> "" And Me.txtApeMaterno.Text.Trim <> "" And Me.cmbArea.SelectedIndex <> -1 Then
            Dim nTrabajador As New RNTrabajador
            Dim trabajador As New Trabajador
            trabajador.nombre = Me.txtNombre.Text
            trabajador.apeMaterno = Me.txtApeMaterno.Text
            trabajador.apePaterno = Me.txtApePaterno.Text
            trabajador.asignacionFamiliar = Me.chkAsignacionFamiliar.Checked
            trabajador.seguro = Me.chkSeguro.Checked
            'Contabilidad
            'Especialista
            'RR.HH

            Select Case Me.cmbArea.SelectedItem
                Case "Contabilidad"
                    trabajador.area = "C"c
                Case "Especialista"
                    trabajador.area = "E"c
                Case "RR.HH"
                    trabajador.area = "R"c
            End Select

            trabajador.sueldo = Me.txtSueldo.Text

            If actual Is Nothing Then

                nTrabajador.registrar(trabajador)
            Else

                trabajador.id = Me.actual.id
                nTrabajador.actualizar(trabajador)
            End If
            listarTabla()
            Me.limpiarControles()
            ActivarControles(False)
            actual = Nothing
        Else
            MsgBox("Rellene los campos para poder registrar/actualizar el Trabajador")
        End If
        
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvTrabajadores.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvTrabajadores.CurrentRow.DataBoundItem, Trabajador)
            Me.ActivarControles(True)
            Me.PresentarDatos()

        Else
            MessageBox.Show("Debe seleccionar un trabajador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim rn As New RNTrabajador
        If Me.dgvTrabajadores.CurrentRow IsNot Nothing Then
            Me.actual = DirectCast(Me.dgvTrabajadores.CurrentRow.DataBoundItem, Trabajador)
            rn.eliminar(Me.actual)
            listarTabla()

        Else
            MessageBox.Show("Debe seleccionar un trabajador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.limpiarControles()
        Me.ActivarControles(True)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.limpiarControles()
        Me.ActivarControles(False)
    End Sub

    Private Sub listarTabla()
        Dim rn As New RNTrabajador
        'licencias, permisos, vacaciones
        Me.dgvTrabajadores.AutoGenerateColumns = False
        Me.dgvTrabajadores.DataSource = rn.listarTrabajadores()
    End Sub

    Private Sub limpiarControles()
        Me.txtNombre.Text = ""
        Me.txtApeMaterno.Text = ""
        Me.txtApePaterno.Text = ""
        Me.cmbArea.SelectedIndex = -1
        Me.txtSueldo.Text = ""
        Me.chkSeguro.Checked = False
        Me.chkAsignacionFamiliar.Checked = False
    End Sub

    Private Sub ActivarControles(e As Boolean)
        Me.cmbArea.Enabled = e
        Me.txtNombre.Enabled = e
        Me.txtApePaterno.Enabled = e
        Me.txtApeMaterno.Enabled = e
        Me.txtSueldo.Enabled = e
        Me.chkSeguro.Enabled = e
        Me.chkAsignacionFamiliar.Enabled = e
        Me.btnCancelar.Enabled = e
        Me.btnGuardar.Enabled = e
        Me.GroupBox1.Enabled = e

        Me.dgvTrabajadores.Enabled = Not e
        Me.btnNuevo.Enabled = Not e
        Me.btnModificar.Enabled = Not e
        Me.btnEliminar.Enabled = Not e
        Me.GroupBox2.Enabled = Not e
    End Sub

    Private Sub PresentarDatos()
        Dim rn As New RNTrabajador
        Try
            Me.actual = rn.leer(Me.actual.id)
            With Me.actual
                Me.txtNombre.Text = .nombre
                Me.txtApeMaterno.Text = .apeMaterno
                Me.txtApePaterno.Text = .apePaterno
                'Contabilidad
                'Especialista
                'RR.HH
                Select Case .area
                    Case "C"c
                        Me.cmbArea.SelectedItem = "Contabilidad"
                    Case "E"c
                        Me.cmbArea.SelectedItem = "Especialista"
                    Case "R"c
                        Me.cmbArea.SelectedItem = "RR.HH"
                End Select
                Me.cmbArea.SelectedValue = .area
                Me.txtSueldo.Text = .sueldo
                Me.chkSeguro.Checked = .seguro
                Me.chkAsignacionFamiliar.Checked = .asignacionFamiliar

            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class