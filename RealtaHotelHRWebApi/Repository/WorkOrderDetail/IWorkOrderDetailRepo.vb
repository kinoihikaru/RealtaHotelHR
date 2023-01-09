Imports RealtaHotelHRWebApi.Model

Namespace Repository
    Public Interface IWorkOrderDetailRepo
        Function CreateWorkOrderDetail(ByVal workOrderDetail As WorkOrderDetail) As WorkOrderDetail
        Function FindAllWorkOrdersDetail() As List(Of WorkOrderDetail)
        Function FindWorkOrderDetailById(ByVal id As Int32) As WorkOrderDetail
        Function DeleteWorkOrdersById(ByVal id As Int32) As Int32
        Function UpdateWorkOrderDetailById(id As Integer, taskName As String, status As String, startDate As DateTime, endDate As DateTime, notes As String, empId As Integer, setaId As Integer, faciId As Integer, woroId As Integer, showCommand As Integer) As Boolean
        Function UpdateWorkOrderDetailSp(id As Integer, taskName As String, status As String, startDate As DateTime, endDate As DateTime, notes As String, empId As Integer, setaId As Integer, faciId As Integer, woroId As Integer, showCommand As Integer) As Boolean

    End Interface

End Namespace