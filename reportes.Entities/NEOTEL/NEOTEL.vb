Partial Public Class NEOTEL
    Inherits _ERROR
    Private _INICIO As Date
    Public Property INICIO() As Date
        Get
            Return _INICIO
        End Get
        Set(ByVal value As Date)
            _INICIO = value
        End Set
    End Property
    Private _TERMINO As Date
    Public Property TERMINO() As Date
        Get
            Return _TERMINO
        End Get
        Set(ByVal value As Date)
            _TERMINO = value
        End Set
    End Property
    Private _INSTANCIA As String
    Public Property INSTANCIA() As String
        Get
            Return _INSTANCIA
        End Get
        Set(ByVal value As String)
            _INSTANCIA = value
        End Set
    End Property
    Private _USUARIO_SQL As String
    Public Property USUARIO_SQL() As String
        Get
            Return _USUARIO_SQL
        End Get
        Set(ByVal value As String)
            _USUARIO_SQL = value
        End Set
    End Property
    Private _PWD_SQL As String
    Public Property PWD_SQL() As String
        Get
            Return _PWD_SQL
        End Get
        Set(ByVal value As String)
            _PWD_SQL = value
        End Set
    End Property
    Private _PROCEDIMIENTO As String
    Public Property PROCEDIMIENTO() As String
        Get
            Return _PROCEDIMIENTO
        End Get
        Set(ByVal value As String)
            _PROCEDIMIENTO = value
        End Set
    End Property

End Class
