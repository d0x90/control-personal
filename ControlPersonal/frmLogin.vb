Imports Entidades
Imports Reglas
Public Class frmLogin

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim rn As New RNUsuario
        Dim res = rn.Verificarusuario(txtUsuario.Text, txtContrasenia.Text)
        ' 0 : no se pudo logear
        If CInt(res.Item(0)) = 0 Then
            MsgBox("Error, usuario y/o contraseña incorrectos")
        Else
            DataSesion.idusuario = CInt(res.Item(1))
            frmMain.Show()
            Me.Hide()
        End If

    End Sub
End Class
