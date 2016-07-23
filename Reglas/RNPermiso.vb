﻿Imports AccesoDatos
Imports Entidades
Imports MySql.Data.MySqlClient

Public Class RNPermiso
    Inherits CADO

    Public Sub registrar(ByVal wPermiso As Permiso)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pcantidaddias", wPermiso.cantidadDias))
        parametros.Add(New CParametro("@pdescripcion", wPermiso.descripcion))
        parametros.Add(New CParametro("@pfechainicio", wPermiso.fechaInicio))
        parametros.Add(New CParametro("@ptipo", wPermiso.tipo))

        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_insertarPermiso", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub
    Public Sub actualizar(ByVal wPermiso As Permiso)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wPermiso.id))
        parametros.Add(New CParametro("@pcantidaddias", wPermiso.cantidadDias))
        parametros.Add(New CParametro("@pdescripcion", wPermiso.descripcion))
        parametros.Add(New CParametro("@pfechainicio", wPermiso.fechaInicio))
        parametros.Add(New CParametro("@ptipo", wPermiso.tipo))

        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_actualizarPermiso", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub
    Public Sub eliminar(ByVal wPermiso As Permiso)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wPermiso.id))
        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_eliminarPermiso", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub

    Public Function leer(ByVal pid As Integer) As Permiso

        Dim permiso As Permiso = Nothing
        Dim parametros As New List(Of CParametro)
        Dim dr As MySqlDataReader = Nothing
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pid", pid))
            dr = Me.PedirDataReader("sp_leerPermiso", parametros)
            If dr.Read = True Then
                permiso = New Permiso
                With permiso
                    .id = pid
                    .cantidadDias = dr.Item("cantidadDias")
                    .fechaInicio = dr.Item("fechaInicio")
                    .fechaFin = dr.Item("fechaFin")
                    .tipo = dr.Item("tipo")
                    .trabajador = New Trabajador With {.id = dr.Item("trabajador")}
                End With
            End If
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Cerrar(False)
        End Try
        Return permiso
    End Function

    Public Function listarPermisos(tipofiltro As String) As List(Of Permiso)
        Dim permisos As List(Of Permiso)
        Dim dr As MySqlDataReader = Nothing
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@tipofiltro", tipofiltro))
            dr = Me.PedirDataReader("sp_ListarPermisos", parametros)
            permisos = New List(Of Permiso)
            While dr.Read
                permisos.Add(New Permiso)
                With permisos.Item(permisos.Count - 1)
                    .id = dr.Item("id")
                    .descripcion = dr.Item("descripcion")
                    .fechaFin = dr.Item("fechaFin")
                    .fechaInicio = dr.Item("fechaInicio")
                    .tipo = dr.Item("tipo")
                    .cantidadDias = dr.Item("cantidadDias")
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
            parametros.Clear()
            parametros = Nothing
        End Try
        Return permisos
    End Function
End Class
