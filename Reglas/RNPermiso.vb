Imports AccesoDatos
Imports Entidades
Imports MySql.Data.MySqlClient

Public Class RNPermiso
    Inherits CADO

    Public Sub registrar(ByVal wPermiso As Permiso)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pcantidadDias", wPermiso.cantidadDias))
        parametros.Add(New CParametro("@pfechaInicio", wPermiso.fechaInicio))
        parametros.Add(New CParametro("@pfechaFin", wPermiso.fechaFin))
        parametros.Add(New CParametro("@pdescripcion", wPermiso.descripcion))
        parametros.Add(New CParametro("@ptrabajador", wPermiso.trabajador.id))
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
        parametros.Add(New CParametro("@pcantidadDias", wPermiso.cantidadDias))
        parametros.Add(New CParametro("@pfechaInicio", wPermiso.fechaInicio))
        parametros.Add(New CParametro("@pfechaFin", wPermiso.fechaFin))
        parametros.Add(New CParametro("@pdescripcion", wPermiso.descripcion))
        parametros.Add(New CParametro("@ptrabajador", wPermiso.trabajador.id))
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
                    .descripcion = dr.Item("descripcion")
                    .trabajador = New Trabajador With {.id = dr.Item("trabajador"), .nombre = dr.Item("nombreTrabajador"), .apePaterno = dr.Item("apellidoTrabajador")}
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
            parametros.Clear()
            parametros = Nothing
        End Try
        Return permisos
    End Function

    Function llenarReporte(p1 As String) As DataTable
        Dim datatable As DataTable
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@tipofiltro", p1))
            datatable = Me.PedirDatatable("sp_listarPermisos", parametros)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Throw ex
        End Try
        Return datatable
    End Function

End Class
