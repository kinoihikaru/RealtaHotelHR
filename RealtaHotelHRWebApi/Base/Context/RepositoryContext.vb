Namespace base
    Public Class RepositoryContext
        Implements IRepositoryContext

        Private ReadOnly _connString As String

        Public Sub New(connString As String)
            _connString = connString
        End Sub

        Public Function GetConnection() As Object Implements IRepositoryContext.GetConnection
            Return _connString
        End Function
    End Class

End Namespace