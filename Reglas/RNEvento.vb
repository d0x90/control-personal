Imports AccesoDatos
Imports MySql.Data.MySqlClient
Imports Entidades

Public Class RNEvento
    Inherits CADO
    Public Sub registrar(ByVal wEvento As Evento)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pdescripcion", wEvento.descripcion))
        parametros.Add(New CParametro("@ptrabajador", wEvento.trabajador.id))
        parametros.Add(New CParametro("@ptipo", wEvento.tipo))

        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_insertarEvento", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub
    Public Sub actualizar(ByVal wEvento As Evento)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wEvento.id))
        parametros.Add(New CParametro("@ptipo", wEvento.tipo))
        parametros.Add(New CParametro("@pdescripcion", wEvento.descripcion))
        parametros.Add(New CParametro("@ptrabajador", wEvento.trabajador.id))


        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_actualizarEvento", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub
    Public Sub eliminar(ByVal wEvento As Evento)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wEvento.id))
        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_eliminarEvento", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub

    Public Function leer(ByVal pid As Integer) As Evento

        Dim evento As Evento = Nothing
        Dim parametros As New List(Of CParametro)
        Dim dr As MySqlDataReader = Nothing
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pid", pid))
            dr = Me.PedirDataReader("sp_leerEvento", parametros)
            If dr.Read = True Then
                evento = New Evento
                With evento
                    .id = pid
                    .tipo = dr.Item("tipo")
                    .descripcion = dr.Item("descripcion")
                    .trabajador = New Trabajador With {.id = dr.Item("trabajador"), .nombre = dr.Item("nombreTrabajador"), .apePaterno = dr.Item("apellidoTrabajador")}
                End With
            End If
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Cerrar(False)
        End Try
        Return evento
    End Function

    Public Function listarEventos(tipofiltro As String) As List(Of Evento)
        Dim eventos As List(Of Evento)
        Dim dr As MySqlDataReader = Nothing
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@tipofiltro", tipofiltro))
            dr = Me.PedirDataReader("sp_listarEventos", parametros)
            eventos = New List(Of Evento)
            While dr.Read
                eventos.Add(New Evento)
                With eventos.Item(eventos.Count - 1)
                    .id = dr.Item("id")
                    .descripcion = dr.Item("descripcion")
                    .tipo = dr.Item("tipo")

                    .trabajador = New Trabajador With {.id = dr.Item("trabajador"), .nombre = dr.Item("nombreTrabajador"), .apePaterno = dr.Item("apellidoTrabajador")}

                End With
            End While
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            If dr IsNot Nothing Then
                dr.Close()
            End If
            dr = Nothing
        End Try
        Return eventos
    End Function

End Class
