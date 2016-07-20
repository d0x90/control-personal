Public Class frmEvento

    Public Property tipoEvento As String
    Private Sub frmEvento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = tipoEvento
        Me.GroupBox1.Text = tipoEvento
    End Sub


End Class