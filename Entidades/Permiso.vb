Public Class Permiso
    Public Property id As Integer
    Public Property cantidadDias As Integer
    Public Property fechaInicio As DateTime
    Public Property fechaFin As DateTime
    Public Property descripcion As String
    Public Property trabajador As Trabajador
    
    Public Property tipo As String

    Public ReadOnly Property nombreTrabajador
        Get
            Return trabajador.nombre & " " & trabajador.apePaterno
        End Get
    End Property
End Class
