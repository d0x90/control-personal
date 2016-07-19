Public Class CParametro

  Public Enum DireccionParametro
    ENTRADA = 1
    SALIDA = 2
    ENTRADA_SALIDA = 3
    RETORNO = 4
  End Enum

#Region "Datos"
  Private mNombre As String
  Private mValor As Object
  Private mDireccion As DireccionParametro
#End Region

#Region "Propiedades"
  Public Property Valor() As Object
    Get
      Return mValor
    End Get
    Set(ByVal value As Object)
      mValor = value
    End Set
  End Property

  Public Property Nombre() As String
    Get
      Return mNombre
    End Get
    Set(ByVal value As String)
      mNombre = value
    End Set
  End Property

  Public Property Direccion() As DireccionParametro
    Get
      Return mDireccion
    End Get
    Set(ByVal value As DireccionParametro)
      mDireccion = value
    End Set
  End Property

  Public ReadOnly Property DireccionBD() As ParameterDirection

    Get
      Select Case Me.Direccion
        Case DireccionParametro.ENTRADA
          Return ParameterDirection.Input
        Case DireccionParametro.SALIDA
          Return ParameterDirection.Output
        Case DireccionParametro.ENTRADA_SALIDA
          Return ParameterDirection.InputOutput
        Case Else
          Return ParameterDirection.ReturnValue
      End Select
    End Get
  End Property

#End Region

#Region "Constructores"
  Public Sub New()
    Me.Nombre = ""
    Me.Valor = Nothing
    Me.Direccion = DireccionParametro.ENTRADA
  End Sub

  Public Sub New(ByVal wNombre As String, ByVal wValor As Object)
    Me.Nombre = wNombre
    Me.Valor = wValor
    Me.Direccion = DireccionParametro.ENTRADA
  End Sub

  Public Sub New(ByVal wNombre As String, ByVal wValor As Object, ByVal wDireccion As DireccionParametro)
    Me.Nombre = wNombre
    Me.Valor = wValor
    Me.Direccion = wDireccion
  End Sub
#End Region

End Class
