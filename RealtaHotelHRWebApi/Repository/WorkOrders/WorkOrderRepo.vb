Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Text.Json
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
            Dim query As String = "SET IDENTITY_INSERT hr.work_orders ON;
                insert into hr.work_order_detail(woro_id, woro_date, woro_status, woro_user_id)" &
                "VALUE (@woro_id, @woro_date, @woro_status, @woro_user_id);" &
                "SET IDENTITY_INSERT hr.work_orders OFF;"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@woro_id", workOrders.WoroId)
                    cmd.Parameters.AddWithValue("@woro_date", workOrders.WoroStartDate)
                    cmd.Parameters.AddWithValue("@woro_status", workOrders.WoroStatus)
                    cmd.Parameters.AddWithValue("@woro_user_id", workOrders.WoroUserId)

                    Try
                        conn.Open()
                        'ExecuteScalar return 1 row & get first column
                        Dim regionId As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newWorkOrders = FindWorkOrdersById(workOrders.WoroId)

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newWorkOrders
        End Function

        Public Function UpdateWorkOrders(id As Integer, startDate As Date, status As String, userId As Integer, showCommand As Integer) As Boolean Implements IWorkOrdersRepo.UpdateWorkOrders
            Dim WorkOrders As New WorkOrders()

            Dim query As String = "UPDATE hr.work_orders
                                   set woro_date = @starDate,
                                   woro_status = @status,
                                   woro_user_id = @userId
                                   WHERE woro_id = @id"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@starDate", startDate)
                    cmd.Parameters.AddWithValue("@userId", status)
                    cmd.Parameters.AddWithValue("@startDate", userId)


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

        Public Function UpdateWorkOrdersSp(id As Integer, startDate As Date, status As String, userId As Integer, showCommand As Integer) As Boolean Implements IWorkOrdersRepo.UpdateWorkOrdersSp
            Dim WorkOrders As New WorkOrders()

            Dim query As String = "sPUpdateWorkOrders
                                   @id,
                                   @starDate,
                                   @status,
                                   @userId"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@starDate", startDate)
                    cmd.Parameters.AddWithValue("@userId", status)
                    cmd.Parameters.AddWithValue("@startDate", userId)


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