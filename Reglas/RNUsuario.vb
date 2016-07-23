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
End Class
