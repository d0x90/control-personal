Imports Reglas

Public Class frmEvento

    Public Property tipoEvento As String
    Private Sub frmEvento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = tipoEvento
        Me.GroupBox1.Text = tipoEvento
        Dim rnEventos As New RNEvento
        'congratulation,amonestacion,sancion
        Me.dgvEventos.DataSource = rnEventos.listarEventos(tipoEvento)
        
    End Sub


End Class