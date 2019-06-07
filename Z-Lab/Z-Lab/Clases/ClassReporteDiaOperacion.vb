Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Public Class ClassReporteDiaOperacion
    ' Properties
    Public Property fecha As DateTime

        Get
            Return Me._fecha
        End Get

        Set(ByVal AutoPropertyValue As DateTime)
            Me._fecha = AutoPropertyValue
        End Set
    End Property

    Public Property horasop As String

        Get
            Return Me._horasop
        End Get

        Set(ByVal AutoPropertyValue As String)
            Me._horasop = AutoPropertyValue
        End Set
    End Property

    Public Property Rfc As String

        Get
            Return Me._Rfc
        End Get

        Set(ByVal AutoPropertyValue As String)
            Me._Rfc = AutoPropertyValue
        End Set
    End Property

    Public Property ton As Decimal

        Get
            Return Me._ton
        End Get

        Set(ByVal AutoPropertyValue As Decimal)
            Me._ton = AutoPropertyValue
        End Set
    End Property

    Public Property ano As Decimal

        Get
            Return Me._ano
        End Get

        Set(ByVal AutoPropertyValue As Decimal)
            Me._ano = AutoPropertyValue
        End Set
    End Property

    Public Property mes As Decimal

        Get
            Return Me._mes
        End Get

        Set(ByVal AutoPropertyValue As Decimal)
            Me._mes = AutoPropertyValue
        End Set
    End Property

    Public Property periodo As String
        Get
            Return Me._periodo
        End Get
        Set(ByVal AutoPropertyValue As String)
            Me._periodo = AutoPropertyValue
        End Set
    End Property


    Private _fecha As DateTime
    Private _horasop As String
    Private _Rfc As String
    Private _ton As Decimal
    Private _ano As Decimal
    Private _mes As Decimal
    Private _periodo As String
    Public Detail As List(Of CToneladasMuestra) = New List(Of CToneladasMuestra)

End Class
