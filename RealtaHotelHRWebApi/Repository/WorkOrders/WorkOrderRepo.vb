Imports System.Data.SqlClient
Imports RealtaHotelHRWebApi.Base
Imports RealtaHotelHRWebApi.Model

Namespace Repository
    Public Class WorkOrderRepo
        Implements IWorkOrdersRepo

        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Public Function FindAllWorkOrders() As List(Of WorkOrders) Implements IWorkOrdersRepo.FindAllWorkOrders
            Dim workOrdersList As New List(Of WorkOrders)

            'query
            Dim query As String = "select * from hr.work_orders"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            workOrdersList.Add(New WorkOrders With {
                                .WoroId = reader.GetInt32(0),
                                .WoroStartDate = reader.GetDateTime(1),
                                .WoroStatus = reader.GetString(2),
                                .WoroUserId = reader.GetInt32(3)
                            })
                        End While
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return workOrdersList
        End Function

        Public Function FindWorkOrdersById(id As Integer) As WorkOrders Implements IWorkOrdersRepo.FindWorkOrdersById
            Dim workOrder As New WorkOrders

            'query
            Dim query As String = "select * from hr.work_orders where woro_id = @id"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows = True Then
                            reader.Read()
                            workOrder.WoroId = reader.GetInt32(0)
                            workOrder.WoroStartDate = reader.GetDateTime(1)
                            workOrder.WoroStatus = reader.GetString(2)
                            workOrder.WoroUserId = reader.GetInt32(3)
                        End If

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using
            Return workOrder
        End Function

        Public Function DeleteWorkOrdersById(id As Integer) As Integer Implements IWorkOrdersRepo.DeleteWorkOrdersById
            Dim rowEffect As Int32 = 0

            'query
            Dim query As String = "delete from hr.work_orders where woro_id = @id"


            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)

                    Try
                        conn.Open()
                        rowEffect = cmd.ExecuteNonQuery()

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using

            Return rowEffect
        End Function

        Public Function CreateWorkOrders(workOrders As WorkOrders) As WorkOrders Implements IWorkOrdersRepo.CreateWorkOrders
            Dim newWorkOrders As New WorkOrders()

            'create query
            Dim query As String = "insert into hr.work_order_detail(woro_id, woro_date, woro_status, woro_user_id)" &
                "VALUE (@woro_id, @woro_date, @woro_status, @woro_user_id);" &
                "select cast(scope_identity() as int)"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}

                End Using
            End Using

            Return newWorkOrders
        End Function

        Public Function UpdateWorkOrders(id As Integer, showCommand As Integer) As Boolean Implements IWorkOrdersRepo.UpdateWorkOrders
            Dim workorder As New WorkOrders()

            'query
            Dim query As String = ""

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}

                End Using
            End Using


            Return True
        End Function

        Public Function UpdateWorkOrdersSp(id As Integer, showCommand As Integer) As Boolean Implements IWorkOrdersRepo.UpdateWorkOrdersSp
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace