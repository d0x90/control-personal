Imports AccesoDatos
Imports MySql.Data.MySqlClient
Imports Entidades

Public Class RNEvento
    Inherits CADO

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
                    .nombre = dr.Item("nombre")
                    .trabajador = New Trabajador With {.id = dr.Item("trabajador")}

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
