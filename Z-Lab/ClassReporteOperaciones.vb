
Public Class CToneladasMuestra
    Public Property Hora() As String
    Public Property Toneladas() As Decimal
    Public Property Turno() As String
    Public Property Muestra() As String
End Class
Public Class ClassReporteDiaOperacion
    Public Property fecha() As Date
    Public Property horasop() As String
    Public Property Rfc() As String
    Public Property ton() As Decimal
    Public Property ano() As Decimal
    Public Property mes() As Decimal
    Public Property periodo() As String

    'Creamos una lista con una nueva Instancia de la clase Articulo
    'esta lista contendra el detalle de la factura
    Public Detail As New List(Of CToneladasMuestra)()
End Class