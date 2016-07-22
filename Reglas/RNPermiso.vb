Imports AccesoDatos
Imports Entidades
Imports MySql.Data.MySqlClient

Public Class RNPermiso
    Inherits CADO
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
        End Try
        Return permisos
    End Function
End Class
