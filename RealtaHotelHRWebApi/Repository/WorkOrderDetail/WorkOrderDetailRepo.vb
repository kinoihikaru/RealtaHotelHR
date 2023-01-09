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
            Dim query As String = "SET IDENTITY_INSERT hr.work_order_detail ON;
                insert into hr.work_order_detail(wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id)" &
                "VALUE (@wodeId, @wodeTaskName, @wodeStatus, @wodeStartDate, @wodeEndDate, @wodeNotes, @wodeEmpId, @wodeSetaId, @wodeFaciId, @wodeWoroId);" &
                "SET IDENTITY_INSERT hr.work_order_detail OFF;"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@wodeId", workOrderDetail.WodeId)
                    cmd.Parameters.AddWithValue("@wodeTaskName", workOrderDetail.WodeTaskName)
                    cmd.Parameters.AddWithValue("@wodeStatus", workOrderDetail.WodeStatus)
                    cmd.Parameters.AddWithValue("@wodeStartDate", workOrderDetail.WodeStartDate)
                    cmd.Parameters.AddWithValue("@wodeEndDate", workOrderDetail.WodeEndDate)
                    cmd.Parameters.AddWithValue("@wodeNotes", workOrderDetail.WodeNotes)
                    cmd.Parameters.AddWithValue("@wodeEmpId", workOrderDetail.WodeEmpId)
                    cmd.Parameters.AddWithValue("@wodeSetaId", workOrderDetail.WodeSetaId)
                    cmd.Parameters.AddWithValue("@wodeFaciId", workOrderDetail.WodeFaciId)
                    cmd.Parameters.AddWithValue("@wodeWoroId", workOrderDetail.WodeWoroId)

                    Try
                        conn.Open()
                        'ExecuteScalar return 1 row & get first column
                        Dim regionId As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newWorkOrderDetail = FindWorkOrderDetailById(workOrderDetail.WodeId)

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newWorkOrderDetail
        End Function


        Public Function UpdateWorkOrderDetailSp(id As Integer, taskName As String, status As String, startDate As Date, endDate As Date, notes As String, empId As Integer, setaId As Integer, faciId As Integer, woroId As Integer, showCommand As Integer) As Boolean Implements IWorkOrderDetailRepo.UpdateWorkOrderDetailSp
            Dim WorkOrderDetailById As New WorkOrderDetail()

            Dim query As String = "sPUpdateWorkOrderDetail
                                   @taskName,
                                   @status,
                                   @startDate,
                                   @endDate,
                                   @notes,
                                   @empId,
                                   @setaId,
                                   @faciId,
                                   @woroId,
                                   @id"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@taskName", taskName)
                    cmd.Parameters.AddWithValue("@status", status)
                    cmd.Parameters.AddWithValue("@startDate", startDate)
                    cmd.Parameters.AddWithValue("@endDate", endDate)
                    cmd.Parameters.AddWithValue("@notes", notes)
                    cmd.Parameters.AddWithValue("@empId", empId)
                    cmd.Parameters.AddWithValue("@setaId", setaId)
                    cmd.Parameters.AddWithValue("@faciId", faciId)
                    cmd.Parameters.AddWithValue("@woroId", woroId)

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return True
        End Function

        Public Function UpdateWorkOrderDetailById(id As Integer, taskName As String, status As String, startDate As Date, endDate As Date, notes As String, empId As Integer, setaId As Integer, faciId As Integer, woroId As Integer, showCommand As Integer) As Boolean Implements IWorkOrderDetailRepo.UpdateWorkOrderDetailById
            Dim WorkOrderDetailById As New WorkOrderDetail()

            Dim query As String = "UPDATE hr.work_order_detail
                                   set wode_task_name = @taskName,
                                   wode_status = @status,
                                   wode_start_date = @startDate,
                                   wode_end_date = @endDate,
                                   wode_notes = @notes,
                                   wode_emp_id = @empId,
                                   wode_seta_id = @setaId,
                                   wode_faci_id = @faciId,
                                   wode_woro_id = @woroId
                                   WHERE wode_id = @id"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@taskName", taskName)
                    cmd.Parameters.AddWithValue("@status", status)
                    cmd.Parameters.AddWithValue("@startDate", startDate)
                    cmd.Parameters.AddWithValue("@endDate", endDate)
                    cmd.Parameters.AddWithValue("@notes", notes)
                    cmd.Parameters.AddWithValue("@empId", empId)
                    cmd.Parameters.AddWithValue("@setaId", setaId)
                    cmd.Parameters.AddWithValue("@faciId", faciId)
                    cmd.Parameters.AddWithValue("@woroId", woroId)

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return True
        End Function
    End Class

End Namespace