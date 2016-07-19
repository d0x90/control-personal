Imports Entidades
Imports AccesoDatos
Imports System.Net
Imports System.Data.SqlClient

Public Class RNUsuario
    Inherits CADO

    Public Function Verificarusuario(txtUsuario As String, txtPassword As String) As List(Of Object)
        Dim parametros As New List(Of CParametro)
        Dim respuesta As New List(Of Object)
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pusername", txtUsuario))
            parametros.Add(New CParametro("@ppassword", txtPassword))
            parametros.Add(New CParametro("@respuesta", False, CParametro.DireccionParametro.SALIDA))
            parametros.Add(New CParametro("@idusu", False, CParametro.DireccionParametro.SALIDA))
            Me.EjecutarOrden("sp_verificarUsuario", parametros)
            respuesta.Add(parametros.Item(2).Valor)
            respuesta.Add(parametros.Item(3).Valor)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
        End Try
        Return respuesta
    End Function

    Public Function ObtenerUsuario(txtUsuario As String, txtPassword As String) As List(Of Object)
        Dim parametros As New List(Of CParametro)
        Dim respuesta As New List(Of Object)
        Dim resultado As Boolean = 0
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pusername", txtUsuario))
            parametros.Add(New CParametro("@ppassword", txtPassword))
            Me.PedirDataReader("sp_verificarUsuario", parametros)
            respuesta.Add(parametros.Item(2).Valor)
            respuesta.Add(parametros.Item(3).Valor)
            Me.Cerrar(True)
        Catch ex As Exception
            resultado = 0
            Me.Cerrar(False)

        End Try
        Return respuesta
    End Function
End Class
