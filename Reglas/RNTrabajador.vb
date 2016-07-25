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


End Class
