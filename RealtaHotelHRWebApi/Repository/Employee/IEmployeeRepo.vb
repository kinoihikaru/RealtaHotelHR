Imports RealtaHotelHRWebApi.Model

Namespace Repository
    Public Interface IEmployeeRepo
        Function CreateEmployee(ByVal employee As Employee) As Employee
        Function FindAllEmployee() As List(Of Employee)
        Function FindEmployeeById(ByVal id As Int32) As Employee
        Function DeleteEmployeeById(ByVal id As Int32) As Int32
        Function UpdateEmployeeById(id As Integer, nationalId As String, birthDate As DateTime, maritalStatus As Char, gender As Char, hireDate As DateTime, salariedFlag As Char, vacationHours As Integer, sickLeaveHours As Integer, currentFlag As Integer, empId As Integer, photo As String, modifiedDate As DateTime, joroId As Integer, Optional showCommand As Boolean = False) As Boolean
        Function UpdateEmployeeBySp(id As Integer, nationalId As String, birthDate As DateTime, maritalStatus As Char, gender As Char, hireDate As DateTime, salariedFlag As Char, vacationHours As Integer, sickLeaveHours As Integer, currentFlag As Integer, empId As Integer, photo As String, modifiedDate As DateTime, joroId As Integer, Optional showCommand As Boolean = False) As Boolean


    End Interface

End Namespace