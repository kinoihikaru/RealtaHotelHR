Imports NorthwindVbNetApi.Context
Imports NorthwindVbNetApi.Repository
Imports RealtaHotelHRWebApi.Repository

Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _workOrders As IWorkOrdersRepo
        Private _workOrderDetail As IWorkOrderDetailRepo
        Private _employee As IEmployeeRepo
        'Private _employeePayHistory As IEmployeePayHistoryRepo
        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Public ReadOnly Property WorkOrders As IWorkOrdersRepo Implements IRepositoryManager.WorkOrders
            Get
                'up IWorkOrders & Implementation
                If _workOrders Is Nothing Then
                    _workOrders = New WorkOrderRepo(_repositoryContext)
                End If
                Return _workOrders
            End Get
        End Property

        Public ReadOnly Property WorkOrderDetail As IWorkOrderDetailRepo Implements IRepositoryManager.WorkOrderDetail
            Get
                If _workOrderDetail Is Nothing Then
                    _workOrderDetail = New WorkOrderDetailRepo(_repositoryContext)
                End If
                Return _workOrderDetail
            End Get
        End Property

        Public ReadOnly Property Employee As IEmployeeRepo Implements IRepositoryManager.Employee
            Get
                If _employee Is Nothing Then
                    _employee = New EmployeeRepo(_repositoryContext)
                End If
                Return _employee
            End Get
        End Property


    End Class

End Namespace