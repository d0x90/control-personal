Imports AccesoDatos
Imports Entidades
Public Class RNAcceso
    Inherits CADO
    Public Sub registrar(acceso As Acceso)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@id", acceso.id))
        parametros.Add(New CParametro("@tipo", acceso.tipo))
        parametros.Add(New CParametro("@hora", acceso.hora))
        parametros.Add(New CParametro("@trabajador", acceso.trabajador.id))
        Try
            Me.Conectar(True)
            Me.EjecutarOrden("sp_registrarAcceso", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cerrar(False)
            Throw ex
        End Try
    End Sub
End Class
