create database examenDepEmpInsertRazor
use examenDepEmpInsertRazor

create table Departamento 
(
	idDepartamento int primary key identity(1,1),
	nombreDepartamento varchar(50) not null
)
create table Empleado
(
	idEmpleado int primary key identity(1,1),
	nombreEmpleado varchar(50) not null,
	idDepartamento int references Departamento(idDepartamento)
)

insert into Departamento(nombreDepartamento) values ('Ventas'),('IT'),('Compras'),('RH')
select * from Departamento

insert into Empleado(nombreEmpleado,idDepartamento) values ('Tomas',1),('Adrian',2)
select * from Empleado

--=================== CREAR PROCEDIMIENTOS ALMACENADOS PARA EMPLEADOS =========================

create procedure sp_ListarEmpleados
as
begin 
	select e.idEmpleado, e.nombreEmpleado, d.idDepartamento, d.nombreDepartamento
	from Empleado e inner join Departamento d on e.idDepartamento = d.idDepartamento;
end

create procedure sp_ListarEmpleadoxDep
(@idDepartamento int)
as 
begin 
	select e.idEmpleado, e.nombreEmpleado, d.idDepartamento, d.nombreDepartamento
	from Empleado e inner join Departamento d on e.idDepartamento = d.idDepartamento
	where d.idDepartamento = @idDepartamento;
end

create procedure sp_InsertarEmpleado
(
	@nombreEmpleado varchar(50),
	@idDepartamento int
)
as
begin
	insert into Empleado(nombreEmpleado,idDepartamento) 
	values (@nombreEmpleado,@idDepartamento)
end


--=================== CREAR PROCEDIMIENTOS ALMACENADOS PARA DEPARTAMENTOS =========================

create procedure sp_ListarDepartamentos
as
begin
	select idDepartamento,nombreDepartamento from Departamento
end