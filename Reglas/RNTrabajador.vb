Imports AccesoDatos
Imports Entidades
Imports MySql.Data.MySqlClient

Public Class RNTrabajador
    Inherits CADO

    Public Function listarTrabajadores() As List(Of Trabajador)
        Dim trabajadores As List(Of Trabajador)
        Dim dr As MySqlDataReader = Nothing
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            dr = Me.PedirDataReader("sp_ListarTrabajadores", parametros)
            trabajadores = New List(Of Trabajador)
            While dr.Read
                trabajadores.Add(New Trabajador)
                With trabajadores.Item(trabajadores.Count - 1)
                    .id = dr.Item("id")
                    .nombre = dr.Item("nombre")
                    .apePaterno = dr.Item("apePaterno")
                    .apeMaterno = dr.Item("apeMaterno")
                    .seguro = dr.Item("seguro")
                    .sueldo = dr.Item("sueldo")
                    .area = dr.Item("area")
                    .asignacionFamiliar = dr.Item("asignacionFamiliar")

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
        Return trabajadores
    End Function

    Public Function llenarReporte() As DataTable
        Dim datatable As DataTable
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            datatable = Me.PedirDatatable("sp_listarTrabajadores", parametros)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Throw ex
        End Try
        Return datatable
    End Function

    Sub actualizar(wtrabajador As Trabajador)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wtrabajador.id))
        parametros.Add(New CParametro("@pnombre", wtrabajador.nombre))
        parametros.Add(New CParametro("@papePaterno", wtrabajador.apePaterno))
        parametros.Add(New CParametro("@papeMaterno", wtrabajador.apeMaterno))
        parametros.Add(New CParametro("@psueldo", wtrabajador.sueldo))
        parametros.Add(New CParametro("@parea", wtrabajador.area))
        parametros.Add(New CParametro("@pseguro", wtrabajador.seguro))
        parametros.Add(New CParametro("@pasignacion", wtrabajador.asignacionFamiliar))

        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_actualizarTrabajador", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub

    Sub registrar(wtrabajador As Trabajador)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pnombre", wtrabajador.nombre))
        parametros.Add(New CParametro("@papePaterno", wtrabajador.apePaterno))
        parametros.Add(New CParametro("@papeMaterno", wtrabajador.apeMaterno))
        parametros.Add(New CParametro("@psueldo", wtrabajador.sueldo))
        parametros.Add(New CParametro("@parea", wtrabajador.area))
        parametros.Add(New CParametro("@pseguro", wtrabajador.seguro))
        parametros.Add(New CParametro("@pasignacionFamiliar", wtrabajador.asignacionFamiliar))
        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_insertarTrabajador", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub

    Function leer(pid As Integer) As Trabajador
        Dim trabajador As Trabajador = Nothing
        Dim parametros As New List(Of CParametro)
        Dim dr As MySqlDataReader = Nothing
        Try
            Me.Conectar(False)
            parametros.Add(New CParametro("@pid", pid))
            dr = Me.PedirDataReader("sp_leerTrabajador", parametros)
            If dr.Read = True Then
                trabajador = New Trabajador
                With trabajador
                    .id = pid
                    .nombre = dr.Item("nombre")
                    .apePaterno = dr.Item("apePaterno")
                    .apeMaterno = dr.Item("apeMaterno")
                    .area = dr.Item("area")
                    .sueldo = dr.Item("sueldo")
                    .seguro = dr.Item("seguro")
                    .asignacionFamiliar = dr.Item("asignacionFamiliar")

                End With
            End If
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Cerrar(False)
        End Try
        Return trabajador
    End Function

    Sub eliminar(wtrabajador As Trabajador)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@pid", wtrabajador.id))
        Try
            Me.Conectar(False)
            Me.EjecutarOrden("sp_eliminarTrabajador", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            Me.Cerrar(False)
            Throw ex
        Finally
            parametros.Clear()
            parametros = Nothing
        End Try
    End Sub


End Class
