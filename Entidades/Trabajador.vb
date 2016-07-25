Public Class Trabajador
    Public Property id As Integer
    Public Property nombre As String
    Public Property apePaterno As String
    Public Property apeMaterno As String
    Public Property seguro As Boolean
    Public Property asignacionFamiliar As Boolean
    Public Property sueldo As Decimal

    Public ReadOnly Property LeerNombreTrabajador
        Get
            Return nombre & " " & apePaterno
        End Get
    End Property
End Class
