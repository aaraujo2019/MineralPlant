
Public Class CToneladasMuestra
    ' Properties
    Public Property Hora As String

        Get
            Return Me._Hora
        End Get

        Set(ByVal AutoPropertyValue As String)
            Me._Hora = AutoPropertyValue
        End Set
    End Property

    Public Property Toneladas As Decimal

        Get
            Return Me._Toneladas
        End Get

        Set(ByVal AutoPropertyValue As Decimal)
            Me._Toneladas = AutoPropertyValue
        End Set
    End Property

    Public Property Turno As String

        Get
            Return Me._Turno
        End Get

        Set(ByVal AutoPropertyValue As String)
            Me._Turno = AutoPropertyValue
        End Set
    End Property

    Public Property Muestra As String

        Get
            Return Me._Muestra
        End Get

        Set(ByVal AutoPropertyValue As String)
            Me._Muestra = AutoPropertyValue
        End Set
    End Property


    Private _Hora As String
    Private _Toneladas As Decimal
    Private _Turno As String
    Private _Muestra As String
End Class
