Public Class frmPermiso
    Public Property tipoPermiso As String
    Private Sub frmPermiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = tipoPermiso
        Me.GroupBox1.Text = tipoPermiso
        Me.GroupBox2.Text = "Lista de " & tipoPermiso

    End Sub


End Class