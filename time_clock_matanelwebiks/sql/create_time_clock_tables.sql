-- יצירת טבלת עובדים
create table Employees(code int primary key identity, 
id varchar(10) UNIQUE NOT NULL,
full_name varchar(20))

-- יצירת טבלת סיסמאות
create table Passwords(code int primary key identity, 
employee_code int foreign key references Employees(code),
password_string varchar(12),
password_expiry_date date,
has_access bit)

-- יצירת טבלת זמנים
create table Clock_Time(code int primary key identity, 
employee_code int foreign key references Employees(code),
entry_time datetime, 
exit_time datetime)

select * from Employees