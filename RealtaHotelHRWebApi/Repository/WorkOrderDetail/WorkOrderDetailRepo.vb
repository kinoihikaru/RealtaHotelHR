Imports System.Data.SqlClient
Imports RealtaHotelHRWebApi.Base
Imports RealtaHotelHRWebApi.Model

Namespace Repository
    Public Class WorkOrderDetailRepo

        Implements IWorkOrderDetailRepo

        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub


        Public Function FindWorkOrderDetailById(id As Integer) As WorkOrderDetail Implements IWorkOrderDetailRepo.FindWorkOrderDetailById
            Dim workOrderDetail As New WorkOrderDetail With {.WodeId = id}

            'query
            Dim query As String = "select * from hr.work_order_detail where wode_id = @id"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows = True Then
                            reader.Read()
                            workOrderDetail.WodeTaskName = reader.GetString(1)
                            workOrderDetail.WodeStatus = reader.GetString(2)
                            workOrderDetail.WodeStartDate = reader.GetDateTime(3)
                            workOrderDetail.WodeEndDate = reader.GetDateTime(4)
                            workOrderDetail.WodeNotes = reader.GetString(5)
                            workOrderDetail.WodeEmpId = reader.GetInt32(6)
                            workOrderDetail.WodeSetaId = reader.GetInt32(7)
                            workOrderDetail.WodeFaciId = reader.GetInt32(8)
                            workOrderDetail.WodeWoroId = reader.GetInt32(9)
                        End If

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using
            Return workOrderDetail
        End Function

        Public Function FindAllWorkOrdersDetail() As List(Of WorkOrderDetail) Implements IWorkOrderDetailRepo.FindAllWorkOrdersDetail
            Dim workOrderDetailList As New List(Of WorkOrderDetail)

            'query
            Dim query As String = "select * from hr.work_order_detail"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            workOrderDetailList.Add(New WorkOrderDetail With {
                                .WodeId = reader.GetInt32(0),
                                .WodeTaskName = reader.GetString(1),
                                .WodeStatus = reader.GetString(2),
                                .WodeStartDate = reader.GetDateTime(3),
                                .WodeEndDate = reader.GetDateTime(4),
                                .WodeNotes = reader.GetString(5),
                                .WodeEmpId = reader.GetInt32(6),
                                .WodeSetaId = reader.GetInt32(7),
                                .WodeFaciId = reader.GetInt32(8),
                                .WodeWoroId = reader.GetInt32(9)
                            })
                        End While
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return workOrderDetailList
        End Function

        Public Function DeleteWorkOrdersById(id As Integer) As Integer Implements IWorkOrderDetailRepo.DeleteWorkOrdersById
            Dim rowEffect As Int32 = 0

            'query
            Dim query As String = "delete from hr.work_order_detail where wode_id = @id"


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

        Public Function CreateWorkOrderDetail(workOrderDetail As WorkOrderDetail) As WorkOrderDetail Implements IWorkOrderDetailRepo.CreateWorkOrderDetail
            Dim newWorkOrderDetail As New WorkOrderDetail()

            'create query
            Dim query As String = "insert into hr.work_order_detail(wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id)" &
                "VALUE (@wodeId, @wodeTaskName, @wodeStatus, @wodeStartDate, @wodeEndDate, @wodeNotes, @wodeEmpId, @wodeSetaId, @wodeFaciId, @wodeWoroId);" &
                "select cast(scope_identity() as int)"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}


                End Using
            End Using

            Return newWorkOrderDetail
        End Function


        Public Function UpdateWorkOrderDetail(id As Integer, showCommand As Integer) As Boolean Implements IWorkOrderDetailRepo.UpdateWorkOrderDetail
            Dim WorkOrderDetailById As New WorkOrderDetail()

            Dim query As String = ""

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}


                End Using
            End Using

            Return True
        End Function

        Public Function UpdateWorkOrderDetailSp(id As Integer, showCommand As Integer) As Boolean Implements IWorkOrderDetailRepo.UpdateWorkOrderDetailSp
            Dim WorkOrderDetailById As New WorkOrderDetail()

            Dim query As String = ""

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}


                End Using
            End Using

            Return True
        End Function
    End Class

End Namespace