Public Class _ERROR
    Private _errores As String = ""
    Public Property errores() As String
        Get
            Return _errores
        End Get
        Set(ByVal value As String)
            _errores = value
        End Set
    End Property
End Class
