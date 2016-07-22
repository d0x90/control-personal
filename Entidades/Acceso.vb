Public Class Acceso
    Public Property id As Integer
    Public Property hora As DateTime
    Public Property tipo As Char
    Public Property trabajador As Trabajador

    Public ReadOnly Property LeerNombreTrabajador
        Get
            Return trabajador.nombre & " " & trabajador.apePaterno
        End Get
    End Property


End Class
