use Hotel_Realta;
GO

CREATE OR ALTER PROCEDURE hr.spUpdateEmployee(
    @id INT,
    @nationalId NVARCHAR(25),
    @birthDate DATETIME,
    @maritalStatus CHAR(1),
    @Gender NCHAR(1),
    @hireDate DATETIME,
    @salariedFlag NCHAR(1),
    @vacationHours INT,
    @sickLeaveHours INT,
    @currentFlag INT,
    @photo NVARCHAR(255), 
    @modifiedDate DATETIME,
    @empId int,
    @joroId int
)
as
BEGIN
    Update hr.employee
    set emp_national_id=@nationalId, 
    emp_birth_date=@birthDate, 
    emp_marital_status=@maritalStatus,
    emp_gender=@Gender, 
    emp_hire_date=@hireDate, 
    emp_salaried_flag=@salariedFlag, 
    emp_vacation_hours=@vacationHours, 
    emp_sickleave_hourse=@sickleaveHours, 
    emp_current_flag=@currentFlag,
    emp_photo=@photo, 
    emp_modified_date=@modifiedDate, 
    emp_emp_id=@empId, 
    emp_joro_id=@joroId
    where emp_id=@id
end
GO

CREATE OR ALTER PROCEDURE sPUpdateWorkOrders(
    @id INT,
    @starDate DATETIME,
    @status NVARCHAR(15),
    @userId INT
)
AS
BEGIN
    UPDATE hr.work_orders
    set woro_date = @starDate,
    woro_status = @status,
    woro_user_id = @userId
    WHERE woro_id=@id
END
GO

CREATE OR ALTER PROCEDURE sPUpdateWorkOrderDetail(
    @id int,
    @taskName NVARCHAR(255),
    @status NVARCHAR(15),
    @startDate DATETIME,
    @endDate DATETIME, 
    @notes NVARCHAR(255),
    @empId INT,
    @setaId INT,
    @faciId INT,
    @woroId INT
)
as
BEGIN
    UPDATE hr.work_order_detail
    set wode_task_name = @taskName,
    wode_status = @status,
    wode_start_date = @startDate,
    wode_end_date = @endDate,
    wode_notes = @notes,
    wode_emp_id = @empId,
    wode_seta_id = @setaId,
    wode_faci_id = @faciId,
    wode_woro_id = @woroId
    WHERE wode_id = @id
END
GO