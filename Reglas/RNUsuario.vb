Imports Entidades
Imports AccesoDatos
Imports System.Net
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class RNUsuario
    Inherits CADO

    Public Function Verificarusuario(ByVal txtUsuario As String, ByVal txtPassword As String) As List(Of Object)
        Dim parametros As New List(Of CParametro)
        Dim respuesta As New List(Of Object)
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pusername", txtUsuario))
            parametros.Add(New CParametro("@ppassword", txtPassword))
            parametros.Add(New CParametro("@respuesta", False, CParametro.DireccionParametro.SALIDA))
            parametros.Add(New CParametro("@idusu", False, CParametro.DireccionParametro.SALIDA))
            'parametros.Add(New CParametro("@tipousu", False, CParametro.DireccionParametro.SALIDA))
            Me.EjecutarOrden("sp_verificarUsuario", parametros)
            respuesta.Add(parametros.Item(2).Valor)
            respuesta.Add(parametros.Item(3).Valor)
            'respuesta.Add(parametros.Item(4).Valor)
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Cerrar(False)
        End Try
        Return respuesta
    End Function

    Public Function ObtenerUsuario(ByVal pid As Integer) As Usuario

        Dim usuario As Usuario = Nothing
        Dim parametros As New List(Of CParametro)
        Dim dr As MySqlDataReader = Nothing
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pid", pid))
            dr = Me.PedirDataReader("sp_leerUsuario", parametros)
            If dr.Read = True Then
                usuario = New Usuario
                With usuario
                    .id = pid
                    .username = dr.Item("username")
                    .tipo = dr.Item("tipo")
                    .trabajador = New Trabajador With {.id = dr.Item("trabajador")}
                End With
            End If
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Cerrar(False)
        End Try
        Return usuario
    End Function
    Sub actualizar(wusuario As Usuario)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wusuario.id))
        parametros.Add(New CParametro("@pusername", wusuario.username))
        parametros.Add(New CParametro("@ppswd", wusuario.pswd))
        parametros.Add(New CParametro("@ptipo", wusuario.tipo))
        parametros.Add(New CParametro("@ptrabajador", wusuario.trabajador.id))

        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_actualizarUsuario", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub

    Sub registrar(wusuario As Usuario)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wusuario.id))
        parametros.Add(New CParametro("@pusername", wusuario.username))
        parametros.Add(New CParametro("@ppswd", wusuario.pswd))
        parametros.Add(New CParametro("@ptipo", wusuario.tipo))
        parametros.Add(New CParametro("@ptrabajador", wusuario.trabajador.id))
        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_insertarUsuario", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub

    Function leer(pid As Integer) As Usuario
        Dim usuario As Usuario = Nothing
        Dim parametros As New List(Of CParametro)
        Dim dr As MySqlDataReader = Nothing
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pid", pid))
            dr = Me.PedirDataReader("sp_leerUsuario", parametros)
            If dr.Read = True Then
                usuario = New Usuario
                With usuario
                    .id = pid
                    .username = dr.Item("username")
                    .pswd = dr.Item("pswd")
                    .tipo = dr.Item("tipo")
                    .trabajador = New Trabajador With {.id = dr.Item("trabajador"), .nombre = dr.Item("nombreTrabajador"), .apePaterno = dr.Item("apellidoTrabajador")}

                End With
            End If
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Cerrar(False)
        End Try
        Return usuario
    End Function

    Sub eliminar(wUsuario As Usuario)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wUsuario.id))
        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_eliminarUsuario", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub
    Public Function listar() As List(Of Usuario)
        Dim usuarios As List(Of Usuario)
        Dim dr As MySqlDataReader = Nothing
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            dr = Me.PedirDataReader("sp_listarUsuarios", parametros)
            usuarios = New List(Of Usuario)
            While dr.Read
                usuarios.Add(New Usuario)
                With usuarios.Item(usuarios.Count - 1)
                    .id = dr.Item("id")
                    .username = dr.Item("username")
                    .pswd = dr.Item("pswd")
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
        Return usuarios

    End Function
End Class
