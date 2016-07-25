Imports AccesoDatos
Imports Entidades
Imports MySql.Data.MySqlClient

Public Class RNAcceso
    Inherits CADO
    Public Sub registrar(acceso As Acceso)
        Dim parametros As New List(Of CParametro)
        parametros.Add(New CParametro("@ptipo", acceso.tipo))
        parametros.Add(New CParametro("@ptrabajador", acceso.trabajador.id))
        Try
            Me.Conectar(True)
            Me.EjecutarOrden("sp_insertarAcceso", parametros)
            Me.Cerrar(True)
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cerrar(False)
            Throw ex
        End Try
    End Sub

    Public Function listar() As List(Of Acceso)
        Dim accesos As List(Of Acceso)
        Dim dr As MySqlDataReader = Nothing
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            dr = Me.PedirDataReader("sp_listarAccesos", parametros)
            accesos = New List(Of Acceso)
            While dr.Read
                accesos.Add(New Acceso)
                With accesos.Item(accesos.Count - 1)
                    .id = dr.Item("id")
                    .hora = dr.Item("hora")
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
        Return accesos
    End Function

    Function llenarReporte() As DataTable
        Dim datatable As DataTable
        Dim parametros As New List(Of CParametro)
        Try
            Me.Conectar(False)
            datatable = Me.PedirDatatable("sp_listarAccesos", parametros)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Throw ex
        End Try
        Return datatable
    End Function

End Class
