Public Class Usuario
    Public Property id As Integer
    Public Property username As String
    Public Property pswd As String
    Public Property tipo As Char
    Public Property trabajador As Trabajador


    Public ReadOnly Property nombreTrabajador
        Get
            Return trabajador.nombre & " " & trabajador.apePaterno
        End Get
    End Property
    Public ReadOnly Property mostrarTipo
        Get
            Select tipo
                Case "R"c
                    Return "RR.HH"
                Case "C"c
                    Return "Contador"
                Case "E"c
                    Return "Especialista"
                Case Else
                    Return "Administrador"
            End Select
        End Get
    End Property

End Class
