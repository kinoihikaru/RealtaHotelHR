Imports RealtaHotelHRWebApi.Model

Namespace Repository
    Public Interface IWorkOrderDetailRepo
        Function CreateWorkOrderDetail(ByVal workOrderDetail As WorkOrderDetail) As WorkOrderDetail
        Function FindAllWorkOrdersDetail() As List(Of WorkOrderDetail)
        Function FindWorkOrderDetailById(ByVal id As Int32) As WorkOrderDetail
        Function DeleteWorkOrdersById(ByVal id As Int32) As Int32
        Function UpdateWorkOrderDetail(id As Integer, showCommand As Integer) As Boolean
        Function UpdateWorkOrderDetailSp(id As Integer, showCommand As Integer) As Boolean

    End Interface

End Namespace