Imports RealtaHotelHRWebApi.Base
Imports RealtaHotelHRWebApi.Model

Namespace Repository
    Public Interface IWorkOrdersRepo
        Function CreateWorkOrders(ByVal workOrders As WorkOrders) As WorkOrders
        Function FindAllWorkOrders() As List(Of WorkOrders)
        Function FindWorkOrdersById(ByVal id As Int32) As WorkOrders
        Function DeleteWorkOrdersById(ByVal id As Int32) As Int32
        Function UpdateWorkOrders(id As Integer, startDate As DateTime, status As String, userId As Integer, showCommand As Integer) As Boolean
        Function UpdateWorkOrdersSp(id As Integer, startDate As DateTime, status As String, userId As Integer, showCommand As Integer) As Boolean

    End Interface

End Namespace