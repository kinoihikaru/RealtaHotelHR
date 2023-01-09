Namespace Model
    Public Class WorkOrderDetail
        Private _wodeId As Integer
        Private _wodeTaskName As String
        Private _wodeStatus As String
        Private _wodeStartDate As DateTime
        Private _wodeEndDate As DateTime
        Private _wodeNotes As String
        Private _wodeEmpId As Integer
        Private _wodeSetaId As Integer
        Private _wodeFaciId As Integer
        Private _wodeWoroId As Integer

        Public Sub New()
        End Sub

        Public Sub New(wodeId As Integer, wodeTaskName As String, wodeStatus As String, wodeStartDate As Date, wodeEndDate As Date, wodeNotes As String, wodeEmpId As Integer, wodeSetaId As Integer, wodefaciId As Integer, wodeWoroId As Integer)
            Me.WodeId = wodeId
            Me.WodeTaskName = wodeTaskName
            Me.WodeStatus = wodeStatus
            Me.WodeStartDate = wodeStartDate
            Me.WodeEndDate = wodeEndDate
            Me.WodeNotes = wodeNotes
            Me.WodeEmpId = wodeEmpId
            Me.WodeSetaId = wodeSetaId
            Me.WodefaciId = wodefaciId
            Me.WodeWoroId = wodeWoroId
        End Sub

        Public Overrides Function ToString() As String
            Return $"WodeId : {_wodeId}, WodeTaskName : {_wodeTaskName}, WodeStatus : {_wodeStatus}, WodeStartDate : {_wodeStartDate}, WodeEndDate : {_wodeEndDate}, WodeNotes : {_wodeNotes}, WodeEmpId : {_wodeEmpId}, WodeSetaId : {_wodeSetaId}, WodeFaciId : {_wodeFaciId}, WodeWoroId : {_wodeWoroId}"
        End Function

        Public Property WodeId As Integer
            Get
                Return _wodeId
            End Get
            Set(value As Integer)
                _wodeId = value
            End Set
        End Property

        Public Property WodeTaskName As String
            Get
                Return _wodeTaskName
            End Get
            Set(value As String)
                _wodeTaskName = value
            End Set
        End Property

        Public Property WodeStatus As String
            Get
                Return _wodeStatus
            End Get
            Set(value As String)
                _wodeStatus = value
            End Set
        End Property

        Public Property WodeStartDate As Date
            Get
                Return _wodeStartDate
            End Get
            Set(value As Date)
                _wodeStartDate = value
            End Set
        End Property

        Public Property WodeEndDate As Date
            Get
                Return _wodeEndDate
            End Get
            Set(value As Date)
                _wodeEndDate = value
            End Set
        End Property

        Public Property WodeNotes As String
            Get
                Return _wodeNotes
            End Get
            Set(value As String)
                _wodeNotes = value
            End Set
        End Property

        Public Property WodeEmpId As Integer
            Get
                Return _wodeEmpId
            End Get
            Set(value As Integer)
                _wodeEmpId = value
            End Set
        End Property

        Public Property WodeSetaId As Integer
            Get
                Return _wodeSetaId
            End Get
            Set(value As Integer)
                _wodeSetaId = value
            End Set
        End Property

        Public Property WodeFaciId As Integer
            Get
                Return _wodeFaciId
            End Get
            Set(value As Integer)
                _wodefaciId = value
            End Set
        End Property

        Public Property WodeWoroId As Integer
            Get
                Return _wodeWoroId
            End Get
            Set(value As Integer)
                _wodeWoroId = value
            End Set
        End Property
    End Class

End Namespace