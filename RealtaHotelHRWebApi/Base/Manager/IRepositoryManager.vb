Imports RealtaHotelHRWebApi.Repository

Namespace Base
    Public Interface IRepositoryManager
        ReadOnly Property WorkOrders As IWorkOrdersRepo
        ReadOnly Property WorkOrderDetail As IWorkOrderDetailRepo
        ReadOnly Property Employee As IEmployeeRepo
        'ReadOnly Property EmployeePayHistory As IEmployeePayHistoryRepo
    End Interface

End Namespace