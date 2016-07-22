Public Class Evento
    Public Property id As Integer
    Enum nombres
        congratulation
        amonestacion
        sancion
    End Enum
    Public Property nombre As String
    Public Property descripcion As String
    Public Property trabajador As Trabajador

End Class
