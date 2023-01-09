Imports System.Data.SqlClient
Imports RealtaHotelHRWebApi.Base
Imports RealtaHotelHRWebApi.Model

Namespace Repository
    Public Class EmployeeRepo
        Implements IEmployeeRepo

        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Public Function CreateEmployee(employee As Employee) As Employee Implements IEmployeeRepo.CreateEmployee
            Dim newEmployee As New Employee()

            'declare stmt
            'primary key using identity integer
            Dim stmtIdentity As String = "SET IDENTITY_INSERT hr.employee ON;
                                          Insert into hr.employee(emp_id, emp_national_id, emp_birth_date, 
                                          emp_marital_status, emp_gender, emp_hire_date, emp_salaried_flag, emp_vacation_hours,
                                          emp_sickleave_hourse, emp_current_flag, emp_photo, emp_modified_date, emp_emp_id, emp_joro_id) 
                                          values (@id, @nationalId, @birthDate, @maritalStatus, @Gender, @hireDate, @salariedFlag,
                                          @vacationHours, @sickLeaveHours, @currentFlag, @photo, @modifiedDate, @empId, @joroId); 
                                          SET IDENTITY_INSERT hr.employee OFF;"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmtIdentity}
                    cmd.Parameters.AddWithValue("@id", employee.EmpId)
                    cmd.Parameters.AddWithValue("@nationalId", employee.EmpNationalId)
                    cmd.Parameters.AddWithValue("@birthDate", employee.EmpBirthDate)
                    cmd.Parameters.AddWithValue("@maritalStatus", employee.EmpMaritalStatus)
                    cmd.Parameters.AddWithValue("@Gender", employee.EmpGender)
                    cmd.Parameters.AddWithValue("@hireDate", employee.EmpHireDate)
                    cmd.Parameters.AddWithValue("@salariedFlag", employee.EmpSalariedFlag)
                    cmd.Parameters.AddWithValue("@vacationHours", employee.EmpVacationHours)
                    cmd.Parameters.AddWithValue("@sickLeaveHours", employee.EmpSickleaveHours)
                    cmd.Parameters.AddWithValue("@currentFlag", employee.EmpCurrentFlag)
                    cmd.Parameters.AddWithValue("@photo", employee.EmpPhoto)
                    cmd.Parameters.AddWithValue("@modifiedDate", employee.EmpModifiedDate)
                    cmd.Parameters.AddWithValue("@empId", employee.EmpEmpId)
                    cmd.Parameters.AddWithValue("@joroId", employee.EmpJoroId)

                    Try
                        conn.Open()
                        'ExecuteScalar return 1 row & get first column
                        Dim regionId As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newEmployee = FindEmployeeById(employee.EmpId)

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using

            Return newEmployee
        End Function

        Public Function FindAllEmployee() As List(Of Employee) Implements IEmployeeRepo.FindAllEmployee
            Dim Employee As New List(Of Employee)

            'query
            Dim query As String = "select * from hr.employee"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            Employee.Add(New Employee With {
                                .EmpId = reader.GetInt32(0),
                                .EmpNationalId = reader.GetString(1),
                                .EmpBirthDate = reader.GetDateTime(2),
                                .EmpMaritalStatus = reader.GetChar(3),
                                .EmpGender = reader.GetChar(4),
                                .EmpHireDate = reader.GetDateTime(5),
                                .EmpSalariedFlag = reader.GetString(6),
                                .EmpVacationHours = reader.GetInt32(7),
                                .EmpSickleaveHours = reader.GetInt32(8),
                                .EmpCurrentFlag = reader.GetInt32(9),
                                .EmpEmpId = reader.GetInt32(10),
                                .EmpPhoto = reader.GetString(11),
                                .EmpModifiedDate = reader.GetDateTime(12),
                                .EmpJoroId = reader.GetInt32(13)
                            })
                        End While
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return Employee
        End Function

        Public Function FindEmployeeById(id As Integer) As Employee Implements IEmployeeRepo.FindEmployeeById
            Dim employee As New Employee

            'query
            Dim query As String = "select * from hr.employee where emp_id = @id"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = query}
                    cmd.Parameters.AddWithValue("@id", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows = True Then
                            reader.Read()
                            employee.EmpId = reader.GetInt32(0)
                            employee.EmpNationalId = reader.GetString(1)
                            employee.EmpBirthDate = reader.GetDateTime(2)
                            employee.EmpMaritalStatus = reader.GetString(3)
                            employee.EmpGender = reader.GetString(4)
                            employee.EmpHireDate = reader.GetDateTime(5)
                            employee.EmpSalariedFlag = reader.GetString(6)
                            employee.EmpVacationHours = reader.GetInt32(7)
                            employee.EmpSickleaveHours = reader.GetInt32(8)
                            employee.EmpCurrentFlag = reader.GetInt32(9)
                            employee.EmpEmpId = reader.GetInt32(10)
                            employee.EmpPhoto = reader.GetString(11)
                            employee.EmpModifiedDate = reader.GetDateTime(12)
                            employee.EmpJoroId = reader.GetInt32(13)
                        End If

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using
            Return employee
        End Function

        Public Function DeleteEmployeeById(id As Integer) As Integer Implements IEmployeeRepo.DeleteEmployeeById
            Dim rowEffect As Int32 = 0

            'query
            Dim query As String = "delete from hr.employee where emp_id = @id"


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

        Public Function UpdateEmployeeById(id As Integer, nationalId As String, birthDate As Date, maritalStatus As Char, gender As Char, hireDate As Date, salariedFlag As Char, vacationHours As Integer, sickLeaveHours As Integer, currentFlag As Integer, empId As Integer, photo As String, modifiedDate As Date, joroId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IEmployeeRepo.UpdateEmployeeById
            Dim updateEmployee As New Employee()

            'declare stmt
            Dim stmt As String = "Update hr.employee " &
                                 "set emp_national_id=@nationalId, emp_birth_date=@birthDate, emp_marital_status=@maritalStatus,
                                 emp_gender=@gender, emp_hire_date=@hireDate, emp_salaried_flag=@salariedFlag, 
                                 emp_vacation_hours=@vacationHours, emp_sickleave_hourse=@sickleaveHours, emp_current_flag=@currentFlag,
                                 emp_photo=@photo, emp_modified_date=@modifiedDate, emp_emp_id=@empId, emp_joro_id=@joroId
                                 where emp_id=@id"



            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@nationalId", nationalId)
                    cmd.Parameters.AddWithValue("@birthDate", birthDate)
                    cmd.Parameters.AddWithValue("@maritalStatus", maritalStatus)
                    cmd.Parameters.AddWithValue("@Gender", gender)
                    cmd.Parameters.AddWithValue("@hireDate", hireDate)
                    cmd.Parameters.AddWithValue("@salariedFlag", salariedFlag)
                    cmd.Parameters.AddWithValue("@vacationHours", vacationHours)
                    cmd.Parameters.AddWithValue("@sickLeaveHours", sickLeaveHours)
                    cmd.Parameters.AddWithValue("@currentFlag", currentFlag)
                    cmd.Parameters.AddWithValue("@photo", photo)
                    cmd.Parameters.AddWithValue("@modifiedDate", modifiedDate)
                    cmd.Parameters.AddWithValue("@empId", empId)
                    cmd.Parameters.AddWithValue("@joroId", joroId)

                    'show command
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

        Public Function UpdateEmployeeBySp(id As Integer, nationalId As String, birthDate As Date, maritalStatus As Char, gender As Char, hireDate As Date, salariedFlag As Char, vacationHours As Integer, sickLeaveHours As Integer, currentFlag As Integer, empId As Integer, photo As String, modifiedDate As Date, joroId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IEmployeeRepo.UpdateEmployeeBySp
            Dim updateEmployee As New Employee()

            'declare stmt
            Dim stmt As String = "hr.spUpdateEmployee @id, @nationalId, @birthDate, @maritalStatus, @Gender, @hireDate, 
                                  @salariedFlag, @vacationHours, @sickLeaveHours, @currentFlag, @photo, @modifiedDate, @empId, @joroId"

            Using conn As New SqlConnection With {.ConnectionString = _repositoryContext.GetConnection}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@nationalId", nationalId)
                    cmd.Parameters.AddWithValue("@birthDate", birthDate)
                    cmd.Parameters.AddWithValue("@maritalStatus", maritalStatus)
                    cmd.Parameters.AddWithValue("@Gender", gender)
                    cmd.Parameters.AddWithValue("@hireDate", hireDate)
                    cmd.Parameters.AddWithValue("@salariedFlag", salariedFlag)
                    cmd.Parameters.AddWithValue("@vacationHours", vacationHours)
                    cmd.Parameters.AddWithValue("@sickLeaveHours", sickLeaveHours)
                    cmd.Parameters.AddWithValue("@currentFlag", currentFlag)
                    cmd.Parameters.AddWithValue("@photo", photo)
                    cmd.Parameters.AddWithValue("@modifiedDate", modifiedDate)
                    cmd.Parameters.AddWithValue("@empId", empId)
                    cmd.Parameters.AddWithValue("@joroId", joroId)
                    cmd.Parameters.AddWithValue("@id", id)

                    'show command
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