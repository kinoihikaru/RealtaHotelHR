Namespace Model
    Public Class WorkOrders
        Private _woroId As Integer
        Private _woroStartDate As DateTime
        Private _woroStatus As String
        Private _woroUserId As Integer = Nothing

        Public Sub New()
        End Sub

        Public Sub New(woroId As Integer, woroStartDate As Date, woroStatus As String, woroUserId As Integer)
            _woroId = woroId
            _woroStartDate = woroStartDate
            _woroStatus = woroStatus
            _woroUserId = woroUserId
        End Sub

        Public Overrides Function ToString() As String
            Return $"WoroId : {_woroId}, WoroStartDate : {_woroStartDate}, WoroStatus : {_woroStatus}, WoroUserId : {_woroUserId}"
        End Function

        Public Property WoroId As Integer
            Get
                Return _woroId
            End Get
            Set(value As Integer)
                _woroId = value
            End Set
        End Property

        Public Property WoroStartDate As Date
            Get
                Return _woroStartDate
            End Get
            Set(value As Date)
                _woroStartDate = value
            End Set
        End Property

        Public Property WoroStatus As String
            Get
                Return _woroStatus
            End Get
            Set(value As String)
                _woroStatus = value
            End Set
        End Property

        Public Property WoroUserId As Integer
            Get
                Return _woroUserId
            End Get
            Set(value As Integer)
                _woroUserId = value
            End Set
        End Property
    End Class

End Namespace