Public Class Evento
    Public Property id As Integer

    Public Property tipo As String
    Public Property descripcion As String
    Public Property trabajador As Trabajador
    Public ReadOnly Property nombreTrabajador
        Get
            Return trabajador.nombre & " " & trabajador.apePaterno
        End Get
    End Property
End Class
