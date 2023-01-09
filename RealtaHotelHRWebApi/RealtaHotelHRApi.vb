Imports RealtaHotelHRWebApi.Base

Public Class RealtaHotelHRApi
    Implements IRealtaHotelHRApi

    Private ReadOnly _repositoryContext As IRepositoryContext
    Private Property _repoManager As IRepositoryManager

    Public Sub New(ByVal connString As String)
        If _repositoryContext Is Nothing Then
            _repositoryContext = New RepositoryContext(connString)
        End If
    End Sub

    Public ReadOnly Property RepositoryManager As IRepositoryManager Implements IRealtaHotelHRApi.RepositoryManager
        Get
            If _repoManager Is Nothing Then
                _repoManager = New RepositoryManager(_repositoryContext)
            End If
            Return _repoManager
        End Get
    End Property
End Class
