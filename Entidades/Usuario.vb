Public Class Usuario
    Public Property id As Integer
    Public Property username As String
    Public Property pswd As String
    Public Property tipo As Char
    Public Property trabajador As Trabajador

    Public ReadOnly Property LeerNombreTrabajador
        Get
            Return trabajador.nombre & " " & trabajador.apePaterno
        End Get
    End Property

End Class
